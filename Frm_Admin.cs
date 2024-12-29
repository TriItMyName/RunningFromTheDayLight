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

namespace RunningFromTheDayLight
{
    public partial class Frm_Admin : Form
    {
        private string DefaultSearchText = "Tìm kiếm tên/id";
        private string currentFilePath;
        private Model_ThiTracNghiem context;

        public Frm_Admin()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            context = new Model_ThiTracNghiem();
        }

        private int GetSelectedRow(string Username)
        {
            for (int i = 0; i < dgv_List.Rows.Count; i++)
            {
                var row = dgv_List.Rows[i];
                if (row != null && row.Cells[1] != null && row.Cells[1].Value != null && row.Cells[1].Value.ToString() == Username)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Frm_Admin_Load(object sender, EventArgs e)
        {
            try
            {
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
            listFacultys.Insert(0, new Khoa());
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "TenKhoa";
            this.cmbFaculty.ValueMember = "MaKhoa";
        }

        private void BindGrid(List<User> users)
        {
            dgv_List.Rows.Clear();
            foreach (var user in context.Users)
            {
                if (user.LoaiUser == "Admin")
                {
                    continue;
                }
                int index = dgv_List.Rows.Add();
                dgv_List.Rows[index].Cells[0].Value = user.UserID;
                dgv_List.Rows[index].Cells[1].Value = user.UserName;
                dgv_List.Rows[index].Cells[2].Value = user.C_Password;
                dgv_List.Rows[index].Cells[3].Value = user.HoTen;
                dgv_List.Rows[index].Cells[4].Value = user.GioiTinh;
                dgv_List.Rows[index].Cells[5].Value = user.NgaySinh;
                var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.UserID == user.UserID);
                var giangVien = context.GiangViens.FirstOrDefault(gv => gv.UserID == user.UserID);
                string facultyName = sinhVien?.Khoa?.TenKhoa ?? giangVien?.Khoa?.TenKhoa ?? "N/A";

                dgv_List.Rows[index].Cells[6].Value = facultyName;
                dgv_List.Rows[index].Cells[7].Value = user.LoaiUser;
            }
        }

        private void ClearData()
        {
            txtID.Text = string.Empty;
            txtNameID.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtName.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            rbMale.Checked = true;
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
                            string userID = row["UserID"].ToString();
                            string username = row["Username"].ToString();
                            string password = row["Password"].ToString();
                            string name = row["Họ tên"].ToString();
                            DateTime dateOfBirth = DateTime.Parse(row["Ngày sinh"].ToString());
                            string gender = row["Giới tính"].ToString();
                            string faculty = row["Khoa"].ToString();
                            string decentralization = row["Phân quyền"].ToString();

                            var user = context.Users.FirstOrDefault(u => u.UserID == userID);

                            if (user != null)
                            {
                                user.UserName = username;
                                user.C_Password = password;
                                user.HoTen = name;
                                user.NgaySinh = dateOfBirth;
                                user.GioiTinh = gender;
                                user.LoaiUser = decentralization;

                                var sinhVien = context.SinhViens.FirstOrDefault(sv => sv.UserID == userID);
                                var giangVien = context.GiangViens.FirstOrDefault(gv => gv.UserID == userID);

                                if (sinhVien != null)
                                {
                                    sinhVien.Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty);
                                }
                                else if (giangVien != null)
                                {
                                    giangVien.Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty);
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
                                        Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                                    };
                                    context.SinhViens.Add(sinhVien);
                                }
                                else if (decentralization == "GiangVien")
                                {
                                    var giangVien = new GiangVien
                                    {
                                        UserID = userID,
                                        Khoa = context.Khoas.FirstOrDefault(k => k.TenKhoa == faculty)
                                    };
                                    context.GiangViens.Add(giangVien);
                                }
                            }
                        }

                        context.SaveChanges();
                        MessageBox.Show("Dữ liệu đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindGrid(context.Users.ToList());
                    }
                    else
                    {
                        MessageBox.Show("Không thể đọc dữ liệu từ file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDataFromFile(string filePath)
        {
            DataTable dt = ReadExcelFile(filePath);

            if (dt != null)
            {
                dgv_List.DataSource = null;
                dgv_List.Columns.Clear();

                foreach (DataColumn column in dt.Columns)
                {
                    dgv_List.Columns.Add(column.ColumnName, column.ColumnName);
                }

                foreach (DataRow row in dt.Rows)
                {
                    dgv_List.Rows.Add(row.ItemArray);
                }
            }
            else
            {
                MessageBox.Show("Không thể đọc dữ liệu từ file.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataGridViewRow row = dgv_List.Rows[e.RowIndex];

                if (dgv_List.Columns.Contains("UserID"))
                {
                    txtID.Text = row.Cells[dgv_List.Columns["UserID"].Index].Value?.ToString() ?? string.Empty;
                }
                if (dgv_List.Columns.Contains("Username"))
                {
                    txtNameID.Text = row.Cells[dgv_List.Columns["Username"].Index].Value?.ToString() ?? string.Empty;
                }
                if (dgv_List.Columns.Contains("Password"))
                {
                    txtPass.Text = row.Cells[dgv_List.Columns["Password"].Index].Value?.ToString() ?? string.Empty;
                }
                if (dgv_List.Columns.Contains("Họ tên"))
                {
                    txtName.Text = row.Cells[dgv_List.Columns["Họ tên"].Index].Value?.ToString() ?? string.Empty;
                }
                if (dgv_List.Columns.Contains("Ngày sinh"))
                {
                    if (DateTime.TryParse(row.Cells[dgv_List.Columns["Ngày sinh"].Index].Value?.ToString(), out DateTime dateValue))
                    {
                        dtpDate.Value = dateValue;
                    }
                }
                if (dgv_List.Columns.Contains("Giới tính"))
                {
                    if (row.Cells[dgv_List.Columns["Giới tính"].Index].Value?.ToString() == "Nam")
                    {
                        rbMale.Checked = true;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                    }
                }
                if (dgv_List.Columns.Contains("Khoa"))
                {
                    cmbFaculty.Text = row.Cells[dgv_List.Columns["Khoa"].Index].Value?.ToString() ?? string.Empty;
                }
                if (dgv_List.Columns.Contains("Phân quyền"))
                {
                    cmbDecntralization.SelectedItem = row.Cells[dgv_List.Columns["Phân quyền"].Index].Value?.ToString() ?? string.Empty;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                SaveDateToFile(currentFilePath);
                LoadDataFromFile(currentFilePath);
                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chưa có tệp nào được tải lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveDateToFile(string filePath)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    for (int col = 1; col <= dgv_List.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col].Value = dgv_List.Columns[col - 1].HeaderText;
                    }
                    for (int row = 0; row < dgv_List.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgv_List.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dgv_List.Rows[row].Cells[col].Value;
                        }
                    }
                    package.SaveAs(new FileInfo(filePath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (!IsValisUserName(username) || (decentralization == "GiangVien" && !char.IsLetter(username[0])) || (decentralization == "SinhVien" && char.IsLetter(username[0])))
                {
                    MessageBox.Show("Tên đăng nhập không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValisName(name))
                {
                    MessageBox.Show("Tên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedRow = GetSelectedRow(username);

                if (selectedRow == -1)
                {
                    selectedRow = dgv_List.Rows.Add(ID, username, password, name, gender, dateOfBirth, faculty, decentralization);
                    MessageBox.Show("Thêm mới sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsValisUserID(string ID)
        {
            return ID.Length <= 4 && ID.All(char.IsLetterOrDigit);
        }

        private bool IsValisName(string name)
        {
            return name.Length >= 3 && name.Length <= 100 && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private bool IsValisUserName(string username)
        {
            return username.Length == 10 && username.All(char.IsLetterOrDigit);
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

                if (!IsValisUserName(username) || (decentralization == "GiangVien" && !char.IsLetter(username[0])) || (decentralization == "SinhVien" && char.IsLetter(username[0])))
                {
                    MessageBox.Show("Tên đăng nhập không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValisName(name))
                {
                    MessageBox.Show("Tên không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedRow = GetSelectedRow(username);

                if (selectedRow != -1)
                {
                    DataGridViewRow row = dgv_List.Rows[selectedRow];
                    row.Cells["UserID"].Value = ID;
                    row.Cells["Username"].Value = username;
                    row.Cells["Password"].Value = password;
                    row.Cells["Họ tên"].Value = name;
                    row.Cells["Ngày sinh"].Value = dateOfBirth;
                    row.Cells["Giới tính"].Value = gender;
                    row.Cells["Khoa"].Value = faculty;
                    row.Cells["Phân quyền"].Value = decentralization;

                    MessageBox.Show("Cập nhật thông tin sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với UserID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

                int selectedRow = GetSelectedRow(username);

                if (selectedRow != -1)
                {
                    dgv_List.Rows.RemoveAt(selectedRow);
                    MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với tên đăng nhập này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                foreach (DataGridViewRow row in dgv_List.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            string lowerSearchText = searchText.ToLower();

            foreach (DataGridViewRow row in dgv_List.Rows)
            {
                if (row.IsNewRow) continue;

                var usernameCellValue = row.Cells["Username"].Value?.ToString().ToLower();
                var nameCellValue = row.Cells["Họ tên"].Value?.ToString().ToLower();

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
            foreach (DataGridViewRow row in dgv_List.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                if (row.Cells["Phân quyền"].Value != null && row.Cells["Phân quyền"].Value.ToString() == "SinhVien")
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
            foreach (DataGridViewRow row in dgv_List.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["6"].Value !=null && row.Cells["6"].Value.ToString() == "GiangVien")
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
            foreach (DataGridViewRow row in dgv_List.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Visible = true;
                }
            }
        }

        private void toolStrip_btnData_Click(object sender, EventArgs e)
        {

        }

        
    }
}
