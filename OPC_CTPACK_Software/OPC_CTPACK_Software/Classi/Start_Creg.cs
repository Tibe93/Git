using Accord.Math;
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
        public Creg[] CregTot;
        public double Bs;
        public double Bv;
        public int OffsetPos;
        public int OffsetNeg;

        public Start_Creg(Creg[] CregTot, int OffsetPos, int OffsetNeg)
        {
            this.CregTot = CregTot;
            this.OffsetPos = OffsetPos;
            this.OffsetNeg = OffsetNeg;
            double[,] Attriti = CalcoloAttriti(this.CregTot);
            this.Bs = Attriti[0,0];
            this.Bv = Attriti[1,0];
        }

        public double[,] CalcoloAttriti(Creg[] CregTot)
        {
            //Inizializzo le variabili
            double[,] VelocitaMediaTot = new double[CregTot.Length, 1];
            double[,] Velocita2RMSTot = new double[CregTot.Length, 1];
            double[,] PotenzaMediaTot = new double[CregTot.Length, 1];
            double[,] A = new double[CregTot.Length, 2];
            double[,] FiMotore = new double[2, CregTot.Length];
            double[,] Attriti = new double[2,1];

            //Metto le variabili necessarie in un array
            for (int i=0; i < (CregTot.Length); i++)
            {
                VelocitaMediaTot[i,0] = (CregTot[i].VelocitaMedia);
                Velocita2RMSTot[i,0] = (CregTot[i].Velocita2RMS);
                PotenzaMediaTot[i,0] = (CregTot[i].PotenzaMedia);
            }

            //Visto che VelocitaMediaTot e Velocita2RMSTot sono delle matrici Nx1
            //Le concateno per fare una matrice Nx2 necessaria per il calcolo della pseudoinversa
            A = VelocitaMediaTot.Concatenate(Velocita2RMSTot);
            
            //Calcolo la pseudoinversa tramite la funzione della libreria Accord.Math
            FiMotore = Matrix.PseudoInverse(A);
            
            //Completo il calcolo di Bs e Bv che verranno inseriti nella matrice 2x1 Attriti
            Attriti = Functions.MultiplyMatrix(FiMotore, PotenzaMediaTot, 2, CregTot.Length, 1);

            return Attriti;
        }  
        
    }
}
