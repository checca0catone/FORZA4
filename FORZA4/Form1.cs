using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORZA4
{
    public partial class Forza4 : Form
    {
        private List<CColonna> colonne = new List<CColonna>();
        private bool turno = false; //turno false = rosso turno true = giallo
        private Image colorID;
        private string colore;
        private Panel ultimoPannelloColorto;
        int x;
        int numBtn;
        public Forza4()
        {
            InitializeComponent();
            for (int i = 1; i <= 7; i++)
            {
                string nomeBottone = $"btn{i}";
                Button btn = this.Controls[nomeBottone] as Button;
                if (btn != null)
                {
                    btn.Click += btnColonna_Click;
                }
                colonne.Add(new CColonna(i, this));
            }
            this.BackColor = Color.Red;
        }

        private void btnColonna_Click(object sender, EventArgs e) // sender è un oggetto che rappresenta l'elemento che ha generato l'evento click
        {
            Button btnPremuto = sender as Button; //prova a convertire l'oggetto sender in button, se ci riesce btnPremuto acquisisce il bottone altrimenti acquisisce null
            string nome = btnPremuto.Name;
            numBtn = int.Parse(nome.Substring(3));
            CColonna colonna = colonne[numBtn - 1];
            if (colonna.pannelliColonna[0].occupato)
            {
                using (ColonnaPiena colonnaPiena = new ColonnaPiena(this))
                {
                    colonnaPiena.ShowDialog();
                }
            }
            else
            {
                if (turno)
                {
                    this.BackColor = Color.Red;
                    colorID = Properties.Resources.cerchiogiallo;
                    colore = "giallo";
                    turno = false;
                }
                else
                {
                    this.BackColor = Color.Yellow;
                    colorID = Properties.Resources.cerchiorosso;
                    colore = "rosso";
                    turno = true;
                }

                for (int i = 5; i >= 0; i--)
                {
                    if (!colonna.pannelliColonna[i].occupato)
                    {
                        colonna.pannelliColonna[i].panel.BackgroundImage = colorID;
                        if (colore == "giallo")
                        {
                            colonna.pannelliColonna[i].colore = "giallo";
                            
                        }
                        else
                        {
                            colonna.pannelliColonna[i].colore = "rosso";
                            
                        }
                        colonna.pannelliColonna[i].occupato = true;
                        ultimoPannelloColorto = colonna.pannelliColonna[i].panel;
                        x = i;
                        break;
                    }
                }
                bool vittoriaG, vittoriaR;
                controlloVittoria(x,out vittoriaG, out vittoriaR);
                if (vittoriaG)
                {
                    using (Vittoria formVittoria = new Vittoria(this))
                    {
                        this.BackColor = Color.Yellow;
                        formVittoria.BackColor = Color.Yellow;
                        formVittoria.label2.Text = "Il giallo ha vinto!";
                        formVittoria.ShowDialog();
                    }
                }
                else if (vittoriaR)
                {
                    using (Vittoria formVittoria = new Vittoria(this))
                    {
                        this.BackColor = Color.Red;
                        formVittoria.BackColor = Color.Red;
                        formVittoria.label2.Text = "Il rosso ha vinto!";
                        formVittoria.ShowDialog();
                    }

                }
            }
        }

        private void controlloVittoria(int x, out bool vittoriaG, out bool vittoriaR)
        {
            vittoriaG = false;
            vittoriaR = false;
            string coloreVittoria = "";
            int count = 0;
            for(int i = 0; i < 6; i++)
            {
                if (colonne[i].pannelliColonna[x].occupato)
                {
                    if (colonne[i].pannelliColonna[x].colore == colonne[i + 1].pannelliColonna[x].colore)
                    {
                        count++;
                        if (count == 3)
                        {
                            coloreVittoria = colonne[i].pannelliColonna[x].colore;
                            break;
                        }
                    }
                    else count = 0;
                }
                else count = 0;
            }

            for(int i = 0; i < 5; i++)
            {
                if (colonne[numBtn - 1].pannelliColonna[i].occupato)
                {
                    if (colonne[numBtn - 1].pannelliColonna[i].colore == colonne[numBtn - 1].pannelliColonna[i + 1].colore)
                    {
                        count++;
                        if (count == 3)
                        {
                            coloreVittoria = colonne[numBtn].pannelliColonna[i].colore;
                            break;
                        }
                    }
                    else count = 0;
                }
                else count = 0;
            }

            for (int r = 0; r <= 5; r++)          
            {
                for (int c = 0; c <= 6; c++)     
                {
                    if (r + 3 <= 5 && c + 3 <= 6)
                    {
                        if (colonne[c].pannelliColonna[r].occupato && colonne[c + 1].pannelliColonna[r + 1].occupato && colonne[c + 2].pannelliColonna[r + 2].occupato && colonne[c + 3].pannelliColonna[r + 3].occupato)
                        {
                            if (colonne[c + 1].pannelliColonna[r + 1].colore == colonne[c + 2].pannelliColonna[r + 2].colore)
                            {
                                if (colonne[c + 2].pannelliColonna[r + 2].colore == colonne[c + 3].pannelliColonna[r + 3].colore)
                                {
                                    coloreVittoria = colonne[c + 2].pannelliColonna[r + 2].colore;
                                    break;
                                }

                            }
                        }
                    }

                    if (r - 3 >= 0 && c + 3 <= 6)
                    {
                        string colore = colonne[c].pannelliColonna[r].colore;

                        if (colonne[c].pannelliColonna[r].occupato && colonne[c + 1].pannelliColonna[r - 1].occupato && colonne[c + 2].pannelliColonna[r - 2].occupato && colonne[c + 3].pannelliColonna[r - 3].occupato)
                        {
                            if(colonne[c + 1].pannelliColonna[r - 1].colore == colonne[c + 2].pannelliColonna[r - 2].colore)
                            {
                                if (colonne[c + 2].pannelliColonna[r - 2].colore == colonne[c + 3].pannelliColonna[r - 3].colore)
                                {
                                    coloreVittoria = colonne[c + 2].pannelliColonna[r - 2].colore;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (coloreVittoria == "giallo") vittoriaG = true;
            else if(coloreVittoria == "rosso") vittoriaR = true; 
        }

        public void reset()
        {
            turno = false;
            colore = "";
            colorID = null;
            ultimoPannelloColorto = null;
            this.BackColor = Color.Red;
            foreach (var colonna in colonne)
            {
                foreach (var pannello in colonna.pannelliColonna)
                {
                    pannello.occupato = false;
                    pannello.colore = "";
                    pannello.panel.BackgroundImage = Properties.Resources.cerchiobianco;
                }
            }
        }

        private void btnistruzioni_Click(object sender, EventArgs e)
        {
            using (Istruzioni istruzioni = new Istruzioni())
            {
                istruzioni.ShowDialog();
            }
        }
    }
}