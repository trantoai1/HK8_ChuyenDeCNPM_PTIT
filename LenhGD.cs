using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor
{
    class LenhGD
    {
        private int id;
        private string macp;
        private char loaigd;
        private DateTime time;
        private double gia;
        private int sl;
        private string trangthai;
        public LenhGD(string macp, char loaigd, DateTime time, double gia, int sl)
        {
            Id = 0;
            Macp = macp;
            Loaigd = loaigd;
            Time = time;
            Gia = gia;
            Sl = sl;
            Trangthai = "Chờ khớp";
        }

        public string Macp { get => macp; set => macp = value; }
        public char Loaigd { get => loaigd; set => loaigd = value; }
        public DateTime Time { get => time; set => time = value; }
        public double Gia { get => gia; set => gia = value; }
        public int Sl { get => sl; set => sl = value; }
        public int Id { get => id; set => id = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
