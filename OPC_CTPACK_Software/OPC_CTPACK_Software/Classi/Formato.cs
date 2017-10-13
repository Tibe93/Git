using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Formato
    {
        public string Nome;
        public Motore Motore;
        public int PpmA;
        public double Kp;
        public double Kv;
        public double Kt;
        public int PpmI;
        public int PpmF;
        public int Passo;

        public Formato(string Nome, Motore Motore, double Kp, double Kv, double Kt, int PpmA, int PpmI, int PpmF, int Passo)
        {
            this.Nome = Nome;
            this.Motore = Motore;
            this.Kp = Kp;
            this.Kv = Kv;
            this.Kt = Kt;
            this.PpmA = PpmA;
            this.PpmI = PpmI;
            this.PpmF = PpmF;
            this.Passo = Passo;
        }

        public override string ToString()
        {
            return  $"Formato: {this.Nome}\n" +
                    $"Motore: {this.Motore.GetModel()}\n" +
                    $"Kp = {this.Kp}\n" +
                    $"Kv = {this.Kv}\n" +
                    $"Kc = {this.Kt}";
        }

        public string GetNome()
        {
            return $"Formato: {this.Nome}, Motore: {this.Motore.GetModel()}";
        }
    }
}
