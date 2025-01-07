using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        public class ThongTin
        {
            static public string mssv, pass;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtNameID.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            try
            {
                using (var dbContext = new Model_ThiTracNghiem())
                {
                    var user = dbContext.Users
                        .FirstOrDefault(u => u.UserName == username && u.C_Password == password);

                    if (user != null && user.C_Password == password)
                    {
                        string loaiUser = user.LoaiUser;

                        if (loaiUser == "Admin")
                        {
                            this.Hide();
                            Frm_Admin adminForm = new Frm_Admin();
                            adminForm.FormClosing += (s, args) => { this.Show(); };
                            adminForm.ShowDialog();
                        }
                        else if (loaiUser == "SinhVien")
                        {
                            this.Hide();
                            ThongTin.mssv = username;
                            ThongTin.pass = password;
                            Confirm_F sinhVienForm = new Confirm_F();
                            sinhVienForm.FormClosing += (s, args) => { this.Show(); };
                            sinhVienForm.ShowDialog();
                        }
                        else if (loaiUser == "GiangVien")
                        {
                            this.Hide();
                            FrmGiangVien giangVienForm = new FrmGiangVien();
                            giangVienForm.FormClosing += (s, args) => { this.Show(); };
                            giangVienForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Bạn không có quyền truy cập vào hệ thống.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
