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
        public static double TempoCampionamento = 0.004; // Tempo di campionamento minimo dei dati da parte del Plc
        public static int NumPeriodi = 3; // Numero di periodi analizzati (Max 5 periodi se non si scende sotto i 70ppm)
        public static int UpdateRate = 1000; // Tempo di aggiornamento del gruppo dell'OPC
        public static int NumeroCampioni = 1200; // Numero di campioni presi per ogni variabile del motore analizzata
        public static int LengthArray = 120; // Lunghezza massima degli array che possono essere scambiati con il Plc tramite OPC

        public static string Path = "../Dati";
        public static string PathTrend = "../Dati/Trend";
        public static string Url = "opcda://localhost/RSLinx OPC Server/{A05BB6D6-2F8A-11D1-9BB0-080009D01446}"; // URL del RSLinx OPC Server
        public static string TopicName = "Creg_OPC_Topic"; // Nome del Topic
    }
}