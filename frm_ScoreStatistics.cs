using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Math;
using RunningFromTheDayLight.Models;

namespace RunningFromTheDayLight
{
    public partial class frm_ScoreStatistics : Form
    {
        private Model_ThiTracNghiem context;

        public frm_ScoreStatistics()
        {
            InitializeComponent();
            context = new Model_ThiTracNghiem();
        }

        private void frm_ScoreStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                List<Mon> mons = context.Mons.ToList();
                List<KetQuaThi> ketQuaThis = context.KetQuaThis.ToList();
                List<SinhVien> sinhViens = context.SinhViens.ToList();
                FillFindNameSubject(mons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFindNameSubject(List<Mon> listMon)
        { 
            listMon = listMon.Where(m => !string.IsNullOrWhiteSpace(m.TenMon)).ToList();
            this.cmbSubject.DataSource = listMon;
            this.cmbSubject.DisplayMember = "TenMon";
            this.cmbSubject.ValueMember = "MaMon";
            this.cmbSubject.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSubject.SelectedValue == null)
                {
                    MessageBox.Show("Please select a subject.");
                    return;
                }

                string maMon = cmbSubject.SelectedValue.ToString();
                DateTime selectedDate = dtpDate.Value;
                DateTime startDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);

                var results = context.KetQuaThis
                    .Where(kq => kq.CuocThi.MaMon == maMon && kq.NgayThi >= startDate && kq.NgayThi <= endDate)
                    .Select(kq => new
                    {
                        kq.SinhVien.MaSV,
                        kq.SinhVien.User.UserName,
                        kq.Diem,
                        kq.ThoiGianLamBai,
                        kq.NgayThi
                    })
                    .ToList<dynamic>();

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào cho tháng đã chọn.");
                    return;
                }

                DisplayCharts(results);
                DisplayTopStudents(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tìm kiếm kết quả thi: {ex.Message}");
            }
        }

        private void DisplayCharts(List<dynamic> results)
        {
            try
            {
                int passCount = results.Count(r => (double?)r.Diem >= 4);
                int failCount = results.Count(r => (double?)r.Diem < 4);

                chartPie.Series.Clear();
                chartPie.Series.Add("Đậu");
                chartPie.Series.Add("Rớt");

                var passPoint = chartPie.Series["Đậu"].Points.AddXY("Đậu", passCount);
                chartPie.Series["Đậu"].Points[passPoint].IsVisibleInLegend = false;

                var failPoint = chartPie.Series["Rớt"].Points.AddXY("Rớt", failCount);
                chartPie.Series["Rớt"].Points[failPoint].IsVisibleInLegend = false;

                chartBar.Series.Clear();
                chartBar.Series.Add("Điểm");
                foreach (var result in results)
                {
                    string userName = (string)result.UserName;
                    double? diem = (double?)result.Diem;
                    chartBar.Series["Điểm"].Points.AddXY(userName, diem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi hiển thị biểu đồ: {ex.Message}");
            }
        }
        private void DisplayTopStudents(List<dynamic> results)
        {
            try
            {
                var topScoreStudent = results.OrderByDescending(r => r.Diem).FirstOrDefault();
                var fastestStudent = results.OrderBy(r => r.ThoiGianLamBai).FirstOrDefault();

                if (topScoreStudent != null)
                {
                    lbl_ID1.Text = $"{topScoreStudent.UserName}";
                }

                if (fastestStudent != null)
                {
                    lbl_ID2.Text = $"{fastestStudent.UserName}";
                }
            }
            catch (Exception ex)        
            {
                MessageBox.Show($"Đã xảy ra lỗi khi hiển thị sinh viên: {ex.Message}");
            }
        }
    }
}
