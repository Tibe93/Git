using Opc.Da;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            
            //Leggo i formati dal file Formati.config e li inserisco in un array
            this.Formati = Com_Functions.LetturaFormati();
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Formati.Length; i++)
            {
                //Aggiungo i formati alla comboBox
                comboBoxFormato.Items.Add(this.Formati[i].GetNome());
            }
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            //Dopo il click seleziono dove salvare il .CSV, il path verrà messo nella textBox
            folderBrowserDialog1.ShowDialog();
            textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            //Dopo il click mi sposto nel Form figlio (Form1)
            FormFiglio.Visible = true;
            this.Visible = false;
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
            butAnalisi.Enabled = true;
        }

        private void butAnalisi_Click(object sender, EventArgs e)
        {
            //Inizializzo le variabili necessarie
            double[] PosPlc = new double[Global.NumeroCampioni];
            double[] VelPlc = new double[Global.NumeroCampioni];
            double[] CorrPlc = new double[Global.NumeroCampioni];
            int[] Tempo = new int[Global.NumeroCampioni]; ;
            string nomeF = "";
            string nomeM = "";
            int indice = 0;
            
            //Mi creo la variabile Tempo che verrà inserita nel File
            double TempoAttuale = 0;

            for (int j = 1; j < PosPlc.Length; j++)
            {
                TempoAttuale = TempoAttuale + (Global.TempoCampionamento * 1000);
                Tempo[j] = Convert.ToInt32(TempoAttuale);
            }

            //Seleziono il formato dell'array creato precedentemente che ha lo stesso nome dell'elemento selezionato nella comboBox
            for (int i=0; i < Formati.Length; i++)
            {
                if(string.Equals(Formati[i].Nome,comboBoxFormato.SelectedItem.ToString().Split(',')[0]))
                {
                    nomeF = Formati[i].Nome;
                    nomeM = Formati[i].Motore.GetModel();
                    indice = i;
                }
            }

            //Chiedo al PLC di far girare il motore del formato selezionato a diverse velocità
            //Parto da una velocità iniziale e aggiungendo il passo arrivo a quella finale
            //Per ognuna di queste velocità mi arriveranno i dati dal PLC con cui andrò a creare i diversi file
            double progresso = 0.0;
            progressBar1.Value = 0;

            for (int i=Formati[indice].PpmI; i <= Formati[indice].PpmF; i=i+Formati[indice].Passo)
            {
                //Dico al PLC di eseguire a velocità i
                Com_Functions.RsLinx_OPC_Client_Write($"[{Global.TopicName}]Ppm_Start", i);

                //Controllo quando Ppm_Start và a zero, quindi quando il plc ha finito l'analisi alla velocità i
                while (true)
                {
                    int Controllo = (int)Com_Functions.RsLinx_OPC_Client_Read($"[{Global.TopicName}]Ppm_Start").Value;
            
                    //Controllo che la lettura si andata a buon fine
                    if (Controllo == -1)
                    {
                        return;
                    }
                    
                    //Attendo che il plc finisca di fare i campionamenti, quando finisce mette Ppm_Start a 0
                    if (Controllo == 0)
                    {
                        break;
                    }

                    Thread.Sleep(500);
                }

                //Leggo i dati di posizione, velocità, corrente dall'OPC in array da 120 elementi l'uno 
                float[] Temp;

                for (int j = 0; j < PosPlc.Length / Global.LengthArray; j++)
                {
                    Temp = (float[])Com_Functions.RsLinx_OPC_Client_Read_Array($"[{Global.TopicName}]Posizione[{j * Global.LengthArray}]", Global.LengthArray)[0].Value;
                    
                    //Controllo che la lettura si andata a buon fine
                    if (Temp[0] == -1)
                    {
                        return;
                    }
                    Temp.CopyTo(PosPlc, j * Global.LengthArray);

                    Temp = (float[])Com_Functions.RsLinx_OPC_Client_Read_Array($"[{Global.TopicName}]Velocita[{j * Global.LengthArray}]", Global.LengthArray)[0].Value;
                    
                    //Controllo che la lettura si andata a buon fine
                    if (Temp[0] == -1)
                    {
                        return;
                    }
                    Temp.CopyTo(VelPlc, j * Global.LengthArray);

                    Temp = (float[])Com_Functions.RsLinx_OPC_Client_Read_Array($"[{Global.TopicName}]Corrente[{j * Global.LengthArray}]", Global.LengthArray)[0].Value;
                    
                    //Controllo che la lettura si andata a buon fine
                    if (Temp[0] == -1)
                    {
                        return;
                    }
                    Temp.CopyTo(CorrPlc, j * Global.LengthArray);

                    //Faccio avanzare la progressBar
                    progresso += (double)progressBar1.Maximum/ Global.LengthArray;
                    progressBar1.Value = (int)progresso;
                }

                //Creo il .CSV con le informazioni alla velocità i lette dal PLC tramite OPC
                StreamWriter FileInfoAsse = new StreamWriter($"{textBoxPath.Text}/{i}_{Formati[indice].Nome}.CSV");

                FileInfoAsse.WriteLine($"Formato\t{nomeF}");
                FileInfoAsse.WriteLine($"Motore\t{nomeM}");
                FileInfoAsse.WriteLine($"TempoCampionamento\t{Global.TempoCampionamento}");
                FileInfoAsse.WriteLine("Time\tPosizione\tVelocità\tCorrente");
                for (int k = 0; k != PosPlc.Length; k++)
                {
                    FileInfoAsse.WriteLine($"{Tempo[k]}\t{PosPlc[k]}\t{VelPlc[k]}\t{CorrPlc[k]}");
                }

                //Chiudo il file
                FileInfoAsse.Close();
            }

            //Porto la ProgressBar al 100%
            progressBar1.Value = progressBar1.Maximum;

            //Mostro un MessageBox informativo
            MessageBox.Show("Creazione file .CSV completata!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}