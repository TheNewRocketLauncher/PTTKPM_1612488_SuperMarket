using System;
using System.Collections.Generic;
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
using Fluent;
using DAL_SuperMarket;
using BUS_SuperMarket;

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for AddCHIETKHAU.xaml
    /// </summary>
    public partial class AddCHIETKHAU : RibbonWindow
    {
        public AddCHIETKHAU()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AddCHIETKHAULoaded);
        }

        private void AddCHIETKHAULoaded(object sender, RoutedEventArgs e)
        {
            List<string> searchDATA = new List<string>();

            var sp = new SanPham();
            List<SANPHAM> sANPHAMs = sp.GetAllSANPHAM();
            foreach (var item in sANPHAMs)
            {
                searchDATA.Add(item.MASP);
            }

            txtMASP.ItemsSource = searchDATA;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newCK = new CHIETKHAU();
                newCK.MASP = txtMASP.Text;
                newCK.CK = float.Parse(txtCHIETKHAU.Text, System.Globalization.CultureInfo.InvariantCulture);
                newCK.THOIGIANBD = THOIGIANBD.SelectedDate;
                newCK.THOIGIANKT = THOIGIANKT.SelectedDate;
                newCK.TENLOAI = txtTENLOAI.Text;

                var ck = new ChietKhau();
                var result = ck.ThemChietKhau(newCK);

                if (result._is_Success)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show(result._error + "   " + result._result);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xẩy ra, vui lòng xem lại dữ liệu vừa nhập","", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn hủy không ? Nhưng thông tin bạn nhập vẫn chưa được lưu", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }
    }
}
