﻿using System;
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
            this.Loaded += new RoutedEventHandler(AddSPLoaded);
        }

        private void AddSPLoaded(object sender, RoutedEventArgs e)
        {
            List<string> searchDATA = new List<string>();

            var lsp = new LoaiSanPham();
            List<LOAISANPHAM> lOAISANPHAMs = lsp.GetAllLoaiSanPham();
            foreach (var item in lOAISANPHAMs)
            {
                searchDATA.Add(item.TENLOAI.ToString());
            }

            txtMALOAI.ItemsSource = searchDATA;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
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
                var lsp = new LoaiSanPham();
                newSP.MALOAI = lsp.GetMaLoaiSanPham(txtMALOAI.Text);

               var sp = new SanPham();
                var result = sp.ThemSanPham(newSP);

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
                MessageBox.Show("Có lỗi xẩy ra, vui lòng xem lại dữ liệu vừa nhập", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn hủy không ? Nhưng thông tin bạn nhập vẫn chưa được lưu", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                
            }
        }

        private void txtMALOAI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
