using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OPC_CTPACK_Software
{
    public partial class Form2 : Form
    {
        Form1 FormPadre;
        Form3 FormFiglio;
        Start_Creg CregInit;

        public Form2(Form1 FormPadre,Start_Creg CregInit)
        {
            this.FormPadre = FormPadre;
            this.FormFiglio = new Form3();
            this.CregInit = CregInit;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Aggiungo i punti al grafico
            for (int i = 0; i < this.CregInit.CregTot.Length; i++)
            {
                chartCreg.Series["Creg"].Points.AddXY(this.CregInit.CregTot[i].Formato.PpmA, this.CregInit.CregTot[i].CregAttuale);
                chartCreg.Series["SogliaPiu"].Points.AddXY(this.CregInit.CregTot[i].Formato.PpmA, (this.CregInit.CregTot[i].CregAttuale+ this.CregInit.CregTot[i].CregAttuale*this.CregInit.OffsetPos/100));
                chartCreg.Series["SogliaMeno"].Points.AddXY(this.CregInit.CregTot[i].Formato.PpmA, (this.CregInit.CregTot[i].CregAttuale + this.CregInit.CregTot[i].CregAttuale * this.CregInit.OffsetNeg/100));
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormPadre.Close();
        }

        private void butIndietro_Click(object sender, EventArgs e)
        {
            this.FormPadre.Visible = true;
            this.Visible = false;
        }

        private void butStorico_Click(object sender, EventArgs e)
        {
            FormFiglio.Show();
        }

        private void butCalcola_Click(object sender, EventArgs e)
        {
            //Prima parte
            //Attraverso l'OPC mi interefaccio col PLC, tiro giu i dati e li salvo su CSV
            //Path di salvataggio
            string Filename = $"{this.CregInit.CregTot[0].Formato.PpmA}_{this.CregInit.CregTot[0].Formato.GetNome()}";
            string Path = $"../{Filename}";//così lo salva in bin, sennò devo mettere il percorso al posto dei ..

            //Seconda parte
            //Apro il CSV appena salvato, calcolo il Creg e lo grafico

        }
    }
}
