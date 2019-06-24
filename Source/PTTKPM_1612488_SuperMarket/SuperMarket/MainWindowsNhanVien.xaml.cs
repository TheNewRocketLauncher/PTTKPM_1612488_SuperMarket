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
using BUS_SuperMarket;
using DAL_SuperMarket;
using PublicClass;

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindowsNhanVien : RibbonWindow
    {
        List<String> QLSPcbxSource = new List<string>();
        int index = 0;
        /*index             type
        0                   Sản phẩm
        1                   Loại sản phẩm
        2                   Hóa đơn
        3                   Chiết khấu
        4                   Phiếu nhập hàng
        5                   Phiếu xuất hàng
        6                   KHTT*/

        List<string> searchDATAQL = new List<string>();
        List<HoaDonThanhToan> hoadontt = new List<HoaDonThanhToan>();
        List<string> searchDATA = new List<string>();
        decimal txtTongTien = new decimal();
        decimal txtGiamGia = 0;
        int makhtt = 0;

        public MainWindowsNhanVien(UserInfo User)
        {
            var user = new UserInfo(User._TenDangNhap, User._MatKhau, User._IDUser);
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindowsNhanVienLoaded);
        }

        /// <summary>
        /// Repair Data Bingding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindowsNhanVienLoaded(object sender, RoutedEventArgs e)
        {
            LoadDataSearchSANPHAM();
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataSearchSANPHAM();
        }



        private void UpdateDataTT()
        {
            TTDataGridItems.ItemsSource = null;
            TTDataGridItems.ItemsSource = hoadontt;

            decimal temp = 0;
            foreach (var item in hoadontt)
            {
                temp += item.GIA;
            }
            txtTongTien = temp;

            TTtxtTongTien.Text = "";
            TTtxtTongTien.Text = txtTongTien.ToString();

            TTtxtGiamGia.Text = "";
            TTtxtGiamGia.Text = txtGiamGia.ToString();
        }

        private void LoadDataSearchSANPHAM()
        {
            searchDATA = new List<string>();

            var sp = new SanPham();
            List<SANPHAM> sANPHAMs = sp.GetAllSANPHAM();
            foreach (var item in sANPHAMs)
            {
                searchDATA.Add(item.MASP);
            }

            TTtxtTimKiem.ItemsSource = searchDATA;
        }
        

        private void TTbtnKHTT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TTbtnDiscount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TTbtnThemVaoHoaDon_Click(object sender, RoutedEventArgs e)
        {
            if (TTtxtSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Hãy nhập số lượng");
            }
            else
            {
                try
                {
                    var sp = new SanPham();
                    SANPHAM result = new SANPHAM();

                    result = sp.GetSANPHAMTheoMASP(TTtxtTimKiem.Text);

                    HoaDonThanhToan newHoaDonTT = new HoaDonThanhToan();
                    newHoaDonTT.MASP = result.MASP;
                    newHoaDonTT.TENSANPHAM = result.TENSP;
                    newHoaDonTT.THUONGHIEU = result.THUONGHIEU;
                    newHoaDonTT.DONGIA = result.GIATIEN.GetValueOrDefault();
                    newHoaDonTT.SOLUONG = Convert.ToInt32(TTtxtSoLuong.Text);
                    newHoaDonTT.GIA = newHoaDonTT.SOLUONG * newHoaDonTT.DONGIA;

                    hoadontt.Add(newHoaDonTT);
                    txtTongTien += newHoaDonTT.GIA - newHoaDonTT.GIA * txtGiamGia;

                    UpdateDataTT();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xẩy ra, vui lòng kiểm tra lại số lượng và tên sản phẩm");
                }

            }
        }

        private void TTbtnLapHoaDon_Click(object sender, RoutedEventArgs e)
        {
            HOADON newhd = new HOADON();
            var hd = new HoaDon();

            newhd.MAKHTT = makhtt;
            var timenow = DateTime.Now;
            newhd.NGAYTT = timenow;
            newhd.TONGTIEN = txtTongTien;

            //hd.ThemHoaDon(newhd);
            //var temp = hd.GetHoaDonThemNgay(timenow, DateTime.Now);

            //foreach (var item in hoadontt)
            //{
            //    try
            //    {
            //        CHITIETHOADON newcthd = new CHITIETHOADON();
            //        var cthd = new ChiTietHoaDon();

            //        newcthd.MAHD = temp.MAHD;
            //        newcthd.MAKHTT = makhtt;
            //        newcthd.MASP = item.MASP;
            //        newcthd.SL = item.SOLUONG;
            //        newcthd.DONGIA = item.DONGIA;
            //        newcthd.THANHTIEN = item.GIA;
            //        newcthd.CHIETKHAU = item.GIAMGIA;

            //        cthd.ThemChiTietHoaDon(newcthd);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Có lỗi khi cố thêm hóa đơn mới");
            //        break;
            //    }
            //}
            MessageBox.Show("Nhập hóa đơn thành công");
            TTtxtSoLuong.Text = "";
            TTtxtTimKiem.Text = "";
            hoadontt = new List<HoaDonThanhToan>();
            UpdateDataTT();
        }

        private void TTbtnXoaSanPham_Click(object sender, RoutedEventArgs e)
        {
            if (TTDataGridItems.SelectedItems.Count > 0)
            {
                hoadontt.RemoveAt(TTDataGridItems.SelectedIndex);
                UpdateDataTT();
            }
        }

    }
}
