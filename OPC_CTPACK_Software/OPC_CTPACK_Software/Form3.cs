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
    public partial class Form3 : Form
    {
        Form2 FormPadre;
        Start_Creg CregInit;

        public Form3(Form2 FormPadre, Start_Creg CregInit)
        {
            this.FormPadre = FormPadre;
            this.CregInit = CregInit;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int NumeroCregMax = 100;
            DateTime[] Tempo = new DateTime[NumeroCregMax];
            double[] StoricoCreg = new double[NumeroCregMax];
            int Tolleranza;
            double CregTeo;

            string Pathh = $"../70_Storico_Creg.txt";
            StreamReader File = new StreamReader(Pathh);
            CregTeo = Convert.ToDouble(File.ReadLine().Split('\t')[1]);
            Tolleranza = Convert.ToInt32(File.ReadLine().Split('\t')[1]); //Leggo la tolleranza dal file
            string a = File.ReadLine(); //spazio, quindi lo salto
            a = File.ReadLine(); //legenda, quindi la salto
            string[] x = new string[10];

            int i = 0;
            while (File.EndOfStream)
            {
                x[0] = File.ReadLine();
                x = x[0].ToString().Split('\t');
                Tempo[i] = Convert.ToDateTime(x[0]);
                StoricoCreg[i] = Convert.ToDouble(x[1]);

                chartStorico.Series["GStorico"].Points.AddXY(Tempo[i], StoricoCreg[i]);
                chartStorico.Series["GLimitNeg"].Points.AddXY(Tempo[i], (CregTeo - (CregTeo*Tolleranza)));
                chartStorico.Series["GLimitPos"].Points.AddXY(Tempo[i], (CregTeo + (CregTeo * Tolleranza)));

                i++;
            }

            //Disegno il grafico
            chartStorico.Series["GStorico"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartStorico.Series["GStorico"].ChartArea = "ChartArea1";

            chartStorico.Series["GLimitNeg"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartStorico.Series["GLimitNeg"].ChartArea = "ChartArea1";

            chartStorico.Series["GLimitPos"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartStorico.Series["GLimitPos"].ChartArea = "ChartArea1";

            //Chiudo il File
            File.Close();
        }
    }
}