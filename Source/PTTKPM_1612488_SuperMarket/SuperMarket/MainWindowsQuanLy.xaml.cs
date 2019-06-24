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
using BUS_SuperMarket;
using DAL_SuperMarket;
using PublicClass;
using Fluent;

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for MainWindowsQuanLy.xaml
    /// </summary>
    public partial class MainWindowsQuanLy : RibbonWindow
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


        public MainWindowsQuanLy(UserInfo user)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindowsQuanLyLoaded);
        }

       /// <summary>
       /// Repair Data Bingding
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        void MainWindowsQuanLyLoaded(object sender, RoutedEventArgs e)
        {
            QLSPcbxSource.Add("Sản phẩm");
            QLSPcbxSource.Add("Loại sản phẩm");
            QLSPcbxSource.Add("Hóa đơn");
            QLSPcbxSource.Add("Chiết khấu");
            QLSPcbxSource.Add("Phiếu nhập hàng");
            QLSPcbxSource.Add("Phiếu xuất hàng");
            QLSPcbxSource.Add("KHTT");
            QLSPcbxType.ItemsSource = QLSPcbxSource;
            QLSPcbxType.SelectedItem = QLSPcbxSource[0];

            LoadDataSearchSANPHAM();
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataSearchSANPHAM();
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





        ////Tab Quản lý
        ///
        private void QLSPcbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = QLSPcbxSource.IndexOf(QLSPcbxType.SelectedItem.ToString());
            LoadTableAndDATASearch();
        }


        /// <summary>
        /// Load Data cho QLSPtxtTimKiem và Grid DATA
        /// </summary>
        private void LoadTableAndDATASearch()
        {
            GridViewSANPHAM.Visibility = System.Windows.Visibility.Hidden;
            GridViewLOAISANPHAM.Visibility = System.Windows.Visibility.Hidden;
            GridViewHOADON.Visibility = System.Windows.Visibility.Hidden;
            GridViewCHIETKHAU.Visibility = System.Windows.Visibility.Hidden;
            GridViewPHIEUNHAPHANG.Visibility = System.Windows.Visibility.Hidden;
            GridViewPHIEUXUATHANG.Visibility = System.Windows.Visibility.Hidden;
            GridViewKHTT.Visibility = System.Windows.Visibility.Hidden;

            QLSPbtnAdd.Visibility = System.Windows.Visibility.Visible;
            QLSPbtnDel.Visibility = System.Windows.Visibility.Visible;
            QLSPbtnEdit.Visibility = System.Windows.Visibility.Visible;

            switch (index)
            {
                case 0:
                    GridViewSANPHAM.Visibility = System.Windows.Visibility.Visible;
                    LoadDataQLSANPHAM();
                    break;
                case 1:
                    GridViewLOAISANPHAM.Visibility = System.Windows.Visibility.Visible;
                    QLSPbtnDel.Visibility = System.Windows.Visibility.Hidden;
                    LoadDataQLLOAISANPHAM();
                    break;
                case 2:
                    GridViewHOADON.Visibility = System.Windows.Visibility.Visible;
                    QLSPbtnAdd.Visibility = System.Windows.Visibility.Hidden;
                    QLSPbtnDel.Visibility = System.Windows.Visibility.Hidden;
                    LoadDataQLHOADON();
                    break;
                case 3:
                    GridViewCHIETKHAU.Visibility = System.Windows.Visibility.Visible;
                    LoadDataQLCHIETKHAU();
                    break;
                case 4:
                    GridViewPHIEUNHAPHANG.Visibility = System.Windows.Visibility.Visible;
                    QLSPbtnDel.Visibility = System.Windows.Visibility.Hidden;
                    LoadDataQLPHIEUNHAPHANG();
                    break;
                case 5:
                    GridViewPHIEUXUATHANG.Visibility = System.Windows.Visibility.Visible;
                    QLSPbtnDel.Visibility = System.Windows.Visibility.Hidden;
                    LoadDataQLPHIEUXUATHANG();
                    break;
                case 6:
                    GridViewKHTT.Visibility = System.Windows.Visibility.Visible;
                    QLSPbtnDel.Visibility = System.Windows.Visibility.Hidden;
                    LoadDataQLKHTT();
                    break;
                default:
                    break;
            }
        }

        private void LoadDataQLSANPHAM()
        {
            searchDATAQL = new List<string>();

            var sp = new SanPham();
            List<SANPHAM> sANPHAMs = sp.GetAllSANPHAM();
            GridViewSANPHAM.ItemsSource = sANPHAMs;
            foreach (var item in sANPHAMs)
            {
                searchDATAQL.Add(item.MASP);
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }

        private void LoadDataQLLOAISANPHAM()
        {
            searchDATAQL = new List<string>();

            var slp = new LoaiSanPham();
            List<LOAISANPHAM> lOAISANPHAMs = slp.GetAllLoaiSanPham();
            GridViewLOAISANPHAM.ItemsSource = lOAISANPHAMs;
            foreach (var item in lOAISANPHAMs)
            {
                searchDATAQL.Add(item.TENLOAI);
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }

        private void LoadDataQLHOADON()
        {
            searchDATAQL = new List<string>();

            var hd = new HoaDon();
            List<HOADON> hOADONs = hd.GetAllHoaDon();
            GridViewHOADON.ItemsSource = hOADONs;
            foreach (var item in hOADONs)
            {
                searchDATAQL.Add(item.MAHD.ToString());
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }

        private void LoadDataQLCHIETKHAU()
        {
            searchDATAQL = new List<string>();

            var ck = new ChietKhau();
            List<CHIETKHAU> cHIETKHAUs = ck.GetAllChietKhau();
            GridViewCHIETKHAU.ItemsSource = cHIETKHAUs;
            foreach (var item in cHIETKHAUs)
            {
                searchDATAQL.Add(item.TENLOAI);
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }

        private void LoadDataQLPHIEUNHAPHANG()
        {
            searchDATAQL = new List<string>();

            var pnh = new PhieuNhapHang();
            List<PHIEUNHAPHANG> pHIEUNHAPHANGs = pnh.GetAllPhieuNhapHang();
            GridViewPHIEUNHAPHANG.ItemsSource = pHIEUNHAPHANGs;
            foreach (var item in pHIEUNHAPHANGs)
            {
                searchDATAQL.Add(item.MASP);
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }

        private void LoadDataQLPHIEUXUATHANG()
        {
            searchDATAQL = new List<string>();

            var pxh = new PhieuXuatHang();
            List<PHIEUXUATHANG> pHIEUXUATHANGs = pxh.GetAllPhieuXuatHang();
            GridViewPHIEUXUATHANG.ItemsSource = pHIEUXUATHANGs;
            foreach (var item in pHIEUXUATHANGs)
            {
                searchDATAQL.Add(item.MASP);
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }

        private void LoadDataQLKHTT()
        {
            searchDATAQL = new List<string>();

            var khtt = new KhachHangTT();
            List<KHTT> kHTTs = khtt.GetAllKHTT();
            GridViewKHTT.ItemsSource = kHTTs;
            foreach (var item in kHTTs)
            {
                searchDATAQL.Add(item.MAKHTT.ToString());
            }

            QLSPtxtTimKiem.ItemsSource = searchDATAQL;
        }




        private void QLSPbtnAdd_Click(object sender, RoutedEventArgs e)
        {
            RouterQLSPbtnAdd(index);
            LoadTableAndDATASearch();
        }

        private void QLSPbtnEdit_Click(object sender, RoutedEventArgs e)
        {
            RouterQLSPbtnEdit(index);
            LoadTableAndDATASearch();
        }

        private void QLSPbtnDel_Click(object sender, RoutedEventArgs e)
        {
            RouterQLSPbtnDel(index);
            LoadTableAndDATASearch();
        }


        private void RouterQLSPbtnAdd(int index)
        {
            switch (index)
            {
                case 0:
                    RouterbtnAddSANPHAM();
                    break;
                case 1:
                    RouterbtnAddLOAISANPHAM();
                    break;
                case 2:
                    //RouterbtnAddHOADON();
                    break;
                case 3:
                    RouterbtnAddCHIETKHAU();
                    break;
                case 4:
                    RouterbtnAddPHIEUNHAPHANG();
                    break;
                case 5:
                    RouterbtnAddPHIEUXUATHANG();
                    break;
                case 6:
                    RouterbtnAddKHTT();
                    break;

                default:
                    break;
            }
        }

        private void RouterQLSPbtnEdit(int index)
        {
            MessageBox.Show("Tính năng còn đang phát triển");
            switch (index)
            {
                case 0:
                    MessageBox.Show("Tính năng còn đang phát triển");
                    break;
                case 2:

                    break;
                case 3:
                    
                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;

                default:
                    break;
            }
        }

        private void RouterQLSPbtnDel(int index)
        {
            MessageBox.Show("Tính năng còn đang phát triển");
            switch (index)
            {
                case 0:
                    
                    break;
                case 2:

                    break;
                case 3:
                    
                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;

                default:
                    break;
            }
        }

        // Nút Thêm

        private void RouterbtnAddSANPHAM()
        {
            var addnew = new AddSP();
            addnew.ShowDialog();
        }

        private void RouterbtnAddCHIETKHAU()
        {
            var addnew = new AddCHIETKHAU();
            addnew.ShowDialog();
        }

        private void RouterbtnAddLOAISANPHAM()
        {
            var addnew = new AddLOAISANPHAM();
            addnew.ShowDialog();
        }

        private void RouterbtnAddPHIEUNHAPHANG()
        {
            var addnew = new AddPHIEUNHAPHANG();
            addnew.ShowDialog();
        }

        private void RouterbtnAddPHIEUXUATHANG()
        {
            var addnew = new AddPHIEUXUATHANG();
            addnew.ShowDialog();
        }

        private void RouterbtnAddKHTT()
        {
            var addnew = new AddKHTT();
            addnew.ShowDialog();
        }

        // Nút Xóa
        // Nút sửa

    }
}
