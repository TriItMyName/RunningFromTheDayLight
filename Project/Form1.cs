using DocumentFormat.OpenXml.Packaging;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RunningFromTheDayLight
{
    public partial class Form1 : Form
    {
        private readonly TRACNGHIEMDB context;  // Đã có biến context

        public Form1()
        {
            InitializeComponent();
            context = new TRACNGHIEMDB();
        }

        // Hàm xử lý khi nhấn nút tải file
        private void btnUpFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                if (Path.GetExtension(filePath) == ".docx")
                {
                    try
                    {
                        // Gọi hàm đọc file và chèn dữ liệu vào database
                        ParseDocxAndInsert(filePath);
                        MessageBox.Show("Dữ liệu đã được chèn vào cơ sở dữ liệu thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một file DOCX.");
                }
            }
        }

        // Hàm đọc file DOCX và chèn dữ liệu vào cơ sở dữ liệu
        private void ParseDocxAndInsert(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;

                string currentNganHang = string.Empty;
                string currentChuong = string.Empty;
                string questionContent = string.Empty;
                string answerA = string.Empty, answerB = string.Empty, answerC = string.Empty, answerD = string.Empty;
                string correctAnswer = string.Empty;
                string level = string.Empty;

                foreach (var para in body.Elements<Paragraph>())
                {
                    string text = para.InnerText;

                    // Kiểm tra nếu là tên ngân hàng câu hỏi
                    if (text.StartsWith("Ngân hàng câu hỏi"))
                    {
                        currentNganHang = text;
                        InsertNganHang(currentNganHang);
                    }

                    // Kiểm tra nếu là tên chương
                    if (text.StartsWith("Chương"))
                    {
                        currentChuong = text;
                        InsertChuong(currentChuong);
                    }

                    // Xử lý các câu hỏi và đáp án
                    if (text.StartsWith("1.") || text.StartsWith("2.") || text.StartsWith("3."))
                    {
                        questionContent = text;
                    }

                    if (text.StartsWith("a."))
                        answerA = text.Substring(2).Trim();
                    if (text.StartsWith("b."))
                        answerB = text.Substring(2).Trim();
                    if (text.StartsWith("c."))
                        answerC = text.Substring(2).Trim();
                    if (text.StartsWith("d."))
                        answerD = text.Substring(2).Trim();

                    // Xác định đáp án đúng và mức độ (TH, VC, VDC, NB)
                    if (text.Contains("(TH)") || text.Contains("(VC)") || text.Contains("(VDC)") || text.Contains("(NB)"))
                    {
                        correctAnswer = text;
                        level = ExtractLevel(text);
                        InsertTracNghiem(questionContent, answerA, answerB, answerC, answerD, correctAnswer, level);
                    }
                }
            }
        }

        // Các hàm chèn dữ liệu vào database bằng Entity Framework
        private void InsertNganHang(string tenNganHang)
        {
            var nganHang = new NganHangCauHoi
            {
                TenNganHang = tenNganHang
            };
            context.NganHangCauHois.Add(nganHang);
            context.SaveChanges();
        }

        private void InsertChuong(string tenChuong)
        {
            var chuong = new Chuong
            {
                TenChuong = tenChuong
            };
            context.Chuongs.Add(chuong);
            context.SaveChanges();
        }

        private void InsertTracNghiem(string noiDung, string dapAnA, string dapAnB, string dapAnC, string dapAnD, string dapAnDung, string mucDo)
        {
            var cauHoi = new TracNghiem
            {
                NoiDung = noiDung,
                DapAnA = dapAnA,
                DapAnB = dapAnB,
                DapAnC = dapAnC,
                DapAnD = dapAnD,
                DapAnDung = dapAnDung,
                MucDo = mucDo
            };
            context.TracNghiems.Add(cauHoi);
            context.SaveChanges();
        }

        private string ExtractLevel(string text)
        {
            if (text.Contains("(TH)")) return "ThongHieu";
            if (text.Contains("(VC)")) return "VanDung";
            if (text.Contains("(VDC)")) return "VanDungCao";
            if (text.Contains("(NB)")) return "NhanBiet";
            return "Unknown";
        }
    }
}
