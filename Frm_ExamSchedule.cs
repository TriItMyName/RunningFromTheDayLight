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
    public partial class Frm_ExamSchedule : Form
    {
        private Model_ThiTracNghiem context;

        public Frm_ExamSchedule()
        {
            InitializeComponent();
            context = new Model_ThiTracNghiem();
        }

        private void Frm_AddContest_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvListExam);
                List<SinhVien> sinhViens = context.SinhViens.ToList();
                List<Mon> monHocs = context.Mons.ToList();
                List<PhongThi> phongThis = context.PhongThis.ToList();
                List<LichThi> lichThis = context.LichThis.ToList();
                List<User> users = context.Users.ToList();
                FillFindStudent(sinhViens, users);
                FillFindSubject(monHocs);
                FillFindRoom(phongThis);

                BindGrid(lichThis);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFindStudent(List<SinhVien> listSinhVien, List<User> listUser)
        {
            try
            {
                listSinhVien = context.SinhViens.ToList();
                listUser = context.Users.ToList();

                var studentDisplayList = from sv in listSinhVien
                                         join u in listUser on sv.UserID equals u.UserID
                                         select new
                                         {
                                             MaSV = sv.MaSV,
                                             DisplayName = $"{sv.MaSV} - {u.HoTen}"
                                         };

                cmbStudentID.DataSource = studentDisplayList.ToList();
                cmbStudentID.DisplayMember = "DisplayName";
                cmbStudentID.ValueMember = "MaSV";
                cmbStudentID.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFindSubject(List<Mon> listMon)
        {
            try
            {
                listMon = context.Mons.ToList();
                cmbSubjectID.DataSource = listMon;
                cmbSubjectID.DisplayMember = "TenMon";
                cmbSubjectID.ValueMember = "MaMon";
                cmbSubjectID.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFindRoom(List<PhongThi> listPhongThi)
        {
            try
            {
                listPhongThi = context.PhongThis.ToList();
                cmbRoomID.DataSource = listPhongThi;
                cmbRoomID.DisplayMember = "TenPhong";
                cmbRoomID.ValueMember = "MaPhong";
                cmbRoomID.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetSelectionRow(string ID)
        {
            for (int i = 0; i < dgvListExam.Rows.Count; i++)
            {
                var cellValue = dgvListExam.Rows[i].Cells[1].Value;
                if (cellValue != null && cellValue.ToString() == ID)
                {
                    return i;
                }
            }
            return -1;
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

        private void dgvListExaam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListExam.Rows[e.RowIndex];

                txtExaScheduleID.Text = row.Cells[0].Value?.ToString();
                cmbStudentID.SelectedValue = row.Cells[1].Value?.ToString();
                cmbSubjectID.SelectedValue = row.Cells[2].Value?.ToString();
                if (DateTime.TryParse(row.Cells[3].Value?.ToString().Trim(), out DateTime dateValue))
                {
                    dtpDate.Value = dateValue;
                }
                else
                {
                    dtpDate.Value = DateTime.Now;
                }
                txtTimeExam.Text = row.Cells[4].Value?.ToString();
                cmbRoomID.SelectedValue = row.Cells[5].Value?.ToString();
            }
        }

        private void BindGrid(List<LichThi> cuocThis)
        {
            try
            {
                dgvListExam.Rows.Clear();
                foreach (var lichthi in context.LichThis)
                {
                    int index = dgvListExam.Rows.Add();
                    dgvListExam.Rows[index].Cells[0].Value = lichthi.MaLichThi;
                    dgvListExam.Rows[index].Cells[1].Value = lichthi.MaSV;
                    dgvListExam.Rows[index].Cells[2].Value = lichthi.MaMon;
                    dgvListExam.Rows[index].Cells[3].Value = lichthi.ThoiGianBatDau;
                    dgvListExam.Rows[index].Cells[4].Value = lichthi.ThoiGianThi;
                    dgvListExam.Rows[index].Cells[5].Value = lichthi.MaPhong;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearData()
        {
            txtExaScheduleID.Text = "";
            cmbStudentID.SelectedIndex = -1;
            cmbSubjectID.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            txtTimeExam.Text = "";
            cmbRoomID.SelectedIndex = -1;
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            try
            {
                string studentID = cmbStudentID.SelectedValue.ToString();
                string subjectID = cmbSubjectID.SelectedValue.ToString();
                string roomID = cmbRoomID.SelectedValue.ToString();
                DateTime startTime = dtpDate.Value;
                int duration = Convert.ToInt32(txtTimeExam.Text);
                string RoomID = cmbRoomID.SelectedValue.ToString();

                if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(subjectID) || string.IsNullOrEmpty(roomID) || string.IsNullOrEmpty(txtTimeExam.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                LichThi lichThi = new LichThi
                {
                    MaSV = studentID,
                    MaMon = subjectID,
                    ThoiGianBatDau = startTime,
                    ThoiGianThi = duration,
                    MaPhong = roomID
                };

                MessageBox.Show("Thêm kỳ thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                context.LichThis.Add(lichThi);
                context.SaveChanges();
                BindGrid(context.LichThis.ToList());
                ClearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateExam_Click(object sender, EventArgs e)
        {
            try
            {
                var id = txtExaScheduleID.Text;
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Vui lòng chọn một kỳ thi để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var name = cmbStudentID.SelectedValue?.ToString();
                var subject = cmbSubjectID.SelectedValue?.ToString();
                var date = dtpDate.Value;
                var time = txtTimeExam.Text;
                var room = cmbRoomID.SelectedValue?.ToString();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(time) || string.IsNullOrEmpty(room))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idInt = int.Parse(id);
                var lichThi = context.LichThis.FirstOrDefault(lt => lt.MaLichThi == idInt);
                if (lichThi != null)
                {
                    lichThi.MaSV = name;
                    lichThi.MaMon = subject;
                    lichThi.ThoiGianBatDau = date;
                    lichThi.ThoiGianThi = int.Parse(time);
                    lichThi.MaPhong = room;

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật kỳ thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.LichThis.ToList());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kỳ thi với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            try
            {
                var id = txtExaScheduleID.Text;
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Vui lòng chọn một kỳ thi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idInt = int.Parse(id);
                var lichThi = context.LichThis.FirstOrDefault(lt => lt.MaLichThi == idInt);
                if (lichThi != null)
                {
                    context.LichThis.Remove(lichThi);
                    context.SaveChanges();
                    MessageBox.Show("Xóa kỳ thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.LichThis.ToList());
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kỳ thi với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
