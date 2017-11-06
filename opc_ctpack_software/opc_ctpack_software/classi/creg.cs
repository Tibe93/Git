using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace OPC_CTPACK_Software
{
    public class Creg
    {
        public Formato Formato;
        public int Periodi;
        double[] PosConv;
        double[] VelConv;
        double[] Coppia;
        double[] Time;
        public double PotenzaMedia;
        public double VelocitaMedia;
        public double Velocita2RMS;
        public double CregAttuale;

        public Creg(Formato Formato, string Path, int Periodi)
        {
            //Costruttore del formato, ne creo un'altra istanza in modo da non passarlo per riferimento
            this.Formato = new Formato(Formato.Nome, Formato.Motore, Formato.Kv, Formato.Kt, Formato.PpmA, Formato.PpmI, Formato.PpmF, Formato.Passo);
            this.Periodi = Periodi;
            string Pathh = $"{Path}/{Formato.PpmA}_{Formato.Nome}.CSV";
            
            //Vecchio metodo per il conto dei campioni necessari, abbastanza preciso ma deprecato
            //int Campioni = Convert.ToInt32(this.Periodi*(60.0 / this.Formato.PpmA)/Global.TempoCampionamento);
            
            //Devo capire quanti campioni mi occorrono per avere i dati per i periodi selezionati
            //Quindi apro il file, lo leggo fino al passare dei periodi selezionati, mi salvo il numero
            //dei campioni necessari e poi lo chiudo il file
            double[] PosInit = new double[Global.NumeroCampioni];
            
            //Controllo che esista il file
            if (!File.Exists(Pathh))
            {
                MessageBox.Show("ERRORE: Il file non esiste", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            //Apro il .CSV
            StreamReader CsvInit = new StreamReader(Pathh);
            int Campioni = 0;
            int Periodi_Count = 0;
            CsvInit.ReadLine(); //Riga 1
            CsvInit.ReadLine(); //Riga 2
            CsvInit.ReadLine(); //Riga 3
            CsvInit.ReadLine(); //Riga 4, i dati iniziano alla riga 5
            PosInit[Campioni] = double.Parse(CsvInit.ReadLine().ToString().Split('\t')[1]);
            while (!CsvInit.EndOfStream)
            {
                Campioni++;
                PosInit[Campioni] = double.Parse(CsvInit.ReadLine().ToString().Split('\t')[1]);

                if(PosInit[Campioni-1] > PosInit[Campioni])
                {   //Le posizioni sono cicliche con modulo di 360.
                    //Se il campione precedente è maggiore di quello successivo significa 
                    //che da 360 passo a 0 e ricomincio il ciclo, incremento quindi il numero di periodi
                    Periodi_Count++;
                }

                if(Periodi_Count == this.Periodi && PosInit[Campioni] > PosInit[0])
                {   //Se il numero di periodi passati coincide con quelli richiesti e
                    //il campione in esame è maggiore di quello iniziale vuol dire che
                    //abbiamo trovato il numero di campioni necessari
                    break;
                }
                else if(PosInit[Campioni] < PosInit[0] && Periodi_Count == (this.Periodi + 1))
                {   //Caso particolare: Se il primo campione del CSV è il numero prima del reset del modulo
                    //Posso incrementare i campioni e resettare il modulo, in questo caso avrò il campione
                    //Successivo minore di quello in esame e il numero di periodi più grande di un unità
                    //Rispetto a quelli richiesti, anche in questo caso ho trovato il numero di campioni necessari
                    break;
                }
                
            }
            
            this.PosConv = new double[Campioni];
            this.VelConv = new double[Campioni];
            this.Coppia = new double[Campioni];
            this.Time = new double[Campioni];
            
            //Controllo che esista il file
            if (!File.Exists(Pathh))
            {
                MessageBox.Show("ERRORE: Il file non esiste", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);                
            }

            //Apro il .CSV
            StreamReader Csv = new StreamReader(Pathh);
            
            //Leggo l'intestazione
            string a = Csv.ReadLine(); //Riga 1
            string b = Csv.ReadLine(); //Riga 2
            string c = Csv.ReadLine(); //Riga 3
            string d = Csv.ReadLine(); //Riga 4, i dati iniziano alla riga 5

            string[] x = new string[20]; //Sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            double[] PotI = new double[Campioni];
            double[] Vel_2 = new double[Campioni];
            
            //Acquisisco il dati dal file .CSV e faccio i calcoli necessari
            for (int i = 0; i<Campioni; i++)
            {
                x[0] = Csv.ReadLine();
                x = x[0].ToString().Split('\t');
                this.Time[i] = (double.Parse(x[0]));
                this.PosConv[i] = double.Parse(x[1]);
                this.VelConv[i] = this.Formato.Kv * (double.Parse(x[2]));
                this.Coppia[i] = this.Formato.Kt * (double.Parse(x[3])); // usavamo questo quando i CSV erano formattati da Logix5000 .Trim('"').Replace('.', ',')));

                PotI[i] = this.Coppia[i] * this.VelConv[i];
                Vel_2[i] = this.VelConv[i] * this.VelConv[i];
            }

            //Chiudo il .CSV
            Csv.Close();

            //Calcolo ciò che mi serve
            double DurataPeriodo = this.Time[this.Time.Length-1];
            this.PotenzaMedia = (1/DurataPeriodo) * Math_Functions.Integration(this.Time, PotI);
            this.Velocita2RMS = (1 / DurataPeriodo) * Math_Functions.Integration(this.Time, Vel_2);
            this.CregAttuale = this.PotenzaMedia / this.Velocita2RMS;

            //Calcolo la velocità media
            foreach(double v in this.VelConv)
            {
                this.VelocitaMedia += v;
            }
            this.VelocitaMedia = this.VelocitaMedia / this.VelConv.Length;
        }
    }
}
