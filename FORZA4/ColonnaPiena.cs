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
    public partial class ColonnaPiena : Form
    {
        private Forza4 mainForm;

        public ColonnaPiena(Forza4 formPrincipale)
        {
            InitializeComponent();
            mainForm = formPrincipale;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
