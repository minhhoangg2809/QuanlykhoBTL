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
    public class MainPage_ViewModel : BaseViewModel
    {
        public ICommand toMathang_Command { get; set; }
        public ICommand toKhachhang_Command { get; set; }
        public ICommand toNhanvien_Command { get; set; }
        public ICommand toNhacungcap_Command { get; set; }
        public ICommand toHethong_Command { get; set; }

        public MainPage_ViewModel()
        {
            toMathang_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Quanly.Mathang view = new View.View_Quanly.Mathang();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toKhachhang_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Quanly.Khachhang view = new View.View_Quanly.Khachhang();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toNhacungcap_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Quanly.Nhacungcap view = new View.View_Quanly.Nhacungcap();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toHethong_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {

                Window win = getParent(p) as Window;

                View.View_Quanly.Quantrihethong view = new View.View_Quanly.Quantrihethong();
                view.WindowState = win.WindowState;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                show_waitingwd();

                view.Show();

                win.Close();
            });

            toNhanvien_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window win = getParent(p) as Window;

                View.View_Quanly.Nhanvien view = new View.View_Quanly.Nhanvien();
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
