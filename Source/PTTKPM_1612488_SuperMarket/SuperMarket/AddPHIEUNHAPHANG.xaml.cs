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
    /// Interaction logic for AddPHIEUNHAPHANG.xaml
    /// </summary>
    public partial class AddPHIEUNHAPHANG : RibbonWindow
    {
        public AddPHIEUNHAPHANG()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindowsQuanLyLoaded);
        }

        private void MainWindowsQuanLyLoaded(object sender, RoutedEventArgs e)
        {
            List<string>  searchDATA = new List<string>();

            var sp = new SanPham();
            List<SANPHAM> sANPHAMs = sp.GetAllSANPHAM();
            foreach (var item in sANPHAMs)
            {
                searchDATA.Add(item.MASP);
            }

            txtTimKiem.ItemsSource = searchDATA;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newpnh = new PHIEUNHAPHANG();
                newpnh.MASP = txtTimKiem.SelectedItem.ToString();
                newpnh.SL = Convert.ToInt32(txtSoLuong.Text);

                var pnh = new PhieuNhapHang();
                var result = pnh.ThemPhieuNhapHang(newpnh);

                if (result._is_Success)
                {
                    try
                    {
                        var sp = new SanPham();
                        var sptemp = sp.GetSANPHAMTheoMASP(newpnh.MASP);
                        sptemp.SLTONKHO += newpnh.SL;

                        sp.SuaSanPham(sptemp);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi khi cập nhật số lượng sản phẩm");
                    }
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show(result._error + "   " + result._result);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xẩy ra, vui lòng xem lại dữ liệu vừa nhập", "", MessageBoxButton.OK, MessageBoxImage.Warning);
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
