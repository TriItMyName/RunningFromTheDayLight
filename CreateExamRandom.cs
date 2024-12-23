using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class CreateExamRandom : Form
    {
        private string maMon;
        private readonly Model_ThiTracNghiem context;

        public CreateExamRandom(string maMon)
        {
            InitializeComponent();
            this.maMon = maMon;

            context = new Model_ThiTracNghiem();
            LoadBaiHoc();

            HideDeleteButtons();
        }

        private void LoadBaiHoc()
        {
            try
            {
                var baiHocs = context.Bais
                    .Where(b => b.MaMon == maMon)
                    .Select(b => b.TenBai)
                    .ToList();

                if (baiHocs.Count == 0)
                {
                    MessageBox.Show("Không có bài học nào cho môn học này.");
                    return;
                }

                List<ComboBox> comboBoxes = new List<ComboBox>
                {
                    cmbPhan1, cmbPhan2, cmbPhan3, cmbPhan4,
                    cmbPhan5, cmbPhan6, cmbPhan7, cmbPhan8,
                    cmbPhan9, cmbPhan10
                };

                foreach (var comboBox in comboBoxes)
                {
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(baiHocs.ToArray());

                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải bài học: {ex.Message}");
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selectedComboBox = sender as ComboBox;
            if (selectedComboBox != null)
            {
                LoadQuestionCounts(selectedComboBox);
                UpdateTotalQuestions();
                ShowDeleteButton(selectedComboBox);
            }
        }

        private void ShowDeleteButton(ComboBox comboBox)
        {
            if (comboBox == cmbPhan1 && btnXoaP1.Visible == false) btnXoaP1.Visible = true;
            else if (comboBox == cmbPhan2 && btnXoaP2.Visible == false) btnXoaP2.Visible = true;
            else if (comboBox == cmbPhan3 && btnXoaP3.Visible == false) btnXoaP3.Visible = true;
            else if (comboBox == cmbPhan4 && btnXoaP4.Visible == false) btnXoaP4.Visible = true;
            else if (comboBox == cmbPhan5 && btnXoaP5.Visible == false) btnXoaP5.Visible = true;
            else if (comboBox == cmbPhan6 && btnXoaP6.Visible == false) btnXoaP6.Visible = true;
            else if (comboBox == cmbPhan7 && btnXoaP7.Visible == false) btnXoaP7.Visible = true;
            else if (comboBox == cmbPhan8 && btnXoaP8.Visible == false) btnXoaP8.Visible = true;
            else if (comboBox == cmbPhan9 && btnXoaP9.Visible == false) btnXoaP9.Visible = true;
            else if (comboBox == cmbPhan10 && btnXoaP10.Visible == false) btnXoaP10.Visible = true;
        }

        private void LoadQuestionCounts(ComboBox cmbPhan)
        {
            if (cmbPhan.SelectedItem == null) return;

            string tenBaiHoc = cmbPhan.SelectedItem.ToString();

            var questionCounts = context.TracNghiems
                .Where(q => q.Bai.TenBai == tenBaiHoc && q.Bai.MaMon == maMon)
                .GroupBy(q => q.LoaiCauHoi)
                .Select(g => new { LoaiCauHoi = g.Key, Count = g.Count() })
                .ToDictionary(x => x.LoaiCauHoi, x => x.Count);
            if (cmbPhan == cmbPhan1)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP1, cmbThongHieuP1, cmbVanDungP1, cmbVanDungCaoP1, questionCounts);
            }
            else if (cmbPhan == cmbPhan2)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP2, cmbThongHieuP2, cmbVanDungP2, cmbVanDungCaoP2, questionCounts);
            }
            else if (cmbPhan == cmbPhan3)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP3, cmbThongHieuP3, cmbVanDungP3, cmbVanDungCaoP3, questionCounts);
            }
            else if (cmbPhan == cmbPhan4)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP4, cmbThongHieuP4, cmbVanDungP4, cmbVanDungCaoP4, questionCounts);
            }
            else if (cmbPhan == cmbPhan5)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP5, cmbThongHieuP5, cmbVanDungP5, cmbVanDungCaoP5, questionCounts);
            }
            else if (cmbPhan == cmbPhan6)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP6, cmbThongHieuP6, cmbVanDungP6, cmbVanDungCaoP6, questionCounts);
            }
            else if (cmbPhan == cmbPhan7)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP7, cmbThongHieuP7, cmbVanDungP7, cmbVanDungCaoP7, questionCounts);
            }
            else if (cmbPhan == cmbPhan8)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP8, cmbThongHieuP8, cmbVanDungP8, cmbVanDungCaoP8, questionCounts);
            }
            else if (cmbPhan == cmbPhan9)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP9, cmbThongHieuP9, cmbVanDungP9, cmbVanDungCaoP9, questionCounts);
            }
            else if (cmbPhan == cmbPhan10)
            {
                UpdateQuestionComboBoxes(cmbNhanBietP10, cmbThongHieuP10, cmbVanDungP10, cmbVanDungCaoP10, questionCounts);
            }
        }

        private void UpdateQuestionComboBoxes(ComboBox cmbNhanBiet, ComboBox cmbThongHieu, ComboBox cmbVanDung, ComboBox cmbVanDungCao, Dictionary<string, int> questionCounts)
        {
            UpdateComboBox(cmbNhanBiet, questionCounts, "NB");
            UpdateComboBox(cmbThongHieu, questionCounts, "TH");
            UpdateComboBox(cmbVanDung, questionCounts, "VD");
            UpdateComboBox(cmbVanDungCao, questionCounts, "VDC");
        }

        private void UpdateComboBox(ComboBox comboBox, Dictionary<string, int> questionCounts, string loaiCauHoi)
        {
            comboBox.Items.Clear();

            if (questionCounts.ContainsKey(loaiCauHoi))
            {
                int maxCount = questionCounts[loaiCauHoi];
                for (int i = 1; i <= maxCount; i++)
                {
                    comboBox.Items.Add(i);
                }
                comboBox.SelectedIndex = 0;

                comboBox.SelectedIndexChanged += (s, e) => UpdateTotalQuestions();
            }
            else
            {
                comboBox.Items.Add(0);
                comboBox.SelectedIndex = 0;

                comboBox.SelectedIndexChanged += (s, e) => UpdateTotalQuestions();
            }
        }

        private void UpdateTotalQuestions()
        {
            int totalQuestions = 0;

            List<ComboBox> comboBoxes = new List<ComboBox>
            {
                cmbNhanBietP1, cmbThongHieuP1, cmbVanDungP1, cmbVanDungCaoP1,
                cmbNhanBietP2, cmbThongHieuP2, cmbVanDungP2, cmbVanDungCaoP2,
                cmbNhanBietP3, cmbThongHieuP3, cmbVanDungP3, cmbVanDungCaoP3,
                cmbNhanBietP4, cmbThongHieuP4, cmbVanDungP4, cmbVanDungCaoP4,
                cmbNhanBietP5, cmbThongHieuP5, cmbVanDungP5, cmbVanDungCaoP5,
                cmbNhanBietP6, cmbThongHieuP6, cmbVanDungP6, cmbVanDungCaoP6,
                cmbNhanBietP7, cmbThongHieuP7, cmbVanDungP7, cmbVanDungCaoP7,
                cmbNhanBietP8, cmbThongHieuP8, cmbVanDungP8, cmbVanDungCaoP8,
                cmbNhanBietP9, cmbThongHieuP9, cmbVanDungP9, cmbVanDungCaoP9,
                cmbNhanBietP10, cmbThongHieuP10, cmbVanDungP10, cmbVanDungCaoP10,
            };

            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.SelectedItem != null)
                {
                    totalQuestions += (int)comboBox.SelectedItem;
                }
            }

            txtXemSoCauHoi.Text = totalQuestions.ToString();
        }

        private void HideDeleteButtons()
        {
            btnXoaP1.Visible = false;
            btnXoaP2.Visible = false;
            btnXoaP3.Visible = false;
            btnXoaP4.Visible = false;
            btnXoaP5.Visible = false;
            btnXoaP6.Visible = false;
            btnXoaP7.Visible = false;
            btnXoaP8.Visible = false;
            btnXoaP9.Visible = false;
            btnXoaP10.Visible = false;
        }

        private void btnXoaP1_Click(object sender, EventArgs e)
        {
            cmbPhan1.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP2_Click(object sender, EventArgs e)
        {
            cmbPhan2.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP3_Click(object sender, EventArgs e)
        {
            cmbPhan3.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP4_Click(object sender, EventArgs e)
        {
            cmbPhan4.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP5_Click(object sender, EventArgs e)
        {
            cmbPhan5.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP6_Click(object sender, EventArgs e)
        {
            cmbPhan6.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP7_Click(object sender, EventArgs e)
        {
            cmbPhan7.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP8_Click(object sender, EventArgs e)
        {
            cmbPhan8.SelectedItem = null;
            HideDeleteButtons();
        }

        private void btnXoaP9_Click(object sender, EventArgs e)
        {
            cmbPhan9.SelectedItem = null;
            HideDeleteButtons();

        }
        private void btnXoaP10_Click(object sender, EventArgs e)
        {
            cmbPhan10.SelectedItem = null;
            HideDeleteButtons();

        }

        private int LayGiaTriComboBox(string comboBoxName)
        {
            ComboBox comboBox = this.Controls.Find(comboBoxName, true).FirstOrDefault() as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                return (int)comboBox.SelectedItem;
            }
            return 0;
        }


        private void btnTaoDe_Click(object sender, EventArgs e)
        {
            try
            {

                int soDeThi;
                if (!int.TryParse(txtSoDeNgauNhien.Text, out soDeThi) || soDeThi <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng đề thi hợp lệ.");
                    return;
                }


                int thoiGianLamBai;
                if (!int.TryParse(txtThoiGianLamBai.Text, out thoiGianLamBai) || thoiGianLamBai <= 0)
                {
                    MessageBox.Show("Vui lòng nhập thời gian làm bài hợp lệ.");
                    return;
                }


                for (int i = 0; i < soDeThi; i++)
                {
                    List<TracNghiem> cauHoiDuocChon = new List<TracNghiem>();
                    List<(ComboBox cmbPhan, ComboBox cmbNhanBiet, ComboBox cmbThongHieu, ComboBox cmbVanDung, ComboBox cmbVanDungCao)> phanList = new List<(ComboBox, ComboBox, ComboBox, ComboBox, ComboBox)>
            {
                (cmbPhan1, cmbNhanBietP1, cmbThongHieuP1, cmbVanDungP1, cmbVanDungCaoP1),
                (cmbPhan2, cmbNhanBietP2, cmbThongHieuP2, cmbVanDungP2, cmbVanDungCaoP2),
                (cmbPhan3, cmbNhanBietP3, cmbThongHieuP3, cmbVanDungP3, cmbVanDungCaoP3),
                (cmbPhan4, cmbNhanBietP4, cmbThongHieuP4, cmbVanDungP4, cmbVanDungCaoP4),
                (cmbPhan5, cmbNhanBietP5, cmbThongHieuP5, cmbVanDungP5, cmbVanDungCaoP5),
                (cmbPhan6, cmbNhanBietP6, cmbThongHieuP6, cmbVanDungP6, cmbVanDungCaoP6),
                (cmbPhan7, cmbNhanBietP7, cmbThongHieuP7, cmbVanDungP7, cmbVanDungCaoP7),
                (cmbPhan8, cmbNhanBietP8, cmbThongHieuP8, cmbVanDungP8, cmbVanDungCaoP8),
                (cmbPhan9, cmbNhanBietP9, cmbThongHieuP9, cmbVanDungP9, cmbVanDungCaoP9),
                (cmbPhan10, cmbNhanBietP10, cmbThongHieuP10, cmbVanDungP10, cmbVanDungCaoP10),
            };

      
                    foreach (var (cmbPhan, cmbNhanBiet, cmbThongHieu, cmbVanDung, cmbVanDungCao) in phanList)
                    {
                        string tenBaiHoc = cmbPhan.SelectedItem?.ToString();
                        if (string.IsNullOrEmpty(tenBaiHoc))
                            continue;

                        int soLuongNhanBiet = LayGiaTriComboBox(cmbNhanBiet.Name);
                        int soLuongThongHieu = LayGiaTriComboBox(cmbThongHieu.Name);
                        int soLuongVanDung = LayGiaTriComboBox(cmbVanDung.Name);
                        int soLuongVanDungCao = LayGiaTriComboBox(cmbVanDungCao.Name);

                        var dsCauHoi = context.TracNghiems
                            .Where(q => q.Bai.TenBai == tenBaiHoc && q.Bai.MaMon == maMon)
                            .ToList();

                        var cauHoiNhanBiet = dsCauHoi.Where(q => q.LoaiCauHoi == "NB").OrderBy(r => Guid.NewGuid()).Take(soLuongNhanBiet);
                        var cauHoiThongHieu = dsCauHoi.Where(q => q.LoaiCauHoi == "TH").OrderBy(r => Guid.NewGuid()).Take(soLuongThongHieu);
                        var cauHoiVanDung = dsCauHoi.Where(q => q.LoaiCauHoi == "VD").OrderBy(r => Guid.NewGuid()).Take(soLuongVanDung);
                        var cauHoiVanDungCao = dsCauHoi.Where(q => q.LoaiCauHoi == "VDC").OrderBy(r => Guid.NewGuid()).Take(soLuongVanDungCao);

                        cauHoiDuocChon.AddRange(cauHoiNhanBiet);
                        cauHoiDuocChon.AddRange(cauHoiThongHieu);
                        cauHoiDuocChon.AddRange(cauHoiVanDung);
                        cauHoiDuocChon.AddRange(cauHoiVanDungCao);
                    }

                    var tenDeThi = $"Đề thi - {maMon} - {i + 1}";
                    if (!cauHoiDuocChon.Any())
                    {
                        MessageBox.Show("Không có câu hỏi nào được chọn. Vui lòng kiểm tra lại.");
                        return;
                    }

                    var deThi = new DeThiNgauNhien
                    {
                        TenDe = tenDeThi,
                        MaMon = maMon,
                        NgayTao = DateTime.Now,
                        CacCauHoi = string.Join(",", cauHoiDuocChon.Select(c => c.ID)),
                        ThoiGianThi = thoiGianLamBai 
                    };

                    context.DeThiNgauNhiens.Add(deThi);
                }

                context.SaveChanges(); 
                MessageBox.Show($"Đã tạo {soDeThi} đề thi ngẫu nhiên thành công!");
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
                MessageBox.Show($"Có lỗi khi tạo đề thi: {ex.Message}");
            }
        }




    }






}

