using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class Frm_AddContest : Form
    {
        private Model_ThiTracNghiem context;

        public Frm_AddContest()
        {
            InitializeComponent();
            context = new Model_ThiTracNghiem();
        }

        private void Frm_AddContest_Load(object sender, EventArgs e)
        {
            try
            { 
                List<Mon> monHocs = context.Mons.ToList();
                List<CuocThi> cuocThis = context.CuocThis.ToList();
                FillFindSubject(monHocs);
                BindGrid(cuocThis);
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
                listMon = context.Mons.Where(m => m.TenMon.Contains(cmbSubjectID.Text)).ToList();
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

        private void BindGrid(List<CuocThi> listCuocthis) 
        {
            dgv_ListContest.Rows.Clear();
            foreach (var cuocthis in context.CuocThis)
            {
                int index = dgv_ListContest.Rows.Add();
                dgv_ListContest.Rows[index].Cells[0].Value = cuocthis.MaCuocThi;
                dgv_ListContest.Rows[index].Cells[1].Value = cuocthis.Mon.TenMon;
                dgv_ListContest.Rows[index].Cells[2].Value = cuocthis.NgayThi;
                dgv_ListContest.Rows[index].Cells[3].Value = cuocthis.ThoiGianBatDau;
                dgv_ListContest.Rows[index].Cells[4].Value = cuocthis.TrangThai;
            }
        }

        public int GetSelectionRow(string ID)
        {
            for (int i = 0; i < dgv_ListContest.Rows.Count; i++)
            {
                var cellValue = dgv_ListContest.Rows[i].Cells[1].Value;
                if (cellValue != null && cellValue.ToString() == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void dgv_ListContest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv_ListContest.Rows[e.RowIndex];
                    txtContestID.Text = row.Cells[0].Value.ToString();
                    cmbSubjectID.Text = row.Cells[1].Value.ToString();
                    dtpDate.Value = Convert.ToDateTime(row.Cells[2].Value);
                    dtpTime.Value = Convert.ToDateTime(row.Cells[3].Value);
                    cmbState.Text = row.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearData()
        {
            txtContestID.Text = "";
            cmbSubjectID.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            cmbState.SelectedIndex = -1;
        }

        private void btnAddContest_Click(object sender, EventArgs e)
        {
            try
            { 
                string maMon = cmbSubjectID.SelectedValue.ToString();
                DateTime ngayThi = dtpDate.Value;
                DateTime thoiGianBatDau = dtpTime.Value;
                string trangThai = cmbState.Text;

                if (string.IsNullOrEmpty(maMon) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CuocThi cuocThi = new CuocThi
                {
                    MaMon = maMon,
                    NgayThi = ngayThi,
                    ThoiGianBatDau = thoiGianBatDau,
                    TrangThai = trangThai
                };

                MessageBox.Show("Thêm cuộc thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                context.CuocThis.Add(cuocThi);
                context.SaveChanges();
                BindGrid(context.CuocThis.ToList());
                ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateContest_Click(object sender, EventArgs e)
        {
            try
            { 
                var id = txtContestID.Text;
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Vui lòng chọn cuộc thi cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var maMon = cmbSubjectID.SelectedValue.ToString();
                var ngayThi = dtpDate.Value;
                var thoiGianBatDau = dtpTime.Value;
                var trangThai = cmbState.Text;

                if (string.IsNullOrEmpty(maMon) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int idInt = int.Parse(id);
                var cuocThi = context.CuocThis.FirstOrDefault(c => c.MaCuocThi == idInt);
                if (cuocThi != null)
                { 
                    cuocThi.MaMon = maMon;
                    cuocThi.NgayThi = ngayThi;
                    cuocThi.ThoiGianBatDau = thoiGianBatDau;
                    cuocThi.TrangThai = trangThai;

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật cuộc thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.CuocThis.ToList());
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cuộc thi cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteContest_Click(object sender, EventArgs e)
        {
            try
            { 
                var id = txtContestID.Text;
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Vui lòng chọn cuộc thi cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var idInt = int.Parse(id);
                var cuocThi = context.CuocThis.FirstOrDefault(c => c.MaCuocThi == idInt);

                if (cuocThi != null)
                {
                    context.CuocThis.Remove(cuocThi);
                    context.SaveChanges();
                    MessageBox.Show("Xóa cuộc thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(context.CuocThis.ToList());
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cuộc thi cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
