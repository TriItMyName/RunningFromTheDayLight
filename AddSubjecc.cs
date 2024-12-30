using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class AddSubjecc : Form
    {
        private readonly Model_ThiTracNghiem context;

        public AddSubjecc()
        {
            context = new Model_ThiTracNghiem();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var maMon = txtMaMon.Text.Trim();
                var tenMon = txtTenMon.Text.Trim();

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

                MessageBox.Show("Thêm môn học thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm môn học: " + ex.Message);
            }
        }

        private void AddSubjecc_Load(object sender, EventArgs e)
        {
            try
            {
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
            dgvListMon.Rows.Clear();
            foreach (var mon in listMon)
            {
                int index = dgvListMon.Rows.Add();
                dgvListMon.Rows[index].Cells[0].Value = mon.MaMon;
                dgvListMon.Rows[index].Cells[1].Value = mon.TenMon;
            }
        }
    }
}
