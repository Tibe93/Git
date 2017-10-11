﻿using Accord.Math;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Start_Creg
    {
        Creg[] CregTot;
        double Bs;
        double Bv;
        int OffsetPos;
        int OffsetNeg;

        public Start_Creg(Creg[] CregTot, double Bs, double Bv, int OffsetPos, int OffsetNeg)
        {
            this.CregTot = CregTot;
            this.Bs = Bs;
            this.Bv = Bv;
            this.OffsetPos = OffsetPos;
            this.OffsetNeg = OffsetNeg;
        }

        public double[,] PseudoInversa()
        {
            double[,] CregAttualeTot = new double[CregTot.Length, 1];
            double[,] VelocitaMediaTot = new double[CregTot.Length, 1];
            double[,] Velocita2RMSTot = new double[CregTot.Length, 1];
            double[,] PotenzaMediaTot = new double[CregTot.Length, 1];
            double[,] A = new double[CregTot.Length, 2];
            double[,] FiMotore = new double[2, CregTot.Length];
            double[,] Attriti = new double[2,1];

            for (int i=0; i < (CregTot.Length); i++)
            {
                CregAttualeTot.Add(CregTot[i].CregAttuale);
                VelocitaMediaTot.Add(CregTot[i].VelocitaMedia);
                Velocita2RMSTot.Add(CregTot[i].Velocita2RMS);
                PotenzaMediaTot.Add(CregTot[i].PotenzaMedia);
            }

            Attriti = Functions.MultiplyMatrix(FiMotore, PotenzaMediaTot, 2, CregTot.Length, 1);
            return Attriti;
        }  
        
    }
}
