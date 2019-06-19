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
        List<HoaDonThanhToan> hoadontt = new List<HoaDonThanhToan>();
        List<string> searchDATA = new List<string>();
        decimal txtTongTien = new decimal();
        decimal txtGiamGia = 0;


        public MainWindowsQuanLy(UserInfo user)
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindowsQuanLyLoaded);
        }

       
        void MainWindowsQuanLyLoaded(object sender, RoutedEventArgs e)
        {
            List<String> QLSPcbxSource = new List<string>();
            QLSPcbxSource.Add("Sản Phẩm");
            QLSPcbxSource.Add("Hóa đơn");
            QLSPcbxSource.Add("Chiết khẩu");
            QLSPcbxSource.Add("Phiếu nhập hàng");
            QLSPcbxSource.Add("Phiếu xuất hàng");
            QLSPcbxSource.Add("KHTT");
            QLSPcbxType.ItemsSource = QLSPcbxSource;

            LoadDataSearchSANPHAM();
        }

        private void LoadData()
        {
            var sp = new SanPham();
            var searchDATA = sp.GetSANPHAM(TTtxtTimKiem.Text);

            TTtxtTimKiem.ItemsSource = null;
            TTtxtTimKiem.ItemsSource = searchDATA;

            QLSPtxtTimKiem.ItemsSource = null;
            QLSPtxtTimKiem.ItemsSource = searchDATA;
        }

        private void tbxTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                //do some thing
            }
        }

        private void SearchSanPham()
        {
            SanPham sp = new SanPham();
            
        }
        
        

        private void QLSPtbxTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            LoadData();
        }
        

        private void QLSPbtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var themSP = new AddSP();
            themSP.Show();
        }

        private void QLSPbtnAdd_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QLSPbtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QLSPbtnEdit_Click(object sender, RoutedEventArgs e)
        {

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
                searchDATA.Add(item.TENSP);
            }

            TTtxtTimKiem.ItemsSource = searchDATA;
        }

        private void LoadDataSearchCHIETKHAU()
        {
            searchDATA = new List<string>();

            var sp = new SanPham();
            List<SANPHAM> sANPHAMs = sp.GetAllSANPHAM();
            foreach (var item in sANPHAMs)
            {
                searchDATA.Add(item.TENSP);
            }

            TTtxtTimKiem.ItemsSource = searchDATA;
        }






        //private void TTtxtTimKiem_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    Fluent.ComboBox cmb = (Fluent.ComboBox)sender;

        //    cmb.IsDropDownOpen = true;

        //    if (!string.IsNullOrEmpty(cmb.Text))
        //    {
        //        string fullText = cmb.Text.Insert(GetChildOfType<Fluent.TextBox>(cmb).CaretIndex, e.Text);
        //        cmb.ItemsSource = searchDATA.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        //    }
        //    else if (!string.IsNullOrEmpty(e.Text))
        //    {
        //        cmb.ItemsSource = searchDATA.Where(s => s.IndexOf(e.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        //    }
        //    else
        //    {
        //        cmb.ItemsSource = Names;
        //    }
        //}

        //private void TTtxtTimKiem_PreviewKeyUp(object sender, KeyEventArgs e)
        //{

        //}

        //private void TTtxtTimKiem_Pasting(object sender, DataObjectPastingEventArgs e)
        //{
        //    Fluent.ComboBox cmb = (Fluent.ComboBox)sender;

        //    cmb.IsDropDownOpen = true;

        //    string pastedText = (string)e.DataObject.GetData(typeof(string));
        //    string fullText = cmb.Text.Insert(GetChildOfType<Fluent.TextBox>(cmb).CaretIndex, pastedText);

        //    if (!string.IsNullOrEmpty(fullText))
        //    {
        //        cmb.ItemsSource = searchDATA.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        //    }
        //    else
        //    {
        //        cmb.ItemsSource = searchDATA;
        //    }
        //}

        //public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj == null) return null;

        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //    {
        //        var child = VisualTreeHelper.GetChild(depObj, i);

        //        var result = (child as T) ?? GetChildOfType<T>(child);
        //        if (result != null) return result;
        //    }
        //    return null;
        //}


    }
}
