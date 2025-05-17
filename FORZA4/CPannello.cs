using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORZA4
{
    internal class CPannello
    {
        public int x;
        public int y;
        public bool occupato;

        public CPannello(int X, int Y)
        {
            x = X;
            y = Y;
            occupato = false;
        }
    }
}
