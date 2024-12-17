using RunningFromTheDayLight.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RunningFromTheDayLight
{
    public partial class Del_Add_Fix_RandomExams : Form
    {
        private readonly DatabaseSroce context;

        public Del_Add_Fix_RandomExams()
        {
            context = new DatabaseSroce();
            InitializeComponent();
            LoadSubjects(); 
            InitializeDataGridView(); 
        }

        private void LoadSubjects()
        {
            var subjects = context.Mon.ToList(); 
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
            var selectedSubject = cmbSubject.SelectedValue?.ToString(); 


            if (!string.IsNullOrEmpty(selectedSubject))
            {
                var randomExams = context.DeThiNgauNhien
                    .Where(de => de.MaMon == selectedSubject) 
                    .ToList()
                    .Select(de => new
                    {
                        ExamID = de.MaDeNgauNhien,
                        ExamName = de.TenDe,
                        CreationDate = de.NgayTao,
                        CountQuestions = de.CacCauHoi.Split(',') 
                            .Select(int.Parse) 
                            .Count(id => context.TracNghiem.Any(t => t.ID == id)), 
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

    
                var examID = (int)selectedRow.Cells["colExamID"].Value;
                SelectedExamID = examID;


                var examName = selectedRow.Cells["colExamName"].Value.ToString();
                var examDuration = selectedRow.Cells["colThoiGianThi"].Value.ToString();

         
                txtDoiTenDe.Text = examName;
                txtSuaThoiGian.Text = examDuration;
            }
        }


  
        private int SelectedExamID { get; set; } = -1; 

        private void btnDelRandomExams_Click(object sender, EventArgs e)
        {
            if (SelectedExamID != -1)
            {
  
                var examToDelete = context.DeThiNgauNhien.FirstOrDefault(de => de.MaDeNgauNhien == SelectedExamID);

                if (examToDelete != null)
                {

                    context.DeThiNgauNhien.Remove(examToDelete);
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

                var createExamForm = new CreateExamRandom(selectedSubject);
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
            // Kiểm tra xem có đề thi nào được chọn để sửa không
            if (SelectedExamID != -1)
            {
                // Tìm đề thi ngẫu nhiên cần sửa theo ID
                var examToUpdate = context.DeThiNgauNhien.FirstOrDefault(de => de.MaDeNgauNhien == SelectedExamID);

                if (examToUpdate != null)
                {
                    // Lấy dữ liệu từ TextBox và cập nhật vào các thuộc tính của đề thi
                    examToUpdate.TenDe = txtDoiTenDe.Text; // Cập nhật tên đề thi
                    if (int.TryParse(txtSuaThoiGian.Text, out int examDuration))
                    {
                        examToUpdate.ThoiGianThi = examDuration; // Cập nhật thời gian thi nếu giá trị hợp lệ
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập thời gian thi là số nguyên hợp lệ.");
                        return;
                    }

                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    // Tải lại danh sách đề thi ngẫu nhiên để cập nhật giao diện
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

        // Sự kiện TextChanged của txtSearch
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = txtSearch.Text.Trim().ToLower(); // Lấy nội dung tìm kiếm và chuyển về chữ thường để so sánh không phân biệt chữ hoa/chữ thường
            var selectedSubject = cmbSubject.SelectedValue?.ToString(); // Lấy mã môn học đã chọn

            // Kiểm tra xem có môn học nào được chọn hay không
            if (!string.IsNullOrEmpty(selectedSubject))
            {
                // Lọc danh sách đề thi ngẫu nhiên dựa trên từ khóa tìm kiếm
                var filteredExams = context.DeThiNgauNhien
                    .Where(de => de.MaMon == selectedSubject && de.TenDe.ToLower().Contains(searchQuery)) // Lọc theo mã môn và tên đề
                    .ToList()
                    .Select(de => new
                    {
                        ExamID = de.MaDeNgauNhien,
                        ExamName = de.TenDe,
                        CreationDate = de.NgayTao,
                        CountQuestions = de.CacCauHoi.Split(',')
                            .Select(int.Parse)
                            .Count(id => context.TracNghiem.Any(t => t.ID == id)),
                        ExamDuration = de.ThoiGianThi
                    })
                    .ToList();

                // Xóa tất cả dữ liệu cũ trong DataGridView
                dgvRamdomExams.Rows.Clear();

                // Thêm dữ liệu đã lọc vào DataGridView
                foreach (var item in filteredExams)
                {
                    dgvRamdomExams.Rows.Add(item.ExamID, item.ExamName, item.CreationDate, item.CountQuestions, item.ExamDuration);
                }
            }
            else
            {
                // Nếu không có môn học nào được chọn, xóa danh sách trong DataGridView
                dgvRamdomExams.Rows.Clear();
            }
        }

        private void btnFixRandomExams_Click(object sender, EventArgs e)
        {
            if (SelectedExamID != -1)
            {
                var selectedSubject = cmbSubject.SelectedValue?.ToString(); // Lấy mã môn học đã chọn
                if (!string.IsNullOrEmpty(selectedSubject))
                {
                    // Mở form Add_Fix_Del_Qestions với mã môn học và mã đề ngẫu nhiên đã chọn
                    var fixQuestionsForm = new Add_Fix_Del_Qestions(SelectedExamID, selectedSubject);
                    fixQuestionsForm.ShowDialog(); // Hiển thị form như một dialog

                    // Sau khi form được đóng, tải lại danh sách đề thi ngẫu nhiên nếu cần
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
