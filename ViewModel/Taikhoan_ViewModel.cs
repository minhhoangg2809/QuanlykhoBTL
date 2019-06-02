using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using QLK_Dn.MySource;
using System.Windows;
using System.Windows.Controls;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Windows.Controls.Primitives;

namespace QLK_Dn.ViewModel
{
    public class Taikhoan_ViewModel : BaseViewModel
    {
        public static Model.TAIKHOAN Glo_CurrentUser;

        private ObservableCollection<Model.TAIKHOAN> _List;

        public ObservableCollection<Model.TAIKHOAN> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.TAIKHOAN> _List_Tinhtrang;

        public ObservableCollection<Model.TAIKHOAN> List_Tinhtrang
        {
            get { return _List_Tinhtrang; }
            set { _List_Tinhtrang = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHANVIEN> _List_Nhanvien;

        public ObservableCollection<Model.NHANVIEN> List_Nhanvien
        {
            get { return _List_Nhanvien; }
            set { _List_Nhanvien = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.TAIKHOAN> _DeleteList;

        public ObservableCollection<Model.TAIKHOAN> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private Model.TAIKHOAN _SelectedItem;

        public Model.TAIKHOAN SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }


        #region Thay doi thong tin

        private string _Tentkmoi;

        public string Tentkmoi
        {
            get { return _Tentkmoi; }
            set { _Tentkmoi = value; OnPropertyChanged(); }
        }

        private string _Matkhaumoi;

        public string Matkhaumoi
        {
            get { return _Matkhaumoi; }
            set { _Matkhaumoi = value; OnPropertyChanged(); }
        }

        private string _XacnhanMatkhaumoi;

        public string XacnhanMatkhaumoi
        {
            get { return _XacnhanMatkhaumoi; }
            set { _XacnhanMatkhaumoi = value; OnPropertyChanged(); }
        }

        private Model.TAIKHOAN _CurrentUser;

        public Model.TAIKHOAN CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                _CurrentUser = value;
                if (_CurrentUser != null)
                {
                    Tentkmoi = _CurrentUser.ten_taikhoan;
                    Glo_CurrentUser = _CurrentUser;
                }
                OnPropertyChanged();
            }
        }

        #endregion

        #region Login (Dangnhap.xaml)


        private string _Tendangnhap;

        public string Tendangnhap
        {
            get { return _Tendangnhap; }
            set { _Tendangnhap = value; OnPropertyChanged(); }
        }

        private string _Matkhau;

        public string Matkhau
        {
            get { return _Matkhau; }
            set { _Matkhau = value; OnPropertyChanged(); }
        }

        private string _Makhoiphuc;

        public string Makhoiphuc
        {
            get { return _Makhoiphuc; }
            set { _Makhoiphuc = value; OnPropertyChanged(); }
        }

        private string _Maxacthuc;

        public string Maxacthuc
        {
            get { return _Maxacthuc; }
            set { _Maxacthuc = value; OnPropertyChanged(); }
        }
        #endregion

        #region Binding Data (Quantrihethong.xaml)
        private string _Tentaikhoan;

        public string Tentaikhoan
        {
            get { return _Tentaikhoan; }
            set { _Tentaikhoan = value; OnPropertyChanged(); }
        }

        private string _Matkhautaikhoan;

        public string Matkhautaikhoan
        {
            get { return _Matkhautaikhoan; }
            set { _Matkhautaikhoan = value; OnPropertyChanged(); }
        }

        private string _Matkhauxacnhan;

        public string Matkhauxacnhan
        {
            get { return _Matkhauxacnhan; }
            set { _Matkhauxacnhan = value; OnPropertyChanged(); }
        }

        private string _Emailkhoiphuc;

        public string Emailkhoiphuc
        {
            get { return _Emailkhoiphuc; }
            set { _Emailkhoiphuc = value; OnPropertyChanged(); }
        }
        private Model.NHANVIEN _SNhanvien;

        public Model.NHANVIEN SNhanvien
        {
            get { return _SNhanvien; }
            set { _SNhanvien = value; OnPropertyChanged(); }
        }

        #endregion

        #region Tinh trang prop

        private bool _IsToggleChecked;

        public bool IsToggleChecked
        {
            get { return _IsToggleChecked; }
            set { _IsToggleChecked = value; OnPropertyChanged(); }
        }

        #endregion

        #region Command

        #region Command Phan quan tri he thong
        public ICommand GetPassword_Command { get; set; }
        public ICommand GetRePassword_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Reset_Command { get; set; }
        #endregion

        #region Command Dang nhap va khoi phuc tai khoan

        public ICommand getCurrentPass_Command { get; set; }
        public ICommand Login_Command { get; set; }
        public ICommand Send_Command { get; set; }
        public ICommand Check_Command { get; set; }

        #endregion

        #region Command Thay doi thong tin
        public ICommand getNewCurrentPass_Command { get; set; }
        public ICommand getNewCurrentRePass_Command { get; set; }
        public ICommand Update_Command { get; set; }
        public ICommand Back_Command { get; set; }

        #endregion

        #region Command Tinh trang ng dung
        public ICommand Status_Command { get; set; }
        public ICommand Refesh_State_Command { get; set; }
        public ICommand Update_Auto_Command { get; set; }

        #endregion

        #endregion

        #region Message

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; OnPropertyChanged(); }
        }

