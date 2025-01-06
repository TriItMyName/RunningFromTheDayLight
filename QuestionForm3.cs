using RunningFromTheDayLight.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningFromTheDayLight
{
    public partial class QuestionForm3 : Form
    {
        private readonly Model_ThiTracNghiem context;

        public string SubjectCode { get; set; }


        public QuestionForm3(string subjectCode)
        {
            InitializeComponent();
            context = new Model_ThiTracNghiem();
            SubjectCode = subjectCode; 
        }

       

        private void LoadBaiLenComboBox()
        {
            if (!string.IsNullOrEmpty(SubjectCode))
            {
                var baiList = context.Bais
                    .Where(b => b.MaMon == SubjectCode)
                    .Select(b => new { b.MaBai, b.TenBai })
                    .ToList();

                cmbBai.DataSource = baiList;
                cmbBai.DisplayMember = "TenBai";
                cmbBai.ValueMember = "MaBai";
            }
            else
            {
                MessageBox.Show("Mã môn học không hợp lệ hoặc không được cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                List<TracNghiem> questionsToSave = new List<TracNghiem>();

                string cauHoi = txtQuestion.Text;
                string dapAnA = txtQuestionA.Text;
                string dapAnB = txtQuestionB.Text;
                string dapAnC = txtQuestionC.Text;
                string dapAnD = txtQuestionD.Text;
                string dapAnDung = rdoQuestionA.Checked ? "A" :
                                   rdoQuestionB.Checked ? "B" :
                                   rdoQuestionC.Checked ? "C" : "D";
                string loaiCauHoi = rdoNhanBiet.Checked ? "NB" :
                                    rdoThongHieu.Checked ? "TH" :
                                    rdoVanDung.Checked ? "VB" : "VDC";
                string audioFileName = rboAudio.Checked ? txtFileNameAudio.Text : null;

                int? maBai = null;
                if (cmbBai.SelectedValue != null && int.TryParse(cmbBai.SelectedValue.ToString(), out int maBaiValue))
                {
                    maBai = maBaiValue;
                }

                if (string.IsNullOrWhiteSpace(cauHoi) || string.IsNullOrWhiteSpace(dapAnDung) || string.IsNullOrWhiteSpace(loaiCauHoi) || maBai == null)
                {
                    MessageBox.Show("Một số trường bắt buộc đang trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cauHoiObj = new TracNghiem
                {
                    NoiDung = cauHoi,
                    DapAnA = dapAnA,
                    DapAnB = dapAnB,
                    DapAnC = dapAnC,
                    DapAnD = dapAnD,
                    DapAnDung = dapAnDung.ToUpper(),
                    LoaiCauHoi = loaiCauHoi,
                    MaBai = maBai,
                    AudioFileName = audioFileName
                };

                questionsToSave.Add(cauHoiObj);

                if (questionsToSave.Count > 0)
                {
                    context.TracNghiems.AddRange(questionsToSave);
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void QuestionForm3_Load(object sender, EventArgs e)
        {
            
                LoadBaiLenComboBox(); 
         }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<TracNghiem> questionsToSave = new List<TracNghiem>();

                string cauHoi = txtQuestion.Text;
                string dapAnA = txtQuestionA.Text;
                string dapAnB = txtQuestionB.Text;
                string dapAnC = txtQuestionC.Text;
                string dapAnD = txtQuestionD.Text;
                string dapAnDung = rdoQuestionA.Checked ? "A" :
                                   rdoQuestionB.Checked ? "B" :
                                   rdoQuestionC.Checked ? "C" : "D";
                string loaiCauHoi = rdoNhanBiet.Checked ? "NB" :
                                    rdoThongHieu.Checked ? "TH" :
                                    rdoVanDung.Checked ? "VB" : "VDC";
                string audioFileName = rboAudio.Checked ? txtFileNameAudio.Text : null;

                int? maBai = null;
                if (cmbBai.SelectedValue != null && int.TryParse(cmbBai.SelectedValue.ToString(), out int maBaiValue))
                {
                    maBai = maBaiValue;
                }
                else
                {
                    string tenBai = cmbBai.Text;
                    var existingBai = context.Bais.FirstOrDefault(b => b.TenBai.Equals(tenBai, StringComparison.OrdinalIgnoreCase) && b.MaMon == SubjectCode);
                    if (existingBai != null)
                    {
                        maBai = existingBai.MaBai;
                    }
                    else
                    {
                        Bai newBai = new Bai
                        {
                            TenBai = tenBai,
                            MaMon = SubjectCode
                        };

                        context.Bais.Add(newBai);
                        context.SaveChanges();
                        maBai = newBai.MaBai;
                    }
                }

                if (string.IsNullOrWhiteSpace(cauHoi) || string.IsNullOrWhiteSpace(dapAnDung) || string.IsNullOrWhiteSpace(loaiCauHoi) || maBai == null)
                {
                    MessageBox.Show("Một số trường bắt buộc đang trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cauHoiObj = new TracNghiem
                {
                    NoiDung = cauHoi,
                    DapAnA = dapAnA,
                    DapAnB = dapAnB,
                    DapAnC = dapAnC,
                    DapAnD = dapAnD,
                    DapAnDung = dapAnDung.ToUpper(),
                    LoaiCauHoi = loaiCauHoi,
                    MaBai = maBai,
                    AudioFileName = audioFileName
                };

                questionsToSave.Add(cauHoiObj);

                if (questionsToSave.Count > 0)
                {
                    context.TracNghiems.AddRange(questionsToSave);
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
             this.DialogResult = DialogResult.Cancel;
             this.Close();
        }

    }
}
