using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLK_Dn.Model
{
    public class Thongke
    {
        private MATHANG _mathang;

        public MATHANG mathang
        {
            get { return _mathang; }
            set { _mathang = value; }
        }

        private int _soluongnhap;

        public int soluongnhap
        {
            get { return _soluongnhap; }
            set { _soluongnhap = value; }
        }

        private int _soluongxuat;

        public int soluongxuat
        {
            get { return _soluongxuat; }
            set { _soluongxuat = value; }
        }

        private int _tonkho;

        public int tonkho
        {
            get { return _tonkho; }
            set { _tonkho = value; }
        }
        public Thongke(MATHANG Mathang, int Soluongnhap, int Soluongxuat, int Tonkho)
        {
            mathang = Mathang;
            soluongnhap = Soluongnhap;
            soluongxuat = Soluongxuat;
            tonkho = Tonkho;
        }
    }
}
