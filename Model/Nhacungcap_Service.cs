using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QLK_Dn.Model
{
    public class Nhacungcap_Service : NHACUNGCAP
    {
        public static void Insert(Model.NHACUNGCAP item)
        {
            Model.DataProvider.Ins.DB.NHACUNGCAPs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.NHACUNGCAP item)
        {
            Model.DataProvider.Ins.DB.NHACUNGCAPs.Remove(item);
        }

        public static void Update(Model.NHACUNGCAP item, string id)
        {
            Model.NHACUNGCAP getdt = Model.DataProvider.Ins.DB.NHACUNGCAPs.Where(x => x.ma_nhacungcap == id).SingleOrDefault();
            getdt.ten_nhacungcap = item.ten_nhacungcap;
            getdt.sodienthoai = item.sodienthoai;
            getdt.diachi = item.diachi;

            Model.DataProvider.Ins.DB.SaveChanges();
        }
    }
}
