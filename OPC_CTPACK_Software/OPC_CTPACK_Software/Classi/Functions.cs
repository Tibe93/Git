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
        {   // Funzione per la moltiplicazione tra matrici
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
        {
            // Funzione integrale con metodo trapezoidale
            double Somma = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                Somma += (A[i] + A[i + 1]) * ((Time[i + 1] - Time[i]) / 2);
            }

            return Somma;
        }

        public static Formato[] LetturaFormati()
        {
            // Apro il file Formati.config e salvo i valori nelle variabili Formato e Motore
            if (!System.IO.File.Exists(Global.PathConfig))
            {
                MessageBox.Show("ERRORE: Il file non esiste", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            StreamReader File = new StreamReader(Global.PathConfig);
            string M = File.ReadLine().Split('\t')[0]; //lettura numero motori
            int NMotori = System.Convert.ToInt32(M);
            Motore[] _Motore = new Motore[NMotori];
            string[] x1 = new string[20];//sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            string a = File.ReadLine(); //legenda, quindi la salto
            for (int i = 0; i < NMotori; i++)
            {
                x1[0] = File.ReadLine();
                x1 = x1[0].ToString().Split('\t');
                _Motore[i] = new Motore(x1[0], x1[1], x1[2], x1[3], x1[4], x1[5], x1[6], x1[7], System.Convert.ToDouble(x1[8]), x1[9], x1[10], x1[11]);
            }

            string F = File.ReadLine().Split('\t')[0]; //lettura numero formati
            int NFormati = System.Convert.ToInt32(F);
            Formato[] _Formati = new Formato[NFormati];
            string[] x2 = new string[20];//sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            int IndiceMotore = 0;
            a = File.ReadLine(); //legenda, quindi la salto

            for (int i = 0; i < NFormati; i++)
            {

                x2[0] = File.ReadLine();
                x2 = x2[0].ToString().Split('\t');
                for (int j = 0; j < NMotori; j++)
                {
                    if (string.Equals(x2[1], _Motore[j].GetModel()))
                    {
                        IndiceMotore = j;
                        break;
                    }
                }
                _Formati[i] = new Formato(x2[0], _Motore[IndiceMotore], System.Convert.ToDouble(x2[2]), System.Convert.ToDouble(x2[3]), System.Convert.ToDouble(x2[4]), System.Convert.ToInt32(x2[5]), System.Convert.ToInt32(x2[6]), System.Convert.ToInt32(x2[7]), System.Convert.ToInt32(x2[8]));
            }

            // Chiudo il File
            File.Close();

            return _Formati;
        }

        public static ItemValueResult RsLinx_OPC_Client_Read(string ItemName)
        {
            try
            {
                Opc.Da.Server server;
                OpcCom.Factory fact = new OpcCom.Factory();
                Opc.Da.Subscription groupRead;
                Opc.Da.SubscriptionState groupState;
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                // 1st: Create a server object and connect to the RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //2nd: Connect to the created server
                server.Connect();

                //3rd Create a group if items            
                groupState = new Opc.Da.SubscriptionState();
                groupState.Name = "Group";
                groupState.UpdateRate = Global.UpdateRate;// this isthe time between every reads from OPC server
                groupState.Active = true;//this must be true if you the group has to read value
                groupRead = (Opc.Da.Subscription)server.CreateSubscription(groupState);


                // add items to the group (in Rockwell names are identified like [Name of PLC in the server]ItemName)
                items[0] = new Opc.Da.Item();
                items[0].ItemName = ItemName;

                items = groupRead.AddItems(items);
                ItemValueResult Ritorno = groupRead.Read(items)[0];
                if(!Ritorno.ResultID.Name.Name.Equals("S_OK"))
                {
                    throw new System.Exception();
                }
                return groupRead.Read(items)[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ItemValueResult Errore = new ItemValueResult();
                Errore.Value = -1;
                return Errore;
            }
        }

        public static void RsLinx_OPC_Client_Write(string ItemName, int Value)
        {
            try
            {
                Opc.Da.Server server;
                OpcCom.Factory fact = new OpcCom.Factory();
                Opc.Da.Subscription groupWrite;
                Opc.Da.SubscriptionState groupStateWrite;
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                // 1st: Create a server object and connect to the RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //2nd: Connect to the created server
                server.Connect();

                // Create a write group            
                groupStateWrite = new Opc.Da.SubscriptionState();
                groupStateWrite.Name = "Group Write";
                groupStateWrite.Active = false;//not needed to read if you want to write only
                groupWrite = (Opc.Da.Subscription)server.CreateSubscription(groupStateWrite);

                //Create the item to write (if the group doesn't have it, we need to insert it)
                Opc.Da.Item[] itemToAdd = new Opc.Da.Item[1];
                itemToAdd[0] = new Opc.Da.Item();
                itemToAdd[0].ItemName = ItemName;

                //create the item that contains the value to write
                Opc.Da.ItemValue[] writeValues = new Opc.Da.ItemValue[1];
                writeValues[0] = new Opc.Da.ItemValue(itemToAdd[0]);

                //make a scan of group to see if it already contains the item
                bool itemFound = false;
                foreach (Opc.Da.Item item in groupWrite.Items)
                {
                    if (item.ItemName == itemToAdd[0].ItemName)
                    {
                        // if it find the item i set the new value
                        writeValues[0].ServerHandle = item.ServerHandle;
                        itemFound = true;
                    }
                }
                if (!itemFound)
                {
                    //if it doesn't find it, we add it
                    groupWrite.AddItems(itemToAdd);
                    writeValues[0].ServerHandle = groupWrite.Items[groupWrite.Items.Length - 1].ServerHandle;
                }
                //set the value to write
                writeValues[0].Value = Value;
                //write
                groupWrite.Write(writeValues);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static ItemValueResult[] RsLinx_OPC_Client_Read_Array(string ItemName, int Length)
        {
            try
            {
                Opc.Da.Server server;
                OpcCom.Factory fact = new OpcCom.Factory();
                Opc.Da.Subscription groupRead;
                Opc.Da.SubscriptionState groupState;
                Opc.Da.Item[] items = new Opc.Da.Item[1];
                // 1st: Create a server object and connect to the RSLinx OPC Server
                server = new Opc.Da.Server(fact, null);
                server.Url = new Opc.URL(Global.Url);

                //2nd: Connect to the created server
                server.Connect();

                //3rd Create a group if items            
                groupState = new Opc.Da.SubscriptionState();
                groupState.Name = "Group";
                groupState.UpdateRate = Global.UpdateRate;// this isthe time between every reads from OPC server
                groupState.Active = true;//this must be true if you the group has to read value
                groupRead = (Opc.Da.Subscription)server.CreateSubscription(groupState);


                // add items to the group (in Rockwell names are identified like [Name of PLC in the server]ItemName)
                items[0] = new Opc.Da.Item();
                items[0].ItemName = $"{ItemName},L{Length}";

                items = groupRead.AddItems(items);
                ItemValueResult[] Ritorno = groupRead.Read(items);
                if (!Ritorno[0].ResultID.Name.Name.Equals("S_OK"))
                {
                    throw new System.Exception();
                }
                return groupRead.Read(items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ItemValueResult[] Errore = new ItemValueResult[1];
                Errore[0] = new ItemValueResult();
                float[] Err = { (float)-1, (float)-1 };
                Errore[0].Value = Err;
                return Errore;
            }
        }
    }
}