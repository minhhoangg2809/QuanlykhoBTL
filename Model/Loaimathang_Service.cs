using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QLK_Dn.Model
{
    public class Loaimathang_Service
    {
        public static void Insert(Model.LOAIHANG item)
        {
            Model.DataProvider.Ins.DB.LOAIHANGs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.LOAIHANG item)
        {
            Model.DataProvider.Ins.DB.LOAIHANGs.Remove(item);
        }

        public static void Update(Model.LOAIHANG item, string id)
        {
            Model.LOAIHANG getdt = Model.DataProvider.Ins.DB.LOAIHANGs.Where(x => x.ma_loaihang == id).SingleOrDefault();
            getdt.ten_loaihang = item.ten_loaihang;
            getdt.mota = item.mota;

            Model.DataProvider.Ins.DB.SaveChanges();
        }
    }
}
