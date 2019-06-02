using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK_Dn.Model
{
    public class Mathang_Service : MATHANG
    {
        public static void Insert(Model.MATHANG item)
        {
            Model.DataProvider.Ins.DB.MATHANGs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.MATHANG item)
        {
            Model.DataProvider.Ins.DB.MATHANGs.Remove(item);
        }

        public static void Update(Model.MATHANG item, string id)
        {
            Model.MATHANG getdt = Model.DataProvider.Ins.DB.MATHANGs.Where(x => x.ma_mathang == id).SingleOrDefault();
            getdt.ten_mathang = item.ten_mathang;
            getdt.hang = item.hang;
            getdt.dong = item.dong;
            getdt.DONVITINH = item.DONVITINH;
            getdt.NHACUNGCAP = item.NHACUNGCAP;
            getdt.LOAIHANG = item.LOAIHANG;
            getdt.mota = item.mota;

            Model.DataProvider.Ins.DB.SaveChanges();
        }
    }
}
