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
    /// Interaction logic for AddSP.xaml
    /// </summary>
    public partial class AddSP : RibbonWindow
    {
        public AddSP()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newSP = new SANPHAM();
            newSP.MASP = txtMASP.Text;
            newSP.TENSP = txtTENSANPHAM.Text;
            newSP.THUONGHIEU = txtTHUONGHIEU.Text;
            newSP.TINHTRANG = txtTINHTRANG.Text;
            newSP.SLBB = 0;
            newSP.SLTONKHO = 0;
            newSP.GIATIEN = Convert.ToInt32(txtGIATIEN.Text);
            newSP.NSX = DateNSX.SelectedDate;
            newSP.THOIHAN = DateTHOIHAN.SelectedDate;

            var pd = new Product();
            var result = pd.themSanPham(newSP);

            if (result._is_Success)
            {
                MessageBox.Show("Thêm thành công");
                //var mess = new Mess("Thêm thành công");
                //mess.Show();
            }
            else
            {
                MessageBox.Show(result._error + "   " + result._result);
                //var mess = new Mess(result._error);
                //mess.Show();
            }
        }
    }
}
