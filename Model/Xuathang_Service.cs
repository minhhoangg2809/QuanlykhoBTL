using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK_Dn.Model
{
    public class Xuathang_Service
    {
        public static void Insert(Model.CHITIETPHIEUXUAT item)
        {
            Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.CHITIETPHIEUXUAT item)
        {
            Model.DataProvider.Ins.DB.CHITIETPHIEUXUATs.Remove(item);
        }
    }
}
