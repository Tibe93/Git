using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPC_CTPACK_Software
{
    public partial class Form0 : Form
    {

        Form1 FormFiglio;
        Formato[] Formati;

        public Form0()
        {
            this.FormFiglio = new Form1(this);
            this.Formati = Functions.LetturaFormati();
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Formati.Length; i++)
            {
                comboBoxFormato.Items.Add(this.Formati[i].GetNome());
            }
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            FormFiglio.Visible = true;
            this.Visible = false;
        }

        private void comboBoxFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFormato.BackColor = Color.White;
            butPath.Enabled = true;
            textBoxPath.Enabled = true;
            textBoxPath.BackColor = Color.LightGreen;
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            textBoxPath.BackColor = Color.White;
            butAnalisi.Enabled = true;
        }

        private void butAnalisi_Click(object sender, EventArgs e)
        {
            // mi connetto all'OPC

            double[] PosPlc = new double[3000];
            double[] VelPlc = new double[3000];
            double[] CorrPlc = new double[3000];
            int[] Tempo = new int[3000]; ;
            int PpmNow = 0;
            double TempoCampionamento = 0;
            string nomeF = "";
            string nomeM = "";
            int indice = 0;
            
            // mi creo la variabile tempo
            double TempoAttuale = 0;
            for (int j = 1; j < PosPlc.Length; j++)
            {
                TempoAttuale = TempoAttuale + (TempoCampionamento * 1000);
                Tempo[j] = Convert.ToInt32(TempoAttuale);
            }

            for (int i=0; i==Formati.Length; i++)
            {
                if(string.Equals(Formati[i].Nome,comboBoxFormato.SelectedItem))
                {
                    nomeF = Formati[i].Nome;
                    nomeM = Formati[i].Motore.GetModel();
                    indice = i;
                }
            }

            for(int i=Formati[indice].PpmI; i == Formati[indice].PpmF; i=i+Formati[indice].Passo)
            {
                // di al PLC di eseguire a velocità i
                // mi salvo le variabili che arrivano dal PLC e creo il CSV alla velocità i

                StreamWriter FileInfoAsse = new StreamWriter($"{textBoxPath.Text}/{i}_{Formati[indice].Nome}.CSV");

                FileInfoAsse.WriteLine($"Formato\t{nomeF}");
                FileInfoAsse.WriteLine($"Motore\t{nomeM}");
                FileInfoAsse.WriteLine($"TempoCampionamento\t{TempoCampionamento}");
                FileInfoAsse.WriteLine("Time\tPosizione\tVelocità\tCorrente");
                for (int j = 0; j == PosPlc.Length; j++)
                {
                    FileInfoAsse.WriteLine($"{Tempo[j]}\t{PosPlc[j]}\t{VelPlc[j]}\t{CorrPlc[j]}");
                }
            }
        }
    }
}
