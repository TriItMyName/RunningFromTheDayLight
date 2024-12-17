using RunningFromTheDayLight.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace RunningFromTheDayLight
{
    public partial class Confirm_F : Form
    {
        private string username = "2280600285";
        private string password = "2280600285";
        private string SubjectCode;
        private string StudentCode;
        private string StudentName;
        //private string MaMon;
        private DateTime TGBD;
        private readonly DatabaseSroce Context;
        private bool Flag = false;
        private string RoomID;

        public Confirm_F()
        {
            InitializeComponent();
            Context = new DatabaseSroce();
        }

        private void Confirm_F_Load(object sender, EventArgs e)
        {
            rdbMonThi.Checked = false;
            btnThi.Enabled = false;

            var student = Context.User
                .FirstOrDefault(u => u.UserName == username && u.C_Password == password);

            if (student != null)
            {
                lbStudentName.Text = student.HoTen;
                StudentName = student.HoTen.ToString();
                var MSSV = student.UserID;
                var SinhVienInfo = Context.SinhVien
                    .FirstOrDefault(sv => sv.UserID == MSSV);

                if (SinhVienInfo != null)
                {
                    lbMSSV.Text = SinhVienInfo.MaSV;
                    StudentCode = SinhVienInfo.MaSV;
                    var thoiGianBatDau = DateTime.Now;
                    TGBD = thoiGianBatDau;
                    // Tìm lịch thi dựa trên khoảng thời gian bắt đầu và kết thúc
                    var examInfo = Context.LichThi
                        .Where(ct => ct.MaSV == SinhVienInfo.MaSV
                            //&& ct.ThoiGianBatDau > thoiGianBatDau
                           && DbFunctions.DiffMinutes(ct.ThoiGianBatDau, thoiGianBatDau) >= 0
                            && DbFunctions.DiffMinutes(ct.ThoiGianBatDau, thoiGianBatDau) <= ct.ThoiGianThi
                            )
                        .OrderBy(ct => ct.ThoiGianBatDau)
                        .FirstOrDefault();
                 
                    if (examInfo != null)
                    {
                        rdbMonThi.Text = $"{examInfo.Mon.TenMon}";
                        SubjectCode = examInfo.MaMon;
                        //MessageBox.Show(examInfo.MaMon);
                        RoomID = examInfo.MaPhong;
                        //label4.Text = examInfo.MaMon;
                        Flag = true;
                    }
                    else
                    {
                        rdbMonThi.Text = "Không có môn thi nào đang diễn ra";
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên trong bảng SinhVien.");
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
            }

            if (Flag)
                btnThi.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Run(new DoExams(SubjectCode));
            DoExams kk = new DoExams(SubjectCode,StudentName,StudentCode,TGBD,RoomID);
            kk.Show();
        }
    }
}
