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
        public static double TempoCampionamento = 0.004; // Tempo minimo di campionamento del Plc
        public static int NumPeriodi = 3; // Numero di periodi che vado ad analizzare (Max 5 periodi se non si scende sotto i 70ppm)
        public static int UpdateRate = 1000; // Tempo di aggiornamento dei gruppi dell'OPC
        public static int NumeroCampioni = 1200; // Numero massimo di campioni che vado ad analizzare nelle variabili acquisite
        public static int LengthArray = 120; // Massima dimensione degli array che posso scambiare con il Plc tramite OPC

        public static string Path = "../Dati/"; // Path dove si trova il file di configurazione dei formati
        public static string PathTrend = "../Dati/Trend_Attuali/"; // Path dove vado a salvare le informazioni attuali del motore per il calcolo del Creg attuale
        public static string PathStorico = "../Dati/Storico/"; // Path dove vado a salvare lo storico dei Creg alle diverse velocità e il file con resoconto totale
        public static string Url = "opcda://localhost/RSLinx OPC Server/{A05BB6D6-2F8A-11D1-9BB0-080009D01446}"; // URL del Server OPC di RSLinx 
        public static string TopicName = "Creg_OPC_Topic"; // Nome del Topic
    }
}