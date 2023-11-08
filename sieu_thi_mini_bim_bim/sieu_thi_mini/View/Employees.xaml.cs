using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using sieu_thi_mini.ViewModel;

namespace sieu_thi_mini.View
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : UserControl
    {
        string ConnectionString = App.ConnectionString;
        public Employees()
        {
            InitializeComponent();
            
        }

        ObservableCollection<NhanVien> NhanViens = new ObservableCollection<NhanVien>();
        public class NhanVien
        {
            public string manv { get; set; }
            public string tennv { get; set; }
            public string gt { get; set; }
            public DateTime ngaysinh { get; set; }
            public string sdt { get; set; }
            public string diachi { get; set; }
            public string email { get; set; }
            public string tk { get; set; }
            public string mk { get; set; }
            public bool IsSelected { get; set; }
        }

        SqlConnection Conn = new SqlConnection();
       

        private void NapDuLieuTuMayChu()
        {
            dgNhanVien.ItemsSource = null;
            NhanViens.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblNhanVien WHERE DaXoa = 0", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NhanVien nv = new NhanVien();

                nv.manv = reader.GetString(0);
                nv.tennv = reader.GetString(1);
                nv.gt = reader.GetString(2);
                nv.ngaysinh = reader.GetDateTime(3);
                nv.sdt = reader.GetString(4);
                nv.diachi = reader.GetString(5);
                nv.email = reader.GetString(6);
                nv.tk = reader.GetString(7);
                nv.mk = reader.GetString(8);
                NhanViens.Add(nv);
            }
            reader.Close();
            dgNhanVien.ItemsSource = NhanViens;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmployees addEmployees = new AddEmployees();
            addEmployees.Closed += AddNhanVien_Closed;
            addEmployees.Show();
        }
        private void AddNhanVien_Closed(object sender, EventArgs e)
        {
            NapDuLieuTuMayChu();
        }
        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                NapDuLieuTuMayChu();
            }
            else
            {
                dgNhanVien.ItemsSource = null;
                NhanViens.Clear();
                if (Conn.State != ConnectionState.Open) return;

                // Sử dụng tham số trong truy vấn SQL để tránh tấn công SQL Injection
                string query = "SELECT * FROM tblNhanVien WHERE (LOWER(HoTen) LIKE @search OR MaNhanVien LIKE @search) " +
                    "OR (Sdt LIKE @search OR GioiTinh LIKE @search OR DiaChi LIKE @search OR Email LIKE @search ) AND DaXoa = 0";
                SqlCommand command = new SqlCommand(query, Conn);
                command.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nv = new NhanVien();

                    nv.manv = reader.GetString(0);
                    nv.tennv = reader.GetString(1);
                    nv.gt = reader.GetString(2);
                    nv.sdt = reader.GetString(4);
                    nv.diachi = reader.GetString(5);
                    nv.email = reader.GetString(6);
                    nv.tk = reader.GetString(7);
                    nv.mk = reader.GetString(8);

                    NhanViens.Add(nv);
                }
                reader.Close();
                dgNhanVien.ItemsSource = NhanViens;
            }
        }
        private void tbnSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }
        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuTuMayChu();
            txtSearch.Text = "Tìm theo tên, mã nhân viên...";
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGrid không
            if (dgNhanVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
                return;
            }

            // Lấy dòng được chọn từ DataGrid
            NhanVien selectedNhanVien = (NhanVien)dgNhanVien.SelectedItem;

            // Hiển thị hộp thoại xác nhận xóa
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Thực hiện xóa dữ liệu trong cơ sở dữ liệu
                if (Conn.State == ConnectionState.Open)
                {
                    
                    string deleteQuery = "UPDATE tblNhanVien SET DaXoa =1 WHERE MaNhanVien = @MaNhanVien";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, Conn);
                    deleteCommand.Parameters.AddWithValue("@MaNhanVien", selectedNhanVien.manv);

                    try
                    {
                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Nhân viên đã được xóa thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa nhân viên. Vui lòng thử lại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
                    }

                    // Sau khi xóa dữ liệu trong cơ sở dữ liệu, cập nhật lại DataGrid
                    NapDuLieuTuMayChu();
                }
                else
                {
                    MessageBox.Show("Không thể thực hiện xóa vì không có kết nối đến cơ sở dữ liệu.");
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgNhanVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một hàng để chỉnh sửa.");
                return;
            }

            // Lấy dòng được chọn từ DataGrid
            NhanVien selectedNhanVien = (NhanVien)dgNhanVien.SelectedItem;
            EditEmployees editEmployees = new EditEmployees(selectedNhanVien.manv, selectedNhanVien.tennv, selectedNhanVien.gt, selectedNhanVien.ngaysinh, selectedNhanVien.sdt, selectedNhanVien.diachi, selectedNhanVien.email, selectedNhanVien.tk, selectedNhanVien.mk);
            editEmployees.Closed += AddNhanVien_Closed;
            editEmployees.Show();
        }

        public bool IsAllSelected { get; set; }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < NhanViens.Count; i++)
            {
                NhanViens[i].IsSelected = true;
            }
            dgNhanVien.ItemsSource = null;
            dgNhanVien.ItemsSource = NhanViens;
        }

        List<string> listCode = new List<string>();
        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < NhanViens.Count; i++)
            {
                NhanViens[i].IsSelected = false;
            }
            dgNhanVien.ItemsSource = null;
            dgNhanVien.ItemsSource = NhanViens;

            for (int i = 0; i < NhanViens.Count; i++)
            {
                if (!NhanViens[i].IsSelected)
                {
                    string valueToRemove = NhanViens[i].manv;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[i] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NhanViens.Count; i++)
            {
                if (NhanViens[i].IsSelected)
                {
                    listCode.Add(NhanViens[i].manv);
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NhanViens.Count; i++)
            {
                if (!NhanViens[i].IsSelected)
                {
                    string valueToRemove = NhanViens[i].manv;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[j] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }
        }

    }
}