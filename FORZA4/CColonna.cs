using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORZA4
{
    internal class CColonna
    {
        public List<CPannello> pannelliColonna = new List<CPannello>();

        public CColonna(int colonna, Form form) 
        {
            for (int riga = 0; riga < 6; riga++)
            {
                int indice = colonna + (riga * 7);
                string nomePannello = $"pnl{indice}";
                CPannello pannello = new CPannello(nomePannello, indice, form);
                pannelliColonna.Add(pannello);
            }
        }
    }
}
