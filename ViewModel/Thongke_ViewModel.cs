using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using QLK_Dn.MySource;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.IO;

namespace QLK_Dn.ViewModel
{
    class Thongke_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Thongke> _List;

        public ObservableCollection<Model.Thongke> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.Thongke> _DeleteList;

        public ObservableCollection<Model.Thongke> DeleteList
        {
            get { return _DeleteList; }
            set { _DeleteList = value; OnPropertyChanged(); }
        }

        private bool _IscheckAll;

        public bool IscheckAll
        {
            get { return _IscheckAll; }
            set { _IscheckAll = value; OnPropertyChanged(); }
        }

        #region MATHANG

        private ObservableCollection<Model.MATHANG> _List_mathang;

        public ObservableCollection<Model.MATHANG> List_mathang
        {
            get { return _List_mathang; }
            set { _List_mathang = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.MATHANG> _FilterList_mathang;

        public ObservableCollection<Model.MATHANG> FilterList_mathang
        {
            get { return _FilterList_mathang; }
            set { _FilterList_mathang = value; OnPropertyChanged(); }
        }

        #endregion

        #region NHA CUNG CAP

        private ObservableCollection<Model.NHACUNGCAP> _List_nhacungcap;

        public ObservableCollection<Model.NHACUNGCAP> List_nhacungcap
        {
            get { return _List_nhacungcap; }
            set { _List_nhacungcap = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.NHACUNGCAP> _FilterList_nhacungcap;

        public ObservableCollection<Model.NHACUNGCAP> FilterList_nhacungcap
        {
            get { return _FilterList_nhacungcap; }
            set { _FilterList_nhacungcap = value; OnPropertyChanged(); }
        }

        #endregion

        #region LOAI MAT HANG

        private ObservableCollection<Model.LOAIHANG> _List_loaihang;

        public ObservableCollection<Model.LOAIHANG> List_loaihang
        {
            get { return _List_loaihang; }
            set { _List_loaihang = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.LOAIHANG> _FilterList_loaihang;

        public ObservableCollection<Model.LOAIHANG> FilterList_loaihang
        {
            get { return _FilterList_loaihang; }
            set { _FilterList_loaihang = value; OnPropertyChanged(); }
        }

        #endregion

        #region DON VI

        private ObservableCollection<Model.DONVITINH> _List_donvi;

        public ObservableCollection<Model.DONVITINH> List_donvi
        {
            get { return _List_donvi; }
            set { _List_donvi = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model.DONVITINH> _FilterList_donvi;

        public ObservableCollection<Model.DONVITINH> FilterList_donvi
        {
            get { return _FilterList_donvi; }
            set { _FilterList_donvi = value; OnPropertyChanged(); }
        }

        #endregion

        #region NGAY THANG

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

        #region Commands add/remove items FilterLists

        public ICommand AddtoFilterNCC_Command { get; set; }
        public ICommand DeletefromFilterNCC_Command { get; set; }
        public ICommand AddtoFilterLH_Command { get; set; }
        public ICommand DeletefromFilterLH_Command { get; set; }
        public ICommand AddtoFilterDV_Command { get; set; }
        public ICommand DeletefromFilterDV_Command { get; set; }
        public ICommand AddtoFilterMH_Command { get; set; }
        public ICommand DeletefromFilterMH_Command { get; set; }

        #endregion

        #region Commands Thong ke + Excel
        public ICommand Statistic_Command { get; set; }
        public ICommand Excel_Command { get; set; }
        #endregion

        #region Commands Xoa
        public ICommand AddDeleteList_Command { get; set; }
        public ICommand RemoveDeleteList_Command { get; set; }
        public ICommand Delete_Command { get; set; }
        public ICommand DeleteShow_Command { get; set; }

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

        public Thongke_ViewModel()
        {
            List = new ObservableCollection<Model.Thongke>();
            DeleteList = new ObservableCollection<Model.Thongke>();

            List_nhacungcap = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
            FilterList_nhacungcap = new ObservableCollection<Model.NHACUNGCAP>();

            List_loaihang = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
            FilterList_loaihang = new ObservableCollection<Model.LOAIHANG>();

            List_donvi = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));
            FilterList_donvi = new ObservableCollection<Model.DONVITINH>();

            List_mathang = new ObservableCollection<Model.MATHANG>(Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false));
            FilterList_mathang = new ObservableCollection<Model.MATHANG>();

            IscheckAll = true;
            IsOpen = false;


            CloseDialog_Command = new RelayCommand<MaterialDesignThemes.Wpf.DialogHost>(p =>
            {
                return true;
            }, p =>
            {
                p.IsOpen = false;
            });

            #region Them / xoa khoi FilterList_nhacungcap

            AddtoFilterNCC_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_nhacungcap.Where(x => x.ma_nhacungcap == id).SingleOrDefault();

                FilterList_nhacungcap.Add(item);
            });

            DeletefromFilterNCC_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_nhacungcap.Where(x => x.ma_nhacungcap == id).SingleOrDefault();

                FilterList_nhacungcap.Remove(item);
            });

            #endregion

            #region Them / xoa khoi FilterList_loaihang

            AddtoFilterLH_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_loaihang.Where(x => x.ma_loaihang == id).SingleOrDefault();

                FilterList_loaihang.Add(item);
            });

