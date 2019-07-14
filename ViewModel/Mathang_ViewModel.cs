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
using System.ComponentModel;

namespace QLK_Dn.ViewModel
{
    class Mathang_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.MATHANG> _List;

        public ObservableCollection<Model.MATHANG> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.MATHANG> _DeleteList;

        public ObservableCollection<Model.MATHANG> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.LOAIHANG> _List_Loai;

        public ObservableCollection<Model.LOAIHANG> List_Loai
        {
            get { return _List_Loai; }
            set { _List_Loai = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHACUNGCAP> _List_Nhacungcap;

        public ObservableCollection<Model.NHACUNGCAP> List_Nhacungcap
        {
            get { return _List_Nhacungcap; }
            set { _List_Nhacungcap = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.DONVITINH> _List_Donvi;

        public ObservableCollection<Model.DONVITINH> List_Donvi
        {
            get { return _List_Donvi; }
            set { _List_Donvi = value; OnPropertyChanged(); }
        }

        private Model.MATHANG _SelectedItem;

        public Model.MATHANG SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Mamathang = _SelectedItem.ma_mathang;
                    Tenmathang = _SelectedItem.ten_mathang;
                    Hang = _SelectedItem.hang;
                    Dong = _SelectedItem.dong;
                    SLoai = _SelectedItem.LOAIHANG;
                    SNhacungcap = _SelectedItem.NHACUNGCAP;
                    SDonvi = _SelectedItem.DONVITINH;
                    Mota = _SelectedItem.mota;
                }
                OnPropertyChanged();
            }
        }

        #region Filter data

        private ObservableCollection<Model.LOAIHANG> _ListLoai_Filter;

        public ObservableCollection<Model.LOAIHANG> ListLoai_Filter
        {
            get { return _ListLoai_Filter; }
            set { _ListLoai_Filter = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Model.DONVITINH> _ListDonvi_Filter;

        public ObservableCollection<Model.DONVITINH> ListDonvi_Filter
        {
            get { return _ListDonvi_Filter; }
            set { _ListDonvi_Filter = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHACUNGCAP> _ListNhacungcap_Filter;

        public ObservableCollection<Model.NHACUNGCAP> ListNhacungcap_Filter
        {
            get { return _ListNhacungcap_Filter; }
            set { _ListNhacungcap_Filter = value; OnPropertyChanged(); }
        }

        private Model.NHACUNGCAP _SNhacungcap_Filter;

        public Model.NHACUNGCAP SNhacungcap_Filter
        {
            get { return _SNhacungcap_Filter; }
            set { _SNhacungcap_Filter = value; OnPropertyChanged(); }
        }

        Model.LOAIHANG _SLoai_Filter;

        public Model.LOAIHANG SLoai_Filter
        {
            get { return _SLoai_Filter; }
            set { _SLoai_Filter = value; OnPropertyChanged(); }
        }

        private Model.DONVITINH _SDonvi_Filter;

        public Model.DONVITINH SDonvi_Filter
        {
            get { return _SDonvi_Filter; }
            set { _SDonvi_Filter = value; OnPropertyChanged(); }
        }

        private bool _IsOpen_Filter;

        public bool IsOpen_Filter
        {
            get { return _IsOpen_Filter; }
            set { _IsOpen_Filter = value; OnPropertyChanged(); }
        }


        #endregion

        #region SelectedItem.prop

        private string _Mamathang;

        public string Mamathang
        {
            get { return _Mamathang; }
            set { _Mamathang = value; OnPropertyChanged(); }
        }

        private string _Tenmathang;

        public string Tenmathang
        {
            get { return _Tenmathang; }
            set { _Tenmathang = value; OnPropertyChanged(); }
        }

        private string _Hang;

        public string Hang
        {
            get { return _Hang; }
            set { _Hang = value; OnPropertyChanged(); }
        }

        private string _Dong;

        public string Dong
        {
            get { return _Dong; }
            set { _Dong = value; OnPropertyChanged(); }
        }

        private Model.LOAIHANG _SLoai;

        public Model.LOAIHANG SLoai
        {
            get { return _SLoai; }
            set { _SLoai = value; OnPropertyChanged(); }
        }

        private Model.DONVITINH _SDonvi;

        public Model.DONVITINH SDonvi
        {
            get { return _SDonvi; }
            set { _SDonvi = value; OnPropertyChanged(); }
        }

        private Model.NHACUNGCAP _SNhacungcap;

        public Model.NHACUNGCAP SNhacungcap
        {
            get { return _SNhacungcap; }
            set { _SNhacungcap = value; OnPropertyChanged(); }
        }

        private string _Mota;

        public string Mota
        {
            get { return _Mota; }
            set { _Mota = value; OnPropertyChanged(); }
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
        public ICommand OpenFilter_Command { get; set; }
        public ICommand Filter_Command { get; set; }
        public ICommand ResetFilter_Command { get; set; }

        #endregion

        #region Commands Sap xep

        public ICommand OrderbyTenMathang_Command { get; set; }
        public ICommand OrderbyTennhacungcap_Command { get; set; }
        public ICommand OrderbyTenloai_Command { get; set; }
        public ICommand OrderbyTendonvi_Command { get; set; }

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

        public Mathang_ViewModel()
        {
            List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
            DeleteList = new ObservableCollection<Model.MATHANG>();

            List_Loai = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
            List_Donvi = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));
            List_Nhacungcap = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

            Active = false;
            IsOpen = false;
            IsOpen_Filter = false;

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
                List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                DeleteList = new ObservableCollection<Model.MATHANG>();

                List_Loai = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
                List_Donvi = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));
                List_Nhacungcap = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

                Active = false;
                IsOpen = false;
                IsOpen_Filter = false;

                ListDonvi_Filter = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));
                ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
                ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));

            });

            #region Tao moi
            Reset_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                SelectedItem = null;
                Tenmathang = "";
                Dong = "";
                Hang = "";
                SNhacungcap = null;
                SLoai = null;
                SDonvi = null;
                Mota = "";
            });
            #endregion

            #region Phan them
            Insert_Command = new RelayCommand<object>(p =>
            {
                if (string.IsNullOrEmpty(Tenmathang) || string.IsNullOrEmpty(Hang) || string.IsNullOrEmpty(Dong))
                    return false;

                if (SDonvi == null || SNhacungcap == null || SLoai == null)
                    return false;

                return true;
            }, p =>
            {
                SelectedItem = null;

                Model.MATHANG newItem = new Model.MATHANG()
                {
                    ma_mathang = MyStaticMethods.RandomInt(10),
                    ten_mathang = Tenmathang,
                    dong = Dong,
                    hang = Hang,
                    LOAIHANG = SLoai,
                    DONVITINH = SDonvi,
                    NHACUNGCAP = SNhacungcap,
                    mota = (string.IsNullOrEmpty(Mota)) ? null : Mota,
                    IsDeleted = false
                };

                Model.Mathang_Service.Insert(newItem);

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

                if (string.IsNullOrEmpty(Tenmathang) || string.IsNullOrEmpty(Hang) || string.IsNullOrEmpty(Dong))
                    return false;

                if (SDonvi == null || SNhacungcap == null || SLoai == null)
                    return false;

                return true;
            }, p =>
            {
                Model.MATHANG UpdateItem = new Model.MATHANG()
                {
                    ten_mathang = Tenmathang,
                    dong = _Dong,
                    hang = _Hang,
                    LOAIHANG = SLoai,
                    NHACUNGCAP = SNhacungcap,
                    DONVITINH = SDonvi,
                    mota = (string.IsNullOrEmpty(Mota)) ? null : Mota
                };
                Model.Mathang_Service.Update(UpdateItem, Mamathang);

                for (int i = 0; i < List.Count(); i++)
                {
                    if (List[i] == SelectedItem)
                    {
                        List[i] = new Model.MATHANG()
                        {
                            ma_mathang = Mamathang,
                            ten_mathang = Tenmathang,
                            dong = Dong,
                            hang = Hang,
                            NHACUNGCAP = SNhacungcap,
                            DONVITINH = SDonvi,
                            LOAIHANG = SLoai,
                            mota = (string.IsNullOrEmpty(Mota)) ? null : Mota
                        };
                        break;
                    }
                }
                //MessageBox.Show("Chỉnh sửa thành công", "THÔNG BÁO");

                SelectedItem = null;
                Tenmathang = "";
                Dong = "";
                Hang = "";
                SNhacungcap = null;
                SLoai = null;
                SDonvi = null;
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
                DeleteList.Add(List.Where(x => x.ma_mathang == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_mathang == p.Uid.ToString()).SingleOrDefault());
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

                DeleteList = new ObservableCollection<Model.MATHANG>();
                IsOpen = false;
                SelectedItem = null;
            });
            #endregion

            #region Phan loc

            ListDonvi_Filter = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));
            ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
            ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));

            OpenFilter_Command = new RelayCommand<object>(p =>
            {
                if (IsOpen == true || IsOpen_Filter == true)
                    return false;

                return true;

            }, p =>
            {
                IsOpen_Filter = true;
            });

            ResetFilter_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));

                SLoai_Filter = null;
                SNhacungcap_Filter = null;
                SDonvi_Filter = null;

                IsOpen_Filter = false;
            });

            Filter_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));

                if (SLoai_Filter != null)
                {
                    FilterbyLoaihang(SLoai_Filter.ma_loaihang);
                }
                if (SNhacungcap_Filter != null)
                {
                    FilterbyNhacungcap(SNhacungcap_Filter.ma_nhacungcap);
                }
                if (SDonvi_Filter != null)
                {
                    FilterbyDonvi(SDonvi_Filter.ma_donvi);
                }

                IsOpen_Filter = false;
            });

            #endregion

            #region Phan sap xep

            OrderbyTenMathang_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.ten_mathang));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.ten_mathang));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            OrderbyTennhacungcap_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.NHACUNGCAP.ten_nhacungcap));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.NHACUNGCAP.ten_nhacungcap));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            OrderbyTenloai_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.LOAIHANG.ten_loaihang));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.LOAIHANG.ten_loaihang));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            OrderbyTendonvi_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.MATHANG> chkList = new ObservableCollection<Model.MATHANG>(List.OrderByDescending(x => x.DONVITINH.ten_donvi));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.MATHANG>(List.OrderBy(x => x.DONVITINH.ten_donvi));
                }
                else
                {
                    List = new ObservableCollection<Model.MATHANG>(chkList);
                }
            });

            #endregion
        }

        #region Methods

        private void FilterbyNhacungcap(string ma_nhacungcap)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].NHACUNGCAP.ma_nhacungcap != ma_nhacungcap)
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

        private void FilterbyLoaihang(string ma_loai)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].LOAIHANG.ma_loaihang != ma_loai)
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

        private void FilterbyDonvi(string ma_donvi)
        {

            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].DONVITINH.ma_donvi != ma_donvi)
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
                foreach (var item in Model.DataProvider.Ins.DB.MATHANGs.ToList())
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
