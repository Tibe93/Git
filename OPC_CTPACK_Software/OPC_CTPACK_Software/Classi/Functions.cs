using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Opc;
using Opc.Da;
using System.Collections;
using System.Threading;

namespace OPC_CTPACK_Software
{
    public class Functions
    {
        public static double[,] MultiplyMatrix(double[,] A, double[,] B, int n, int m, int r)
        {   //Funzione per la moltiplicazione tra matrici
            double[,] C = new double[n, r];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }
        
        public static double Integration(double[] Time, double[] A)
        {   //Funzione integrale con metodo trapezoidale
            double Somma = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                Somma += (A[i] + A[i + 1]) * ((Time[i + 1] - Time[i]) / 2);
            }

            return Somma;
        }

        public static Formato[] LetturaFormati()
        {   //Funzione che apre il file Formati.config e salva i valori nelle variabili Formato e Motore
            
            //Controllo che il file esista
            if (!File.Exists(Global.PathConfig))
            {
                MessageBox.Show("ERRORE: Il file non esiste", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            //Apro il file Formati.config
            StreamReader FileConfig = new StreamReader(Global.PathConfig);

            string M = FileConfig.ReadLine().Split('\t')[0]; //Lettura numero motori
            int NMotori = System.Convert.ToInt32(M);
            Motore[] _Motore = new Motore[NMotori];

            string[] x1 = new string[20]; //Sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            string a = FileConfig.ReadLine(); //Legenda, quindi la salto
            
            //Leggo i dati di ogni motore e lo inizializzo
            for (int i = 0; i < NMotori; i++)
            {
                x1[0] = FileConfig.ReadLine();
                x1 = x1[0].ToString().Split('\t');
                _Motore[i] = new Motore(x1[0], x1[1], x1[2], x1[3], x1[4], x1[5], x1[6], x1[7], System.Convert.ToDouble(x1[8]), x1[9], x1[10], x1[11]);
            }

            string F = FileConfig.ReadLine().Split('\t')[0]; //Lettura numero formati
            int NFormati = System.Convert.ToInt32(F);
            Formato[] _Formati = new Formato[NFormati];

            string[] x2 = new string[20]; //Sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            int IndiceMotore = 0;
            a = FileConfig.ReadLine(); //Legenda, quindi la salto

            //Leggo i dati di ogni formato e lo inizializzo
            for (int i = 0; i < NFormati; i++)
            {

                x2[0] = FileConfig.ReadLine();
                x2 = x2[0].ToString().Split('\t');

                //Cerco il motore corrispondente
                for (int j = 0; j < NMotori; j++)
                {
                    if (string.Equals(x2[1], _Motore[j].GetModel()))
                    {
                        IndiceMotore = j;
                        break;
                    }
                }

                _Formati[i] = new Formato(x2[0], _Motore[IndiceMotore], System.Convert.ToDouble(x2[2]), System.Convert.ToDouble(x2[3]), System.Convert.ToInt32(x2[4]), System.Convert.ToInt32(x2[5]), System.Convert.ToInt32(x2[6]), System.Convert.ToInt32(x2[7]));
            }

            // Chiudo il File
            FileConfig.Close();

            return _Formati;
        }

        public static ItemValueResult RsLinx_OPC_Client_Read(string ItemName)
        {
            try
            {
                //Creo un istanza di OPC.server
                Opc.Da.Server server;
                
                //Parametro necessario alla connect
                OpcCom.Factory fact = new OpcCom.Factory();
                
                //Creo un istanza di Sottoscrizione
                Opc.Da.Subscription groupRead;
                
                //Creo un istanza di SubscriptionState, utile per controllare lo stato della sottoscrizione
                Opc.Da.SubscriptionState groupState;
                
                //Creo un array di OPC.Da.Item
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                
                //Setto factory e url del server, come url utilizzo quello del RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //Connetto il server
                server.Connect();

                //Istanzio la sottoscrizione           
                groupState = new Opc.Da.SubscriptionState();
                groupState.Name = "Group";
                groupState.UpdateRate = Global.UpdateRate; //Setto il tempo di Refresh del gruppo
                groupState.Active = true; //Questo valore deve essere true se voglio aver la possibilità di leggere
                
                //Creo il gruppo sul server
                groupRead = (Opc.Da.Subscription)server.CreateSubscription(groupState);

                //Istanzio l'Item
                items[0] = new Opc.Da.Item();
                
                //Gli do il nome (Rockwell utilizza questa formzattazione dei nomi [NomeTopicOPC]NomeTag es. [MyOPCTopic]Posizione)
                items[0].ItemName = ItemName;

                //Aggiungo l'oggetto al gruppo
                items = groupRead.AddItems(items);
                
                //Leggo il valore dell'item aggiunto
                ItemValueResult Ritorno = groupRead.Read(items)[0];
                
                //Controllo che la lettura sia andata a buon fine, se non è così lancio un'eccezione
                if(!Ritorno.ResultID.Name.Name.Equals("S_OK"))
                {
                    throw new System.Exception("Errore lettura OPC Tag");
                }

                return groupRead.Read(items)[0];
            }
            catch (Exception ex)
            {   //Se viene lanciata un'eccezione ritorno un ItemValueResult con valore -1 e mostro un Messagebox con l'errore
                MessageBox.Show(ex.Message);
                ItemValueResult Errore = new ItemValueResult();
                Errore.Value = -1;
                return Errore;
            }
        }

        public static void RsLinx_OPC_Client_Write(string ItemName, object Value)
        {
            try
            {
                //Creo un istanza di OPC.server
                Opc.Da.Server server;

                //Parametro necessario alla connect
                OpcCom.Factory fact = new OpcCom.Factory();
                
                //Creo un istanza di Sottoscrizione
                Opc.Da.Subscription groupWrite;
                
                //Creo un istanza di SubscriptionState, utile per controllare lo stato della sottoscrizione
                Opc.Da.SubscriptionState groupStateWrite;
                
                //Creo un array di OPC.Da.Item
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                
                //Setto factory e url del server, come url utilizzo quello del RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //Connetto il server
                server.Connect();

                //Istanzio la sottoscrizione                    
                groupStateWrite = new Opc.Da.SubscriptionState();
                groupStateWrite.Name = "Group Write";
                //Questo valore deve essere true se voglio aver la possibilità di leggere, se devo solo scrivere lo metto false
                groupStateWrite.Active = false;
                
                //Creo il gruppo sul server
                groupWrite = (Opc.Da.Subscription)server.CreateSubscription(groupStateWrite);

                //Creo l'Item da scrivere (se il gruppo non lo possiede, lo devo inserire)
                Opc.Da.Item[] itemToAdd = new Opc.Da.Item[1];
                itemToAdd[0] = new Opc.Da.Item();
                itemToAdd[0].ItemName = ItemName;

                //Creo l'istanza di ItemValue che possiede il mio Item e il valore che voglio assegnargli
                Opc.Da.ItemValue[] writeValues = new Opc.Da.ItemValue[1];
                writeValues[0] = new Opc.Da.ItemValue(itemToAdd[0]);

                //Controllo se l'oggetto esiste nel gruppo
                bool itemFound = false;
                foreach (Opc.Da.Item item in groupWrite.Items)
                {
                    if (item.ItemName == itemToAdd[0].ItemName)
                    {
                        //Se lo trovo gli setto il nuovo valore
                        writeValues[0].ServerHandle = item.ServerHandle;
                        itemFound = true;
                    }
                }
                if (!itemFound)
                {
                    //Se non ho trovato l'oggetto nel gruppo lo aggiungo..
                    groupWrite.AddItems(itemToAdd);
                    writeValues[0].ServerHandle = groupWrite.Items[groupWrite.Items.Length - 1].ServerHandle;
                }
                
                //...gli setto il valore
                writeValues[0].Value = Value;
                
                //e lo scrivo
                groupWrite.Write(writeValues);
            }
            catch (Exception ex)
            {   //Se viene lanciata un'eccezione la mostro
                MessageBox.Show(ex.Message);
            }
        }

        public static ItemValueResult[] RsLinx_OPC_Client_Read_Array(string ItemName, int Length)
        {
            try
            {
                //Creo un istanza di OPC.server
                Opc.Da.Server server;

                //Parametro necessario alla connect
                OpcCom.Factory fact = new OpcCom.Factory();
                
                //Creo un istanza di Sottoscrizione
                Opc.Da.Subscription groupRead;
                
                //Creo un istanza di SubscriptionState, utile per controllare lo stato della sottoscrizione
                Opc.Da.SubscriptionState groupState;
                
                //Creo un array di OPC.Da.Item
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                
                //Setto factory e url del server, come url utilizzo quello del RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //Connetto il server
                server.Connect();

                //Istanzio la sottoscrizione           
                groupState = new Opc.Da.SubscriptionState();
                groupState.Name = "Group";
                groupState.UpdateRate = Global.UpdateRate; //Setto il tempo di Refresh del gruppo
                groupState.Active = true; //Questo valore deve essere true se voglio aver la possibilità di leggere
                
                //Creo il gruppo sul server
                groupRead = (Opc.Da.Subscription)server.CreateSubscription(groupState);
                
                //Istanzio l'Item
                items[0] = new Opc.Da.Item();
                
                //Gli do il nome (Rockwell utilizza questa formzattazione dei nomi per gli array
                //[NomeTopicOPC]NomeTag,LDimensioneArray es. [MyOPCTopic]Posizione,L50)
                items[0].ItemName = $"{ItemName},L{Length}";

                //Aggiungo l'oggetto al gruppo
                items = groupRead.AddItems(items);
                
                //Leggo il valore dell'item aggiunto
                ItemValueResult[] Ritorno = groupRead.Read(items);

                //Controllo che la lettura dell'array sia andata a buon fine, se non è così lancio un'eccezione
                if (!Ritorno[0].ResultID.Name.Name.Equals("S_OK"))
                {
                    throw new System.Exception("Errore lettura OPC Tag");
                }

                return groupRead.Read(items);
            }
            catch (Exception ex)
            {   //Se viene lanciata un'eccezione ritorno un array di ItemValueResult con il primo che ha valore -1 e mostro un Messagebox con l'errore
                MessageBox.Show(ex.Message);
                ItemValueResult[] Errore = new ItemValueResult[1];
                Errore[0] = new ItemValueResult();
                float[] Err = { (float)-1, (float)-1 };
                Errore[0].Value = Err;
                return Errore;
            }
        }

        public static void RsLinx_OPC_Client_Write_Array(string ItemName, int Lenght, float[] Value)
        {
            try
            {
                //Creo un istanza di OPC.server
                Opc.Da.Server server;

                //Parametro necessario alla connect
                OpcCom.Factory fact = new OpcCom.Factory();
                
                //Creo un istanza di Sottoscrizione
                Opc.Da.Subscription groupWrite;
                
                //Creo un istanza di SubscriptionState, utile per controllare lo stato della sottoscrizione
                Opc.Da.SubscriptionState groupStateWrite;
                
                //Creo un array di OPC.Da.Item
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                
                //Setto factory e url del server, come url utilizzo quello del RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //Connetto il server
                server.Connect();

                //Istanzio la sottoscrizione                    
                groupStateWrite = new Opc.Da.SubscriptionState();
                groupStateWrite.Name = "Group Write";
                //Questo valore deve essere true se voglio aver la possibilità di leggere, se devo solo scrivere lo metto false
                groupStateWrite.Active = false;
                
                //Creo il gruppo sul server
                groupWrite = (Opc.Da.Subscription)server.CreateSubscription(groupStateWrite);

                //Creo l'Item da scrivere (se il gruppo non lo possiede, lo devo inserire)
                Opc.Da.Item[] itemToAdd = new Opc.Da.Item[1];
                itemToAdd[0] = new Opc.Da.Item();
                itemToAdd[0].ItemName = $"{ItemName},L{Lenght}";

                //Creo l'istanza di ItemValue che possiede il mio Item e il valore che voglio assegnargli
                Opc.Da.ItemValue[] writeValues = new Opc.Da.ItemValue[1];
                writeValues[0] = new Opc.Da.ItemValue(itemToAdd[0]);

                //Controllo se l'oggetto esiste nel gruppo
                bool itemFound = false;
                foreach (Opc.Da.Item item in groupWrite.Items)
                {
                    if (item.ItemName == itemToAdd[0].ItemName)
                    {
                        //Se lo trovo gli setto il nuovo valore
                        writeValues[0].ServerHandle = item.ServerHandle;
                        itemFound = true;
                    }
                }
                if (!itemFound)
                {
                    //Se non ho trovato l'oggetto nel gruppo lo aggiungo..
                    groupWrite.AddItems(itemToAdd);
                    writeValues[0].ServerHandle = groupWrite.Items[groupWrite.Items.Length - 1].ServerHandle;
                }
                
                //...gli setto il valore
                writeValues[0].Value = Value;
                
                //e lo scrivo
                groupWrite.Write(writeValues);
            }
            catch (Exception ex)
            {   //Se viene lanciata un'eccezione la mostro
                MessageBox.Show(ex.Message);
            }
        }
    }
}