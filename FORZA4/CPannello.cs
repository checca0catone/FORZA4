using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORZA4
{
    internal class CPannello
    {
        public Panel panel;
        public bool occupato;
        public string colore;
        public bool giallo;
        public int num;

        public CPannello(string nomePannello, int Num, Form form)
        {
            panel = (Panel)form.Controls.Find(nomePannello, true)[0];
            panel.Name = nomePannello;
            occupato = false;
            colore = "";
            num = Num;
        }
    }
}
