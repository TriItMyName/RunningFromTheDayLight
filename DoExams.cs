using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using RunningFromTheDayLight.Models;
using NAudio.Wave;


namespace RunningFromTheDayLight
{
    public partial class DoExams : Form
    {
        private readonly Model_ThiTracNghiem context;
        private List<Question> loadedQuestions;
        private System.Windows.Forms.Timer countdownTimer;
        private int remainingTime;
        private string Subjectcode;
        private string StudentName;
        private string StudentCode;
        private int timeDoExam;
        private DateTime TGBD;
        private String RoomID;
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;

        public DoExams(string Subjectcode, string StudentName, string StudentCode, DateTime TGBD, string roomID)
        {
            context = new Model_ThiTracNghiem();
            InitializeComponent();
            this.Subjectcode = Subjectcode;
            LoadRandomExam();
            this.StudentName = StudentName;
            this.StudentCode = StudentCode;
            this.TGBD = TGBD;
            RoomID = roomID;
        }

        // Lớp đại diện cho một câu hỏi
        public class Question
        {
            public int ID { get; set; }
            public string Content { get; set; }
            public string OptionA { get; set; }
            public string OptionB { get; set; }
            public string OptionC { get; set; }
            public string OptionD { get; set; }
            public string CorrectAnswer { get; set; }
            public string AudioFileName { get; set; }
        }

        // Lấy đề thi ngẫu nhiên và tải các câu hỏi
        private void LoadRandomExam()
        {
            lbStudentCode.Text = StudentCode;
            lbStudentName.Text = StudentName;
            var deThiNgauNhien = context.DeThiNgauNhiens
                .Where(d => d.MaMon == Subjectcode)
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefault();

            if (deThiNgauNhien == null)
            {
                MessageBox.Show($"Không có đề thi nào cho môn: {Subjectcode}");
                return;
            }
            timeDoExam = deThiNgauNhien.ThoiGianThi.HasValue ? deThiNgauNhien.ThoiGianThi.Value * 60 : 0;
            remainingTime = deThiNgauNhien.ThoiGianThi.HasValue ? deThiNgauNhien.ThoiGianThi.Value * 60 : 0;

            StartTimer();

            var questionIds = deThiNgauNhien.CacCauHoi.Split(',').Select(int.Parse).ToList();
            loadedQuestions = context.TracNghiems
                .Where(q => questionIds.Contains(q.ID))
                .Select(q => new Question
                {
                    ID = q.ID,
                    Content = q.NoiDung,
                    OptionA = q.DapAnA,
                    OptionB = q.DapAnB,
                    OptionC = q.DapAnC,
                    OptionD = q.DapAnD,
                    CorrectAnswer = q.DapAnDung,
                    AudioFileName = q.AudioFileName
                })
                .ToList();

            DisplayQuestions();
        }

        // Khởi tạo và khởi động Timer
        private void StartTimer()
        {
            countdownTimer = new System.Windows.Forms.Timer(); // Khởi tạo Timer
            countdownTimer.Interval = 1000; // Mỗi giây
            countdownTimer.Tick += CountdownTimer_Tick; // Đăng ký sự kiện
            countdownTimer.Start(); // Bắt đầu Timer
        }

        // Cập nhật Timer mỗi giây
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                int minutes = remainingTime / 60;
                int seconds = remainingTime % 60;
                lblTimer.Text = $"{minutes:D2}:{seconds:D2}";

