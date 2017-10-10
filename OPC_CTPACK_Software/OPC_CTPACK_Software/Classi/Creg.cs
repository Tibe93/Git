using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        double VelocitaMedia;
        double Velocita2RMS;
        double CregAttuale;

        public Creg(Formato Formato, string Path)
        {
            this.Formato = Formato;        }
    }
}
