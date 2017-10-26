using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Accord.Math;
using System.IO;

namespace OPC_CTPACK_Software
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Apro la Form0
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(Directory.Exists(Global.StandardPath))
            {
                //Se la cartella esiste controllo se esistono Formati.config e Sottocartelle
                if(!Directory.Exists(Global.PathTrend))
                {
                    //Se la cartella Trend_Attuali non esiste la creo
                    Directory.CreateDirectory(Global.PathTrend);
                }
                if (!Directory.Exists(Global.PathStorico))
                {
                    //Se la cartella Storico non esiste la creo
                    Directory.CreateDirectory(Global.PathStorico);
                }
                if(!File.Exists(Global.PathConfig))
                {
                    //Se il File Formati.config non esiste lo creo e aggiungo un motore e due formati standard
                    StreamWriter FormatiConfig = new StreamWriter(Global.PathConfig);
                    FormatiConfig.WriteLine("1\tMotori");
                    FormatiConfig.WriteLine("MotorModel RPower  RVoltage    RSpeed  RCurrent    RTorque PCount  PeakCur TorqueK VoltageK");
                    FormatiConfig.WriteLine("VPL-B1153F\t2,3\t480\t5000\t6,28\t6,55\t8\t23,33\t1,189\t71.82815\t2,09\t0,01104");
                    FormatiConfig.WriteLine("2\tFormati");
                    FormatiConfig.WriteLine("Nome	Motore		Kp	Kv	Kt	PpmA	PpmI	PpmF	Passo");
                    FormatiConfig.WriteLine("Catena\tVPL-B1153F\t1\t0,1\t0,075\t200\t70\t400\t30");
                    FormatiConfig.WriteLine("Masse\tVPL-B1153F\t1\t0,087\t0,075\t200\t70\t400\t30");
                    FormatiConfig.Close();
                }
            }
            else
            {
                //Se la cartella non esiste la creo e creo anche le sottocartelle necessarie
                Directory.CreateDirectory(Global.StandardPath);
                Directory.CreateDirectory(Global.PathTrend);
                Directory.CreateDirectory(Global.PathStorico);
                
                //Creo anche il File Formati.config con un motore e due formati standard
                StreamWriter FormatiConfig = new StreamWriter(Global.PathConfig);
                FormatiConfig.WriteLine("1\tMotori");
                FormatiConfig.WriteLine("MotorModel RPower  RVoltage    RSpeed  RCurrent    RTorque PCount  PeakCur TorqueK VoltageK");
                FormatiConfig.WriteLine("VPL-B1153F\t2,3\t480\t5000\t6,28\t6,55\t8\t23,33\t1,189\t71.82815\t2,09\t0,01104");
                FormatiConfig.WriteLine("2\tFormati");
                FormatiConfig.WriteLine("Nome	Motore		Kp	Kv	Kt	PpmA	PpmI	PpmF	Passo");
                FormatiConfig.WriteLine("Catena\tVPL-B1153F\t1\t0,1\t0,075\t200\t70\t400\t30");
                FormatiConfig.WriteLine("Masse\tVPL-B1153F\t1\t0,087\t0,075\t200\t70\t400\t30");
                FormatiConfig.Close();
            }

            Form0 Form_0 = new Form0();
            Application.Run(Form_0);
        }
    }
}
