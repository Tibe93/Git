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
            //Prendi le info dal file di configurazione dei Formati e li istanzio
            this.Formati = Functions.LetturaFormati();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0; i < this.Formati.Length; i++)
            {
                //Aggiungo i formati alla combobox
                comboBoxFormato.Items.Add(this.Formati[i].GetNome());
            }
            
            
        }

        private void butIndietro_Click(object sender, EventArgs e)
        {
            //Visualizzo il FormPadre tornando indietro
            this.FormPadre.Visible = true;
            this.Visible = false;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            //Visualizzo il FormFiglio andando avanti
            FormFiglio.Visible = true;
            this.Visible = false;
        }

        private void butCalcolo_Click(object sender, EventArgs e)
        {
            //Cancello i punti del grafico precedente
            foreach (var series in chartCreg.Series)
            {
                series.Points.Clear();
            }

            //Rendo visibile il grafico 
            chartCreg.Visible = true;

            //ottengo l'indice dell'array del formato selezionato nella combobox
            int IndiceFormato =0;
            for (int i = 0; i < this.Formati.Length; i++)
            {
                if(Formati[i].GetNome().Equals(comboBoxFormato.SelectedItem))
                {
                    IndiceFormato = i;
                    break;
                }
            }

            //Setto il formato attuale
            Formato FormatoA = this.Formati[IndiceFormato];

            //Calcolo il numero di Creg da calcolare
            int NumeroCreg = ((FormatoA.PpmF-FormatoA.PpmI)/FormatoA.Passo)+1;
            Creg[] CregTot = new Creg[NumeroCreg];
            
            //Istanzio i vari Creg e li inizializzo
            for(int i = 0; i< NumeroCreg; i++)
            {
                FormatoA.PpmA = FormatoA.PpmI + (FormatoA.Passo * i);
                CregTot[i] = new Creg( FormatoA, textBoxPath.Text, 2);
                chartCreg.Series["Creg"].Points.AddXY(FormatoA.PpmA, CregTot[i].CregAttuale);
            }

            //Setto la tolleranza
            int Tolleranza = Convert.ToInt32(textBoxTolleranza.Text);

            //Istanzio lo Start_Creg, ovvero la classe che contiene tutti i Creg di inizializzazione
            this.CregInit = new Start_Creg(CregTot, Tolleranza, (-1 * Tolleranza));

            //Visualizzo Bs e Bv
            textBoxBs.Text = CregInit.Bs.ToString();
            textBoxBv.Text = CregInit.Bv.ToString();
            this.butAvanti.Enabled = true;

            //Disegno il grafico
            chartCreg.Series["Creg"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartCreg.Series["Creg"].ChartArea = "ChartArea1";

            //Aggiorno FormFiglio
            this.FormFiglio = new Form2(this, this.CregInit);

            //Operazioni sulla grafica
            butCalcolo.Enabled = false;
            comboBoxFormato.BackColor = Color.LightGreen;
            textBoxPath.Text = "Inserire Path Salvataggio .CSV";
            textBoxTolleranza.Text = "Inserire un Intero";
            textBoxPath.Enabled = false;
            textBoxTolleranza.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Quando chiudo il form chiudo anche il FormPadre
            this.FormPadre.Close();
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            //Utilizzo una finestra di dialogo per selezionare la cartella dove sono salvati i .CSV
            folderBrowserDialog1.ShowDialog();
            textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBoxTolleranza_Click(object sender, EventArgs e)
        {
            //Operazioni sulla grafica
            textBoxTolleranza.Text = "";
        }

        private void comboBoxFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Operazioni sulla grafica
            comboBoxFormato.BackColor = Color.White;
            butPath.Enabled = true;
            textBoxPath.Enabled = true;
            textBoxPath.BackColor = Color.LightGreen;
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            //Operazioni sulla grafica
            textBoxPath.BackColor = Color.White;
            if(!textBoxPath.Text.Equals("Inserire Path Salvataggio .CSV"))
            {
                textBoxTolleranza.Enabled = true;
                textBoxTolleranza.BackColor = Color.LightGreen;
            }
        }

        private void textBoxTolleranza_TextChanged(object sender, EventArgs e)
        {
            //Operazioni sulla grafica
            if (!(textBoxTolleranza.Text.Equals("Inserire un Intero")|| textBoxTolleranza.Text.Equals("")))
            {
                butCalcolo.Enabled = true;
            }
            textBoxTolleranza.BackColor = Color.White;
        }

        private void textBoxTolleranza_Leave(object sender, EventArgs e)
        {
            //Operazioni sulla grafica
            if (textBoxTolleranza.Text.Equals(""))
            {
                textBoxTolleranza.Text = "Inserire un Intero";
                textBoxTolleranza.BackColor = Color.LightGreen;
            }
        }
    }
}
