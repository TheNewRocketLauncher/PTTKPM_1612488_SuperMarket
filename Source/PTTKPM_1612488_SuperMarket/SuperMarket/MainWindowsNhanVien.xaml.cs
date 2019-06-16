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
using PublicClass;

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for MainWindows.xaml
    /// </summary>
    public partial class MainWindowsNhanVien : RibbonWindow
    {
        //public MainWindows()
        //{
        //    InitializeComponent();
        //}

        public MainWindowsNhanVien(UserInfo User)
        {
            var user = new UserInfo(User._TenDangNhap, User._MatKhau, User._IDUser);
            InitializeComponent();
        }
    }
}
