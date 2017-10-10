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
        public double PotenzaMedia;
        public double VelocitaMedia;
        public double Velocita2RMS;
        public double CregAttuale;

        public Creg(Formato Formato, string Path)
        {
            this.Formato = Formato;
            //dovrei usare il Path che mi da il form, ma per adesso uso questo
            Path = $@"{Path}_{Formato.Ppm}_Fossalta_Temperature.CSV";
            File.OpenRead(Path);
        }
    }
}
