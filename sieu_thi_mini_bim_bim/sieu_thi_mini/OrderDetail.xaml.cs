using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using Paragraph = iTextSharp.text.Paragraph;

namespace sieu_thi_mini
{
    /// <summary>
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public class MatHang
    {
        public string maHD { get; set; }
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public int soL { get; set; }
        public float donG { get; set; }
        public float thanhT { get; set; }

    }
    public partial class OrderDetail : Window
    {
        ObservableCollection<MatHang> orders = new ObservableCollection<MatHang>();
        public OrderDetail(string OrderCode, string EmployeeCode, DateTime OrderDate, TimeSpan OrderTime,float TotalMoney, string OrderStatus)
        {
            InitializeComponent();
            txtMaDonHang.Text = OrderCode;
            txtNgayBan.Text = OrderDate.ToString("dd/MM/yyyy");
            txtMaNhanVien.Text = EmployeeCode;
            txtGioBan.Text = OrderTime.ToString();
            txtTongTien.Text = (TotalMoney).ToString("N0") + 'đ';
        }
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;
        private void NapDuLieuTuMayChu()
        {
            dgProducts.ItemsSource = null;
            orders.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblChiTietHoaDon WHERE MaHoaDon like '%" + txtMaDonHang.Text + "%'", Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MatHang order = new MatHang();
                order.maHD = reader.GetString(0);
                order.maSP = reader.GetString(1);
                order.tenSP = reader.GetString(2);
                order.soL = reader.GetInt32(3);
                order.donG = (float)reader.GetDouble(4);
                order.thanhT = (float)reader.GetDouble(5);
                orders.Add(order);

            }
            reader.Close();
            //Thiết lập cho hiển thị trên DataGrid
            dgProducts.ItemsSource = orders;
        }
        private void CreatePDFInvoice(DataGrid dataGrid)
        {
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            try
            {
                string pdfPath = @"E:\C#\sieu_thi_mini\sieu_thi_mini\FilePDF\" + txtMaDonHang.Text.ToString() + ".pdf";
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));

                // Đường dẫn đến font Unicode
                string fontPath = @"E:\C#\sieu_thi_mini\packages\MaterialDesignThemes.4.9.0\build\Resources\Roboto\Roboto-Regular.ttf";

                BaseFont unicodeBaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font unicodeFont = new Font(unicodeBaseFont, 12);

                doc.Open();

                var maHoaDonText = "Mã hóa đơn: " + txtMaDonHang.Text.ToString();
                var paragraph = new Paragraph(maHoaDonText, new Font(unicodeBaseFont, 12));
                paragraph.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph);

                

                var manvText = "Mã nhân viên: " + txtMaNhanVien.Text.ToString();
                var paragraph1 = new Paragraph(manvText, new Font(unicodeBaseFont, 12));
                paragraph1.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph1);

                var ngayText = "Ngày bán: " + txtNgayBan.Text.ToString();
                var paragraph2 = new Paragraph(ngayText, new Font(unicodeBaseFont, 12));
                paragraph2.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph2);

                var gioText = "Giờ bán: " + txtGioBan.Text.ToString();
                var paragraph3 = new Paragraph(gioText, new Font(unicodeBaseFont, 12));
                paragraph3.Alignment = Element.ALIGN_CENTER;
                doc.Add(paragraph3);


                doc.Add(Chunk.NEWLINE);

                // Tạo một bảng trong tài liệu PDF
                PdfPTable pdfTable = new PdfPTable(dataGrid.Columns.Count);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                // Tạo các cột cho bảng PDF từ tiêu đề cột của DataGrid
                foreach (DataGridColumn column in dataGrid.Columns)
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(column.Header.ToString(), unicodeFont))); // Sử dụng font Unicode
                }

                // Đọc dữ liệu từ DataGrid và thêm vào bảng PDF
                for (int i = 0; i < orders.Count; i++)
                {

                    pdfTable.AddCell(new PdfPCell(new Phrase(orders[i].maSP, unicodeFont))); // Add maSP
                    pdfTable.AddCell(new PdfPCell(new Phrase(orders[i].tenSP, unicodeFont))); // Add tenSP
                    pdfTable.AddCell(new PdfPCell(new Phrase(orders[i].soL.ToString(), unicodeFont))); // Convert soL to string
                    pdfTable.AddCell(new PdfPCell(new Phrase(orders[i].donG.ToString("N0") + "đ", unicodeFont))); // Convert donG to string with format
                    pdfTable.AddCell(new PdfPCell(new Phrase(orders[i].thanhT.ToString("N0") + "đ", unicodeFont))); // Convert thanhT to string with format
                }

                // Thêm bảng PDF vào tài liệu
                doc.Add(pdfTable);
                doc.Add(Chunk.NEWLINE);

                var totalAmountText = "Tổng tiền hóa đơn " + txtTongTien.Text.ToString();
                var paragraph4 = new Paragraph(totalAmountText, new Font(unicodeBaseFont, 12));
                paragraph4.Alignment = Element.ALIGN_RIGHT;
                doc.Add(paragraph4);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                doc.Close();
            }
        }







        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối dữ liệu " + ex.ToString());
            }
        }

        private void In_Click(object sender, RoutedEventArgs e)
        {
            CreatePDFInvoice(dgProducts);
            MessageBox.Show("Hóa đơn PDF đã được tạo.");
        }

        private void Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
