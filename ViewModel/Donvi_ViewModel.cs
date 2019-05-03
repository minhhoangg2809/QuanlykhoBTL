using QLK_Dn.MySource;
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
    public class Donvi_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.DONVITINH> _List;

        public ObservableCollection<Model.DONVITINH> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.DONVITINH> _DeleteList;

        public ObservableCollection<Model.DONVITINH> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private Model.DONVITINH _SelectedItem;

        public Model.DONVITINH SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Madonvi = _SelectedItem.ma_donvi;
                    Tendonvi = _SelectedItem.ten_donvi;
                    Mota = _SelectedItem.mota;
                }
                OnPropertyChanged();
            }
        }

        #region SelectedItem.prop

        private string _Madonvi;

        public string Madonvi
        {
            get { return _Madonvi; }
            set { _Madonvi = value; OnPropertyChanged(); }
        }

        private string _Tendonvi;

        public string Tendonvi
        {
            get { return _Tendonvi; }
            set { _Tendonvi = value; OnPropertyChanged(); }
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

        public Donvi_ViewModel()
        {
            List = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));
            DeleteList = new ObservableCollection<Model.DONVITINH>();

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
                if (string.IsNullOrEmpty(Tendonvi))
                    return false;

                var check = Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.ten_donvi == Tendonvi);
                if (check == null || check.Count() != 0)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = null;

                Model.DONVITINH newItem = new Model.DONVITINH()
                {
                    ma_donvi = MyStaticMethods.RandomString(5, false),
                    ten_donvi = Tendonvi,
                    mota = (string.IsNullOrEmpty(Mota)) ? null : Mota,
                    IsDeleted = false
                };

                Model.Donvitinh_Service.Insert(newItem);

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

                if (string.IsNullOrEmpty(Tendonvi))
                    return false;

                return true;
            }, p =>
            {
                Model.DONVITINH UpdateItem = new Model.DONVITINH()
                {
                    ten_donvi = Tendonvi,
                    mota = string.IsNullOrEmpty(Mota) ? null : Mota
                };
                Model.Donvitinh_Service.Update(UpdateItem, Madonvi);

                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i] == SelectedItem)
                    {
                        List[i] = new Model.DONVITINH()
                        {
                            ma_donvi = Madonvi,
                            ten_donvi = Tendonvi,
                            mota = (string.IsNullOrEmpty(Mota)) ? null : Mota
                        };
                        break;
                    }
                }
                //MessageBox.Show("Chỉnh sửa thành công", "THÔNG BÁO");

                SelectedItem = null;
                Tendonvi = "";
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
                DeleteList.Add(List.Where(x => x.ma_donvi == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_donvi == p.Uid.ToString()).SingleOrDefault());
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

                    DeleteList = new ObservableCollection<Model.DONVITINH>();
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
                Tendonvi = "";
                Mota = "";
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
                foreach (var item in Model.DataProvider.Ins.DB.DONVITINHs.ToList())
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
