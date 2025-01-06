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
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Slicer.Style;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Data.Entity;
using RunningFromTheDayLight.Models;
using System.Data.Entity.Validation;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace RunningFromTheDayLight
{
    public partial class Frm_Admin : Form
    {
        private string DefaultSearchText = "Tìm kiếm theo Tên/Username/UserID";
        private string currentFilePath;
        private Model_ThiTracNghiem context;

        public Frm_Admin()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            context = new Model_ThiTracNghiem();
        }

        private void Frm_Admin_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgv_ListUser);
                List<User> users = context.Users.ToList();
                List<SinhVien> sinhViens = context.SinhViens.ToList();
                List<GiangVien> giangViens = context.GiangViens.ToList();
                List<Khoa> khoas = context.Khoas.ToList();
                FillFalcultyCombobox(khoas);
                BindGrid(users);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FillFalcultyCombobox(List<Khoa> listFacultys)
        {
            listFacultys = listFacultys.Where(k => !string.IsNullOrWhiteSpace(k.TenKhoa)).ToList();
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "TenKhoa";
            this.cmbFaculty.ValueMember = "MaKhoa";
            this.cmbFaculty.SelectedIndex = -1;
        }

        private void BindGrid(List<User> users)
        {
            dgv_ListUser.Rows.Clear();
            foreach (var user in context.Users)
            {
                if (user.LoaiUser == "Admin")
                {
                    continue;
                }
                int index = dgv_ListUser.Rows.Add();
                dgv_ListUser.Rows[index].Cells[0].Value = user.UserID;
                dgv_ListUser.Rows[index].Cells[1].Value = user.UserName;
                dgv_ListUser.Rows[index].Cells[2].Value = user.C_Password;
                dgv_ListUser.Rows[index].Cells[3].Value = user.HoTen;
                dgv_ListUser.Rows[index].Cells[4].Value = user.NgaySinh;
                dgv_ListUser.Rows[index].Cells[5].Value = user.GioiTinh;
                var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.UserID == user.UserID);
                var giangVien = context.GiangViens.FirstOrDefault(gv => gv.UserID == user.UserID);
                string facultyName = sinhVien?.Khoa?.TenKhoa ?? giangVien?.Khoa?.TenKhoa ?? "N/A";

                dgv_ListUser.Rows[index].Cells[6].Value = facultyName;
                dgv_ListUser.Rows[index].Cells[7].Value = user.LoaiUser;
            }
        }

        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dgview.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = System.Drawing.Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ClearData()
        {
            txtID.Text = string.Empty;
            txtNameID.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtName.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            rbMale.Checked = false;
            rbFemale.Checked = false;
            cmbFaculty.SelectedIndex = -1;
            cmbDecntralization.SelectedIndex = -1;
        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel để upload"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentFilePath = openFileDialog.FileName;
                    DataTable dt = ReadExcelFile(currentFilePath);

                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string userID = row[0].ToString();
                            string username = row[1].ToString();
                            string password = row[2].ToString();
                            string name = row[3].ToString();
                            DateTime dateOfBirth = DateTime.Parse(row[4].ToString());
                            string gender = row[5].ToString();
                            string faculty = row[6].ToString();
                            string decentralization = row[7].ToString();
                            string facultyID = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)?.MaKhoa;

                            var user = context.Users.FirstOrDefault(u => u.UserID == userID);

                            if (!IsValisUserID(userID))
                            {
                                MessageBox.Show($"User ID không hợp lệ: {userID}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }

                            if (!IsValidUserName(username, decentralization))
                            {
                                MessageBox.Show($"Tên đăng nhập không hợp lệ: {username}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }

                            if (!IsValisName(name))
                            {
                                MessageBox.Show($"Tên không hợp lệ: {name}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }

                            if (user != null)
                            {
                                user.C_Password = password;
                                user.HoTen = name;
                                user.NgaySinh = dateOfBirth;
                                user.GioiTinh = gender;
                                user.LoaiUser = decentralization;

                                var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.UserID == userID);
                                var giangVien = context.GiangViens.FirstOrDefault(gv => gv.UserID == userID);

                                if (decentralization == "SinhVien")
                                {
                                    if (sinhVien == null)
                                    {
                                        sinhVien = new SinhVien
                                        {
                                            UserID = userID.Trim(),
                                            MaSV = username,
                                            Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                                        };
                                        context.SinhViens.Add(sinhVien);
                                    }
                                    else
                                    {
                                        sinhVien.Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty);
                                    }

                                    if (giangVien != null)
                                    {
                                        context.GiangViens.Remove(giangVien);
                                    }
                                }
                                else if (decentralization == "GiangVien")
                                {
                                    if (giangVien == null)
                                    {
                                        giangVien = new GiangVien
                                        {
                                            UserID = userID.Trim(),
                                            MaGV = username,
                                            Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                                        };
                                        context.GiangViens.Add(giangVien);
                                    }
                                    else
                                    {
                                        giangVien.Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty);
                                    }

                                    if (sinhVien != null)
                                    {
                                        context.SinhViens.Remove(sinhVien);
                                    }
                                }
                            }
                            else
                            {
                                user = new User
                                {
                                    UserID = userID,
                                    UserName = username,
                                    C_Password = password,
                                    HoTen = name,
                                    NgaySinh = dateOfBirth,
                                    GioiTinh = gender,
                                    LoaiUser = decentralization
                                };
                                context.Users.Add(user);

                                if (decentralization == "SinhVien")
                                {
                                    var sinhVien = new SinhVien
                                    {
                                        UserID = userID,
                                        MaSV = username,
                                        MaKhoa = facultyID,
                                        Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                                    };
                                    context.SinhViens.Add(sinhVien);
                                }
                                else if (decentralization == "GiangVien")
                                {
                                    var giangVien = new GiangVien
                                    {
                                        UserID = userID,
                                        MaGV = username,
                                        MaKhoa = facultyID,
                                        Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                                    };
                                    context.GiangViens.Add(giangVien);
                                }
                            }
                        }

                        MessageBox.Show("Dữ liệu đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGrid(context.Users.ToList());
                        btnSave.Enabled = true;
                        btnNoSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể đọc dữ liệu từ file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dgv_ListUser.Refresh();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message + "\n" + ex.InnerException?.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            try
            {
                var dataTable = new DataTable();

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    if (worksheet == null)
                    {
                        throw new Exception("Không tìm thấy worksheet nào trong file Excel.");
                    }

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        dataTable.Columns.Add(worksheet.Cells[1, col].Text);
                    }

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void dgv_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_ListUser.Rows[e.RowIndex];

                txtID.Text = row.Cells[0].Value?.ToString().Trim() ?? string.Empty;
                txtNameID.Text = row.Cells[1].Value?.ToString().Trim() ?? string.Empty;
                txtPass.Text = row.Cells[2].Value?.ToString().Trim() ?? string.Empty;
                txtName.Text = row.Cells[3].Value?.ToString().Trim() ?? string.Empty;

                if (DateTime.TryParse(row.Cells[4].Value?.ToString().Trim(), out DateTime dateValue))
                {
                    dtpDate.Value = dateValue;
                }

                if (row.Cells[5].Value?.ToString().Trim() == "Nam")
                {
                    rbMale.Checked = true;
                }
                else
                {
                    rbFemale.Checked = true;
                }

                cmbFaculty.Text = row.Cells[6].Value?.ToString().Trim() ?? string.Empty;
                cmbDecntralization.SelectedItem = row.Cells[7].Value?.ToString().Trim() ?? string.Empty;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = txtID.Text;
                string username = txtNameID.Text;
                string password = txtPass.Text;
                string name = txtName.Text;
                string dateOfBirth = dtpDate.Value.ToString("yyyy-MM-dd");
                string gender = rbMale.Checked ? "Nam" : "Nữ";
                string faculty = cmbFaculty.Text;
                string decentralization = cmbDecntralization.SelectedItem != null ? cmbDecntralization.SelectedItem.ToString() : string.Empty;

                if (string.IsNullOrWhiteSpace(ID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(faculty) ||
                     string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(decentralization))
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValisUserID(ID))
                {
                    MessageBox.Show("User ID không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidUserName(username, decentralization))
                {
                    MessageBox.Show("Tên đăng nhập không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValisName(name))
                {
                    MessageBox.Show("Tên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingUser = context.Users.FirstOrDefault(u => u.UserID == ID || u.UserName == username);
                if (existingUser != null)
                {
                    MessageBox.Show("User ID hoặc Username đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = new User
                {
                    UserID = ID,
                    UserName = username,
                    C_Password = password,
                    HoTen = name,
                    NgaySinh = DateTime.Parse(dateOfBirth),
                    GioiTinh = gender,
                    LoaiUser = decentralization
                };

                context.Users.Add(user);

                if (decentralization == "SinhVien")
                {
                    var sinhVien = new SinhVien
                    {
                        UserID = ID,
                        MaSV = username,
                        MaKhoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)?.MaKhoa
                    };
                    context.SinhViens.Add(sinhVien);
                }
                else if (decentralization == "GiangVien")
                {
                    var giangVien = new GiangVien
                    {
                        UserID = ID,
                        MaGV = username,
                        MaKhoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)?.MaKhoa
                    };
                    context.GiangViens.Add(giangVien);
                }

                MessageBox.Show("Thêm mới người dùng thành công. Nhấn 'Lưu' để lưu thay đổi hoặc 'Không lưu' để hủy bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.Users.ToList());
                ClearData();
                btnSave.Enabled = true;
                btnNoSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = txtID.Text;
                string username = txtNameID.Text;
                string password = txtPass.Text;
                string name = txtName.Text;
                string dateOfBirth = dtpDate.Value.ToString("yyyy-MM-dd");
                string gender = rbMale.Checked ? "Nam" : "Nữ";
                string faculty = cmbFaculty.Text;
                string decentralization = cmbDecntralization.SelectedItem != null ? cmbDecntralization.SelectedItem.ToString() : string.Empty;

                if (string.IsNullOrWhiteSpace(ID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                     string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(decentralization))
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValisUserID(ID))
                {
                    MessageBox.Show("User ID không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidUserName(username, decentralization))
                {
                    MessageBox.Show("Tên đăng nhập không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValisName(name))
                {
                    MessageBox.Show("Tên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = context.Users.FirstOrDefault(u => u.UserID == ID);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng với UserID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                user.C_Password = password;
                user.HoTen = name;
                user.NgaySinh = DateTime.Parse(dateOfBirth);
                user.GioiTinh = gender;
                user.LoaiUser = decentralization;

                var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.UserID == ID);
                var giangVien = context.GiangViens.FirstOrDefault(gv => gv.UserID == ID);

                if (decentralization == "SinhVien")
                {
                    if (sinhVien == null)
                    {
                        sinhVien = new SinhVien
                        {
                            UserID = ID,
                            MaSV = username,
                            Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                        };
                        context.SinhViens.Add(sinhVien);
                    }
                    else
                    {
                        sinhVien.Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty);
                    }

                    if (giangVien != null)
                    {
                        context.GiangViens.Remove(giangVien);
                    }
                }
                else if (decentralization == "GiangVien")
                {
                    if (giangVien == null)
                    {
                        giangVien = new GiangVien
                        {
                            UserID = ID,
                            MaGV = username,
                            Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                        };
                        context.GiangViens.Add(giangVien);
                    }
                    else
                    {
                        giangVien.Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty);
                    }

                    if (sinhVien != null)
                    {
                        context.SinhViens.Remove(sinhVien);
                    }
                }

                MessageBox.Show("Cập nhật thông tin người dùng thành công. Nhấn 'Lưu' để lưu thay đổi hoặc 'Không lưu' để hủy bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.Users.ToList());
                ClearData();
                btnSave.Enabled = true;
                btnNoSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsValidUserName(string username, string decentralization)
        {
            if (decentralization == "SinhVien")
            {
                return username.Length == 10 && username.All(char.IsDigit);
            }
            else if (decentralization == "GiangVien")
            {
                return username.Length == 10 && username.Take(3).All(char.IsLetter) && username.Skip(3).All(char.IsDigit);
            }
            return false;
        }

        private bool IsValisUserID(string ID)
        {
            return ID.Length <= 10 && ID.All(char.IsLetterOrDigit);
        }

        private bool IsValisName(string name)
        {
            return name.Length >= 3 && name.Length <= 100 && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtNameID.Text;

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Bạn phải nhập tên đăng nhập để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = context.Users.FirstOrDefault(u => u.UserName == username);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.UserID == user.UserID);
                var giangVien = context.GiangViens.FirstOrDefault(gv => gv.UserID == user.UserID);

                if (sinhVien != null)
                {
                    context.SinhViens.Remove(sinhVien);
                }
                else if (giangVien != null)
                {
                    context.GiangViens.Remove(giangVien);
                }

                context.Users.Remove(user);

                MessageBox.Show("Xóa người dùng thành công. Nhấn 'Lưu' để lưu thay đổi hoặc 'Không lưu' để hủy bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid(context.Users.ToList());
                ClearData();
                btnSave.Enabled = true;
                btnNoSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            SearchStudentByUserNameOrUserID(searchText);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == DefaultSearchText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = DefaultSearchText;
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void SearchStudentByUserNameOrUserID(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText) || searchText == DefaultSearchText)
            {
                foreach (DataGridViewRow row in dgv_ListUser.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            string lowerSearchText = searchText.ToLower();

            foreach (DataGridViewRow row in dgv_ListUser.Rows)
            {
                if (row.IsNewRow) continue;

                var usernameCellValue = row.Cells[1].Value?.ToString().ToLower();
                var nameCellValue = row.Cells[3].Value?.ToString().ToLower();

                if ((usernameCellValue != null && usernameCellValue.Contains(lowerSearchText)) ||
                    (nameCellValue != null && nameCellValue.Contains(lowerSearchText)))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void toolStrip_btnListStudent_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_ListUser.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                if (row.Cells[7].Value != null && row.Cells[7].Value.ToString() == "SinhVien")
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void toolStrip_btnTeacher_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_ListUser.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                if (row.Cells[7].Value != null && row.Cells[7].Value.ToString() == "GiangVien")
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void toolStrip_btnHome_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_ListUser.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Visible = true;
                }
            }
        }

        private void toolStrip_btnScore_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frm_ScoreStatistics frmScore = new frm_ScoreStatistics();
                frmScore.FormClosing += (s, args) =>
                {
                    this.ShowDialog();
                };
                frmScore.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStrip_btnAddExaSchedule_Click(object sender, EventArgs e)
        {
            try 
            {
                this.Hide();
                Frm_ExamSchedule frmAddContest = new Frm_ExamSchedule();
                frmAddContest.FormClosing += (s, args) => 
                { 
                    this.ShowDialog(); 
                };
                frmAddContest.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStrip_btnAddExam_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Frm_AddContest frmAddContest = new Frm_AddContest();
                frmAddContest.FormClosing += (s, args) => 
                { 
                    this.ShowDialog(); 
                };
                frmAddContest.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStrip_btnSuject_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                AddSubject frmSubject = new AddSubject();
                frmSubject.FormClosing += (s, args) => 
                { 
                    this.ShowDialog();
                };
                frmSubject.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStrip_btnAddMajor_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                AddMajor addMajor = new AddMajor();
                addMajor.FormClosing += (s, args) =>
                {
                    this.ShowDialog();
                };
                addMajor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("Lưu thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                btnSave.Enabled = false;
                btnNoSave.Enabled = false;
                BindGrid(context.Users.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message + "\n" + ex.InnerException?.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            try
            {
                context = new Model_ThiTracNghiem();
                MessageBox.Show("Không lưu thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                btnSave.Enabled = false;
                btnNoSave.Enabled = false;
                BindGrid(context.Users.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
