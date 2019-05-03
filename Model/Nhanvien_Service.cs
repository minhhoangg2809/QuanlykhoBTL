using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK_Dn.Model
{
    public class Nhanvien_Service
    {
        public static void Insert(Model.NHANVIEN item)
        {
            Model.DataProvider.Ins.DB.NHANVIENs.Add(item);
            Model.DataProvider.Ins.DB.SaveChanges();
        }

        public static void Delete(Model.NHANVIEN item)
        {
            Model.DataProvider.Ins.DB.NHANVIENs.Remove(item);
        }

        public static void Update(Model.NHANVIEN item, string id)
        {
            Model.NHANVIEN getdt = Model.DataProvider.Ins.DB.NHANVIENs.Where(x => x.ma_nhanvien == id).SingleOrDefault();
            getdt.ten_nhanvien = item.ten_nhanvien;
            getdt.ngaysinh = item.ngaysinh;
            getdt.sodienthoai = item.sodienthoai;
            getdt.diachi = item.diachi;
            getdt.QUYEN = item.QUYEN;

            Model.DataProvider.Ins.DB.SaveChanges();
        }
    }
}
