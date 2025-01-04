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
    public partial class AddMajor : Form
    {
        private Model_ThiTracNghiem context;

        public AddMajor()
        {
            InitializeComponent();
            context = new Model_ThiTracNghiem();
        }

        private void AddMajor_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvListMajor);
                List<Khoa> khoas = context.Khoas.ToList();
                BindGrid(khoas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void BindGrid(List<Khoa> listMajor) 
        {
            dgvListMajor.Rows.Clear();
            foreach (var major in listMajor)
            {
                int index = dgvListMajor.Rows.Add();
                dgvListMajor.Rows[index].Cells[0].Value = major.MaKhoa;
                dgvListMajor.Rows[index].Cells[1].Value = major.TenKhoa;
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

        private void dgvListMajor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListMajor.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
            }
        }

        private void ClearDate()
        {
            txtID.Text = "";
            txtName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var maKhoa = txtID.Text.Trim();
                var tenKhoa = txtName.Text.Trim();

                if (string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(tenKhoa))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khoa.");
                    return;
                }

                var existingMajor = context.Khoas.FirstOrDefault(m => m.MaKhoa == maKhoa);
                if (existingMajor != null)
                {
                    MessageBox.Show("Mã khoa đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }

                var khoa = new Khoa
                {
                    MaKhoa = maKhoa,
                    TenKhoa = tenKhoa
                };

                context.Khoas.Add(khoa);
                context.SaveChanges();
                ClearDate();
                MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khoa: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var maKhoa = txtID.Text.Trim();
                if (string.IsNullOrWhiteSpace(maKhoa))
                {
                    MessageBox.Show("Vui lòng chọn khoa cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var existingMajor = context.Khoas.FirstOrDefault(m => m.MaKhoa == maKhoa);
                if (existingMajor == null)
                {
                    MessageBox.Show("Mã khoa không tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                context.Khoas.Remove(existingMajor);
                context.SaveChanges();
                ClearDate();
                MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khoa: " + ex.Message);
            }
        }
    }
}
