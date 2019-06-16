using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace QLK_Dn.ViewModel
{
    public class Nhacungcap_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.NHACUNGCAP> _List;

        public ObservableCollection<Model.NHACUNGCAP> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHACUNGCAP> _DeleteList;

        public ObservableCollection<Model.NHACUNGCAP> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private Model.NHACUNGCAP _SelectedItem;

        public Model.NHACUNGCAP SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Manhacungcap = _SelectedItem.ma_nhacungcap;
                    Tennhacungcap = _SelectedItem.ten_nhacungcap;
                    Diachi = _SelectedItem.diachi;
                    Sodienthoai = _SelectedItem.sodienthoai;
                }
                OnPropertyChanged();
            }
        }

        #region SelectedItem.prop

        private string _Manhacungcap;

        public string Manhacungcap
        {
            get { return _Manhacungcap; }
            set { _Manhacungcap = value; OnPropertyChanged(); }
        }

        private string _Tennhacungcap;

        public string Tennhacungcap
        {
            get { return _Tennhacungcap; }
            set { _Tennhacungcap = value; OnPropertyChanged(); }
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
        public ICommand Load_Command { get; set; }
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand Update_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
        public ICommand Reset_Command { get; set; }
        public ICommand Search_Command { get; set; }
        public ICommand Sort_Command { get; set; }
        public ICommand SortbyDiachi_Command { get; set; }
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

        public Nhacungcap_ViewModel()
        {
            List = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
            DeleteList = new ObservableCollection<Model.NHACUNGCAP>();

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

            Load_Command = new RelayCommand<object>(p => 
            {
                return true;
            }, p => 
            {
                List = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
                DeleteList = new ObservableCollection<Model.NHACUNGCAP>();

                Active = false;
                IsOpen = false;

            });

            #region Phan them
            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Tennhacungcap) || string.IsNullOrEmpty(Sodienthoai) || string.IsNullOrEmpty(Diachi))
                    return false;

                int i = 0;
                if (!Int32.TryParse(Sodienthoai, out i))
                    return false;

                var check = Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.ten_nhacungcap == Tennhacungcap);
                if (check == null || check.Count() != 0)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = null;

                Model.NHACUNGCAP newItem = new Model.NHACUNGCAP()
                {
                    ma_nhacungcap = Guid.NewGuid().ToString(),
                    ten_nhacungcap = Tennhacungcap,
                    diachi = Diachi,
                    sodienthoai = Sodienthoai,
                    IsDeleted = false
                };

                Model.Nhacungcap_Service.Insert(newItem);

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

                int i = 0;
                if (!Int32.TryParse(Sodienthoai, out i))
                    return false;

                if (string.IsNullOrEmpty(Tennhacungcap) || string.IsNullOrEmpty(Sodienthoai) || string.IsNullOrEmpty(Diachi))
                    return false;

                var check = Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.ten_nhacungcap == Tennhacungcap && x.diachi == Diachi && x.sodienthoai == Sodienthoai);
                if (check == null || check.Count() != 0)
                    return false;

                return true;
            }, p =>
            {
                Model.NHACUNGCAP UpdateItem = new Model.NHACUNGCAP()
                {
                    ten_nhacungcap = Tennhacungcap,
                    sodienthoai = Sodienthoai,
                    diachi = Diachi
                };
                Model.Nhacungcap_Service.Update(UpdateItem, Manhacungcap);

                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i] == SelectedItem)
                    {
                        List[i] = new Model.NHACUNGCAP()
                        {
                            ma_nhacungcap = Manhacungcap,
                            ten_nhacungcap = Tennhacungcap,
                            diachi = Diachi,
                            sodienthoai = Sodienthoai
                        };
                        break;
                    }
                }
                //MessageBox.Show("Chỉnh sửa thành công", "THÔNG BÁO");

                SelectedItem = null;
                Tennhacungcap = "";
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
                DeleteList.Add(List.Where(x => x.ma_nhacungcap == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_nhacungcap == p.Uid.ToString()).SingleOrDefault());
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

                DeleteList = new ObservableCollection<Model.NHACUNGCAP>();
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
                Tennhacungcap = "";
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
                List = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

                if (!string.IsNullOrEmpty(str))
                {
                    var filterlist = List.Where(x => x.ten_nhacungcap.Contains(str)||x.diachi.Contains(str)||x.sodienthoai.Contains(str));

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
                    List = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
                }
            });

            #endregion

            #region Phan sap xep

            Sort_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                ObservableCollection<Model.NHACUNGCAP> chkList = new ObservableCollection<Model.NHACUNGCAP>(List.OrderByDescending(x => x.ten_nhacungcap));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.NHACUNGCAP>(List.OrderBy(x => x.ten_nhacungcap));
                }
                else
                {
                    List = new ObservableCollection<Model.NHACUNGCAP>(chkList);
                }
            });

            SortbyDiachi_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                ObservableCollection<Model.NHACUNGCAP> chkList = new ObservableCollection<Model.NHACUNGCAP>(List.OrderByDescending(x => x.diachi));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.NHACUNGCAP>(List.OrderBy(x => x.diachi));
                }
                else
                {
                    List = new ObservableCollection<Model.NHACUNGCAP>(chkList);
                }
            });

            #endregion
        }

        #region Methods
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
                foreach (var item in Model.DataProvider.Ins.DB.NHACUNGCAPs.ToList())
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

        #endregion

    }
}
