﻿using System;
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
        public double Kc;

        public Formato(string Nome, Motore Motore,int Ppm, double Kc, double Kv, double Kp)
        {
            this.Nome = Nome;
            this.Motore = Motore;
            this.Kc = Kc;
            this.Kv = Kv;
            this.Kp = Kp;
            this.Ppm = Ppm;
        }

        public override string ToString()
        {
            return  $"Formato: {this.Nome}\n" +
                    $"Motore: {this.Motore.GetModel()}\n" +
                    $"Kp = {this.Kp}\n" +
                    $"Kv = {this.Kv}\n" +
                    $"Kc = {this.Kc}";
        }
    }
}
