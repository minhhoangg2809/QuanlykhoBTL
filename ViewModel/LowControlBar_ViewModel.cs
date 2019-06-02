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
    public class LowControlBar_ViewModel : BaseViewModel
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
        public ICommand ToMain_Command { get; set; }
        public ICommand Account_Command { get; set; }
        public ICommand Logout_Command { get; set; }
        public ICommand LogoutShow_Command { get; set; }
        public ICommand CloseDialog_Command { get; set; } 
        public LowControlBar_ViewModel()
        {
            IsOpen = false;
            Content = " Bạn muốn đăng xuất ???";

            CloseDialog_Command = new RelayCommand<object>(p => 
            {
                return true;
            }, p => 
            {
                IsOpen = false;
            });

            ToMain_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (p.Uid.ToString() == "QL")
                {
                    View.View_Quanly.Manhinhchinh view = new View.View_Quanly.Manhinhchinh();
                    view.WindowState = windowparent.WindowState;
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                    view.Show();
                }
                else if (p.Uid.ToString() == "TK")
                {
                    View.View_Thukho.Manhinhchinh view = new View.View_Thukho.Manhinhchinh();
                    view.WindowState = windowparent.WindowState;
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                    view.Show();
                }

                windowparent.Close();
            });

            Account_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                if (p.Uid.ToString() == "QL")
                {
                    View.View_Quanly.Thongtin_taikhoan view = new View.View_Quanly.Thongtin_taikhoan();
                    view.ShowDialog();
                }
                else if (p.Uid.ToString() == "TK")
                {
                    View.View_Thukho.Thongtin_taikhoan view = new View.View_Thukho.Thongtin_taikhoan();
                    view.ShowDialog();
                }

            });

            Logout_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                if (ViewModel.Taikhoan_ViewModel.Glo_CurrentUser != null)
                {
                    ViewModel.Taikhoan_ViewModel.Chuyentrangthai_Dong(ViewModel.Taikhoan_ViewModel.Glo_CurrentUser);
                }

                IsOpen = false;
                Dangnhap dangnhap = new Dangnhap();
                dangnhap.Show();
                
                Window windowparent = getParent(p) as Window;
                if (windowparent != null)
                {
                    windowparent.Close();
                }
               
            });

            LogoutShow_Command = new RelayCommand<UserControl>(p => 
            {
                if (IsOpen == true)
                    return false;

                return true;
            }, p => 
            {
                IsOpen = true;
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
