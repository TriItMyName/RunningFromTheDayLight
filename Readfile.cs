using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RunningFromTheDayLight;
using RunningFromTheDayLight.Models; 

namespace WinFormApp
{
    public partial class Readfile : Form
    {
        private int selectedQuestionId;

        private readonly DatabaseSroce context; 
        private bool isInitializing = true; 

        public Readfile()
        {
            context = new DatabaseSroce(); 
            InitializeComponent();
            LoadMonHocToComboBox(); 
            LoadDataGrid(); 
            isInitializing = false; 
        }

        private void LoadMonHocToComboBox()
        {
            try
            {
                var monHocs = context.Mon.Select(m => new { m.MaMon, m.TenMon }).ToList();
                cmbTenMonHoc.DataSource = monHocs;
                cmbTenMonHoc.DisplayMember = "TenMon"; 
                cmbTenMonHoc.ValueMember = "MaMon";  
                cmbTenMonHoc.SelectedIndex = -1;       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải môn học: " + ex.Message);
            }
        }

        private void LoadQuestionsFromDatabase()
        {
            try
            {
                if (cmbTenMonHoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học.");
                    return;
                }

                string maMon = cmbTenMonHoc.SelectedValue.ToString();

                var questions = context.TracNghiem
                    .Join(context.Bai,
                          t => t.MaBai,
                          b => b.MaBai, 
                          (t, b) => new { t, b }) 
                    .Where(x => x.b.MaMon == maMon) 
                    .Select(x => new
                    {
                        BaiHoc = x.b.TenBai,
                        LoaiCauHoi = x.t.LoaiCauHoi,
                        CauHoi = x.t.NoiDung,
                        DapAnA = x.t.DapAnA,
                        DapAnB = x.t.DapAnB,
                        DapAnC = x.t.DapAnC,
                        DapAnD = x.t.DapAnD,
                        DapAnDung = x.t.DapAnDung
                    })
                    .ToList();

                if (questions.Count == 0)
                {
                    MessageBox.Show("Không có câu hỏi nào cho môn học này.");
                    dgvCauHoi.Rows.Clear();
                    txtSoLuong.Text = "0";
                    return;
                }


              
                dgvCauHoi.Rows.Clear();

                foreach (var question in questions)
                {
                    dgvCauHoi.Rows.Add(
                        question.BaiHoc,
                        question.LoaiCauHoi,
                        question.CauHoi,
                        question.DapAnA,
                        question.DapAnB,
                        question.DapAnC,
                        question.DapAnD,
                        question.DapAnDung
                    );
                }

                txtSoLuong.Text = questions.Count.ToString(); 

                MessageBox.Show("Tải dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải câu hỏi: {ex.Message}");
            }
        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    dgvCauHoi.Rows.Clear();

                    string loaiCauHoi = "";
                    string cauHoi = "";
                    string dapAnA = "", dapAnB = "", dapAnC = "", dapAnD = "", dapAnDung = "";
                    string bai = "";
                    int questionCount = 0;

                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        if (Regex.IsMatch(line, @"^Bài \d+:", RegexOptions.IgnoreCase))
                        {
                            bai = line.Trim();
                        }
                        else if (Regex.IsMatch(line, @"^\s*\d*\.?\s*\((TH|NB|VD|VDC)\)\s*(.*)"))
                        {
                     
                            var match = Regex.Match(line, @"^\s*\d*\.?\s*\((TH|NB|VD|VDC)\)\s*(.*)");
                            if (match.Success)
                            {
                                loaiCauHoi = match.Groups[1].Value;
                                cauHoi = match.Groups[2].Value.Trim(); 
                            }
                        }
                        else if (line.Contains("a.") || line.Contains("b.") || line.Contains("c.") || line.Contains("d."))
                        {
             
                            if (line.Contains("a."))
                            {
                                dapAnA = line.Substring(line.IndexOf("a.") + 2).Trim();
                                if (line.Contains("*")) dapAnDung = "A"; 
                            }
                            if (line.Contains("b."))
                            {
                                dapAnB = line.Substring(line.IndexOf("b.") + 2).Trim();
                                if (line.Contains("*")) dapAnDung = "B"; 
                            }
                            if (line.Contains("c."))
                            {
                                dapAnC = line.Substring(line.IndexOf("c.") + 2).Trim();
                                if (line.Contains("*")) dapAnDung = "C";
                            }
                            if (line.Contains("d."))
                            {
                                dapAnD = line.Substring(line.IndexOf("d.") + 2).Trim();
                                if (line.Contains("*")) dapAnDung = "D";
                            }
                        }

                        if (!string.IsNullOrEmpty(cauHoi) && !string.IsNullOrEmpty(dapAnA) &&
                            !string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnC) &&
                            !string.IsNullOrEmpty(dapAnD) && !string.IsNullOrEmpty(dapAnDung))
                        {
                            dgvCauHoi.Rows.Add(bai, loaiCauHoi, cauHoi, dapAnA, dapAnB, dapAnC, dapAnD, dapAnDung);
                            questionCount++; 

                            loaiCauHoi = "";
                            cauHoi = "";
                            dapAnA = dapAnB = dapAnC = dapAnD = dapAnDung = "";
                        }
                    }

