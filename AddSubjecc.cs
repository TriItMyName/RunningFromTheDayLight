using System;
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
    }
}
