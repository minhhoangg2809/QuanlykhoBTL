using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK_Dn.Model
{
    public class Nhaphang_Service
    {
        public static void Insert(Model.CHITIETPHIEUNHAP item)
        {
            Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.CHITIETPHIEUNHAP item)
        {
            Model.DataProvider.Ins.DB.CHITIETPHIEUNHAPs.Remove(item);
        }

    }
}
