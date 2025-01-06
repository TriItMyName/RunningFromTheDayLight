using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class FrmGiangVien : Form
    {
        private readonly Model_ThiTracNghiem context;
        private DataTable dataTable;
        private Dictionary<string, string> audioFiles;

        public FrmGiangVien()
        {
            InitializeComponent();
            context = new Model_ThiTracNghiem();
            audioFiles = new Dictionary<string, string>();
        }

        private void toolStrip_btnAddMon_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                AddSubject addSubjecc = new AddSubject();
                addSubjecc.FormClosing += (s, args) =>
                {
                    this.ShowDialog();
                    RefreshSubjectList();
                };
                addSubjecc.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStrip_btnAddQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbsubjects.SelectedValue != null)
                {
                    string subjectCode = cmbsubjects.SelectedValue.ToString();
                    this.Hide();
                    QuestionForm3 questionForm3 = new QuestionForm3(subjectCode);
                    questionForm3.FormClosing += (s, args) =>
                    {
                        this.ShowDialog();
                    };
                    questionForm3.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbsubjects.SelectedValue != null)
                {
                    string subjectCode = cmbsubjects.SelectedValue.ToString();
                    this.Hide();
                    CreateExamRandom createExamForm = new CreateExamRandom(subjectCode);
                    createExamForm.FormClosing += (s, args) =>
                    {
                        this.ShowDialog();
                    };
                    createExamForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn môn học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStrip_btnReadList_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Del_Add_Fix_RandomExams del_Add_Fix_RandomExams = new Del_Add_Fix_RandomExams();
                del_Add_Fix_RandomExams.FormClosing += (s, args) =>
                {
                    this.ShowDialog();
                };
                del_Add_Fix_RandomExams.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmGiangVien_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvListSubject);
                RefreshSubjectList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = System.Drawing.Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void RefreshSubjectList()
        {
            List<Mon> mons = context.Mons.ToList();
            FillSubjectComBox(mons);
        }

        private void FillSubjectComBox(List<Mon> listMon)
        {
            listMon = listMon.Where(m => !string.IsNullOrWhiteSpace(m.TenMon)).ToList();
            this.cmbsubjects.DataSource = listMon;
            this.cmbsubjects.DisplayMember = "TenMon";
            this.cmbsubjects.ValueMember = "MaMon";
            this.cmbsubjects.SelectedIndex = -1;
        }

        private void toolStrip_UpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt|Word Documents|*.docx",
                Title = "Chọn file văn bản để upload"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    dataTable = new DataTable();
                    dataTable.Columns.Add("Bài");
                    dataTable.Columns.Add("Loại câu hỏi");
                    dataTable.Columns.Add("Câu hỏi");
                    dataTable.Columns.Add("Đáp án A");
                    dataTable.Columns.Add("Đáp án B");
                    dataTable.Columns.Add("Đáp án C");
                    dataTable.Columns.Add("Đáp án D");
                    dataTable.Columns.Add("Đáp án đúng");
                    dataTable.Columns.Add("AudioFileName");

                    if (Path.GetExtension(filePath).ToLower() == ".txt")
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        ProcessLines(lines, dataTable);
                    }
                    else if (Path.GetExtension(filePath).ToLower() == ".docx")
                    {
                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
                        {
                            Body body = wordDoc.MainDocumentPart.Document.Body;
                            List<string> lines = new List<string>();
                            foreach (var paragraph in body.Elements<Paragraph>())
                            {
                                string paragraphText = string.Join(" ", paragraph.Elements<Run>().Select(r => r.GetFirstChild<Text>().Text));
                                lines.Add(paragraphText);
                            }
                            ProcessLines(lines.ToArray(), dataTable);
                        }
                    }

                    dgvListSubject.DataSource = dataTable;
                    txtCount.Text = dataTable.Rows.Count.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProcessLines(string[] lines, DataTable dt)
        {
            string currentBai = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                if (lines[i].StartsWith("Bài"))
                {
                    currentBai = lines[i].Trim();
                }
                else if (lines[i].Contains(".("))
                {
                    string loaiCauHoi = lines[i].Substring(lines[i].IndexOf('(') + 1, 2);
                    string question = lines[i].Substring(lines[i].IndexOf(')') + 1).Trim();
                    string answerA = lines[i + 1].Trim();
                    string answerB = lines[i + 2].Trim();
                    string answerC = lines[i + 3].Trim();
                    string answerD = lines[i + 4].Trim();
                    string correctAnswer = string.Empty;
                    string audioFileName = string.Empty;

                    if (loaiCauHoi == "AU"  )
                    {
                        audioFileName = lines[i + 1].Split(new[] { ':' }, 2)[1].Trim();
                        answerA = lines[i + 2].Trim();
                        answerB = lines[i + 3].Trim();
                        answerC = lines[i + 4].Trim();
                        answerD = lines[i + 5].Trim();
                        i++;
                    }

                    if (answerA.StartsWith("*"))
                    {
                        correctAnswer = "A";
                        answerA = answerA.Substring(1).Trim();
                    }
                    else if (answerB.StartsWith("*"))
                    {
                        correctAnswer = "B";
                        answerB = answerB.Substring(1).Trim();
                    }
                    else if (answerC.StartsWith("*"))
                    {
                        correctAnswer = "C";
                        answerC = answerC.Substring(1).Trim();
                    }
                    else if (answerD.StartsWith("*"))
                    {
                        correctAnswer = "D";
                        answerD = answerD.Substring(1).Trim();
                    }

                    dt.Rows.Add(currentBai, loaiCauHoi, question, answerA, answerB, answerC, answerD, correctAnswer, audioFileName);

                    if (!string.IsNullOrEmpty(audioFileName))
                    {
                        audioFiles.Add(question, audioFileName);
                    }

                    i += 5;
                }
            }
        }

        private void SaveToDatabase(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                string tenBai = row["Bài"].ToString();
                int? maBai = AddOrUpdateBai(tenBai);

                var cauHoi = new TracNghiem
                {
                    NoiDung = row["Câu hỏi"].ToString(),
                    DapAnA = row["Đáp án A"].ToString(),
                    DapAnB = row["Đáp án B"].ToString(),
                    DapAnC = row["Đáp án C"].ToString(),
                    DapAnD = row["Đáp án D"].ToString(),
                    DapAnDung = row["Đáp án đúng"].ToString(),
                    LoaiCauHoi = row["Loại câu hỏi"].ToString(),
                    MaBai = maBai,
                    AudioFileName = row["AudioFileName"].ToString()
                };

                context.TracNghiems.Add(cauHoi);
            }
            context.SaveChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataTable != null)
            {
                SaveToDatabase(dataTable);
                context.SaveChanges();
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int? AddOrUpdateBai(string tenBai)
        {
            var existingBai = context.Bais.FirstOrDefault(b => b.TenBai == tenBai);
            if (existingBai != null)
            {
                return existingBai.MaBai;
            }

            var newBai = new Bai
            {
                TenBai = tenBai,
                MaMon = cmbsubjects.SelectedValue.ToString()
            };

            context.Bais.Add(newBai);
            context.SaveChanges();
            return newBai.MaBai;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchtext = txtSearch.Text;
            SearchSubject(searchtext);
        }

        private void SearchSubject(string searchtext)
        {
            if (string.IsNullOrWhiteSpace(searchtext) || searchtext == default)
            {
                foreach (DataGridViewRow row in dgvListSubject.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            string lowerSearchText = searchtext.Trim().ToLower();

            foreach (DataGridViewRow row in dgvListSubject.Rows)
            {
                if (row.IsNewRow) continue;

                var question = row.Cells["Câu hỏi"].Value.ToString().Trim().ToLower();

                if (question != null && question.Contains(lowerSearchText))
                {
                    row.Visible = true;
                }
                else if (row.Index != dgvListSubject.CurrentCell.RowIndex)
                {
                    row.Visible = false;
                }
            }
        }

        private void toolStrip_btnHome_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbsubjects.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataTable != null)
                {
                    dataTable.Clear();
                    dgvListSubject.DataSource = dataTable;
                    txtCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
