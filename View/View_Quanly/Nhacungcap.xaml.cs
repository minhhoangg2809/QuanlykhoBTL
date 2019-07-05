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

namespace QLK_Dn.View.View_Quanly
{
    /// <summary>
    /// Interaction logic for Nhacungcap.xaml
    /// </summary>
    public partial class Nhacungcap : Window
    {
        public Nhacungcap()
        {
            InitializeComponent();
            ButtonClose.Click += ButtonClose_Click;
            ButtonOpen.Click += ButtonOpen_Click;
        }

        void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Hidden;
            ButtonOpen.Visibility = Visibility.Visible;

            GridMain.IsEnabled = true;
        }

        void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            ButtonClose.Visibility = Visibility.Visible;
            ButtonOpen.Visibility = Visibility.Hidden;

            GridMain.IsEnabled = false;
        }
    }
}
