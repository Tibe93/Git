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
        public double VelocitaMedia;
        public double Velocita2RMS;
        public double CregAttuale;

        public Creg(Formato Formato, string Path)
        {
            this.Formato = Formato;
            File.OpenRead("C:\Users\CtPack\Desktop\Tiberia\Trend_Tibe\_Fossalta_Temperature_Termoregolate\1");
        }
    }
}
