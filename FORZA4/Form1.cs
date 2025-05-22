using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORZA4
{
    public partial class Forza4 : Form
    {
        public Forza4()
        {
            InitializeComponent();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            CColonna colonna = new CColonna(2);
            for(int i = 0; i < 6; i++)
            {
                if(colonna.pannelliColonna[i].occupato == false)
                {
                    colonna.pannelliColonna[i].pannello.BackgroundImage = Properties.Resources.cer
                }
            }
        }
    }
}