            DeletefromFilterLH_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_loaihang.Where(x => x.ma_loaihang == id).SingleOrDefault();

                FilterList_loaihang.Remove(item);
            });

            #endregion

            #region Them / xoa khoi FilterList_donvi

            AddtoFilterDV_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_donvi.Where(x => x.ma_donvi == id).SingleOrDefault();

                FilterList_donvi.Add(item);
            });

            DeletefromFilterDV_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_donvi.Where(x => x.ma_donvi == id).SingleOrDefault();

                FilterList_donvi.Remove(item);
            });

            #endregion

            #region Them / xoa khoi FilterList_mathang

            AddtoFilterMH_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_mathang.Where(x => x.ma_mathang == id).SingleOrDefault();

                FilterList_mathang.Add(item);
            });

            DeletefromFilterMH_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                string id = p.Uid.ToString();
                var item = List_mathang.Where(x => x.ma_mathang == id).SingleOrDefault();

                FilterList_mathang.Remove(item);
            });

            #endregion

            #region Phan xoa

            AddDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Add(List.Where(x => x.mathang.ma_mathang == p.Uid.ToString()).SingleOrDefault());
            });

            RemoveDeleteList_Command = new RelayCommand<CheckBox>(p =>
            {
                return true;
            }, p =>
            {
                DeleteList.Remove(List.Where(x => x.mathang.ma_mathang == p.Uid.ToString()).SingleOrDefault());
            });

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
                Content = "  Xóa các bản ghi được chọn ???";
            });

            Delete_Command = new RelayCommand<object>(p =>
            {
                if (DeleteList.Count() == 0)
                    return false;

                return true;
            }, p =>
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

                DeleteList = new ObservableCollection<Model.Thongke>();
                IsOpen = false;
            });

            #endregion

            #region Thong ke
            Statistic_Command = new RelayCommand<object>(p =>
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
                List = new ObservableCollection<Model.Thongke>();
                Filter_ngaythang(MyStaticMethods.FormatDateString(Date_Start), MyStaticMethods.FormatDateString(Date_End));

                if (IscheckAll == false) 
                {
                    UncheckAll_Filter();
                }

                if (FilterList_nhacungcap.Count() != 0)
                {
                    Filter_nhacungcap();
                }

                if (FilterList_loaihang.Count() != 0)
                {
                    Filter_loaimathang();
                }

                if (FilterList_donvi.Count() != 0)
                {
                    Filter_donvi();
                }

                if (FilterList_mathang.Count != 0)
                {
                    Filter_mathang();
                }
            });
            #endregion

            #region Xuat Excel

            Excel_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;
            }, p =>
            {
                string filePath = "*.xlsx";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialogs = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialogs.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialogs.ShowDialog() == true)
                {
                    filePath = dialogs.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }
                try
                {
                    using (ExcelPackage pk = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        pk.Workbook.Properties.Author = ViewModel.Taikhoan_ViewModel.getCurrent();

                        // đặt tiêu đề cho file
                        pk.Workbook.Properties.Title = "Báo cáo thống kê";

                        //Tạo một sheet để làm việc trên đó
                        pk.Workbook.Worksheets.Add("BCTK sheet");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = pk.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        ws.Name = "BCTK sheet";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 11;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = {  
                                                (Date_Start+" - "+Date_End),
                                                "Mã mặt hàng",
                                                "Tên mặt hàng",
                                                "Loại mặt hàng",
                                                "Nhà cung cấp",
                                                "Số lượng nhập",
                                                "Số lượng xuất",
                                                "Số lượng tồn",
                                                "Đơn vị tính"
                };

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        ws.Cells[1, 1].Value = "Thống kê hàng hóa";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }

                        // lấy ra danh sách UserInfo từ ItemSource của DataGrid
                        List<Model.Thongke> userList = List.Cast<Model.Thongke>().ToList();

                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in userList)
                        {
                            // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            colIndex = 1;

                            // rowIndex tương ứng từng dòng dữ liệu
                            rowIndex++;

                            //gán giá trị cho từng cell      
                            ws.Cells[rowIndex, colIndex++].Value = "";

                            ws.Cells[rowIndex, colIndex++].Value = item.mathang.ma_mathang;

                            ws.Cells[rowIndex, colIndex++].Value = item.mathang.ten_mathang;

                            ws.Cells[rowIndex, colIndex++].Value = item.mathang.LOAIHANG.ten_loaihang;

                            ws.Cells[rowIndex, colIndex++].Value = item.mathang.NHACUNGCAP.ten_nhacungcap;

                            ws.Cells[rowIndex, colIndex++].Value = item.soluongnhap;

                            ws.Cells[rowIndex, colIndex++].Value = item.soluongxuat;

                            ws.Cells[rowIndex, colIndex++].Value = item.tonkho;

                            ws.Cells[rowIndex, colIndex++].Value = item.mathang.DONVITINH.ten_donvi;
                        }

                        //Lưu file lại
                        Byte[] bin = pk.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Thành công !!!", "THÔNG BÁO");
                    Process.Start(filePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi khi lưu file !!!", "THÔNG BÁO");
                }

            });

            #endregion
        }

        #region Methods

        private void UncheckAll_Filter()
        {
            if (List.Count() != 0)
            {
                for (int i = 0; i < List.Count(); i++)
                {
                    while (List[i].soluongnhap == 0 && List[i].soluongxuat == 0 && List[i].tonkho == 0)
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
        }

        private void Filter_nhacungcap()
        {
            if (List.Count() != 0)
            {
                for (int i = 0; i < List.Count(); i++)
                {
                    while (FilterList_nhacungcap.Where(x => x == List[i].mathang.NHACUNGCAP).Count() == 0)
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
        }

        private void Filter_mathang()
        {
            if (List.Count() != 0)
            {
                for (int i = 0; i < List.Count(); i++)
                {
                    while (FilterList_mathang.Where(x => x == List[i].mathang).Count() == 0)
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
        }

        private void Filter_loaimathang()
        {
            if (List.Count() != 0)
            {
                for (int i = 0; i < List.Count(); i++)
                {
                    while (FilterList_loaihang.Where(x => x == List[i].mathang.LOAIHANG).Count() == 0)
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
        }

        private void Filter_donvi()
        {
            if (List.Count() != 0)
            {
                for (int i = 0; i < List.Count(); i++)
                {
                    while (FilterList_donvi.Where(x => x == List[i].mathang.DONVITINH).Count() == 0)
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
        }

        private void Filter_ngaythang(string datest, string datend)
        {
            DateTime date_start = MyStaticMethods.ConvertStringtoDate(datest);
            DateTime date_end = MyStaticMethods.ConvertStringtoDate(datend);

            int tongnhap = 0;
            int tongxuat = 0;
            int tonkho = 0;

            var list_mathang = Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false).ToList();

            foreach (var item in list_mathang)
            {
                var list_phieunhap = Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.MATHANG.ma_mathang == item.ma_mathang && x.IsDeleted == false).ToList();
                var list_phieuxuat = Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Where(x => x.CHITIETPHIEUNHAP.MATHANG.ma_mathang == item.ma_mathang && x.IsDeleted == false).ToList();

                if (list_phieunhap != null)
                {
                    tongnhap = list_phieunhap.Where(x => MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap) >= date_start
                        && MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap) <= date_end).Sum(x => x.soluongthuc);

                    tonkho = list_phieunhap.Where(x => MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap) >= date_start
                       && MyStaticMethods.ConvertStringtoDate(x.PHIEUNHAP.ngaynhap) <= date_end).Sum(x => x.soluongton);
                }

                else
                {
                    tongnhap = 0;
                    tonkho = 0;
                }

                if (list_phieuxuat != null)
                {
                    tongxuat = list_phieuxuat.Where(x => MyStaticMethods.ConvertStringtoDate(x.PHIEUXUAT.ngayxuat) >= date_start
                      && MyStaticMethods.ConvertStringtoDate(x.PHIEUXUAT.ngayxuat) <= date_end).Sum(x => x.soluongthucxuat);
                }

                else
                {
                    tongxuat = 0;
                }

                Model.Thongke obj = new Model.Thongke(item, tongnhap, tongxuat, tonkho);
                if (!List.Contains(obj))
                {
                    List.Add(obj);
                }
            }
        }

        #endregion
    }

}

