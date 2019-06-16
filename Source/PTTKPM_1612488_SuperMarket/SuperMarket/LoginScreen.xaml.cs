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


namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : RibbonWindow
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void DangNhap()
        {
            var login = new Login();
            string tendangnhap = tbxUsername.Text;
            string matkhau = tbxPassword.Password.ToString();

            var result = login.dangNhap(tendangnhap, matkhau);
            if (result._is_Success)
            {
                UserInfo user = new UserInfo(tendangnhap, matkhau, Convert.ToInt32(result._result));

                bool isQuanLy = login.isQuanLy(user._IDUser)._is_Success;
                if (isQuanLy)
                {
                    MainWindowsQuanLy mainWindow = new MainWindowsQuanLy(user);
                    mainWindow.Show();
                }
                else
                {
                    MainWindowsNhanVien mainWindow = new MainWindowsNhanVien(user);
                    mainWindow.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show(result._error);
            }
        }


        private void DangNhapButton_Click(object sender, RoutedEventArgs e)
        {
            DangNhap();
        }

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                DangNhap();
            }
        }
    }
}
