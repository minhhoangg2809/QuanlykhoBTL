using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace QLK_Dn.ViewModel
{
    public class SearchBar_ViewModel : BaseViewModel
    {
        private string texts;

        public string Texts
        {
            get
            {
                return texts;
            }

            set
            {
                texts = value;
                OnPropertyChanged();
            }
        }

        public ICommand Search_Command { get; set; }
        public ICommand Load_Command { get; set; }

        public SearchBar_ViewModel()
        {
            Search_Command = new RelayCommand<TextBox>(p =>
            {
                return true;
            }, p =>
            {
                Texts = p.Text;
                Window wd = getParent(p) as Window;

                if (wd != null)
                {
                    #region tim view thu kho

                    if ((wd.GetType() == typeof(View.View_Thukho.Mathang)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_mathang;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }


                    if ((wd.GetType() == typeof(View.View_Thukho.Donvi)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_donvi;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Thukho.Loaimathang)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_loaihang;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Thukho.Nhaphang)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_nhap;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Thukho.Xuathang)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_xuat;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Thukho.Thongke)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_thongke;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    #endregion

                    #region tim view quan ly

                    if (wd.GetType() == typeof(View.View_Quanly.Mathang))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_thongke;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Quanly.Khachhang)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_khachhang;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Quanly.Nhacungcap)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_nhacungcap;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Quanly.Nhanvien)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_nhanvien;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    if ((wd.GetType() == typeof(View.View_Quanly.Quantrihethong)))
                    {
                        foreach (ListView item in MySource.MyStaticMethods.FindVisualChildren<ListView>(wd))
                        {
                            CollectionView viewfilter = (CollectionView)CollectionViewSource.GetDefaultView(item.ItemsSource);
                            viewfilter.Filter = Search_taikhoan;
                            CollectionViewSource.GetDefaultView(item.ItemsSource).Refresh();

                            break;
                        }
                    }

                    #endregion

                }
            });

            Load_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                Texts = string.Empty;
            });
        }

        #region Methods

        private FrameworkElement getParent(TextBox uc)
        {
            FrameworkElement p = uc;
            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            return p;
        }

        #region Search Thu kho

        private bool Search_mathang(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return
                    ((Model.MATHANG)item).ma_mathang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.MATHANG)item).ten_mathang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.MATHANG)item).hang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.MATHANG)item).dong.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.MATHANG)item).NHACUNGCAP.ten_nhacungcap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.MATHANG)item).DONVITINH.ten_donvi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.MATHANG)item).LOAIHANG.ten_loaihang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_donvi(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return
                    ((Model.DONVITINH)item).ten_donvi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_loaihang(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return
                        ((Model.LOAIHANG)item).ma_loaihang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                         ((Model.LOAIHANG)item).ten_loaihang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;

                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_nhap(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.CHITIETPHIEUNHAP)item).ma_ctphieunhap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).nguoitao.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).MATHANG.ten_mathang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).PHIEUNHAP.ngaynhap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).MATHANG.NHACUNGCAP.ten_nhacungcap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUNHAP)item).MATHANG.DONVITINH.ten_donvi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;

                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_xuat(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.CHITIETPHIEUXUAT)item).ma_ctphieuxuat.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).nguoitao.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).CHITIETPHIEUNHAP.MATHANG.ten_mathang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).PHIEUXUAT.ngayxuat.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).CHITIETPHIEUNHAP.MATHANG.NHACUNGCAP.ten_nhacungcap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.CHITIETPHIEUXUAT)item).KHACHHANG.ten_khachhang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;

                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_thongke(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.Thongke)item).mathang.ma_mathang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.ten_mathang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.NHACUNGCAP.ten_nhacungcap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.DONVITINH.ten_donvi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.Thongke)item).mathang.LOAIHANG.ten_loaihang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;

                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        #endregion

        #region Search Quan ly

        private bool Search_nhanvien(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.NHANVIEN)item).ma_nhanvien.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHANVIEN)item).ten_nhanvien.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHANVIEN)item).diachi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHANVIEN)item).sodienthoai.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHANVIEN)item).QUYEN.ten_quyen.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHANVIEN)item).ngaysinh.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;

                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_khachhang(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.KHACHHANG)item).ten_khachhang.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.KHACHHANG)item).diachi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.KHACHHANG)item).sodienthoai.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_nhacungcap(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.NHACUNGCAP)item).ten_nhacungcap.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHACUNGCAP)item).diachi.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.NHACUNGCAP)item).sodienthoai.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        private bool Search_taikhoan(object item)
        {
            if (String.IsNullOrEmpty(Texts))
            {
                return true;
            }
            else
            {
                try
                {
                    return ((Model.TAIKHOAN)item).ten_taikhoan.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.TAIKHOAN)item).email.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ((Model.TAIKHOAN)item).NHANVIEN.ten_nhanvien.IndexOf(Texts, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch (Exception)
                {
                    return true;
                }

            }
        }

        #endregion

        #endregion
    }
}
