using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace RunningFromTheDayLight
{
    public partial class UpLoardUser : Form
    {
        public UpLoardUser()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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

                    string filePath = openFileDialog.FileName;
                    DataTable dt = ReadExcelFile(filePath);

                    if (dt != null)
                    {

                        dgvUser.DataSource = null;
                        dgvUser.Columns.Clear();

                        foreach (DataColumn column in dt.Columns)
                        {
                            dgvUser.Columns.Add(column.ColumnName, column.ColumnName);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            dgvUser.Rows.Add(row.ItemArray);
                        }
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

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
