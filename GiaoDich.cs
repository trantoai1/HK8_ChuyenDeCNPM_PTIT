using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor
{
    

    class GiaoDich
    {
        private double gia;
        private int soluong;
        private ColorTable c_gia;
        private ColorTable c_sl;
        public GiaoDich()
        {
            this.Gia = 0;
            this.Soluong = 0;
            c_gia = new ColorTable();
            c_sl = new ColorTable();
        }
        public GiaoDich(double gia,int soluong)
        {
            this.Gia = gia;
            this.Soluong = soluong;
            c_gia = new ColorTable();
            c_sl = new ColorTable();
        }
        public double Gia { get => gia; set => gia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        internal ColorTable C_gia { get => c_gia; set => c_gia = value; }
        internal ColorTable C_sl { get => c_sl; set => c_sl = value; }
    }
}
