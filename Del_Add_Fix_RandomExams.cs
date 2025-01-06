using RunningFromTheDayLight.Models;
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace RunningFromTheDayLight
{
    public partial class Del_Add_Fix_RandomExams : Form
    {
        private readonly Model_ThiTracNghiem context;

        public Del_Add_Fix_RandomExams()
        {
            context = new Model_ThiTracNghiem();
            InitializeComponent();
            LoadSubjects(); 
            InitializeDataGridView(); 
        }

        private void LoadSubjects()
        {
            var subjects = context.Mons.ToList(); 
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "TenMon"; 
            cmbSubject.ValueMember = "MaMon";
            cmbSubject.SelectedIndexChanged += CmbSubject_SelectedIndexChanged;

            cmbSubject.SelectedIndex = -1;
        }

        private void CmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRandomExams(); 
        }

   
        private void LoadRandomExams()
        {
            setGridViewStyle(dgvRamdomExams);

            var selectedSubject = cmbSubject.SelectedValue?.ToString(); 

            if (!string.IsNullOrEmpty(selectedSubject))
            {
                var randomExams = context.DeThiNgauNhiens
                    .Where(de => de.MaMon == selectedSubject) 
                    .ToList()
                    .Select(de => new
                    {
                        ExamID = de.MaDeNgauNhien,
                        ExamName = de.TenDe,
                        CreationDate = de.NgayTao,
                        CountQuestions = de.CacCauHoi.Split(',') 
                            .Select(int.Parse) 
                            .Count(id => context.TracNghiems.Any(t => t.ID == id)), 
                        ExamDuration = de.ThoiGianThi 
                    })
                    .ToList(); 

                dgvRamdomExams.Rows.Clear();

                foreach (var item in randomExams)
                {
                    dgvRamdomExams.Rows.Add(item.ExamID, item.ExamName, item.CreationDate, item.CountQuestions, item.ExamDuration);
                }
            }
            else
            {
                dgvRamdomExams.Rows.Clear();
            }
        }

        private void InitializeDataGridView()
        {
            dgvRamdomExams.Columns.Clear();
            dgvRamdomExams.Columns.Add("colExamID", "Mã Đề"); 
            dgvRamdomExams.Columns.Add("colExamName", "Tên Đề"); 
            dgvRamdomExams.Columns.Add("colCreationDate", "Ngày Tạo");
            dgvRamdomExams.Columns.Add("colCountQuestions", "Số Câu"); 
            dgvRamdomExams.Columns.Add("colThoiGianThi", "Thời Gian Thi");
        }

        private void dgvRamdomExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvRamdomExams.Rows[e.RowIndex];

                var examIDCell = selectedRow.Cells["colExamID"].Value;
                if (examIDCell != null)
                {
                    var examID = (int)examIDCell;
                    SelectedExamID = examID;
                }
                else
                {
                    MessageBox.Show("Mã đề thi chưa được thiết lập.");
                    return;
                }

                var examNameCell = selectedRow.Cells["colExamName"].Value;
                var examDurationCell = selectedRow.Cells["colThoiGianThi"].Value;

                if (examNameCell != null && examDurationCell != null)
                {
                    var examName = examNameCell.ToString();
                    var examDuration = examDurationCell.ToString();

                    txtDoiTenDe.Text = examName;
                    txtSuaThoiGian.Text = examDuration;
                }
                else
                {
                    MessageBox.Show("Tên đề thi hoặc thời gian thi chưa được thiết lập.");
                }
            }
        }

        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private int SelectedExamID { get; set; } = -1; 

        private void btnDelRandomExams_Click(object sender, EventArgs e)
        {
            if (SelectedExamID != -1)
            {
  
                var examToDelete = context.DeThiNgauNhiens.FirstOrDefault(de => de.MaDeNgauNhien == SelectedExamID);

                if (examToDelete != null)
                {

                    context.DeThiNgauNhiens.Remove(examToDelete);
                    context.SaveChanges();

                    LoadRandomExams();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đề thi để xóa.");
            }
        }

        private void btnAddRandomExams_Click(object sender, EventArgs e)
        {
            var selectedSubject = cmbSubject.SelectedValue?.ToString(); 

            if (!string.IsNullOrEmpty(selectedSubject))
            {
                this.Hide();
                var createExamForm = new CreateExamRandom(selectedSubject);
                createExamForm.FormClosed += (s, args) =>
                {
                    this.Show();
                };
                createExamForm.ShowDialog(); 

                LoadRandomExams();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học trước khi thêm đề thi.");
            }
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            if (SelectedExamID != -1)
            {
                var examToUpdate = context.DeThiNgauNhiens.FirstOrDefault(de => de.MaDeNgauNhien == SelectedExamID);

                if (examToUpdate != null)
                {
                    examToUpdate.TenDe = txtDoiTenDe.Text;
                    if (int.TryParse(txtSuaThoiGian.Text, out int examDuration))
                    {
                        examToUpdate.ThoiGianThi = examDuration;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập thời gian thi là số nguyên hợp lệ.");
                        return;
                    }

                    context.SaveChanges();

                    LoadRandomExams();

                    MessageBox.Show("Cập nhật đề thi thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đề thi để cập nhật.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đề thi để sửa.");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = txtSearch.Text.Trim().ToLower();
            var selectedSubject = cmbSubject.SelectedValue?.ToString(); 

            if (!string.IsNullOrEmpty(selectedSubject))
            {
                var filteredExams = context.DeThiNgauNhiens
                    .Where(de => de.MaMon == selectedSubject && de.TenDe.ToLower().Contains(searchQuery)) 
                    .ToList()
                    .Select(de => new
                    {
                        ExamID = de.MaDeNgauNhien,
                        ExamName = de.TenDe,
                        CreationDate = de.NgayTao,
                        CountQuestions = de.CacCauHoi.Split(',')
                            .Select(int.Parse)
                            .Count(id => context.TracNghiems.Any(t => t.ID == id)),
                        ExamDuration = de.ThoiGianThi
                    })
                    .ToList();

                dgvRamdomExams.Rows.Clear();

                foreach (var item in filteredExams)
                {
                    dgvRamdomExams.Rows.Add(item.ExamID, item.ExamName, item.CreationDate, item.CountQuestions, item.ExamDuration);
                }
            }
            else
            {
                dgvRamdomExams.Rows.Clear();
            }
        }

        private void btnFixRandomExams_Click(object sender, EventArgs e)
        {
            if (SelectedExamID != -1)
            {
                var selectedSubject = cmbSubject.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(selectedSubject))
                {
                    var fixQuestionsForm = new Add_Fix_Del_Qestions(SelectedExamID, selectedSubject);
                    fixQuestionsForm.ShowDialog();

                    LoadRandomExams();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn môn học trước khi sửa câu hỏi.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đề thi để sửa câu hỏi.");
            }
        }
    }
}
