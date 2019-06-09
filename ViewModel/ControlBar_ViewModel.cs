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
    public class ControlBar_ViewModel : BaseViewModel
    {
        private bool _IsOpen;

        public bool IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; OnPropertyChanged(); }
        }

        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; OnPropertyChanged(); }
        }

        public ICommand Minimize_Command { get; set; }
        public ICommand Maximize_Command { get; set; }
        public ICommand Close_Command { get; set; }
        public ICommand Drag_Command { get; set; }
        public ICommand CloseDialog_Command { get; set; }
        public ICommand OpenDialog_Command { get; set; }


        public ControlBar_ViewModel()
        {
            IsOpen = false;
            Content = "  Đóng ứng dụng ???";

            Minimize_Command = new RelayCommand<UserControl>(p =>
            {
                if (IsOpen == true)
                    return false;

                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    windowparent.WindowState = WindowState.Minimized;
                }
            });

            Maximize_Command = new RelayCommand<UserControl>(p =>
            {
                if (IsOpen == true)
                    return false;

                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    if (windowparent.WindowState == WindowState.Maximized)
                    {
                        windowparent.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        windowparent.WindowState = WindowState.Maximized;
                    }
                }
            });


            Close_Command = new RelayCommand<UserControl>(p =>
             {
                 if (IsOpen == false)
                     return false;

                 return true;
             }, p =>
             {
                 if (ViewModel.Taikhoan_ViewModel.Glo_CurrentUser != null)
                 {
                     ViewModel.Taikhoan_ViewModel.Chuyentrangthai_Dong(ViewModel.Taikhoan_ViewModel.Glo_CurrentUser);
                 }

                 Application.Current.Shutdown();

             });

            Drag_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    windowparent.DragMove();
                }

            });

            OpenDialog_Command = new RelayCommand<UserControl>(p =>
            {
                if (IsOpen == true)
                    return false;

                return true;
            }, p =>
            {
                IsOpen = true;
            });

            CloseDialog_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                IsOpen = false;
            });
        }

        private FrameworkElement getParent(UserControl uc)
        {
            FrameworkElement p = uc;
            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            return p;
        }
    }
}
