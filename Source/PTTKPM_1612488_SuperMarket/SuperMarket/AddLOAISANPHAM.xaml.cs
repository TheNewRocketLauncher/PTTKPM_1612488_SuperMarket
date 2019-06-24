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
using PublicClass;

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for AddLOAISANPHAM.xaml
    /// </summary>
    public partial class AddLOAISANPHAM : RibbonWindow
    {
        public AddLOAISANPHAM()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newLSP = new LOAISANPHAM();
                newLSP.TENLOAI = txtTENLOAI.Text;

                var lsp = new LoaiSanPham();
                var result = lsp.ThemLoaiSanPham(newLSP);

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
