using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK_Dn.Model
{
    public class DataProvider
    {
        private static DataProvider _Ins;

        public static DataProvider Ins
        {
            get
            {
                if (_Ins == null)
                {
                    _Ins = new DataProvider();
                }
                return _Ins;
            }
            set { _Ins = value; }
        }
        public QuanlyKhoDoanhNghiepEntities DB { get; set; }
        public DataProvider()
        {
            DB = new QuanlyKhoDoanhNghiepEntities();
        }
    }
}
