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
    public class Xuathang_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.CHITIETPHIEUXUAT> _List;

        public ObservableCollection<Model.CHITIETPHIEUXUAT> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.CHITIETPHIEUXUAT> _DeleteList;

        public ObservableCollection<Model.CHITIETPHIEUXUAT> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private Model.CHITIETPHIEUXUAT _SelectedItem;

        public Model.CHITIETPHIEUXUAT SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.MATHANG> _ListMathang;

        public ObservableCollection<Model.MATHANG> ListMathang
        {
            get { return _ListMathang; }
            set { _ListMathang = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.CHITIETPHIEUNHAP> _ListPhieunhap;

        public ObservableCollection<Model.CHITIETPHIEUNHAP> ListPhieunhap
        {
            get { return _ListPhieunhap; }
            set { _ListPhieunhap = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Model.KHACHHANG> _ListKhachhang;

        public ObservableCollection<Model.KHACHHANG> ListKhachhang
        {
            get { return _ListKhachhang; }
            set { _ListKhachhang = value; OnPropertyChanged(); }
        }

        #region prop

        private ObservableCollection<string> _ListSoluong;

        public ObservableCollection<string> ListSoluong
        {
            get { return _ListSoluong; }
            set { _ListSoluong = value; OnPropertyChanged(); }
        }

        private Model.MATHANG _SMathang;

        public Model.MATHANG SMathang
        {
            get { return _SMathang; }
            set { _SMathang = value; OnPropertyChanged(); }
        }

        private Model.CHITIETPHIEUNHAP _SPhieunhap;

        public Model.CHITIETPHIEUNHAP SPhieunhap
        {
            get { return _SPhieunhap; }
            set { _SPhieunhap = value; OnPropertyChanged(); }
        }

        private Model.KHACHHANG _SKhachhang;

        public Model.KHACHHANG SKhachhang
        {
            get { return _SKhachhang; }
            set { _SKhachhang = value; OnPropertyChanged(); }
        }

        private string _Soluongxuat;

        public string Soluongxuat
        {
            get { return _Soluongxuat; }
            set { _Soluongxuat = value; OnPropertyChanged(); }
        }

        private string _Soluongthucxuat;

        public string Soluongthucxuat
        {
            get { return _Soluongthucxuat; }
            set { _Soluongthucxuat = value; OnPropertyChanged(); }
        }

        private string _Dongiaxuat;

        public string Dongiaxuat
        {
            get { return _Dongiaxuat; }
            set { _Dongiaxuat = value; OnPropertyChanged(); }
        }

        private string _Ghichu;

        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; OnPropertyChanged(); }
        }

        private string _Ngay;

        public string Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; OnPropertyChanged(); }
        }

        #endregion

        #region Filter data

        private ObservableCollection<Model.CHITIETPHIEUXUAT> _ListPhieu_Filter;

        public ObservableCollection<Model.CHITIETPHIEUXUAT> ListPhieu_Filter
        {
            get { return _ListPhieu_Filter; }
            set { _ListPhieu_Filter = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Model.MATHANG> _ListMathang_Filter;

        public ObservableCollection<Model.MATHANG> ListMathang_Filter
        {
            get { return _ListMathang_Filter; }
            set { _ListMathang_Filter = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.KHACHHANG> _ListKhachhang_Filter;

        public ObservableCollection<Model.KHACHHANG> ListKhachhang_Filter
        {
            get { return _ListKhachhang_Filter; }
            set { _ListKhachhang_Filter = value; OnPropertyChanged(); }
        }

        private Model.KHACHHANG _SKhachhang_Filter;

        public Model.KHACHHANG SKhachhang_Filter
        {
            get { return _SKhachhang_Filter; }
            set { _SKhachhang_Filter = value; OnPropertyChanged(); }
        }

        Model.CHITIETPHIEUXUAT _SPhieuxuat_Filter;

        public Model.CHITIETPHIEUXUAT SPhieuxuat_Filter
        {
            get { return _SPhieuxuat_Filter; }
            set { _SPhieuxuat_Filter = value; OnPropertyChanged(); }
        }

        private Model.MATHANG _SMathang_Filter;

        public Model.MATHANG SMathang_Filter
        {
            get { return _SMathang_Filter; }
            set { _SMathang_Filter = value; OnPropertyChanged(); }
        }

        private string _Date_Start;

        public string Date_Start
        {
            get { return _Date_Start; }
            set { _Date_Start = value; OnPropertyChanged(); }
        }

        private string _Date_End;

        public string Date_End
        {
            get { return _Date_End; }
            set { _Date_End = value; OnPropertyChanged(); }
        }

        #endregion

        #region Filter Commands
        public ICommand Filter_Command { get; set; }
        public ICommand ResetFilter_Command { get; set; }
        public ICommand FilterPhieu_Command { get; set; }
        public ICommand FilterKhachhang_Command { get; set; }
        #endregion

        #region Commands
        public ICommand Select_mathang_Command { get; set; }
        public ICommand Select_phieunhap_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand InsertShow_Command { get; set; }
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
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

        private bool _IsOpen_insert;

        public bool IsOpen_insert
        {
            get { return _IsOpen_insert; }
            set { _IsOpen_insert = value; OnPropertyChanged(); }
        }

        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; OnPropertyChanged(); }
        }

        public ICommand CloseDialog_Command { get; set; }

        #endregion

        public Xuathang_ViewModel()
        {
            List = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ma_phieuxuat));
            DeleteList = new ObservableCollection<Model.CHITIETPHIEUXUAT>();

            ListMathang = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
            ListKhachhang = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));
            ListPhieunhap = new ObservableCollection<Model.CHITIETPHIEUNHAP>();

            ListSoluong = new ObservableCollection<string>();

            Active = false;
            IsOpen = false;
            IsOpen_insert = false;

            Active_Command = new RelayCommand<object>(p =>
            {
                if (Active == false)
                    return false;

                return true;
            }, p =>
            {
                Active = false;
            });

            CloseDialog_Command = new RelayCommand<MaterialDesignThemes.Wpf.DialogHost>(p =>
            {
                return true;
            }, p =>
            {
                p.IsOpen = false;
            });

            #region Lua chon mat hang va phieu nhap

            Select_mathang_Command = new RelayCommand<ComboBox>(p =>
            {
                if (SMathang == null)
                    return false;

                return true;
            }, p =>
            {
                ListPhieunhap = new ObservableCollection<Model.CHITIETPHIEUNHAP>();
                foreach (var item in Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == false))
                {
                    while (item.MATHANG == SMathang)
                    {
                        ListPhieunhap.Add(item);
                        break;
                    }
                }
            });

            Select_phieunhap_Command = new RelayCommand<ComboBox>(p =>
            {
                if (SMathang == null || SPhieunhap == null)
                    return false;

                return true;
            }, p =>
            {
                Dongiaxuat = SPhieunhap.giaxuat.ToString();

                ListSoluong = new ObservableCollection<string>();
                for (int i = 1; i <= SPhieunhap.soluongton; i++)
                {
                    ListSoluong.Add(i.ToString());
                }
            });

            #endregion


            #region Them moi

            InsertShow_Command = new RelayCommand<object>(p =>
            {
                if (SPhieunhap == null || SKhachhang == null || SMathang == null)
                    return false;

                if (string.IsNullOrEmpty(Soluongxuat) || string.IsNullOrEmpty(Soluongthucxuat))
                    return false;

                int soluongnhap = 0;
                if (!int.TryParse(Soluongxuat.Replace(" ", String.Empty), out soluongnhap))
                    return false;

                int soluongthucnhap = 0;
                if (!int.TryParse(Soluongthucxuat.Replace(" ", String.Empty), out soluongthucnhap))
                    return false;

                if (IsOpen_insert == true || IsOpen == true)
                    return false;

                return true;
            }, p =>
            {
                IsOpen_insert = true;

                string date_str = MyStaticMethods.ConvertDate2Vn_Today();
                Ngay = date_str;
            });

            Insert_Command = new RelayCommand<object>(p =>
            {
                if (SPhieunhap == null || SKhachhang == null || SMathang == null)
                    return false;

                if (string.IsNullOrEmpty(Soluongxuat) || string.IsNullOrEmpty(Soluongthucxuat))
                    return false;

                int soluongnhap = 0;
                if (!int.TryParse(Soluongxuat.Replace(" ", String.Empty), out soluongnhap))
                    return false;

                int soluongthucnhap = 0;
                if (!int.TryParse(Soluongthucxuat.Replace(" ", String.Empty), out soluongthucnhap))
                    return false;

                return true;
            }, p =>
            {
                string date_str = MyStaticMethods.ConvertDate2Vn_Today();
                Model.PHIEUXUAT Phieu = CheckPhieuxuat(date_str);

                Model.CHITIETPHIEUXUAT newPhieu = new Model.CHITIETPHIEUXUAT()
                {
                    ma_ctphieuxuat = MyStaticMethods.RandomInt(5) + "-" + SPhieunhap.MATHANG.ma_mathang,
                    CHITIETPHIEUNHAP = SPhieunhap,
                    KHACHHANG = SKhachhang,
                    PHIEUXUAT = Phieu,

                    soluongxuat = Convert.ToInt32(Soluongxuat),
                    soluongthucxuat = Convert.ToInt32(Soluongthucxuat),

                    nguoitao = getCurrentUser(),
                    ghichu = Ghichu != "" ? Ghichu : null,
                    IsDeleted = false,
                };

                Model.Xuathang_Service.Insert(newPhieu);

                Update_luonghang(Convert.ToInt32(Soluongthucxuat), newPhieu.ma_ctphieunhap);

                List.Insert(0, newPhieu);
                SelectedItem = newPhieu;

                Active = true;
                Message = "Thêm mới thành công !!!";

                IsOpen_insert = false;

            });

            #endregion

            #region Phan xoa

            DeleteShow_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                if (IsOpen_insert == true || IsOpen == true)
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
                DeleteList.Add(List.Where(x => x.ma_ctphieuxuat == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_ctphieuxuat == p.Uid.ToString()).SingleOrDefault());
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

                DeleteList = new ObservableCollection<Model.CHITIETPHIEUXUAT>();
                ListPhieu_Filter = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false));
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
                SMathang = null;
                SPhieunhap = null;
                SKhachhang = null;
                Soluongxuat = "";
                Soluongthucxuat = "";
                Dongiaxuat = "";
                SelectedItem = null;

                ListMathang = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                ListKhachhang = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));
                ListPhieunhap = new ObservableCollection<Model.CHITIETPHIEUNHAP>();

                ListSoluong = new ObservableCollection<string>();
            });
            #endregion

            #region Phan loc

            ListPhieu_Filter = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false));
            ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
            ListKhachhang_Filter = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));

            FilterPhieu_Command = new RelayCommand<ComboBox>(p =>
            {
                if (SPhieuxuat_Filter == null)
                    return false;

                return true;
            }, p =>
            {
                string mamathang = SPhieuxuat_Filter.CHITIETPHIEUNHAP.MATHANG.ma_mathang;

                FilterPhieu(mamathang);
            });


            ResetFilter_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                ListPhieu_Filter = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false));
                ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                ListKhachhang_Filter = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));

                SKhachhang_Filter = null;
                SMathang_Filter = null;
                SPhieuxuat_Filter = null;
                Date_Start = String.Empty;
                Date_End = String.Empty;

                List = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ma_phieuxuat));
            });
            Filter_Command = new RelayCommand<Button>(p =>
            {
                if (string.IsNullOrEmpty(Date_Start) || string.IsNullOrEmpty(Date_End))
                    return false;

                DateTime date_start = Convert.ToDateTime(Date_Start);
                DateTime date_end = Convert.ToDateTime(Date_End);
                if ((date_start > date_end) && DateTime.TryParse(Date_Start, out date_start) && DateTime.TryParse(Date_End, out date_end))
                    return false;

                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ma_phieuxuat));

                DateTime date_start = Convert.ToDateTime(Date_Start);
                DateTime date_end = Convert.ToDateTime(Date_End);

                FindByDate(date_start, date_end);

                if (SMathang_Filter != null)
                {
                    FindByMH(SMathang_Filter.ma_mathang);
                }

                if (SKhachhang_Filter != null)
                {
                    FindByKH(SKhachhang_Filter.ma_khachhang);
                }

                if (SPhieuxuat_Filter != null)
                {
                    FindByPH(SPhieuxuat_Filter.ma_ctphieuxuat);
                }
            });
            #endregion

        }

        #region Filter Methods
        private void FindByDate(DateTime date_start, DateTime date_end)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while ((MyStaticMethods.ConvertStringtoDate(List[i].PHIEUXUAT.ngayxuat)) < date_start || (MyStaticMethods.ConvertStringtoDate(List[i].PHIEUXUAT.ngayxuat) > date_end))
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

        private void FindByKH(string makh)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].KHACHHANG.ma_khachhang != makh)
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

        private void FindByMH(string mamathang)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].CHITIETPHIEUNHAP.MATHANG.ma_mathang != mamathang)
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

        private void FindByPH(string mactphieu)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].ma_ctphieuxuat != mactphieu)
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

        private void FilterMathang(string makh, string mamathang = null)
        {
            ListKhachhang_Filter = new ObservableCollection<Model.KHACHHANG>(Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.IsDeleted == false));

            for (int i = 0; i < ListKhachhang_Filter.Count(); i++)
            {
                while (ListKhachhang_Filter[i].ma_khachhang != makh)
                {
                    if (ListKhachhang_Filter[i] == ListKhachhang_Filter[ListKhachhang_Filter.Count() - 1])
                    {
                        ListKhachhang_Filter.Remove(ListKhachhang_Filter[i]);
                        break;
                    }
                    else
                    {
                        ListKhachhang_Filter.Remove(ListKhachhang_Filter[i]);
                    }
                };
            }

            if (mamathang != null)
            {
                ListPhieu_Filter = new ObservableCollection<Model.CHITIETPHIEUXUAT>(Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.IsDeleted == false));

                for (int i = 0; i < ListPhieu_Filter.Count(); i++)
                {
                    while (ListPhieu_Filter[i].CHITIETPHIEUNHAP.ma_mathang != mamathang)
                    {
                        if (ListPhieu_Filter[i] == ListPhieu_Filter[ListPhieu_Filter.Count() - 1])
                        {
                            ListPhieu_Filter.Remove(ListPhieu_Filter[i]);
                            break;
                        }
                        else
                        {
                            ListPhieu_Filter.Remove(ListPhieu_Filter[i]);
                        }
                    };
                }
            }
        }

        private void FilterPhieu(string mamathang)
        {
            ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));

            for (int i = 0; i < ListMathang_Filter.Count(); i++)
            {
                while (ListMathang_Filter[i].ma_mathang != mamathang)
                {
                    if (ListMathang_Filter[i] == ListMathang_Filter[ListMathang_Filter.Count() - 1])
                    {
                        ListMathang_Filter.Remove(ListMathang_Filter[i]);
                        break;
                    }
                    else
                    {
                        ListMathang_Filter.Remove(ListMathang_Filter[i]);
                    }
                };
            }
        }

        #endregion

        #region Methods
        private Model.PHIEUXUAT CheckPhieuxuat(string str)
        {
            Model.PHIEUXUAT result = Model.DataProvider.Ins.DB.PHIEUXUATs.Where(x => x.ngayxuat == str).SingleOrDefault();
            if (result == null)
            {
                Model.PHIEUXUAT newItem = new Model.PHIEUXUAT()
                {
                    ma_phieuxuat = Guid.NewGuid().ToString(),
                    ngayxuat = MyStaticMethods.ConvertDate2Vn_Today(),
                };

                Model.DataProvider.Ins.DB.PHIEUXUATs.Add(newItem);
                Model.DataProvider.Ins.DB.SaveChanges();

                return newItem;
            }

            return result;
        }

        private string getCurrentUser()
        {
            string result = Taikhoan_ViewModel.getCurrent();
            return result;
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
                foreach (var item in Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.ToList())
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

        private void Update_luonghang(int soluongxuat, string ma)
        {
            var item = Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.ma_ctphieunhap == ma).SingleOrDefault();

            item.soluongton = item.soluongton - soluongxuat;
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        #endregion
    }
}
