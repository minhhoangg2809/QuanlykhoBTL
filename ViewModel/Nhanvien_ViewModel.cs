using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QLK_Dn.MySource;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace QLK_Dn.ViewModel
{
    public class Nhanvien_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.NHANVIEN> _List;

        public ObservableCollection<Model.NHANVIEN> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.QUYEN> _List_Quyen;

        public ObservableCollection<Model.QUYEN> List_Quyen
        {
            get { return _List_Quyen; }
            set { _List_Quyen = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHANVIEN> _DeleteList;

        public ObservableCollection<Model.NHANVIEN> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        Model.NHANVIEN _SelectedItem;

        public Model.NHANVIEN SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Manhanvien = _SelectedItem.ma_nhanvien;
                    Tennhanvien = _SelectedItem.ten_nhanvien;
                    Diachi = _SelectedItem.diachi;
                    Sodienthoai = _SelectedItem.sodienthoai;
                    Ngaysinh = MyStaticMethods.DateVNtoUS(_SelectedItem.ngaysinh);
                    SQuyen = _SelectedItem.QUYEN;
                }
                OnPropertyChanged();
            }
        }

        #region SelectedItem.prop

        private Model.QUYEN _SQuyen;

        public Model.QUYEN SQuyen
        {
            get { return _SQuyen; }
            set { _SQuyen = value; OnPropertyChanged(); }
        }

        private string _Manhanvien;

        public string Manhanvien
        {
            get { return _Manhanvien; }
            set { _Manhanvien = value; OnPropertyChanged(); }
        }

        private string _Tennhanvien;

        public string Tennhanvien
        {
            get { return _Tennhanvien; }
            set { _Tennhanvien = value; OnPropertyChanged(); }
        }

        private string _Sodienthoai;

        public string Sodienthoai
        {
            get { return _Sodienthoai; }
            set { _Sodienthoai = value; OnPropertyChanged(); }
        }
        private string _Diachi;

        public string Diachi
        {
            get { return _Diachi; }
            set { _Diachi = value; OnPropertyChanged(); }
        }

        private string _Ngaysinh;

        public string Ngaysinh
        {
            get { return _Ngaysinh; }
            set { _Ngaysinh = value; OnPropertyChanged(); }
        }
        #endregion

        #region Command
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand Update_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
        public ICommand Reset_Command { get; set; }
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

        public Nhanvien_ViewModel()
        {
            List = new ObservableCollection<Model.NHANVIEN>(Model.DataProvider.Ins.DB.NHANVIENs.Where(x => x.IsDeleted == false));
            DeleteList = new ObservableCollection<Model.NHANVIEN>();

            List_Quyen = new ObservableCollection<Model.QUYEN>(Model.DataProvider.Ins.DB.QUYENs);

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

            #region Tao moi
            Reset_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                SelectedItem = null;
                Tennhanvien = "";
                Diachi = "";
                Sodienthoai = "";
                Ngaysinh = "";
                SQuyen = null;
            });
            #endregion

            #region Phan them
            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Tennhanvien) || string.IsNullOrEmpty(Sodienthoai) || string.IsNullOrEmpty(Diachi) || string.IsNullOrEmpty(Ngaysinh))
                    return false;

                long i = 0;
                if (!long.TryParse(Sodienthoai, out i))
                    return false;

                if (SQuyen == null)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = null;

                Model.NHANVIEN newItem = new Model.NHANVIEN()
                {
                    ma_nhanvien = MyStaticMethods.RandomInt(10),
                    ten_nhanvien = Tennhanvien,
                    ngaysinh = MyStaticMethods.FormatDateString(Ngaysinh),
                    QUYEN = SQuyen,
                    diachi = Diachi,
                    sodienthoai = Sodienthoai,
                    IsDeleted = false
                };

                Model.Nhanvien_Service.Insert(newItem);

                List.Insert(0, newItem);
                SelectedItem = newItem;

                Active = true;
                Message = "Thêm mới thành công !!!";
            });
            #endregion

            #region Phan sua
            Update_Command = new RelayCommand<object>(p =>
            {
                if (SelectedItem == null)
                    return false;

                if (string.IsNullOrEmpty(Tennhanvien) || string.IsNullOrEmpty(Sodienthoai) || string.IsNullOrEmpty(Diachi) || string.IsNullOrEmpty(Ngaysinh))
                    return false;

                long i = 0;
                if (!long.TryParse(Sodienthoai, out i))
                    return false;

                if (SQuyen == null)
                    return false;

                return true;
            }, p =>
            {
                Model.NHANVIEN UpdateItem = new Model.NHANVIEN()
                {
                    ten_nhanvien = Tennhanvien,
                    ngaysinh = MyStaticMethods.FormatDateString(Ngaysinh),
                    QUYEN = SQuyen,
                    diachi = Diachi,
                    sodienthoai = Sodienthoai
                };
                Model.Nhanvien_Service.Update(UpdateItem, Manhanvien);

                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i] == SelectedItem)
                    {
                        List[i] = new Model.NHANVIEN()
                        {
                            ma_nhanvien = Manhanvien,
                            ten_nhanvien = Tennhanvien,
                            diachi = Diachi,
                            sodienthoai = Sodienthoai,
                            ngaysinh = MyStaticMethods.FormatDateString(Ngaysinh),
                            QUYEN = _SQuyen
                        };
                        break;
                    }
                }

                //MessageBox.Show("Chỉnh sửa thành công", "THÔNG BÁO");

                SelectedItem = null;
                Tennhanvien = "";
                Diachi = "";
                Sodienthoai = "";
                Ngaysinh = "";
                SQuyen = null;

                Active = true;
                Message = "Chỉnh sửa thành công !!!";
            });
            #endregion

            #region Phan xoa

            DeleteShow_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                IsOpen = true;
                Content = "  Xóa các bản ghi được chọn ???";
            });

            AddDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Add(List.Where(x => x.ma_nhanvien == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_nhanvien == p.Uid.ToString()).SingleOrDefault());
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
                Capnhat_dboTaiKhoan();

                DeleteList = new ObservableCollection<Model.NHANVIEN>();
                IsOpen = false;
                SelectedItem = null;
            });
            #endregion
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
                foreach (var item in Model.DataProvider.Ins.DB.NHANVIENs.ToList())
                {
                    while (item == DeleteList[i])
                    {
                        item.IsDeleted = true;
                        Model.DataProvider.Ins.DB.SaveChanges();
                        break;
                    }
                }
            }

        }

        private void Capnhat_dboTaiKhoan()
        {
            for (int i = 0; i < DeleteList.Count(); i++)
            {
                foreach (var item in Model.DataProvider.Ins.DB.TAIKHOANs.ToList())
                {
                    while (item.NHANVIEN == DeleteList[i])
                    {
                        item.IsDeleted = true;
                        Model.DataProvider.Ins.DB.SaveChanges();
                        break;
                    }
                }
            }
        }
    }
}
