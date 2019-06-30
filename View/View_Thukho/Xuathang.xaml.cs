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
    /// Interaction logic for Xuathang.xaml
    /// </summary>
    public partial class Xuathang : Window
    {
        public Xuathang()
        {
            InitializeComponent();
            ButtonOpen.Click += ButtonOpen_Click;
            ButtonClose.Click += ButtonClose_Click;

            UserControls_Pages.SearchBar.Gl_search.TextChanged += tb_Search_TextChanged;
        }

        #region Phan tim kiem
        private bool Search(object item)
        {
            if (String.IsNullOrEmpty(UserControls_Pages.SearchBar.Gl_search.Text))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.CHITIETPHIEUXUAT)item).ma_ctphieuxuat.IndexOf(UserControls_Pages.SearchBar.Gl_search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).nguoitao.IndexOf(UserControls_Pages.SearchBar.Gl_search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).CHITIETPHIEUNHAP.MATHANG.ten_mathang.IndexOf(UserControls_Pages.SearchBar.Gl_search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).PHIEUXUAT.ngayxuat.IndexOf(UserControls_Pages.SearchBar.Gl_search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).CHITIETPHIEUNHAP.MATHANG.NHACUNGCAP.ten_nhacungcap.IndexOf(UserControls_Pages.SearchBar.Gl_search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).KHACHHANG.ten_khachhang.IndexOf(UserControls_Pages.SearchBar.Gl_search.Text, StringComparison.OrdinalIgnoreCase) >= 0;

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
