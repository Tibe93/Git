using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPC_CTPACK_Software
{
    public class Global
    {
        //Costanti numeriche
        public static double TempoCampionamento; //Tempo minimo di campionamento del Plc
        public static int NumPeriodi; //Numero di periodi che vado ad analizzare (Max 5 periodi se non si scende sotto i 70ppm)
        public static int UpdateRate; //Tempo di aggiornamento dei gruppi dell'OPC
        public static int NumeroCampioni; //Numero massimo di campioni che vado ad analizzare nelle variabili acquisite
        public static int LengthArray; //Massima dimensione degli array che posso scambiare con il Plc tramite OPC

        //Costanti letterali
        public static string StandardPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/OPC Monitoring/"; //Path dove si trova il file di configurazione dei formati
        public static string PathTrend = $"{StandardPath}Trend_Attuali/"; //Path dove vado a salvare le informazioni attuali del motore per il calcolo del Creg attuale
        public static string PathStorico = $"{StandardPath}Storico/"; //Path dove vado a salvare lo storico dei Creg alle diverse velocità e il file con resoconto totale
        public static string PathConfig = $"{StandardPath}Formati.config"; //Path del file Formati.config
        public static string PathCostanti = $"{StandardPath}Costanti.config";
        public static string Url; //URL del Server OPC di RSLinx 
        public static string TopicName; //Nome del Topic

        public static void CostantiConfig()
        {
            StreamReader FileConfig = new StreamReader(PathCostanti);
            FileConfig.ReadLine();//Salto la di intestazione

            //Costanti numeriche
            TempoCampionamento = Double.Parse(FileConfig.ReadLine().Split('\t')[1]);
            NumPeriodi = Int32.Parse(FileConfig.ReadLine().Split('\t')[1]);
            UpdateRate = Int32.Parse(FileConfig.ReadLine().Split('\t')[1]);
            NumeroCampioni = Int32.Parse(FileConfig.ReadLine().Split('\t')[1]);
            LengthArray = Int32.Parse(FileConfig.ReadLine().Split('\t')[1]);

            FileConfig.ReadLine();//Salto la riga di separazione
            FileConfig.ReadLine();//Salto la riga di intestazione

            //Costanti letterali
            Url = FileConfig.ReadLine().Split('\t')[1];
            TopicName = FileConfig.ReadLine().Split('\t')[1];
        }
    }
}