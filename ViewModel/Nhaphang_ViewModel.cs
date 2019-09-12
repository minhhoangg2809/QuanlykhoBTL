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

        #region Print

        private bool _IsOpen_prt;

        public bool IsOpen_prt
        {
            get { return _IsOpen_prt; }
            set { _IsOpen_prt = value; OnPropertyChanged(); }
        }

        private int _ItemsCount;

        public int ItemsCount
        {
            get { return _ItemsCount; }
            set { _ItemsCount = value; OnPropertyChanged(); }
        }

        private double _Tongtien;

        public double Tongtien
        {
            get { return _Tongtien; }
            set { _Tongtien = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.CHITIETPHIEUNHAP> _List_Print;

        public ObservableCollection<Model.CHITIETPHIEUNHAP> List_Print
        {
            get { return _List_Print; }
            set { _List_Print = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHACUNGCAP> _ListNCC_Print;

        public ObservableCollection<Model.NHACUNGCAP> ListNCC_Print
        {
            get { return _ListNCC_Print; }
            set { _ListNCC_Print = value; OnPropertyChanged(); }
        }

        private Model.NHACUNGCAP _SNhacungcapPrint;

        public Model.NHACUNGCAP SNhacungcapPrint
        {
            get { return _SNhacungcapPrint; }
            set { _SNhacungcapPrint = value; OnPropertyChanged(); }
        }

        private string _DayPrintVN;

        public string DayPrintVN
        {
            get { return _DayPrintVN; }
            set
            {
                _DayPrintVN = value;
                OnPropertyChanged();
            }
        }

        private string _DayPrint;

        public string DayPrint
        {
            get { return _DayPrint; }
            set { _DayPrint = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands Print

        public ICommand PrinterOpen_Command { get; set; }
        public ICommand PrinterFormClose_Command { get; set; }
        public ICommand OpenPrintDialog_Command { get; set; }
        public ICommand Print_Command { get; set; }

        #endregion

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

        private bool _IsOpen_Filter;

        public bool IsOpen_Filter
        {
            get { return _IsOpen_Filter; }
            set { _IsOpen_Filter = value; OnPropertyChanged(); }
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

        public ICommand OpenFilter_Command { get; set; }
        public ICommand Filter_Command { get; set; }
        public ICommand ResetFilter_Command { get; set; }
        public ICommand FilterLoai_Command { get; set; }

        #endregion

        #region Command

        public ICommand Load_Command { get; set; }
        public ICommand Insert_Command { get; set; }
        public ICommand InsertShow_Command { get; set; }
        public ICommand Reset_Command { get; set; }
        public ICommand GetvalueTextbox_Command { get; set; }
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }

        #endregion

        #region Commands Sap xep

        public ICommand OrderbyTenMathang_Command { get; set; }
        public ICommand OrderbyTennhacungcap_Command { get; set; }
        public ICommand OrderbyNgay_Command { get; set; }
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

            ListNCC_Print = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

            Active = false;
            IsOpen = false;
            IsOpen_insert = false;
            IsOpen_Filter = false;
            IsOpen_prt = false;

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
                IsOpen_prt = false;
            });

            Load_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                TaoDS_nhap();
                DeleteList = new ObservableCollection<Model.CHITIETPHIEUNHAP>();
                ListMathang = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));

                ListNCC_Print = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

                ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
                ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

                Active = false;
                IsOpen = false;
                IsOpen_insert = false;
                IsOpen_Filter = false;
                IsOpen_prt = false;
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

                try
                {
                    if (Convert.ToInt32(Soluongnhap) <= 0 || Convert.ToInt32(Soluongthucnhap) <= 0)
                        return false;

                    if (Convert.ToInt32(Dongianhap) <= 0 || Convert.ToDouble(Phantram) < 0)
                        return false;

                    if (Convert.ToInt32(Dongiaxuat) <= 0)
                        return false;
                }
                catch (Exception) {/*Try catch de sua loi FormatException*/}


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

            OpenFilter_Command = new RelayCommand<object>(p =>
            {
                if (IsOpen_Filter == true || IsOpen == true || IsOpen_insert == true || IsOpen_prt == true)
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
                ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
                ListMathang_Filter = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
                ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));

                SNhacungcap_Filter = null;
                SMathang_Filter = null;
                SLoai_Filter = null;
                Date_Start = String.Empty;
                Date_End = String.Empty;

                TaoDS_nhap();

                IsOpen_Filter = false;
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
                ObservableCollection<Model.CHITIETPHIEUNHAP> chkList = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderByDescending(x => x.MATHANG.ten_mathang));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderBy(x => x.MATHANG.ten_mathang));
                }
                else
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(chkList);
                }
            });

            OrderbyTennhacungcap_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.CHITIETPHIEUNHAP> chkList = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderByDescending(x => x.MATHANG.NHACUNGCAP.ten_nhacungcap));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderBy(x => x.MATHANG.NHACUNGCAP.ten_nhacungcap));
                }
                else
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(chkList);
                }
            });

            OrderbyNgay_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.CHITIETPHIEUNHAP> chkList = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderByDescending(x => MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap)));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderBy(x => MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap)));
                }
                else
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(chkList);
                }
            });

            OrderbyTendonvi_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.CHITIETPHIEUNHAP> chkList = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderByDescending(x => x.MATHANG.DONVITINH.ten_donvi));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.OrderBy(x => x.MATHANG.DONVITINH.ten_donvi));
                }
                else
                {
                    List = new ObservableCollection<Model.CHITIETPHIEUNHAP>(chkList);
                }
            });

            #endregion

            #region Printer

            PrinterOpen_Command = new RelayCommand<object>(p =>
            {
                if (SNhacungcapPrint == null)
                    return false;

                if (string.IsNullOrEmpty(DayPrint))
                    return false;

                return true;

            }, p =>
            {
                List_Print = new ObservableCollection<Model.CHITIETPHIEUNHAP>(List.Where(x => x.MATHANG.NHACUNGCAP == SNhacungcapPrint
                                                                 && x.PHIEUNHAP.ngaynhap == MyStaticMethods.FormatDateString(DayPrint)));

                var list_chk = new ObservableCollection<Model.CHITIETPHIEUNHAP>();

                ItemsCount = 0;
                Tongtien = 0;

                foreach (var item in List_Print)
                {
                    Tongtien += (double)(item.gianhap * item.soluongthuc);

                    if (list_chk.Where(x => x.MATHANG == item.MATHANG).Count() == 0)
                    {
                        list_chk.Add(item);
                    }
                }

                ItemsCount = list_chk.Count();


                DayPrintVN = MyStaticMethods.FormatDateString(DayPrint);

                View.View_Thukho.In_Nhap w = new View.View_Thukho.In_Nhap();
                w.ShowDialog();
            });

            OpenPrintDialog_Command = new RelayCommand<object>(p =>
            {
                if (IsOpen == true)
                    return false;

                if (IsOpen_insert == true)
                    return false;

                if (IsOpen_Filter == true)
                    return false;

                return true;
            }, p =>
            {
                IsOpen_prt = true;
            });

            Print_Command = new RelayCommand<Grid>(p =>
            {
                return true;
            }, p =>
            {
                try
                {
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(p, "invoice");
                    }

                    MessageBox.Show("Thành công !!!", "THÔNG BÁO");
                }
                catch (Exception) { MessageBox.Show("Có lỗi xảy ra !!!", "THÔNG BÁO"); };
            });

            PrinterFormClose_Command = new RelayCommand<Window>(p =>
            {
                return true;
            }, p =>
            {
                if (p != null)
                {
                    p.Close();
                    IsOpen_prt = false;
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
