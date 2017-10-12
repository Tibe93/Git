using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPC_CTPACK_Software
{
    public partial class Form1 : Form
    {
        Form0 FormPadre;
        Form2 FormFiglio;
        Formato[] Formati;
        Start_Creg CregInit;

        public Form1(Form0 FormPadre)
        {
            InitializeComponent();
            this.FormPadre = FormPadre;
            this.FormFiglio = new Form2(this,this.CregInit);
            this.Formati = Functions.LetturaFormati();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0; i < this.Formati.Length; i++)
            {
                comboBoxFormato.Items.Add(this.Formati[i].GetNome());
            }
        }

        private void butIndietro_Click(object sender, EventArgs e)
        {
            this.FormPadre.Visible = true;
            this.Visible = false;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            FormFiglio.Visible = true;
            this.Visible = false;
        }

        private void butCalcolo_Click(object sender, EventArgs e)
        {
            int IndiceFormato;
            for (int i = 0; i < this.Formati.Length; i++)
            {
                if(Formati[i].GetNome().Equals(comboBoxFormato.SelectedItem))
                {
                    IndiceFormato = i;
                    break;
                }
            }

            Formato FormatoA = this.Formati[0];
            int NumeroCreg = ((FormatoA.PpmF-FormatoA.PpmI)/FormatoA.Passo)+1;
            Creg[] CregTot = new Creg[NumeroCreg];
            for(int i = 0; i< NumeroCreg; i++)
            {
                FormatoA.PpmA = FormatoA.PpmI + (FormatoA.Passo * i);
                CregTot[i] = new Creg(FormatoA, textBoxPath.Text, 2);
                chartCreg.Series["Series1"].Points.AddXY(FormatoA.PpmA, CregTot[i].CregAttuale);
            }

            int Tolleranza = Convert.ToInt32(textBoxTolleranza.Text);
            this.CregInit = new Start_Creg(CregTot, Tolleranza, (-1 * Tolleranza));
            this.butAvanti.Enabled = true;

            //Disegno il grafico
            chartCreg.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartCreg.Series["Series1"].ChartArea = "ChartArea1";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormPadre.Close();
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBoxTolleranza_Click(object sender, EventArgs e)
        {
            
            textBoxTolleranza.Text = "";
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
            textBoxTolleranza.Enabled = true;
            textBoxTolleranza.BackColor = Color.LightGreen;
        }

        private void textBoxTolleranza_TextChanged(object sender, EventArgs e)
        {
            textBoxTolleranza.BackColor = Color.White;
            butCalcolo.Enabled = true;
        }
    }
}
