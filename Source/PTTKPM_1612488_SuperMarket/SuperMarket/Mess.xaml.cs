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

namespace SuperMarket
{
    /// <summary>
    /// Interaction logic for Mess.xaml
    /// </summary>
    public partial class Mess : RibbonWindow
    {
        public Mess(string mess)
        {
            string Messenger = mess;
            InitializeComponent();
            
        }
    }
}
