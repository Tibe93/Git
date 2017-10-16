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
            this.FormFiglio = new Form3();
            FormFiglio.Show();
        }

        private void butCalcola_Click(object sender, EventArgs e)
        {
            //Cancello i punti del grafico precedente
            chartCreg.Series["CregAttuale"].Points.Clear();

            ///////////////TODO: timer e prima parte con l'opc

            //Prima parte
            //Attraverso l'OPC mi interefaccio col PLC, tiro giu i dati e li salvo su CSV
            //Path di salvataggio
            int PpmNow = 400; //Dato che prendo dalla macchina, mi dice a quanti ppm sta andando
            string Filename = $"{PpmNow}_{this.CregInit.CregTot[0].Formato.Nome}";
            string Path = $"../Dati/{Filename}";//così lo salva in bin, sennò devo mettere il percorso al posto dei ..

            //Seconda parte
            //Apro il CSV appena salvato, calcolo il Creg e lo grafico
            Creg CregAttuale = new Creg(this.CregInit.CregTot[0].Formato, "../Dati/Trend", this.CregInit.CregTot[0].Periodi);
            CregAttuale.Formato.PpmA = PpmNow;
            chartCreg.Series["CregAttuale"].Points.AddXY(CregAttuale.Formato.PpmA, CregAttuale.CregAttuale);
            textBoxCreg.Text = CregAttuale.CregAttuale.ToString();
            pictureBoxAllarme.Enabled = false;

            double CregTeo = 0;
            if(CregAttuale.Formato.PpmA == CregInit.CregTot[0].Formato.PpmA)
            {
                CregTeo = CregInit.CregTot[0].CregAttuale;
            }
            else
            {
                for (int i = 1; i < CregInit.CregTot.Length; i++)
                {
                    if (CregAttuale.Formato.PpmA == CregInit.CregTot[i].Formato.PpmA)
                    {
                        CregTeo = CregInit.CregTot[i].CregAttuale;
                    }
                    else if ((CregAttuale.Formato.PpmA > CregInit.CregTot[i-1].Formato.PpmA) && (CregAttuale.Formato.PpmA < CregInit.CregTot[i].Formato.PpmA))
                    {
                        CregTeo = ((CregInit.CregTot[i - 1].CregAttuale * (CregInit.CregTot[i].Formato.PpmA - CregAttuale.Formato.PpmA)) + (CregInit.CregTot[i].CregAttuale * (CregAttuale.Formato.PpmA - CregInit.CregTot[i-1].Formato.PpmA)))/CregInit.CregTot[i].Formato.Passo;
                    }
                }
            }
            

            for (int i = 0; i < chartCreg.Series["SogliaPiu"].Points.Count; i++)
            {

                if(CregAttuale.CregAttuale >= (CregTeo + CregTeo*CregInit.OffsetPos))
                {
                    pictureBoxAllarme.Enabled = true;
                }
                if(CregAttuale.CregAttuale <= (CregTeo + CregTeo * CregInit.OffsetNeg))
                {
                    pictureBoxAllarme.Enabled = true;
                }
            }
            
            /*
            if(File.Exists("$../Dati/{ CregAttuale.Formato.PpmA}_Storico_Creg.txt"))
            {
                StreamWriter Storico = File.AppendText($"../Dati/{CregAttuale.Formato.PpmA}_Storico_Creg.txt");
            }
            else
            {
                StreamWriter Storico = new StreamWriter($"../Dati/{CregAttuale.Formato.PpmA}_Storico_Creg.txt");

                Storico.WriteLine($"CregTeo\t{}");
                Storico.WriteLine($"Tolleranza\t{this.CregInit.OffsetPos}");
                Storico.WriteLine("");
                Storico.WriteLine("DateTime Creg");
            }
            */
        }
    }
}
