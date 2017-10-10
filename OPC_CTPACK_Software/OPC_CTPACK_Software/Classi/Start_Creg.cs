using System;
using System.Collections.Generic;
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

        /*public double PseudoInversa()
        {
            double[] VelocitaMediaTot;
            double[] Velocita2RMSTot;
            double[] Attriti= { Bs, Bv };

            for (int i=0; i < (CregTot.Length); i++)
            {
                VelocitaMediaTot[i] = CregTot[i].VelocitaMedia;
                Velocita2RMSTot[i] = CregTot[i].Velocita2RMS;
            }
            FiMotore = PseudoInverse[VelocitaMediaTot, Velocita2RMSTot];
        }   
        */
    }
}
