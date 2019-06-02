using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QLK_Dn.Model
{
    public class Khachhang_Service : KHACHHANG
    {
        public static void Insert(Model.KHACHHANG item)
        {
            Model.DataProvider.Ins.DB.KHACHHANGs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.KHACHHANG item)
        {
            Model.DataProvider.Ins.DB.KHACHHANGs.Remove(item);
        }

        public static void Update(Model.KHACHHANG item, string id)
        {
            Model.KHACHHANG getdt = Model.DataProvider.Ins.DB.KHACHHANGs.Where(x => x.ma_khachhang == id).SingleOrDefault();
            getdt.ten_khachhang = item.ten_khachhang;
            getdt.sodienthoai = item.sodienthoai;
            getdt.diachi = item.diachi;

            Model.DataProvider.Ins.DB.SaveChanges();
        }

    }
}
