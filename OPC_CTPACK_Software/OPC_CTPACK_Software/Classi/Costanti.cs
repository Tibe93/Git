using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPC_CTPACK_Software
{
    public class Global
    {
        public static double TempoCampionamento = 0.004;
        public static int NumPeriodi = 3;
        public static int UpdateRate = 1000;
        public static int NumeroCampioni = 1200;
        public static int LengthArray = 120;

        public static string Path = "../Dati/";
        public static string PathTrend = "../Dati/Trend_Attuali/";
        public static string PathStorico = "../Dati/Storico/";
        public static string Url = "opcda://localhost/RSLinx OPC Server/{A05BB6D6-2F8A-11D1-9BB0-080009D01446}";
        public static string TopicName = "Creg_OPC_Topic";
    }
}