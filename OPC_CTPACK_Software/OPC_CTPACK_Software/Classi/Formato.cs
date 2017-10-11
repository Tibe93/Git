using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Formato
    {
        string Nome;
        Motore Motore;
        public int Ppm;
        public double Kp;
        public double Kv;
        public double Kt;

        public Formato(string Nome, Motore Motore,int Ppm, double Kp, double Kv, double Kt)
        {
            this.Nome = Nome;
            this.Motore = Motore;
            this.Kp = Kp;
            this.Kv = Kv;
            this.Kt = Kt;
            this.Ppm = Ppm;
        }

        public override string ToString()
        {
            return  $"Formato: {this.Nome}\n" +
                    $"Motore: {this.Motore.GetModel()}\n" +
                    $"Kp = {this.Kp}\n" +
                    $"Kv = {this.Kv}\n" +
                    $"Kc = {this.Kt}";
        }
    }
}
