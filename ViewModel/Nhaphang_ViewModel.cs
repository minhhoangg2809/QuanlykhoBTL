using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QLK_Dn.MySource;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace QLK_Dn.ViewModel
{
    public class Nhaphang_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.CHITIETPHIEUNHAP> _List;

        public ObservableCollection<Model.CHITIETPHIEUNHAP> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.CHITIETPHIEUNHAP> _DeleteList;

        public ObservableCollection<Model.CHITIETPHIEUNHAP> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private Model.CHITIETPHIEUNHAP _SelectedItem;

        public Model.CHITIETPHIEUNHAP SelectedItem
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

        #region Filter data

        private ObservableCollection<Model.LOAIHANG> _ListLoai_Filter;

        public ObservableCollection<Model.LOAIHANG> ListLoai_Filter
        {
            get { return _ListLoai_Filter; }
            set { _ListLoai_Filter = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Model.MATHANG> _ListMathang_Filter;

        public ObservableCollection<Model.MATHANG> ListMathang_Filter
        {
            get { return _ListMathang_Filter; }
            set { _ListMathang_Filter = value; OnPropertyChanged(); }
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

        #region prop

        private Model.MATHANG _SMathang;

        public Model.MATHANG SMathang
        {
            get { return _SMathang; }
            set { _SMathang = value; OnPropertyChanged(); }
        }

        private string _Soluongnhap;

        public string Soluongnhap
        {
            get { return _Soluongnhap; }
            set { _Soluongnhap = value; OnPropertyChanged(); }
        }

        private string _Soluongthucnhap;

        public string Soluongthucnhap
        {
            get { return _Soluongthucnhap; }
            set { _Soluongthucnhap = value; OnPropertyChanged(); }
        }

        private string _Dongianhap;

        public string Dongianhap
        {
            get { return _Dongianhap; }
            set { _Dongianhap = value; OnPropertyChanged(); }
        }

        private string _Phantram;

        public string Phantram
        {
            get { return _Phantram; }
            set { _Phantram = value; OnPropertyChanged(); }
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

        #region Filter Commands
        public ICommand Filter_Command { get; set; }
        public ICommand ResetFilter_Command { get; set; }
        public ICommand FilterLoai_Command { get; set; }

        #endregion

        #region Command
        public ICommand Insert_Command { get; set; }
        public ICommand InsertShow_Command { get; set; }
        public ICommand Reset_Command { get; set; }
        public ICommand GetvalueTextbox_Command { get; set; }
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }
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

        public Nhaphang_ViewModel()
        {
            TaoDS_nhap();
            DeleteList = new ObservableCollection<Model.CHITIETPHIEUNHAP>();
            ListMathang = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));

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

            #region Tao moi
            Reset_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                SMathang = null;
                Soluongnhap = "";
                Soluongthucnhap = "";
                Dongianhap = "";
                Dongiaxuat = "";
                Phantram = "";
                SelectedItem = null;
            });
            #endregion

            #region Phan them

            GetvalueTextbox_Command = new RelayCommand<TextBox>(p =>
            {
                double d;
                if (!double.TryParse((p.Text), out d))
                    return false;

                if (string.IsNullOrEmpty(p.Text))
                    return false;

                if (SMathang == null)
                    return false;

                if (string.IsNullOrEmpty(Soluongnhap) || string.IsNullOrEmpty(Soluongthucnhap) || string.IsNullOrEmpty(Dongianhap))
                    return false;

                int dongianhap = 0;
                if (!int.TryParse(Dongianhap.Replace(" ", String.Empty), out dongianhap))
                    return false;

                int soluongnhap = 0;
                if (!int.TryParse(Soluongnhap.Replace(" ", String.Empty), out soluongnhap))
                    return false;

                int soluongthucnhap = 0;
                if (!int.TryParse(Soluongthucnhap.Replace(" ", String.Empty), out soluongthucnhap))
                    return false;

                return true;
            }, p =>
            {
                Dongiaxuat = String.Empty;

                double phantram = Convert.ToDouble(Phantram) / 100;
                double dongianhap = Convert.ToDouble(Dongianhap.Replace(" ", String.Empty));
                double dongiaxuat = ((phantram * dongianhap) + dongianhap);

                Dongiaxuat = dongiaxuat.ToString();
            });

            InsertShow_Command = new RelayCommand<object>(p =>
            {
                if (SMathang == null)
                    return false;

                if (string.IsNullOrEmpty(Soluongnhap) || string.IsNullOrEmpty(Soluongthucnhap) ||
                    string.IsNullOrEmpty(Dongiaxuat) || string.IsNullOrEmpty(Dongianhap) || string.IsNullOrEmpty(Phantram))
                    return false;

                int dongianhap = 0;
                if (!int.TryParse(Dongianhap.Replace(" ", String.Empty), out dongianhap))
                    return false;

                int soluongnhap = 0;
                if (!int.TryParse(Soluongnhap.Replace(" ", String.Empty), out soluongnhap))
                    return false;

                int soluongthucnhap = 0;
                if (!int.TryParse(Soluongthucnhap.Replace(" ", String.Empty), out soluongthucnhap))
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
                if (SMathang == null)
                    return false;

                if (string.IsNullOrEmpty(Soluongnhap) || string.IsNullOrEmpty(Soluongthucnhap) ||
                    string.IsNullOrEmpty(Dongiaxuat) || string.IsNullOrEmpty(Dongianhap) || string.IsNullOrEmpty(Phantram))
                    return false;

                int dongianhap = 0;
                if (!int.TryParse(Dongianhap.Replace(" ", String.Empty), out dongianhap))
                    return false;

                int soluongnhap = 0;
                if (!int.TryParse(Soluongnhap.Replace(" ", String.Empty), out soluongnhap))
                    return false;

                int soluongthucnhap = 0;
                if (!int.TryParse(Soluongthucnhap.Replace(" ", String.Empty), out soluongthucnhap))
                    return false;

                return true;
            }, p =>
            {
                string date_str = MyStaticMethods.ConvertDate2Vn_Today();
                Model.PHIEUNHAP Phieu = CheckPhieunhap(date_str);

                Model.CHITIETPHIEUNHAP newPhieu = new Model.CHITIETPHIEUNHAP()
                {
                    ma_ctphieunhap = MyStaticMethods.RandomInt(5) + "-" + SMathang.ma_mathang,
                    MATHANG = SMathang,
                    ma_phieunhap = Phieu.ma_phieunhap,

                    soluongnhap = Convert.ToInt32(Soluongnhap.Replace(" ", String.Empty)),
                    soluongthuc = Convert.ToInt32(Soluongthucnhap.Replace(" ", String.Empty)),
                    soluongton = Convert.ToInt32(Soluongthucnhap.Replace(" ", String.Empty)),

                    gianhap = Convert.ToDouble(Dongianhap.Replace(" ", String.Empty)),
                    giaxuat = Convert.ToDouble(Dongiaxuat.Replace(" ", String.Empty)),

                    nguoitao = getCurrentUser(),
                    ghichu = Ghichu != "" ? Ghichu : null,
                    IsDeleted = false,
                };

                Model.Nhaphang_Service.Insert(newPhieu);

                List.Insert(0, newPhieu);
                SelectedItem = newPhieu;

                Active = true;
                Message = "Thêm mới thành công !!!";
                IsOpen_insert = false;
            });

            #endregion

            #region Phan xoa

            AddDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Add(List.Where(x => x.ma_ctphieunhap == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.ma_ctphieunhap == p.Uid.ToString()).SingleOrDefault());
            });

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


            Delete_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                RemoveIteminDb();
                RemoveIteminList();


                DeleteList = new ObservableCollection<Model.CHITIETPHIEUNHAP>();
                IsOpen = false;
                SelectedItem = null;

            });
            #endregion

            #region Phan loc

            ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
            ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
            ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

            FilterLoai_Command = new RelayCommand<ComboBox>(p =>
            {
                return true;
            }, p =>
            {
                if (SLoai_Filter != null)
                {
                    string ma = SLoai_Filter.ma_loaihang;
                    FilterMathangby_Loai(ma);
                }
                else
                {
                    ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                }

            });

            ResetFilter_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
                ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

                SNhacungcap_Filter = null;
                SMathang_Filter = null;
                SLoai_Filter = null;
                Date_Start = String.Empty;
                Date_End = String.Empty;

                TaoDS_nhap();
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
                List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ma_phieunhap));

                DateTime date_start = Convert.ToDateTime(Date_Start);
                DateTime date_end = Convert.ToDateTime(Date_End);

                FindByDate(date_start, date_end);

                if (SMathang_Filter != null)
                {
                    FindByMH(SMathang_Filter.ma_mathang);
                }

                if (SNhacungcap_Filter != null)
                {
                    FindByNCC(SNhacungcap_Filter.ma_nhacungcap);
                }

                if (SLoai_Filter != null)
                {
                    FindByLOAI(SLoai_Filter.ma_loaihang);
                }
            });
            #endregion

            #region Phan tim kiem

            Search_Command = new RelayCommand<TextBox>(p =>
            {
                return true;
            }, p =>
            {
                string str = p.Text;
                List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == false));

                if (!string.IsNullOrEmpty(str))
                {
                    var filterlist = List.Where(x => x.MATHANG.ten_mathang.Contains(str) || x.MATHANG.NHACUNGCAP.ten_nhacungcap.Contains(str)
                                     || x.MATHANG.DONVITINH.ten_donvi.Contains(str) || x.MATHANG.LOAIHANG.ten_loaihang.Contains(str) || x.PHIEUNHAP.ngaynhap.Contains(str));

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
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == false));
                }
            });

            #endregion
        }

        #region Filter Methods
        private void FindByDate(DateTime date_start, DateTime date_end)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while ((MyStaticMethods.ConvertStringtoDate(List[i].PHIEUNHAP.ngaynhap)) < date_start || (MyStaticMethods.ConvertStringtoDate(List[i].PHIEUNHAP.ngaynhap) > date_end))
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

        private void FindByNCC(string mancc)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].MATHANG.NHACUNGCAP.ma_nhacungcap != mancc)
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
                while (List[i].MATHANG.ma_mathang != mamathang)
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

        private void FindByLOAI(string ma)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].MATHANG.LOAIHANG.ma_loaihang != ma)
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

        private void FilterMathangby_Loai(string maloai)
        {
            ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));

            for (int i = 0; i < ListMathang_Filter.Count(); i++)
            {
                while (ListMathang_Filter[i].ma_loaihang != maloai)
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

        private void TaoDS_nhap()
        {
            List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.IsDeleted == false).ToList().OrderByDescending(x => MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap)));
        }

        private Model.PHIEUNHAP CheckPhieunhap(string str)
        {
            Model.PHIEUNHAP result = Model.DataProvider.Ins.DB.PHIEUNHAPs.Where(x => x.ngaynhap == str).SingleOrDefault();
            if (result == null)
            {
                Model.PHIEUNHAP newItem = new Model.PHIEUNHAP()
                {
                    ma_phieunhap = Guid.NewGuid().ToString(),
                    ngaynhap = MyStaticMethods.ConvertDate2Vn_Today(),
                };

                Model.DataProvider.Ins.DB.PHIEUNHAPs.Add(newItem);
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
                foreach (var item in Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.ToList())
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
