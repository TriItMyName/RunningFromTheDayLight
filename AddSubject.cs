using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class AddSubject : Form
    {
        private Model_ThiTracNghiem context;

        public AddSubject()
        {
            context = new Model_ThiTracNghiem();
            InitializeComponent();
        }

        private void AddSubjecc_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvListSubject);
                List<Mon> mons = context.Mons.ToList();
                BindGird(mons);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu môn học: " + ex.Message);
            }
        }

        private void BindGird(List<Mon> listMon)
        {
            dgvListSubject.Rows.Clear();
            foreach (var mon in listMon)
            {
                int index = dgvListSubject.Rows.Add();
                dgvListSubject.Rows[index].Cells[0].Value = mon.MaMon;
                dgvListSubject.Rows[index].Cells[1].Value = mon.TenMon;
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

        private void ClearDate()
        {
            txtID.Text = "";
            txtName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var maMon = txtID.Text.Trim();
                var tenMon = txtName.Text.Trim();

                if (string.IsNullOrWhiteSpace(maMon) || string.IsNullOrWhiteSpace(tenMon))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học.");
                    return;
                }

                var existingMon = context.Mons.FirstOrDefault(m => m.MaMon == maMon);
                if (existingMon != null)
                {
                    MessageBox.Show("Mã môn học đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }

                var monHoc = new Mon
                {
                    MaMon = maMon,
                    TenMon = tenMon
                };

                context.Mons.Add(monHoc);
                context.SaveChanges();
                ClearDate();
                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm môn học: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var maMon = txtID.Text.Trim();
                if (string.IsNullOrWhiteSpace(maMon))
                {
                    MessageBox.Show("Vui lòng chọn môn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var existingMon = context.Mons.FirstOrDefault(m => m.MaMon == maMon);
                if (existingMon == null)
                {
                    MessageBox.Show("Mã môn khong tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                context.Mons.Remove(existingMon);
                context.SaveChanges();
                ClearDate();
                MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa môn học: " + ex.Message);
            }
        }
    }
}
