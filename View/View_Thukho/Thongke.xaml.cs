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

namespace QLK_Dn.View.View_Thukho
{
    /// <summary>
    /// Interaction logic for Thongke.xaml
    /// </summary>
    public partial class Thongke : Window
    {
        public Thongke()
        {
            InitializeComponent();

            ButtonOpen.Click += ButtonOpen_Click;
            ButtonClose.Click += ButtonClose_Click;

            tb_Search.TextChanged += tb_Search_TextChanged;
        }

        #region Phan tim kiem

        private bool Search(object item)
        {
            if (String.IsNullOrEmpty(tb_Search.Text))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.Thongke)item).mathang.ma_mathang.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.ten_mathang.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.NHACUNGCAP.ten_nhacungcap.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.DONVITINH.ten_donvi.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.LOAIHANG.ten_loaihang.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0;

                }
                catch (Exception)
                {
                    return true;
                }

            }
        }


        void tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(lv_hienthi.ItemsSource);
            viewfilter.Filter = Search;
            CollectionViewSource.GetDefaultView(lv_hienthi.ItemsSource).Refresh();
        }


        #endregion

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

        private void DatePicker_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DatePicker dp = sender as DatePicker;

            if (dp.Text == string.Empty)
            {
                dp.Text = DateTime.Today.ToShortDateString();
            }
        }
    }
}
