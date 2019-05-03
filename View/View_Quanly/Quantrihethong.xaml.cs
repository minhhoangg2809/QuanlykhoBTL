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
    /// Interaction logic for Quantrihethong.xaml
    /// </summary>
    public partial class Quantrihethong : Window
    {
        public Quantrihethong()
        {
            InitializeComponent();
            ButtonOpen.Click += ButtonOpen_Click;
            ButtonClose.Click += ButtonClose_Click;

            this.DataContext = new ViewModel.Taikhoan_ViewModel();
            tb_Search.TextChanged+=tb_Search_TextChanged;
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
                    return ((Model.TAIKHOAN)item).ten_taikhoan.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.TAIKHOAN)item).NHANVIEN.ten_nhanvien.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.TAIKHOAN)item).email.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.TAIKHOAN)item).NHANVIEN.ma_nhanvien.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0;
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
        private void btn_reye_Click(object sender, RoutedEventArgs e)
        {
            if (ricon.Kind == MaterialDesignThemes.Wpf.PackIconKind.EyeOutline)
            {
                btn_reye.ToolTip = "Ẩn mật khẩu";
                ricon.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOffOutline;

                pb_pass.Visibility = Visibility.Hidden;
                tb_pass.Visibility = Visibility.Visible;

                pb_repass.Visibility = Visibility.Hidden;
                tb_repass.Visibility = Visibility.Visible;

                tb_repass.Text = pb_repass.Password;
                tb_pass.Text = pb_pass.Password;
            }
            else
            {
                btn_reye.ToolTip = "Hiển thị mật khẩu";
                ricon.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOutline;

                tb_pass.Visibility = Visibility.Hidden;
                pb_pass.Visibility = Visibility.Visible;

                tb_repass.Visibility = Visibility.Hidden;
                pb_repass.Visibility = Visibility.Visible;

                pb_repass.Password = tb_repass.Text;
                pb_pass.Password = tb_pass.Text;
            }
        }
    }
}