                if (remainingTime == 300)
                {
                    MessageBox.Show("Còn 5 phút! Hãy kiểm tra bài làm của bạn!");
                }
            }
            else
            {
                countdownTimer.Stop();
                MessageBox.Show("Hết thời gian làm bài!");
                SubmitExam();
            }
        }

        // Inside the DisplayQuestions method
        private void DisplayQuestions()
        {
            flpQuestions.Controls.Clear();

            foreach (var question in loadedQuestions)
            {
                Panel questionPanel = new Panel
                {
                    Width = flpQuestions.Width - 25,
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblContent = new Label
                {
                    Text = question.Content,
                    Width = questionPanel.Width - 20,
                    Location = new Point(10, 10),
                    AutoSize = false
                };
                questionPanel.Controls.Add(lblContent);

                if (!string.IsNullOrEmpty(question.AudioFileName))
                {
                    try
                    {
                        int playCount = 0;
                        int stopCount = 0;

                        Button btnPlay = new Button
                        {
                            Text = "Play",
                            Location = new Point(10, 40),
                            Width = 75
                        };

                        Button btnStop = new Button
                        {
                            Text = "Stop",
                            Location = new Point(90, 40),
                            Width = 75
                        };

                        btnPlay.Click += (s, e) =>
                        {
                            if (playCount <= 5)
                            {
                                PlayAudio(question.AudioFileName);
                                playCount++;
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã đạt đến số lần phát tối đa (5).");
                                btnPlay.Enabled = false;
                                btnStop.Enabled = false;
                            }
                        };
                        questionPanel.Controls.Add(btnPlay);

                        btnStop.Click += (s, e) =>
                        {
                            if (stopCount <= 5)
                            {
                                StopAudio();
                                stopCount++;
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã đạt đến số lần dừng tối đa (5).");
                                btnPlay.Enabled = false;
                                btnStop.Enabled = false;
                            }
                        };
                        questionPanel.Controls.Add(btnStop);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải tệp phương tiện: {ex.Message}");
                    }
                }

                RadioButton rdoA = new RadioButton
                {
                    Text = "A. " + question.OptionA,
                    Location = new Point(10, 90),
                    Width = questionPanel.Width - 20,
                    Tag = "A"
                };
                questionPanel.Controls.Add(rdoA);

                RadioButton rdoB = new RadioButton
                {
                    Text = "B. " + question.OptionB,
                    Location = new Point(10, 110),
                    Width = questionPanel.Width - 20,
                    Tag = "B"
                };
                questionPanel.Controls.Add(rdoB);

                RadioButton rdoC = new RadioButton
                {
                    Text = "C. " + question.OptionC,
                    Location = new Point(10, 130),
                    Width = questionPanel.Width - 20,
                    Tag = "C"
                };
                questionPanel.Controls.Add(rdoC);

                RadioButton rdoD = new RadioButton
                {
                    Text = "D. " + question.OptionD,
                    Location = new Point(10, 150),
                    Width = questionPanel.Width - 20,
                    Tag = "D"
                };
                questionPanel.Controls.Add(rdoD);

                questionPanel.Tag = question;

                flpQuestions.Controls.Add(questionPanel);
            }

            Button btnSubmit = new Button
            {
                Text = "Nộp bài",
                Width = 100,
                Height = 40,
                Location = new Point(flpQuestions.Width / 2 - 50, flpQuestions.Height - 50)
            };
            btnSubmit.Click += btnSubmit_Click_1;
            flpQuestions.Controls.Add(btnSubmit);
        }

        private void PlayAudio(string fileName)
        {
            try
            {
                waveOutDevice = new WaveOut();
                audioFileReader = new AudioFileReader(fileName);
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phát tệp âm thanh: {ex.Message}");
            }
        }

        private void StopAudio()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        // Tính điểm khi bấm Nộp bài
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            using (var confirmForm = new Confirm_F())
            {
                if (confirmForm.ShowDialog() == DialogResult.OK)
                {
                    float score = SubmitExam();
                    if (float.IsNaN(score) || float.IsInfinity(score))
                    {
                        MessageBox.Show("Invalid score value.");
                        return;
                    }

                    int ThoiGianLamBai = timeDoExam - remainingTime;
                    savetodb(score, ThoiGianLamBai);
                }
            }
        }

        private void savetodb(float score, int thoiGianLamBai)
        {
            Console.WriteLine($"Subjectcode: {Subjectcode}, TGBD: {TGBD}");

            var temp = context.CuocThis
                .FirstOrDefault(a => a.MaMon == Subjectcode && a.ThoiGianBatDau <= TGBD);

            if (temp == null)
            {
                MessageBox.Show("Không tìm thấy cuộc thi với điều kiện được cung cấp.");
                return;
            }

            var ketquathi = new KetQuaThi
            {
                MaSV = StudentCode,
                MaCuocThi = temp.MaCuocThi,
                Diem = score,
                ThoiGianLamBai = thoiGianLamBai / 60,
                NgayThi = DateTime.Now
            };

            context.KetQuaThis.Add(ketquathi);
            context.SaveChanges();

            MessageBox.Show("Lưu kết quả thi thành công!");
            Application.Exit();
        }

        // Hàm nộp bài và tính điểm
        private float SubmitExam()
        {
            int score = 0;
            int totalQuestions = flpQuestions.Controls.OfType<Panel>().Count(); // Đếm tổng số câu hỏi

            foreach (Panel panel in flpQuestions.Controls.OfType<Panel>())
            {
                if (panel.Tag is Question question)
                {
                    // Tìm RadioButton được chọn
                    var selectedOption = panel.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

                    if (selectedOption != null && selectedOption.Tag.ToString() == question.CorrectAnswer)
                    {
                        score++;
                    }
                }
            }

            // Quy đổi điểm thành thang điểm 10
            float finalScore = (float)score / totalQuestions * 10;

            // Làm gì đó với điểm số, ví dụ: hiển thị điểm
            MessageBox.Show($"Điểm số của bạn là: {finalScore:F1} / 10");
            return finalScore;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Nơi lưu trữ các câu trả lời của sinh viên nếu cần
        }

        private void DoExams_Load(object sender, EventArgs e)
        {
            // Cài đặt thông tin hiển thị với định dạng và font đẹp
            lbStudentCode.Text = $"MSSV: {StudentCode}";
            lbStudentCode.Font = new Font("Arial", 12, FontStyle.Bold);

            lbStudentName.Text = $"Họ tên: {StudentName}";
            lbStudentName.Font = new Font("Arial", 12, FontStyle.Bold);

            lblRoom.Text = $"Phòng: {RoomID}";
            lblRoom.Font = new Font("Arial", 12, FontStyle.Bold);

            lblSubjectName.Text = $"Môn học: {Subjectcode}";
            lblSubjectName.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        private void DoExams_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                Environment.Exit(0);
            }
        }
    }
}
