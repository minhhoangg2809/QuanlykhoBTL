using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QLK_Dn.Model
{
    public class Donvitinh_Service : DONVITINH
    {
        public static void Insert(Model.DONVITINH item)
        {
            Model.DataProvider.Ins.DB.DONVITINHs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.DONVITINH item)
        {
            Model.DataProvider.Ins.DB.DONVITINHs.Remove(item);
        }

        public static void Update(Model.DONVITINH item, string id)
        {
            Model.DONVITINH getdt = Model.DataProvider.Ins.DB.DONVITINHs.Where(x => x.ma_donvi == id).SingleOrDefault();
            getdt.ten_donvi = item.ten_donvi;
            getdt.mota = item.mota;

            Model.DataProvider.Ins.DB.SaveChanges();
        }

    }
}
