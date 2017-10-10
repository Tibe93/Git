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
            while (!Csv.EndOfStream)
            {
                x.Add(Csv.ReadLine());
            }
            int i = 0;
            ArrayList y = new ArrayList();
            StreamWriter Css = new StreamWriter($"{Path}test.CSV");
            for(i = 0; i <3000; i++)
            {
                y.Add($"{4*i},{ x[i].ToString().Substring(29,35)}");//!!devo fare il parsing utilizzando la formattazione sennò non va
            }
            Console.ReadLine();
            Css.WriteLine(a);
            Css.WriteLine(b);
            foreach (string s in y)
            {
                Css.WriteLine(s);
            }
            Css.Close();
        }
    }
}
