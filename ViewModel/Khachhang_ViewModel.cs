using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLK_Dn.ViewModel
{
    public class Khachhang_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.KHACHHANG> _List;

        public ObservableCollection<Model.KHACHHANG> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.KHACHHANG> _DeleteList;

        public ObservableCollection<Model.KHACHHANG> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private Model.KHACHHANG _SelectedItem;

        public Model.KHACHHANG SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Makhachhang = _SelectedItem.ma_khachhang;
                    Tenkhachhang = _SelectedItem.ten_khachhang;
                    Diachi = _SelectedItem.diachi;
                    Sodienthoai = _SelectedItem.sodienthoai;
                }
                OnPropertyChanged();
            }
        }

        #region SelectedItem.prop

        private string _Makhachhang;

        public string Makhachhang
        {
            get { return _Makhachhang; }
            set { _Makhachhang = value; OnPropertyChanged(); }
        }

        private string _Tenkhachhang;

        public string Tenkhachhang
        {
            get { return _Tenkhachhang; }
            set { _Tenkhachhang = value; OnPropertyChanged(); }
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

        #endregion

        #region Command
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand Update_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
        public ICommand Reset_Command { get; set; }
        public ICommand Search_Command { get; set; }
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

        public Khachhang_ViewModel()
        {
            List = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));
            DeleteList = new ObservableCollection<Model.KHACHHANG>();

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

            #region Phan them
            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Tenkhachhang) || string.IsNullOrEmpty(Sodienthoai) || string.IsNullOrEmpty(Diachi))
                    return false;

                long i = 0;
                if (!long.TryParse(Sodienthoai, out i))
                    return false;

                var check = Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.ten_khachhang == Tenkhachhang);
                if (check == null || check.Count() != 0)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = null;

                Model.KHACHHANG newItem = new Model.KHACHHANG()
                {
                    ma_khachhang = Guid.NewGuid().ToString(),
                    ten_khachhang = Tenkhachhang,
                    diachi = Diachi,
                    sodienthoai = Sodienthoai,
                    IsDeleted = false
                };

                Model.Khachhang_Service.Insert(newItem);

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

                long i = 0;
                if (!long.TryParse(Sodienthoai, out i))
                    return false;

                if (string.IsNullOrEmpty(Tenkhachhang) || string.IsNullOrEmpty(Sodienthoai) || string.IsNullOrEmpty(Diachi))
                    return false;

                var check = Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.ten_khachhang == Tenkhachhang && x.diachi == Diachi && x.sodienthoai == Sodienthoai);
                if (check == null || check.Count() != 0)
                    return false;

                return true;
            }, p =>
            {
                Model.KHACHHANG UpdateItem = new Model.KHACHHANG()
                {
                    ten_khachhang = Tenkhachhang,
                    sodienthoai = Sodienthoai,
                    diachi = Diachi
                };
                Model.Khachhang_Service.Update(UpdateItem, Makhachhang);

                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i] == SelectedItem)
                    {
                        List[i] = new Model.KHACHHANG()
                        {
                            ma_khachhang = Makhachhang,
                            ten_khachhang = Tenkhachhang,
                            diachi = Diachi,
                            sodienthoai = Sodienthoai
                        };
                        break;
                    }
                }
                //MessageBox.Show("Chỉnh sửa thành công", "THÔNG BÁO");

                SelectedItem = null;
                Tenkhachhang = "";
                Sodienthoai = "";
                Diachi = "";

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
                DeleteList.Add(List.Where(x => x.ma_khachhang == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_khachhang == p.Uid.ToString()).SingleOrDefault());
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


                DeleteList = new ObservableCollection<Model.KHACHHANG>();
                IsOpen = false;
                SelectedItem = null;

            });
            #endregion

            #region Tao moi
            Reset_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                SelectedItem = null;
                Tenkhachhang = "";
                Diachi = "";
                Sodienthoai = "";
            });
            #endregion

            #region Phan tim kiem

            Search_Command = new RelayCommand<TextBox>(p =>
            {
                return true;
            }, p =>
            {
                string str = p.Text;
                List = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));

                if (!string.IsNullOrEmpty(str))
                {
                    var filterlist = List.Where(x => x.ten_khachhang.Contains(str)||x.diachi.Contains(str)||x.sodienthoai.Contains(str));

                    for (int i = 0; i < List.Count(); i++)
                    {
                        while (!filterlist.Contains(List[i]))
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
                        }
                    }
                }
                else
                {
                    List = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));
                }
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
                foreach (var item in Model.DataProvider.Ins.DB.KHACHHANGs.ToList())
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
    }
}

