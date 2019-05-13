using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using QLK_Dn.MySource;
using System.Windows;

namespace QLK_Dn.ViewModel
{
    public class Loaimathang_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.LOAIHANG> _List;

        public ObservableCollection<Model.LOAIHANG> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.LOAIHANG> _DeleteList;

        public ObservableCollection<Model.LOAIHANG> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }


        private Model.LOAIHANG _SelectedItem;

        public Model.LOAIHANG SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Maloaihang = _SelectedItem.ma_loaihang;
                    Tenloaihang = _SelectedItem.ten_loaihang;
                    Mota = _SelectedItem.mota;
                }
                OnPropertyChanged();
            }
        }

        #region SelectedItem.prop

        private string _Maloaihang;

        public string Maloaihang
        {
            get { return _Maloaihang; }
            set { _Maloaihang = value; OnPropertyChanged(); }
        }

        private string _Tenloaihang;

        public string Tenloaihang
        {
            get { return _Tenloaihang; }
            set { _Tenloaihang = value; OnPropertyChanged(); }
        }

        private string _Mota;

        public string Mota
        {
            get { return _Mota; }
            set { _Mota = value; OnPropertyChanged(); }
        }

        #endregion

        #region Command
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand Update_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
        public ICommand Delete_Command { get; set; }
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

        public Loaimathang_ViewModel()
        {
            List = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
            DeleteList = new ObservableCollection<Model.LOAIHANG>();

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
                if (string.IsNullOrEmpty(Tenloaihang))
                    return false;

                var check = Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.ten_loaihang == Tenloaihang);
                if (check == null || check.Count() != 0)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = null;

                Model.LOAIHANG newItem = new Model.LOAIHANG()
                {
                    ma_loaihang = MyStaticMethods.RandomString(5, false),
                    ten_loaihang = Tenloaihang,
                    mota = (string.IsNullOrEmpty(Mota)) ? null : Mota,
                    IsDeleted = false
                };

                Model.Loaimathang_Service.Insert(newItem);

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

                if (string.IsNullOrEmpty(Tenloaihang))
                    return false;

                return true;
            }, p =>
            {
                Model.LOAIHANG UpdateItem = new Model.LOAIHANG()
                {
                    ten_loaihang = Tenloaihang,
                    mota = string.IsNullOrEmpty(Mota) ? null : Mota
                };
                Model.Loaimathang_Service.Update(UpdateItem, Maloaihang);

                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i] == SelectedItem)
                    {
                        List[i] = new Model.LOAIHANG()
                        {
                            ma_loaihang = Maloaihang,
                            ten_loaihang = Tenloaihang,
                            mota = (string.IsNullOrEmpty(Mota)) ? null : Mota
                        };
                        break;
                    }
                }
                //MessageBox.Show("Chỉnh sửa thành công", "THÔNG BÁO");

                SelectedItem = null;
                Tenloaihang = "";
                Mota = "";

                Active = true;
                Message = "Chỉnh sửa thành công !!!";
            });
            #endregion

            #region Phan xoa
            AddDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Add(List.Where(x => x.ma_loaihang == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_loaihang == p.Uid.ToString()).SingleOrDefault());
            });

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

            Delete_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                RemoveIteminDb();
                RemoveIteminList();

                DeleteList = new ObservableCollection<Model.LOAIHANG>();
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
                Tenloaihang = "";
                Mota = "";
            });
            #endregion

            #region Phan tim kiem

            Search_Command = new RelayCommand<TextBox>(p =>
            {
                return true;
            }, p =>
            {
                string str = p.Text;
                List = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));

                if (!string.IsNullOrEmpty(str))
                {
                    var filterlist = List.Where(x => x.ten_loaihang.Contains(str));

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
                    List = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
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
                foreach (var item in Model.DataProvider.Ins.DB.LOAIHANGs.ToList())
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