                    txtSoLuong.Text = questionCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi đọc file: " + ex.Message);
                }
            }
        }




        private void LoadDataGrid()
        {
            dgvCauHoi.Rows.Clear();
        }

        private void menuThemMonHoc_Click_1(object sender, EventArgs e)
        {
            AddSubjecc addMonHocForm = new AddSubjecc();
            addMonHocForm.ShowDialog();
            LoadMonHocToComboBox(); 
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTenMonHoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học trước khi lưu.");
                    return;
                }

                string maMon = cmbTenMonHoc.SelectedValue.ToString();
                List<TracNghiem> questionsToSave = new List<TracNghiem>();
                StringBuilder errorMessage = new StringBuilder();

                foreach (DataGridViewRow row in dgvCauHoi.Rows)
                {
                    if (row.IsNewRow) continue;

                    var bai = row.Cells[0].Value?.ToString();
                    var loaiCauHoi = row.Cells[1].Value?.ToString();
                    var cauHoi = row.Cells[2].Value?.ToString();
                    var dapAnA = row.Cells[3].Value?.ToString(); 
                    var dapAnB = row.Cells[4].Value?.ToString(); 
                    var dapAnC = row.Cells[5].Value?.ToString();
                    var dapAnD = row.Cells[6].Value?.ToString(); 
                    var dapAnDung = row.Cells[7].Value?.ToString(); 

                    if (string.IsNullOrEmpty(cauHoi) || string.IsNullOrEmpty(dapAnDung) || dapAnDung.Length != 1)
                    {
                        errorMessage.AppendLine($"Câu hỏi không hợp lệ hoặc thiếu đáp án đúng cho câu hỏi: {cauHoi}");
                        continue;
                    }

                    Bai baiHoc = context.Bai.FirstOrDefault(b => b.TenBai == bai && b.MaMon == maMon);
                    if (baiHoc == null)
                    {
                        baiHoc = new Bai { TenBai = bai, MaMon = maMon };
                        context.Bai.Add(baiHoc);
                        context.SaveChanges();
                    }

                    int maBai = baiHoc.MaBai;

                    var cauHoiObj = new TracNghiem
                    {
                        NoiDung = cauHoi,
                        DapAnA = dapAnA,
                        DapAnB = dapAnB,
                        DapAnC = dapAnC,
                        DapAnD = dapAnD,
                        DapAnDung = dapAnDung.ToUpper(),
                        LoaiCauHoi = loaiCauHoi,
                        MaBai = maBai
                    };

                    questionsToSave.Add(cauHoiObj);
                }

                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (questionsToSave.Count > 0)
                {
                    context.TracNghiem.AddRange(questionsToSave);
                    context.SaveChanges();
                    MessageBox.Show("Lưu dữ liệu thành công!");
                }
                else
                {
                    MessageBox.Show("Không có câu hỏi hợp lệ nào để lưu.");
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi lưu dữ liệu: {ex.Message}");
            }
        }

        private void cmbTenMonHoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                LoadQuestionsFromDatabase();
            }
        }

        private void btnDeleteALLQS_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả câu hỏi không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dgvCauHoi.Rows.Clear();
                    txtSoLuong.Text = "0"; 

                    MessageBox.Show("Đã xóa tất cả câu hỏi thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xóa dữ liệu: " + ex.Message);
                }
            }
        }

     

        private void btnTaoCauHoi_Click(object sender, EventArgs e)
        {
            if (cmbTenMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                return;
            }

            if (dgvCauHoi.Rows.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi nào để tạo đề.");
                return;
            }

    
            string maMon = cmbTenMonHoc.SelectedValue.ToString();
            CreateExamRandom createExamForm = new CreateExamRandom(maMon);
            createExamForm.ShowDialog(); 

        }



        private void btnaddquestion_Click_1(object sender, EventArgs e)
        {
            if (cmbTenMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                return;
            }

            string subjectCode = cmbTenMonHoc.SelectedValue.ToString();
            QuestionForm3 questionForm3 = new QuestionForm3(subjectCode);
            if (questionForm3.ShowDialog() == DialogResult.OK)
            {
                

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                if (cmbTenMonHoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học trước khi tìm kiếm.");
                    return;
                }

                string maMon = cmbTenMonHoc.SelectedValue.ToString();
                var filteredQuestions = context.TracNghiem
                    .Join(context.Bai,
                          t => t.MaBai,
                          b => b.MaBai,
                          (t, b) => new { t, b })
                    .Where(x => x.b.MaMon == maMon && x.t.NoiDung.ToLower().Contains(searchText))
                    .Select(x => new
                    {
                        BaiHoc = x.b.TenBai,
                        LoaiCauHoi = x.t.LoaiCauHoi,
                        CauHoi = x.t.NoiDung,
                        DapAnA = x.t.DapAnA,
                        DapAnB = x.t.DapAnB,
                        DapAnC = x.t.DapAnC,
                        DapAnD = x.t.DapAnD,
                        DapAnDung = x.t.DapAnDung
                    })
                    .ToList();

                dgvCauHoi.Rows.Clear();

                foreach (var question in filteredQuestions)
                {
                    dgvCauHoi.Rows.Add(
                        question.BaiHoc,
                        question.LoaiCauHoi,
                        question.CauHoi,
                        question.DapAnA,
                        question.DapAnB,
                        question.DapAnC,
                        question.DapAnD,
                        question.DapAnDung
                    );
                }

                txtSoLuong.Text = filteredQuestions.Count.ToString(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tìm kiếm câu hỏi: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {

                string questionContent = dgvCauHoi.Rows[e.RowIndex].Cells[2].Value?.ToString();


                var question = context.TracNghiem.FirstOrDefault(q => q.NoiDung == questionContent);
                if (question != null)
                {
                    selectedQuestionId = question.ID;
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedQuestionId <= 0)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi để xóa.", "Thông báo");
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var questionToDelete = context.TracNghiem.FirstOrDefault(q => q.ID == selectedQuestionId);
                    if (questionToDelete != null)
                    {
                        context.TracNghiem.Remove(questionToDelete);
                        context.SaveChanges();

                        LoadQuestionsFromDatabase();
                        MessageBox.Show("Xóa câu hỏi thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy câu hỏi để xóa.", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi khi xóa câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }



}

