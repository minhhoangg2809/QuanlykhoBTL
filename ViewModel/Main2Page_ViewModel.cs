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
    public class Main2Page_ViewModel : BaseViewModel
    {
        public ICommand toMathang_Command { get; set; }
        public ICommand toXuat_Command { get; set; }
        public ICommand toNhap_Command { get; set; }
        public ICommand toThongke_Command { get; set; }
        public ICommand toLoaimathang_Command { get; set; }
        public ICommand toDonvi_Command { get; set; }

        public Main2Page_ViewModel()
        {
            toMathang_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Thukho.Mathang view = new View.View_Thukho.Mathang();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toXuat_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Thukho.Xuathang view = new View.View_Thukho.Xuathang();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toNhap_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Thukho.Nhaphang view = new View.View_Thukho.Nhaphang();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();

            });

            toThongke_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Thukho.Thongke view = new View.View_Thukho.Thongke();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toLoaimathang_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Thukho.Loaimathang view = new View.View_Thukho.Loaimathang();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();

            });

            toDonvi_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Thukho.Donvi view = new View.View_Thukho.Donvi();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });
        }

        private FrameworkElement getParent(Button lv)
        {
            FrameworkElement p = lv;
            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            return p;
        }

        private void show_waitingwd()
        {
            View.Waiting_window waiting = new View.Waiting_window();
            waiting.ShowDialog();

        }
    }
}
