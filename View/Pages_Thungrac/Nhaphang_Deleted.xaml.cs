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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLK_Dn.Pages_Thungrac
{
    /// <summary>
    /// Interaction logic for Nhaphang_Deleted.xaml
    /// </summary>
    public partial class Nhaphang_Deleted : Page
    {
        public Nhaphang_Deleted()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Nhaphang_Deleted_ViewModel();

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
                    return ((Model.CHITIETPHIEUNHAP)item).ma_ctphieunhap.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).nguoitao.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).MATHANG.ten_mathang.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).PHIEUNHAP.ngaynhap.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).MATHANG.NHACUNGCAP.ten_nhacungcap.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).MATHANG.DONVITINH.ten_donvi.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0;

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
    }
}
