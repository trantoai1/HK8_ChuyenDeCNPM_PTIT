using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor
{
    class ColorTable
    {
        private Color f;
        private Color b;
        public ColorTable()
        {
            F = Color.Black;
            B = Color.WhiteSmoke;
        }
        public ColorTable(Color f, Color b)
        {
            F = f;
            B = b;
        }

        public Color F { get => f; set => f = value; }
        public Color B { get => b; set => b = value; }
        public void Tang()
        {
            F = Color.White;
            B = Color.Green;
        }
        public void Giam()
        {
            F = Color.White;
            B = Color.Red;
        }
        public void MacDinh()
        {
            F = Color.Black;
            B = Color.WhiteSmoke;
        }
    }
}
