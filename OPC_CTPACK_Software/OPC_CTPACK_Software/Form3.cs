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

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //comboBoxStorico.Items.AddRange(System.IO.Directory.GetFiles($"../"));

            DirectoryInfo dir = new DirectoryInfo($"../");
            dir.GetFileSystemInfos("*_Storico_Creg.txt");
            comboBoxStorico.DataSource = dir.GetFiles();
            comboBoxStorico.DisplayMember = "Name";
            comboBoxStorico.ValueMember = "FullName";
            
        }

        private void comboBoxStorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NumeroCregMax = 100;
            DateTime[] Tempo = new DateTime[NumeroCregMax];
            double[] StoricoCreg = new double[NumeroCregMax];
            int Tolleranza;
            double CregTeo;

            string Pathh = $"{ comboBoxStorico.SelectedItem }";
            StreamReader File = new StreamReader(Pathh);
            CregTeo = Convert.ToDouble(File.ReadLine().Split('\t')[1]); // leggo il creg teorico dal file
            Tolleranza = Convert.ToInt32(File.ReadLine().Split('\t')[1]); //leggo la tolleranza dal file
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
                chartStorico.Series["GLimitNeg"].Points.AddXY(Tempo[i], (CregTeo - (CregTeo * Tolleranza)));
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