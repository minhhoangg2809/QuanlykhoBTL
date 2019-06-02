using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLK_Dn.View.View_Quanly
{
    /// <summary>
    /// Interaction logic for Tinhtrang_nguoidung.xaml
    /// </summary>
    public partial class Tinhtrang_nguoidung : Window
    {
        public Tinhtrang_nguoidung()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
