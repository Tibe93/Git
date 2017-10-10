using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Start_Creg
    {
        Creg[] Creg;
        double Bs;
        double Bv;
        int OffsetPos;
        int OffsetNeg;

        public Start_Creg(double[] Creg, double Bs, double Bv, int OffsetPos, int OffsetNeg)
        {
            this.Creg = Creg;
            this.Bs = Bs;
            this.Bv = Bv;
            this.OffsetPos = OffsetPos;
            this.OffsetNeg = OffsetNeg;
        }


        public static double[][] PseudoInverse
        (
            this double[][] matrix
        )
    }
}
