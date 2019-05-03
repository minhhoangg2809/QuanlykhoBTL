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
    public class Menu_Tk_ViewModel : BaseViewModel
    {
        public ICommand SelectionChanged_Command { get; set; }

        public Menu_Tk_ViewModel()
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

                Select_Window(i, wds, WindowStartupLocation.CenterScreen);

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
        private void Select_Window(int i, WindowState wd, WindowStartupLocation wd_st)
        {
            switch (i)
            {
                case 1:
                    {
                        View.View_Thukho.Mathang view = new View.View_Thukho.Mathang();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 2:
                    {
                        View.View_Thukho.Loaimathang view = new View.View_Thukho.Loaimathang();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 3:
                    {
                        View.View_Thukho.Donvi view = new View.View_Thukho.Donvi();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 4:
                    {
                        View.View_Thukho.Xuathang view = new View.View_Thukho.Xuathang();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 5:
                    {
                        View.View_Thukho.Nhaphang view = new View.View_Thukho.Nhaphang();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 6:
                    {
                        View.View_Thukho.Thongke view = new View.View_Thukho.Thongke();
                        view.WindowState = wd;
                        view.WindowStartupLocation = wd_st;
                        view.Show();
                    }
                    break;
                case 7:
                    {
                        View.View_Thukho.Thungrac view = new View.View_Thukho.Thungrac();
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
