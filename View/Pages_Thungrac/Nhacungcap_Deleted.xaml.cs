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
    /// Interaction logic for Nhacungcap_Deleted.xaml
    /// </summary>
    public partial class Nhacungcap_Deleted : Page
    {
        public Nhacungcap_Deleted()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Nhacungcap_Deleted_ViewModel();
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
                    return ((Model.NHACUNGCAP)item).ten_nhacungcap.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHACUNGCAP)item).diachi.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHACUNGCAP)item).sodienthoai.IndexOf(tb_Search.Text, StringComparison.OrdinalIgnoreCase) >= 0;
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
