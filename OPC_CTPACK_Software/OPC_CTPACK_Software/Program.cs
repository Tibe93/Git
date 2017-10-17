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
            // Apro la Form0
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form0 Form_0 = new Form0();
            Application.Run(Form_0);
        }
    }
}
