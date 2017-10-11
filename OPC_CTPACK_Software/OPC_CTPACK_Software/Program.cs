using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Accord.Math;

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

            double[,] VelocitaMediaTot = new double[2, 5] { { 1,1,1,1,1 }, { 2,2,2,2,2 }};
            double[,] Velocita2RMSTot = new double[5, 1] { { 1 }, { 1 }, { 1 }, { 1 }, { 1 } };
            double[,] Attriti = new double[2, 1];
            Attriti = Functions.MultiplyMatrix(VelocitaMediaTot, Velocita2RMSTot, 2, 4, 0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
