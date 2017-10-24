using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace OPC_CTPACK_Software
{
    public partial class Form2 : Form
    {
        Form1 FormPadre;
        Form3 FormFiglio;
        Start_Creg CregInit;
        bool Timer = false;//Variabile che mi fa capire se devo far partire o no il timer

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
            //Quando chiudo il form chiudo anche il FormPadre
            this.FormPadre.Close();
        }

        private void butIndietro_Click(object sender, EventArgs e)
        {
            //Visualizzo il FormPadre tornando indietro
            this.FormPadre.Visible = true;
            this.Visible = false;
        }

        private void butStorico_Click(object sender, EventArgs e)
        {
            //Apro la finestra dello storico
            this.FormFiglio = new Form3();
            FormFiglio.Show();
        }

        private void butCalcola_Click(object sender, EventArgs e)
        {
            //Se è necessario avvio il timer
            if(Timer && !timer1.Enabled)
            {
                timer1.Start();
            }

            //Cancello i punti del grafico precedente
            chartCreg.Series["CregAttuale"].Points.Clear();

            //Prima parte
            //Attraverso l'OPC mi interefaccio col PLC, tiro giu i dati e li salvo su CSV
            string TopicName = "Creg_OPC_Topic";//Setto il nome del Topic OPC
            double[] PosNow = new double[1250];
            double[] VelNow = new double[1250];
            double[] CorNow = new double[1250];
            int[] Tempo = new int[1250];
            double TempoCampionamento = 0.004;

            //Leggo la velocità a cui sta andando la macchina
            int PpmNow = (int)Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Ppm_Run").Value;
            Functions.RsLinx_OPC_Client_Write($"[{TopicName}]Ppm_Start", PpmNow);
            while(true)
            {
                //Attendo che il plc finisca di fare i campionamenti, quando finisce mette Ppm_Start a 0
                if((int)Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Ppm_Start").Value == 0)
                {
                    break;
                }
                Thread.Sleep(500);
            }

            //Ne creo una nuova istanza per non aver problemi visto che le classi vengono passate per riferimento
            Formato FormatoAttuale = new Formato(this.CregInit.CregTot[0].Formato.Nome, this.CregInit.CregTot[0].Formato.Motore, this.CregInit.CregTot[0].Formato.Kp, this.CregInit.CregTot[0].Formato.Kv, this.CregInit.CregTot[0].Formato.Kt, PpmNow, this.CregInit.CregTot[0].Formato.PpmI, this.CregInit.CregTot[0].Formato.PpmF, this.CregInit.CregTot[0].Formato.Passo);


            for (int i = 0; i < PosNow.Length; i++)
            {
                PosNow[i] = (float)Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Posizione_{PpmNow}[{i}]").Value;
                VelNow[i] = (float)Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Velocita_{PpmNow}[{i}]").Value;
                CorNow[i] = (float)Functions.RsLinx_OPC_Client_Read($"[{TopicName}]Corrente_{PpmNow}[{i}]").Value;
                Tempo[i] = (int) (i * (TempoCampionamento * 1000));
            }

            // Mi salvo le variabili che arrivano dal PLC e creo il .CSV con le informazioni alla velocità i
            StreamWriter FileInfoAsse = new StreamWriter($"../Dati/Trend/prova/{FormatoAttuale.PpmA}_{FormatoAttuale.Nome}.CSV");
            

            FileInfoAsse.WriteLine($"Formato\t{FormatoAttuale.Nome}");
            FileInfoAsse.WriteLine($"Motore\t{FormatoAttuale.Motore.GetModel()}");
            FileInfoAsse.WriteLine($"TempoCampionamento\t{TempoCampionamento}");
            FileInfoAsse.WriteLine("Time\tPosizione\tVelocità\tCorrente");

            for (int k = 0; k < PosNow.Length; k++)
            {
                FileInfoAsse.WriteLine($"{Tempo[k]}\t{PosNow[k]}\t{VelNow[k]}\t{CorNow[k]}");
            }

            FileInfoAsse.Close();

            //Seconda parte
            //Apro il CSV appena salvato, calcolo il Creg e lo grafico
            Creg CregAttuale = new Creg(FormatoAttuale, "../Dati/Trend/prova", this.CregInit.CregTot[0].Periodi);

            //Disegno il punto del CregAttuale sul grafico
            chartCreg.Series["CregAttuale"].Points.AddXY(CregAttuale.Formato.PpmA, CregAttuale.CregAttuale);

            //Visualizzo il valore di CregAttuale
            textBoxCreg.Text = CregAttuale.CregAttuale.ToString();
            pictureBoxAllarme.Enabled = false;

            //Ottengo il valore di CregTeo relativo ai Ppm attuali necessario per il confronto
            double CregTeo = 0;
            if (CregAttuale.Formato.PpmA == CregInit.CregTot[0].Formato.PpmA)
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
                        break;
                    }
                    else if ((CregAttuale.Formato.PpmA > CregInit.CregTot[i - 1].Formato.PpmA) && (CregAttuale.Formato.PpmA < CregInit.CregTot[i].Formato.PpmA))
                    {
                        CregTeo = ((CregInit.CregTot[i - 1].CregAttuale * (CregInit.CregTot[i].Formato.PpmA - CregAttuale.Formato.PpmA)) + (CregInit.CregTot[i].CregAttuale * (CregAttuale.Formato.PpmA - CregInit.CregTot[i - 1].Formato.PpmA))) / CregInit.CregTot[i].Formato.Passo;
                        break;
                    }
                }
            }

            //Controllo se il CregAttuale è nelle soglie, se così non è attivo allarme
            if (CregAttuale.CregAttuale >= (CregTeo + (CregTeo * CregInit.OffsetPos) / 100))
            {
                pictureBoxAllarme.Enabled = true;
            }
            if (CregAttuale.CregAttuale <= (CregTeo + (CregTeo * CregInit.OffsetNeg) / 100))
            {
                pictureBoxAllarme.Enabled = true;
            }

            //Scrivo il valore del CregAttuale sul file per lo storico con PPM
            StreamWriter Storico;
            if (File.Exists($"../Dati/{CregAttuale.Formato.PpmA}_{CregAttuale.Formato.Nome}_Storico_Creg.txt"))
            {
                //Se il file esiste già lo apro in append
                Storico = File.AppendText($"../Dati/{CregAttuale.Formato.PpmA}_{CregAttuale.Formato.Nome}_Storico_Creg.txt");
            }
            else
            {
                //Se non esiste lo creo e scrivo l'intestazione
                Storico = new StreamWriter($"../Dati/{CregAttuale.Formato.PpmA}_{CregAttuale.Formato.Nome}_Storico_Creg.txt");

                Storico.WriteLine($"Tolleranza\t{this.CregInit.OffsetPos}");
                Storico.WriteLine($"CregTeo\t{CregTeo}");
                Storico.WriteLine("");
                Storico.WriteLine("DateTime\t\tCreg");
            }
            //Scrivo il CregAttuale e chiudo il file
            Storico.WriteLine($"{DateTime.Now}\t{CregAttuale.CregAttuale}");
            Storico.Close();

            //Scrivo il valore del CregAttuale sul file per lo storico Totale
            StreamWriter StoricoTot;
            if (File.Exists($"../Dati/TOT_{CregAttuale.Formato.Nome}_Storico_Creg.txt"))
            {
                //Se il file esiste già lo apro in append
                StoricoTot = File.AppendText($"../Dati/TOT_{CregAttuale.Formato.Nome}_Storico_Creg.txt");
            }
            else
            {
                //Se non esiste lo creo e scrivo l'intestazione
                StoricoTot = new StreamWriter($"../Dati/TOT_{CregAttuale.Formato.Nome}_Storico_Creg.txt");

                StoricoTot.WriteLine($"Tolleranza\t{this.CregInit.OffsetPos}");
                StoricoTot.WriteLine("");
                StoricoTot.WriteLine("DateTime\t\tCreg\t\t\tCregTeo\t\t\tPpm");
            }
            //Scrivo il CregAttuale e chiudo il file
            StoricoTot.WriteLine($"{DateTime.Now}\t{CregAttuale.CregAttuale}\t{CregTeo}\t{CregAttuale.Formato.PpmA}");
            StoricoTot.Close();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            //Stoppo il timer
            this.Timer = false;
            timer1.Stop();
            //Operazioni sulla grafica
            butStop.Enabled = false;
            comboxTime.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Simulo il clock del bottone Calcola via software
            butCalcola.PerformClick();
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Setto gli intervalli del timer in base a quelli selezionati
            butStop.Enabled = true;
            if(comboxTime.Text.Equals("10 minuti"))
            {
                timer1.Interval = 600000;
            }
            else if (comboxTime.Text.Equals("1 ora"))
            {
                timer1.Interval = 3600000;
            }
            else if (comboxTime.Text.Equals("4 ore"))
            {
                timer1.Interval = 14400000;
            }
            this.Timer = true;
        }
    }
}
