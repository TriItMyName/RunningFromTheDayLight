using RunningFromTheDayLight.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RunningFromTheDayLight
{
    public partial class Add_Fix_Del_Qestions : Form
    {
        private readonly DatabaseSroce context;
        private int selectedExamID;
        private string selectedSubjectID;
        private TracNghiem selectedQuestion;

        public Add_Fix_Del_Qestions(int examID, string subjectID)
        {
            InitializeComponent();
            context = new DatabaseSroce();
            selectedExamID = examID;
            selectedSubjectID = subjectID;
            LoadQuestions();

            this.MouseWheel += new MouseEventHandler(Form_MouseWheel);
        }

        private void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            int scrollValue = e.Delta > 0 ? -40 : 40;
            int newScrollPosition = flpQuestions.VerticalScroll.Value + scrollValue;

            newScrollPosition = Math.Max(newScrollPosition, flpQuestions.VerticalScroll.Minimum);
            newScrollPosition = Math.Min(newScrollPosition, flpQuestions.VerticalScroll.Maximum);

            flpQuestions.VerticalScroll.Value = newScrollPosition;
        }

        private void LoadQuestions()
        {
            var exam = context.DeThiNgauNhien
                .Where(de => de.MaDeNgauNhien == selectedExamID && de.MaMon == selectedSubjectID)
                .Select(de => de.CacCauHoi)
                .FirstOrDefault();

            if (exam == null)
            {
                MessageBox.Show("Không tìm thấy đề thi.");
                return;
            }

            var questionIds = exam.Split(',').Select(id => id.Trim()).ToList();
            var questions = context.TracNghiem
                .Where(q => questionIds.Contains(q.ID.ToString()))
                .ToList();

            flpQuestions.Controls.Clear();

            int questionNumber = 1;
            foreach (var question in questions)
            {
                Panel questionPanel = new Panel
                {
                    Width = flpQuestions.Width - 25,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(3, 3, 3, 10)
                };

                Label lblContent = new Label
                {
                    Text = $"Câu {questionNumber}: {question.NoiDung}",
                    Width = questionPanel.Width - 20,
                    Location = new Point(10, 10),
                    Font = new Font("Microsoft Sans Serif", 10F),
                    AutoSize = false
                };
                questionPanel.Controls.Add(lblContent);

                RadioButton rdoA = new RadioButton
                {
                    Text = "A. " + question.DapAnA,
                    Location = new Point(10, 40),
                    Width = questionPanel.Width - 20,
                    Enabled = false
                };
                questionPanel.Controls.Add(rdoA);

                RadioButton rdoB = new RadioButton
                {
                    Text = "B. " + question.DapAnB,
                    Location = new Point(10, 65),
                    Width = questionPanel.Width - 20,
                    Enabled = false
                };
                questionPanel.Controls.Add(rdoB);

                RadioButton rdoC = new RadioButton
                {
                    Text = "C. " + question.DapAnC,
                    Location = new Point(10, 90),
                    Width = questionPanel.Width - 20,
                    Enabled = false
                };
                questionPanel.Controls.Add(rdoC);

                RadioButton rdoD = new RadioButton
                {
                    Text = "D. " + question.DapAnD,
                    Location = new Point(10, 115),
                    Width = questionPanel.Width - 20,
                    Enabled = false
                };
                questionPanel.Controls.Add(rdoD);

                switch (question.DapAnDung)
                {
                    case "A": rdoA.Checked = true; break;
                    case "B": rdoB.Checked = true; break;
                    case "C": rdoC.Checked = true; break;
                    case "D": rdoD.Checked = true; break;
                }

                questionPanel.Tag = question;
                questionPanel.Click += (s, e) => SelectQuestion(question);
                foreach (Control control in questionPanel.Controls)
                {
                    control.Click += (s, e) => SelectQuestion(question);
                }

                flpQuestions.Controls.Add(questionPanel);
                questionNumber++;
            }
        }

        private void SelectQuestion(TracNghiem question)
        {
            selectedQuestion = question;
            txtQuestion.Text = question.NoiDung;
            txtOptionA.Text = question.DapAnA;
            txtOptionB.Text = question.DapAnB;
            txtOptionC.Text = question.DapAnC;
            txtOptionD.Text = question.DapAnD;
            cboCorrectAnswer.SelectedItem = question.DapAnDung;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newQuestion = new TracNghiem
            {
                NoiDung = txtQuestion.Text,
                DapAnA = txtOptionA.Text,
                DapAnB = txtOptionB.Text,
                DapAnC = txtOptionC.Text,
                DapAnD = txtOptionD.Text,
                DapAnDung = cboCorrectAnswer.SelectedItem.ToString()
            };

            context.TracNghiem.Add(newQuestion);
            context.SaveChanges();

            int newQuestionID = newQuestion.ID;

            var exam = context.DeThiNgauNhien.FirstOrDefault(de => de.MaDeNgauNhien == selectedExamID && de.MaMon == selectedSubjectID);

            if (exam != null)
            {

                if (string.IsNullOrEmpty(exam.CacCauHoi))
                {
                    exam.CacCauHoi = newQuestionID.ToString();  
                }
                else
                {
                    exam.CacCauHoi += "," + newQuestionID;  
                }

                context.SaveChanges();

                LoadQuestions();
                ClearFields();

                MessageBox.Show("Câu hỏi đã được thêm vào đề thi thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy đề thi để cập nhật.");
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedQuestion != null)
            {
                selectedQuestion.NoiDung = txtQuestion.Text;
                selectedQuestion.DapAnA = txtOptionA.Text;
                selectedQuestion.DapAnB = txtOptionB.Text;
                selectedQuestion.DapAnC = txtOptionC.Text;
                selectedQuestion.DapAnD = txtOptionD.Text;
                selectedQuestion.DapAnDung = cboCorrectAnswer.SelectedItem.ToString();

                context.SaveChanges();
                LoadQuestions();
                ClearFields();
                MessageBox.Show("Câu hỏi đã được sửa thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần sửa.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedQuestion != null)
            {
                context.TracNghiem.Remove(selectedQuestion);
                context.SaveChanges();
                LoadQuestions();
                ClearFields();
                MessageBox.Show("Câu hỏi đã được xóa!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtQuestion.Clear();
            txtOptionA.Clear();
            txtOptionB.Clear();
            txtOptionC.Clear();
            txtOptionD.Clear();
            cboCorrectAnswer.SelectedIndex = -1; // Reset ComboBox
            selectedQuestion = null; // Reset câu hỏi đã chọn
        }
    }
}
