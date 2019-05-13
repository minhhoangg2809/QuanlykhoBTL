using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QLK_Dn.MySource;

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
        public Mathang_Quanly_ViewModel()
        {
            List = new ObservableCollection<Model.Thongke>();
            getThongke_list();
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
        #endregion
    }
}
