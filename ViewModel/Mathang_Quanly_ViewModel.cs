using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QLK_Dn.MySource;
using System.Windows.Input;
using System.Windows.Controls;

namespace QLK_Dn.ViewModel
{
    public class Mathang_Quanly_ViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Thongke> _List;

        public ObservableCollection<Model.Thongke> List
        {
            get { return _List; }
            set { _List = value; OnPropertyChanged(); }
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


        #endregion

        #region Commands
        public ICommand Filter_Command { get; set; }
        public ICommand ResetFilter_Command { get; set; }
        public ICommand Load_Command { get; set; }
        public ICommand OrderbyTon_Command { get; set; }

        #endregion


        public Mathang_Quanly_ViewModel()
        {
            List = new ObservableCollection<Model.Thongke>();
            getThongke_list();

            ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
            ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
            ListDonvi_Filter = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));

            Load_Command = new RelayCommand<object>(p =>
            {
                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.Thongke>();
                getThongke_list();

                ListLoai_Filter = new ObservableCollection<Model.LOAIHANG>(Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.IsDeleted == false));
                ListNhacungcap_Filter = new ObservableCollection<Model.NHACUNGCAP>(Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.IsDeleted == false));
                ListDonvi_Filter = new ObservableCollection<Model.DONVITINH>(Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.IsDeleted == false));

            });

            #region Phan loc

            ResetFilter_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.Thongke>();
                getThongke_list();

                SLoai_Filter = null;
                SDonvi_Filter = null;
                SNhacungcap_Filter = null;
            });

            Filter_Command = new RelayCommand<Button>(p =>
            {
                return true;
            }, p =>
            {
                List = new ObservableCollection<Model.Thongke>();
                getThongke_list();


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
            });

            #endregion

            #region Sap xep

            OrderbyTon_Command = new RelayCommand<object>(p =>
            {
                if (List.Count() == 0)
                    return false;

                return true;

            }, p =>
            {
                ObservableCollection<Model.Thongke> chkList = new ObservableCollection<Model.Thongke>(List.OrderByDescending(x => x.tonkho));

                if (List[0] == chkList[0])
                {
                    List = new ObservableCollection<Model.Thongke>(List.OrderBy(x => x.tonkho));
                }
                else
                {
                    List = new ObservableCollection<Model.Thongke>(chkList);
                }
            });

            #endregion

        }

        #region  Methods
        private void getThongke_list()
        {
            int tongnhap = 0;
            int tongxuat = 0;
            int tonkho = 0;

            var list_mathang = Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.IsDeleted == false).ToList();

            foreach (var item in list_mathang)
            {
                var list_phieunhap = Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Where(x => x.MATHANG.ma_mathang == item.ma_mathang).ToList();
                if (list_phieunhap != null)
                {
                    tonkho = list_phieunhap.Sum(x => x.soluongton);
                }

                else
                {
                    tonkho = 0;
                }

                Model.Thongke obj = new Model.Thongke(item, tongnhap, tongxuat, tonkho);
                if (!List.Contains(obj))
                {
                    List.Add(obj);
                }
            }
        }

        private void FilterbyNhacungcap(string ma_nhacungcap)
        {
            for (int i = 0; i < List.Count(); i++)
            {
                while (List[i].mathang.NHACUNGCAP.ma_nhacungcap != ma_nhacungcap)
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
                while (List[i].mathang.LOAIHANG.ma_loaihang != ma_loai)
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
                while (List[i].mathang.DONVITINH.ma_donvi != ma_donvi)
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

        #endregion

    }
}
