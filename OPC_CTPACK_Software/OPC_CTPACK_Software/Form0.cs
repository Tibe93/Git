﻿using Opc.Da;
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
            // Leggo i formati dal file Formati.config e li inserisco in un array
            this.Formati = Functions.LetturaFormati();
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Formati.Length; i++)
            {
                // Aggiungo i formati alla comboBox
                comboBoxFormato.Items.Add(this.Formati[i].GetNome());
            }
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            // Dopo il click seleziono dove salvare il .CSV, il path verrà messo nella textBox
            folderBrowserDialog1.ShowDialog();
            textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            // Dopo il click mi sposto nel Form figlio (Form1)
            FormFiglio.Visible = true;
            this.Visible = false;
        }

        private void comboBoxFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Operazioni sulla grafica
            comboBoxFormato.BackColor = Color.White;
            butPath.Enabled = true;
            textBoxPath.Enabled = true;
            textBoxPath.BackColor = Color.LightGreen;
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            // Operazioni sulla grafica
            textBoxPath.BackColor = Color.White;
            butAnalisi.Enabled = true;
        }

        private void butAnalisi_Click(object sender, EventArgs e)
        {
            // mi connetto all'OPC

            // Inizializzo le variabili necessarie
            // 1250 è il numero di campioni che abbiamo deciso di salvare visto che corrispondono a circa 5 secondi
            double[] PosPlc = new double[1250];
            double[] VelPlc = new double[1250];
            double[] CorrPlc = new double[1250];
            int[] Tempo = new int[1250]; ;
            double TempoCampionamento = 0.004;
            string nomeF = "";
            string nomeM = "";
            string TopicName = "Creg_OPC_Topic";
            int indice = 0;
            
            // Mi creo la variabile Tempo che verrà inserita nel File
            double TempoAttuale = 0;
            for (int j = 1; j < PosPlc.Length; j++)
            {
                TempoAttuale = TempoAttuale + (TempoCampionamento * 1000);
                Tempo[j] = Convert.ToInt32(TempoAttuale);
            }

            // Seleziono il formato dell'array creato precedentemente che ha lo stesso nome dell'elemento selezionato nella comboBox
            for (int i=0; i < Formati.Length; i++)
            {
                if(string.Equals(Formati[i].Nome,comboBoxFormato.SelectedItem.ToString().Split(',')[0]))
                {
                    nomeF = Formati[i].Nome;
                    nomeM = Formati[i].Motore.GetModel();
                    indice = i;
                }
            }

            // Chiedo al PLC di far girare il motore del formato selezionato a diverse velocità
            // Parto da una velocità iniziale e aggiungendo il passo arrivo a quella finale
            // Per ognuna di queste velocità mi arriveranno i dati dal PLC con qui andrò a creare i diversi file
            double progresso = 0.0;
            progressBar1.Value = 0;
            for (int i=Formati[indice].PpmI; i <= Formati[indice].PpmF; i=i+Formati[indice].Passo)
            {
                // Dico al PLC di eseguire a velocità i
                Functions.RsLinx_OPC_Client_Write($"[{TopicName}]Ppm_Start", i);

                // Controllo quando Ppm_Start và a zero, quindi quando il plc ha finito l'analisi alla velocità i
                while (true)
                {
                    //Attendo che il plc finisca di fare i campionamenti, quando finisce mette Ppm_Start a 0
                    if ((int)Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Ppm_Start").Value == 0)
                    {
                        break;
                    }
                    Thread.Sleep(500);
                }

                for (int j=0; j<1250; j++)
                {
                    PosPlc[j] = (float) Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Posizione_{i}[{j}]").Value;
                    VelPlc[j] = (float) Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Velocita_{i}[{j}]").Value;
                    CorrPlc[j] = (float) Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Corrente_{i}[{j}]").Value;
                    progresso += (double)100/15000;
                    progressBar1.Value = (int)progresso;
                }

                // Mi salvo le variabili che arrivano dal PLC e creo il .CSV con le informazioni alla velocità i
                StreamWriter FileInfoAsse = new StreamWriter($"{textBoxPath.Text}/{i}_{Formati[indice].Nome}.CSV");

                FileInfoAsse.WriteLine($"Formato\t{nomeF}");
                FileInfoAsse.WriteLine($"Motore\t{nomeM}");
                FileInfoAsse.WriteLine($"TempoCampionamento\t{TempoCampionamento}");
                FileInfoAsse.WriteLine("Time\tPosizione\tVelocità\tCorrente");
                for (int k = 0; k != PosPlc.Length; k++)
                {
                    FileInfoAsse.WriteLine($"{Tempo[k]}\t{PosPlc[k]}\t{VelPlc[k]}\t{CorrPlc[k]}");
                }

                FileInfoAsse.Close();
            }
            progressBar1.Value = 100;
        }
    }
}