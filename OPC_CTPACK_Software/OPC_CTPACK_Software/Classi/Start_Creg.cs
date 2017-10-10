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

        /*public double[] PseudoInversa()
        {
            double[,] FiMotore = new double[,];
            double[,] VelocitaMediaTot = new ArrayList();
            double[,] Velocita2RMSTot = new ArrayList();
            double[,] PotenzaMediaTot = new ArrayList();
            double[] Attriti = { Bs, Bv };

            for (int i=0; i < (CregTot.Length); i++)
            {
                VelocitaMediaTot.Add(CregTot[i].VelocitaMedia);
                Velocita2RMSTot.Add(CregTot[i].Velocita2RMS);
                PotenzaMediaTot.Add(CregTot[i].PotenzaMedia);
            }
            FiMotore = Matrix.PseudoInverse(VelocitaMediaTot, Velocita2RMSTot);
            return Attriti = FiMotore * PotenzaMediaTot;
        } */  
        
    }
}
