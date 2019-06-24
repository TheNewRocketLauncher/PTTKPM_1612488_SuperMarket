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
using BUS_SuperMarket;
using DAL_SuperMarket;

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for ValidKHTT.xaml
    /// </summary>
    public partial class AddKHTT : RibbonWindow
    {
        public AddKHTT()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newkhtt = new KHTT();
                newkhtt.SDT = txtSDT.Text;
                newkhtt.CMND = txtCMND.Text;
                

                var khtt = new KhachHangTT();
                var result = khtt.ThemKHTT(newkhtt);
                
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
