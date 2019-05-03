using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLK_Dn.ViewModel
{
    public class Menu_ViewModel : BaseViewModel
    {
        public ICommand SelectionChanged_Command { get; set; }

        public Menu_ViewModel()
        {
            SelectionChanged_Command = new RelayCommand<ListView>(p =>
            {
                return true;
            }, p =>
            {
                var menu_item = p.SelectedItem as ListViewItem;
                int i = Convert.ToInt32(menu_item.Uid);

                Window win = getParent(p) as Window;
                WindowState wds = win.WindowState;

                Select_Window(i, wds,WindowStartupLocation.CenterScreen);

                win.Close();
            });
        }

        private FrameworkElement getParent(ListView lv)
        {
            FrameworkElement p = lv;
            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            return p;
        }
        private void Select_Window(int i, WindowState wd,WindowStartupLocation wd_st)
        {
            switch (i)
            {
                case 1:
                    {
                        View.View_Quanly.Mathang view = new View.View_Quanly.Mathang();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 2:
                    {
                        View.View_Quanly.Khachhang view = new View.View_Quanly.Khachhang();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 3:
                    {
                        View.View_Quanly.Nhacungcap view = new View.View_Quanly.Nhacungcap();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 4:
                    {
                        View.View_Quanly.Quantrihethong view = new View.View_Quanly.Quantrihethong();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 5:
                    {
                        View.View_Quanly.Nhanvien view = new View.View_Quanly.Nhanvien();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 6:
                    {
                        View.View_Quanly.Thungrac view = new View.View_Quanly.Thungrac();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
