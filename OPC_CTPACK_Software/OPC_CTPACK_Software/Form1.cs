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

        public Form1(Form0 FormPadre)
        {
            InitializeComponent();
            this.FormPadre = FormPadre;
            this.FormFiglio = new Form2(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Motore M1 = new Motore("VPL-B1153F-C", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c","c");
            Formato F1 = new Formato("ChocoRolles", M1, 70, 1, 0.01, 0.075);
            Creg C1 = new Creg(F1, $@"C:\Users\CtPack\Desktop\Tiberia\Trend_Tibe\_Fossalta_Temperature_Termoregolate\",2);
            */
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
            Formato FormatoA = new Formato();
            int NumeroCreg = (FormatoA.PpmF-FormatoA.PpmI)/FormatoA.Passo;
            Creg[] CregTot = new Creg[NumeroCreg];
            for(int i = 0; i<= NumeroCreg; i++)
            {
                FormatoA.PpmA = FormatoA.PpmI + (FormatoA.Passo * i);
                CregTot[i] = new Creg(FormatoA, textBoxPath.Text, 2);
                chartCreg.Series["Series1"].Points.AddXY(FormatoA.PpmA, CregTot[i].CregAttuale);
            }

            int Tolleranza = Convert.ToInt32(labelTolleranza.Text);
            Start_Creg CregInit = new Start_Creg(CregTot, Tolleranza, (-1 * Tolleranza));
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
    }
}
