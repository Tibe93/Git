using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

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
            this.Formato = new Formato(Formato.Nome, Formato.Motore, Formato.Kp, Formato.Kv, Formato.Kt, Formato.PpmA, Formato.PpmI, Formato.PpmF, Formato.Passo);
            this.Periodi = Periodi;
            int Campioni = Convert.ToInt32(this.Periodi*(60.0 / this.Formato.PpmA)/0.004);
            this.PosConv = new double[Campioni];
            this.VelConv = new double[Campioni];
            this.Coppia = new double[Campioni];
            this.Time = new double[Campioni];

            //dovrei usare il Path che mi da il form, ma per adesso uso questo
            string Pathh = $"{Path}/{Formato.PpmA}_{Formato.Nome}.CSV"; //Fossalta_Temperature.CSV";
            StreamReader Csv = new StreamReader(Pathh);
            string a = Csv.ReadLine(); //riga 1
            string b = Csv.ReadLine(); //riga 2, i dati iniziano alla riga 3
            
            string[] x = new string[20];//sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            double[] PotI = new double[Campioni];
            double[] Vel_2 = new double[Campioni];
            
            //Acquisisco il dati dal file .CSV e faccio i calcoli necessari
            for (int i = 0; i<Campioni; i++)
            {
                x[0] = Csv.ReadLine();
                x = x[0].ToString().Split('\t');
                this.Time[i] = (double.Parse(x[0]));
                this.PosConv[i] = this.Formato.Kp * (double.Parse(x[1].Trim('"').Replace('.',',')));
                this.VelConv[i] = this.Formato.Kv * (double.Parse(x[2].Trim('"').Replace('.', ',')));
                this.Coppia[i] = this.Formato.Kt * (double.Parse(x[3].Trim('"').Replace('.', ',')));
                PotI[i] = this.Coppia[i] * this.VelConv[i];
                Vel_2[i] = this.VelConv[i] * this.VelConv[i];
            }

            //Chiudo il .CSV
            Csv.Close();

            //Calcolo ciò che mi serve
            double DurataPeriodo = this.Time[this.Time.Length-1];
            this.PotenzaMedia = (1/DurataPeriodo) * Functions.Integration(this.Time, PotI);
            this.Velocita2RMS = (1 / DurataPeriodo) * Functions.Integration(this.Time, Vel_2);
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
