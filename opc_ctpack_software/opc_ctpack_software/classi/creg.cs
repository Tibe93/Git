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
        Formato Formato;
        int Periodi;
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
            this.Formato = Formato;
            this.Periodi = Periodi;
            int Campioni = Convert.ToInt32(this.Periodi*(60.0 / this.Formato.Ppm)/0.004);
            this.PosConv = new double[Campioni];
            this.VelConv = new double[Campioni];
            this.Coppia = new double[Campioni];
            this.Time = new double[Campioni];

            //dovrei usare il Path che mi da il form, ma per adesso uso questo
            string Pathh = $@"{Path}_{Formato.Ppm}_Fossalta_Temperature.CSV";
            StreamReader Csv = new StreamReader(Pathh);
            string a = Csv.ReadLine(); //riga 1
            string b = Csv.ReadLine(); //riga 2, i dati iniziano alla riga 3
            
            string[] x = new string[20];//sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            double[] PotI = new double[Campioni];
            double[] Vel_2 = new double[Campioni];
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

            double DurataPeriodo = this.Time[this.Time.Length-1];
            this.PotenzaMedia = (1/DurataPeriodo) * Functions.Integration(this.Time, PotI);
            this.Velocita2RMS = (1 / DurataPeriodo) * Functions.Integration(this.Time, Vel_2);
            this.CregAttuale = this.PotenzaMedia / this.Velocita2RMS;

            foreach(double v in this.VelConv)
            {
                this.VelocitaMedia += v;
            }
            this.VelocitaMedia = this.VelocitaMedia / this.VelConv.Length;

            /* Questa porzione di codice è stata utilizzata per modificare un .CSV di quelli vecchi in modo da crearne uno attuale
            int i = 0;
            ArrayList y = new ArrayList();
            StreamWriter Css = new StreamWriter($"{Path}test.CSV");
            string[] appoggio;
            for(i = 0; i <3000; i++)
            {
                appoggio = x[i].ToString().Split(',');
                y.Add($"{4 * i}\t{appoggio[1].Trim('"').Replace('.',',')}\t{appoggio[2].Trim('"').Replace('.', ',')}\t{appoggio[3].Trim('"').Replace('.', ',')}");//ToString().Substring(29,35)}");
            }
            Console.ReadLine();
            Css.WriteLine(a);
            Css.WriteLine(b);
            foreach (string s in y)
            {
                Css.WriteLine(s);
            }
            Css.Close();
            */
        }
    }
}
