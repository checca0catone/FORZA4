using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORZA4
{
    internal class CColonna
    {
        private int x;
        public List<CPannello> pannelliColonna = new List<CPannello>();

        public CColonna(int X)
        {
            x = X;
            for (int i = 0; i < 6; i++)
            {
                CPannello pannello = new CPannello(x, i);
                pannelliColonna.Add(pannello);
            }
        }
    }
}
