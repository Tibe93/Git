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
        double[] PosConv;
        double[] VelConv;
        double[] CorrConv;
        double[] Time;
        int Periodi;
        public double PotenzaMedia;
        public double VelocitaMedia;
        public double Velocita2RMS;
        public double CregAttuale;

        public Creg(Formato Formato, string Path)
        {
            this.Formato = Formato;
            //dovrei usare il Path che mi da il form, ma per adesso uso questo
            string Pathh = $@"{Path}_{Formato.Ppm}_Fossalta_Temperature.CSV";
            StreamReader Csv = new StreamReader(Pathh);
            string a = Csv.ReadLine(); //riga 1
            string b = Csv.ReadLine(); //riga 2, i dati iniziano alla riga 3
            
            ArrayList x = new ArrayList();
            string[] y;
            ArrayList Tempo = new ArrayList();
            ArrayList Pos = new ArrayList(); 
            ArrayList Vel = new ArrayList(); 
            ArrayList Cor = new ArrayList();
            int i = 0;
            while (!Csv.EndOfStream)
            {
                x.Add(Csv.ReadLine());
                y = x[i].ToString().Split(',');
                Tempo.Add(double.Parse(y[0]));
                Pos.Add(double.Parse(y[1].Trim('"').Replace('.',',')));
                Vel.Add(double.Parse(y[2].Trim('"').Replace('.', ',')));
                Cor.Add(double.Parse(y[3].Trim('"').Replace('.', ',')));
                i++;
            }


            Console.ReadLine();
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
