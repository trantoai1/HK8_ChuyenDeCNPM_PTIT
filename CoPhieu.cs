using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor
{
    class CoPhieu
    {
        private string maCK;
        private GiaoDich [] dumua;
        private GiaoDich khop;
        private GiaoDich[] duban;
        public CoPhieu(string ma)
        {
            MaCK = ma;
            Dumua = new GiaoDich[2];
            Khop = new GiaoDich();
            Duban = new GiaoDich[2];
            for(int i=0;i<2;i++)
            {
                Dumua[i] = new GiaoDich();
                Duban[i] = new GiaoDich();
            }    
        }
        public string MaCK { get => maCK; set => maCK = value; }
        public GiaoDich[] Dumua { get => dumua; set => dumua = value; }
        public GiaoDich[] Duban { get => duban; set => duban = value; }
        public GiaoDich Khop { get => khop; set => khop = value; }
    }
}