        private bool _Active;

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; OnPropertyChanged(); }
        }

        public ICommand Active_Command { get; set; }

        #endregion

        #region Dialog

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

        public ICommand CloseDialog_Command { get; set; }

        #endregion

        public Taikhoan_ViewModel()
        {
            List = new ObservableCollection<Model.TAIKHOAN>(Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.IsDeleted == false));

            TaoDSNhanvien();
            DeleteList = new ObservableCollection<Model.TAIKHOAN>();

            GetPassword_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password.Length < 5)
                    return false;

                return true;
            }, p =>
            {
                Matkhautaikhoan = p.Password;
            });


            GetRePassword_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password.Length < 5)
                    return false;

                return true;
            }, p =>
            {
                Matkhauxacnhan = p.Password;
            });

            getNewCurrentPass_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password.Length < 5)
                    return false;

                if (string.IsNullOrEmpty(p.Password))
                    return false;

                return true;
            }, p =>
            {
                Matkhaumoi = p.Password;
            });

            getNewCurrentRePass_Command = new RelayCommand<PasswordBox>(p =>
            {
                if (p.Password.Length < 5)
                    return false;

                if (string.IsNullOrEmpty(p.Password))
                    return false;

                return true;
            }, p =>
            {
                XacnhanMatkhaumoi = p.Password;
            });

            Active = false;
            IsOpen = false;

            Active_Command = new RelayCommand<object>(p =>
            {
                if (Active == false)
                    return false;

                return true;
            }, p =>
            {
                Active = false;
            });

            CloseDialog_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                IsOpen = false;
            });

            IsToggleChecked = false;

            #region Them tai khoan

            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Tentaikhoan) || string.IsNullOrEmpty(Emailkhoiphuc) || string.IsNullOrEmpty(Matkhautaikhoan) || string.IsNullOrEmpty(Matkhauxacnhan))
                    return false;

                if (SNhanvien == null)
                    return false;

                if (MyStaticMethods.CheckEmail(Emailkhoiphuc) == false)
                    return false;

                return true;
            }, p =>
            {
                if (Matkhauxacnhan == Matkhautaikhoan)
                {
                    if (!Kiemtratendangnhap(Tentaikhoan))
                    {
                        Model.TAIKHOAN newItem = new Model.TAIKHOAN()
                        {
                            ma_taikhoan = MyStaticMethods.RandomInt(10),
                            ten_taikhoan = Tentaikhoan,
                            email = Emailkhoiphuc,
                            matkhau = MyStaticMethods.MD5Hash(MyStaticMethods.Base64Encode(Matkhautaikhoan)),
                            NHANVIEN = SNhanvien,
                            IsDeleted = false,
                            IsLogin = false
                        };

                        Model.DataProvider.Ins.DB.TAIKHOANs.Add(newItem);
                        Model.DataProvider.Ins.DB.SaveChanges();

                        List.Insert(0, newItem);
                        TaoDSNhanvien();
                        SelectedItem = newItem;

                        Active = true;
                        Message = "Thêm mới thành công !!!";
                    }
                    else
                    {
                        Active = true;
                        Message = "Tên đăng nhập đã tồn tại !!!";
                    }
                }
                else
                {
                    Active = true;
                    Message = "Mật khẩu và xác nhận mật khẩu không trùng khớp !!!";
                }
            });
            #endregion

            #region Tao moi
            Reset_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Tentaikhoan = "";
                Matkhautaikhoan = "";
                Matkhauxacnhan = "";
                Emailkhoiphuc = "";
                SNhanvien = null;

                SelectedItem = null;
            });
            #endregion

            #region Xoa tai khoan

            DeleteShow_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                if (IsOpen == true)
                    return false;

                return true;
            }, p =>
            {
                IsOpen = true;
                Content = "  Xóa vĩnh viễn các bản ghi được chọn ???";
            });

            AddDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Add(List.Where(x => x.ma_taikhoan == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_taikhoan == p.Uid.ToString()).SingleOrDefault());
            });

            Delete_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                RemoveIteminDb();
                RemoveIteminList();

                DeleteList = new ObservableCollection<Model.TAIKHOAN>();

                Tentaikhoan = "";
                Matkhautaikhoan = "";
                Emailkhoiphuc = "";
                SNhanvien = null;

                TaoDSNhanvien();
                IsOpen = false;

            });
            #endregion

            #region Dang nhap

            getCurrentPass_Command = new RelayCommand<PasswordBox>(p =>
            {
                return true;
            }, p =>
            {
                Matkhau = p.Password;
            });

            Login_Command = new RelayCommand<Button>(p =>
            {
                if (string.IsNullOrEmpty(Matkhau) || string.IsNullOrEmpty(Tendangnhap))
                    return false;

                return true;
            }, p =>
            {
                if (Kiemtrataikhoan(Tendangnhap, Matkhau))
                {
                    string mk = MyStaticMethods.MD5Hash(MyStaticMethods.Base64Encode(Matkhau));
                    var current_user = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ten_taikhoan == Tendangnhap && x.matkhau == mk).SingleOrDefault();
                    if (current_user.NHANVIEN.ma_quyen == 1)
                    {
                        View.View_Quanly.Manhinhchinh view = new View.View_Quanly.Manhinhchinh();
                        view.Show();

                        //MessageBox.Show("Đăng nhập thành công", "THÔNG BÁO");
                    }
                    else
                    {
                        View.View_Thukho.Manhinhchinh view = new View.View_Thukho.Manhinhchinh();
                        view.Show();

                        //MessageBox.Show("Đăng nhập thành công", "THÔNG BÁO");
                    }

                    CurrentUser = current_user;
                    Matkhau = "";

                    Window w = getWindowParent(p) as Window;
                    if (p != null)
                    {
                        w.Close();
                    }

                    Chuyentrangthai_Mo(CurrentUser);
                }
                else
                {
                    Active = true;
                    Message = "Vui lòng kiểm tra lại tên đăng nhập và mật khẩu !!!";
                }
            });

            #endregion

            #region Khoi phuc

            Send_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                if (!string.IsNullOrEmpty(Tendangnhap))
                {
                    var result = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ten_taikhoan == Tendangnhap).Count();
                    if (result != 0)
                    {
                        Model.TAIKHOAN TK = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ten_taikhoan == Tendangnhap).SingleOrDefault();
                        try
                        {
                            Makhoiphuc = GuiMail(TK);

                            Khoiphuctk view = new Khoiphuctk();
                            view.Show();

                            Window w = getWindowParent(p) as Window;
                            if (w != null)
                            {
                                w.Close();
                            }

                            Active = true;
                            Message = "Đã gửi mã xác thực !!! Vui lòng kiểm tra email ";
                        }
                        catch (Exception)
                        {
                            Active = true;
                            Message = "Không thể gửi mã !!! ";
                        }

                    }
                    else
                    {
                        Active = true;
                        Message = "Tên đăng nhập không tồn tại !!!";
                    }
                }

                else
                {
                    Active = true;
                    Message = "Vui lòng điền tên đăng nhập !!!";
                }

            });

            Check_Command = new RelayCommand<Button>(p =>
            {
                if (string.IsNullOrEmpty(Tendangnhap) || string.IsNullOrEmpty(Maxacthuc))
                    return false;

                return true;
            }, p =>
            {
                Model.TAIKHOAN TK = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ten_taikhoan == Tendangnhap).SingleOrDefault();

                if (Maxacthuc == Makhoiphuc)
                {
                    if (TK.NHANVIEN.ma_quyen == 1)
                    {
                        View.View_Quanly.Manhinhchinh view = new View.View_Quanly.Manhinhchinh();
                        view.Show();

                        //MessageBox.Show("Đăng nhập thành công", "THÔNG BÁO");
                    }
                    else
                    {
                        View.View_Thukho.Manhinhchinh view = new View.View_Thukho.Manhinhchinh();
                        view.Show();

                        //MessageBox.Show("Đăng nhập thành công", "THÔNG BÁO");
                    }

                    CurrentUser = TK;
                    Makhoiphuc = "";
                    Maxacthuc = "";

                    Window w = getWindowParent(p) as Window;
                    if (w != null)
                    {
                        w.Close();
                    }

                    Chuyentrangthai_Mo(CurrentUser);
                }
                else
                {
                    Active = true;
                    Message = "Mã xác thực sai";
                }
            });
            #endregion

            #region Thay doi thong tin

            Update_Command = new RelayCommand<Button>(p =>
            {
                if (string.IsNullOrEmpty(Tentkmoi) || string.IsNullOrEmpty(CurrentUser.email) || string.IsNullOrEmpty(CurrentUser.NHANVIEN.ten_nhanvien))
                    return false;

                if (!MyStaticMethods.CheckEmail(CurrentUser.email))
                    return false;

                return true;
            }, p =>
            {
                if (!Kiemtratendangnhap(Tentkmoi))
                {
                    if (!string.IsNullOrEmpty(Matkhaumoi) && !string.IsNullOrEmpty(XacnhanMatkhaumoi))
                    {
                        if (Matkhaumoi == XacnhanMatkhaumoi)
                        {
                            CurrentUser.matkhau = MyStaticMethods.MD5Hash(MyStaticMethods.Base64Encode(Matkhaumoi));
                        }

                    }

                    CurrentUser.ten_taikhoan = Tentkmoi;
                    Model.DataProvider.Ins.DB.SaveChanges();

                    Active = true;
                    Message = "Đã cập nhật thông tin !!!";
                }
                else
                {
                    if (!string.IsNullOrEmpty(Matkhaumoi) && !string.IsNullOrEmpty(XacnhanMatkhaumoi))
                    {
                        if (Matkhaumoi == XacnhanMatkhaumoi)
                        {
                            CurrentUser.matkhau = MyStaticMethods.MD5Hash(MyStaticMethods.Base64Encode(Matkhaumoi));
                        }
                    }

                    Model.DataProvider.Ins.DB.SaveChanges();

                    Active = true;
                    Message = "Đã cập nhật thông tin !!! Không sửa tên đăng nhập";
                }

            });

            Back_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                Window w = getWindowParent(p) as Window;
                if (w != null)
                {
                    CurrentUser = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ma_taikhoan == CurrentUser.ma_taikhoan).SingleOrDefault();
                    w.Close();
                }
            });

            #endregion

            #region Phan tinh trang

            Status_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                View.View_Quanly.Tinhtrang_nguoidung view = new View.View_Quanly.Tinhtrang_nguoidung();
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view.ShowDialog();
            });

            Refesh_State_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                if (p != null)
                {
                    if (p.GetType() == typeof(Button))
                    {
                        IsToggleChecked = false;
                    }
                }

                Capnhattrangthai();
            });

            Update_Auto_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Thread thr = new Thread(t => Capnhattrangthai());

                if (IsToggleChecked == true)
                {
                    thr.Start();
                    Thread.Sleep(1000);
                }
                else
                {
                    thr.Abort();
                }

            });

            #endregion

        }

        #region Methods

        public void Capnhattrangthai()
        {
            Model.QuanlyKhoDoanhNghiepEntities UpdateStatus = new Model.QuanlyKhoDoanhNghiepEntities();
            List_Tinhtrang = new ObservableCollection<Model.TAIKHOAN>(UpdateStatus.TAIKHOANs.Where(x => x.IsDeleted == false));
        }

        public static void Chuyentrangthai_Mo(Model.TAIKHOAN taikhoan)
        {
            taikhoan.IsLogin = true;
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Chuyentrangthai_Dong(Model.TAIKHOAN taikhoan)
        {
            taikhoan.IsLogin = false;
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static string getCurrent()
        {
            return Glo_CurrentUser.NHANVIEN.ten_nhanvien;
        }

        private string GuiMail(Model.TAIKHOAN TK)
        {
            string mail = TK.email;
            string makhoiphuc = MyStaticMethods.RandomString(10, false);

            string from = "ctythietbiyte.vietnhat@gmail.com";
            string frompass = "vnisdabest";
            if (!string.IsNullOrEmpty(mail))
            {
                var mess = "Mã xác thực : " + makhoiphuc;


                MailMessage messenge = new MailMessage(from, mail, ("Xin chào " + TK.ten_taikhoan), mess);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;

                client.Credentials = new NetworkCredential(from, frompass);

                client.Send(messenge);

            }
            else
            {
                Active = true;
                Message = "Tài khoản này không có E-Mail khôi phục";
            }


            return makhoiphuc;
        }
        private FrameworkElement getWindowParent(Button btn)
        {
            FrameworkElement p = btn;

            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            return p;
        }
        private bool Kiemtrataikhoan(string tendn, string matkhau)
        {
            string mk = MyStaticMethods.MD5Hash(MyStaticMethods.Base64Encode(matkhau));
            var result = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ten_taikhoan == tendn && x.matkhau == mk && x.IsDeleted == false).Count();
            if (result != 0)
            {
                return true;
            }

            return false;
        }
        private void TaoDSNhanvien()
        {
            List_Nhanvien = new ObservableCollection<Model.NHANVIEN>(Model.DataProvider.Ins.DB.NHANVIENs.Where(x => x.IsDeleted == false));

            for (int i = 0; i < List_Nhanvien.Count(); i++)
            {
                while (List.Where(x => x.NHANVIEN == List_Nhanvien[i]).Count() != 0)
                {
                    if (List_Nhanvien[i] == List_Nhanvien[List_Nhanvien.Count() - 1])
                    {
                        List_Nhanvien.Remove(List_Nhanvien[i]);
                        break;
                    }
                    else
                    {
                        List_Nhanvien.Remove(List_Nhanvien[i]);
                    }
                };
            }
        }
        private bool Kiemtratendangnhap(string tendangnhap)
        {
            var result = Model.DataProvider.Ins.DB.TAIKHOANs.Where(x => x.ten_taikhoan == tendangnhap).Count();
            if (result != 0)
            {
                return true;
            }
            return false;
        }
        private void RemoveIteminList()
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (DeleteList.Where(x => x == List[i]).Count() != 0)
                {
                    if (List[i] == List[List.Count() - 1])
                    {
                        List.Remove(List[i]);
                        break;
                    }
                    else
                    {
                        List.Remove(List[i]);
                    }
                };
            }
        }

        private void RemoveIteminDb()
        {
            for (int i = 0; i < DeleteList.Count(); i++)
            {
                foreach (var item in Model.DataProvider.Ins.DB.TAIKHOANs)
                {
                    while (item == DeleteList[i])
                    {
                        Model.DataProvider.Ins.DB.TAIKHOANs.Remove(item);
                        break;
                    }
                }
            }
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        #endregion

    }
}
