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
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            chartStorico.Visible = true;

            //rimuovo vecchio grafico
            foreach (var series in chartStorico.Series)
            {
                series.Points.Clear();
            }

            int NumeroCregMax = 100;
            //DateTime[] Tempo = new DateTime[NumeroCregMax];
            int[] Tempo = new int[NumeroCregMax];
            double[] StoricoCreg = new double[NumeroCregMax];
            int Tolleranza;
            double CregTeo;

            string Pathh = $"../Dati/{ comboBoxStorico.SelectedItem }";
            StreamReader File = new StreamReader(Pathh);
            CregTeo = Convert.ToDouble(File.ReadLine().Split('\t')[1]); // leggo il creg teorico dal file
            Tolleranza = Convert.ToInt32(File.ReadLine().Split('\t')[1]); //leggo la tolleranza dal file
            string a = File.ReadLine(); //spazio, quindi lo salto
            a = File.ReadLine(); //legenda, quindi la salto
            string[] x = new string[10];

            int i = 0;
            while (!(File.EndOfStream))
            {
                x[0] = File.ReadLine();
                x = x[0].ToString().Split('\t');
                //Tempo[i] = Convert.ToDateTime(x[0]);
                Tempo[i] = Convert.ToInt32(x[0]);
                StoricoCreg[i] = Convert.ToDouble(x[1]);

                chartStorico.Series["GStorico"].Points.AddXY(Tempo[i], StoricoCreg[i]);
                chartStorico.Series["GLimitNeg"].Points.AddXY(Tempo[i], (CregTeo - (CregTeo * Tolleranza) / 100));
                chartStorico.Series["GLimitPos"].Points.AddXY(Tempo[i], (CregTeo + (CregTeo * Tolleranza) / 100));

                i++;
            }

            //Chiudo il File
            File.Close();
        }

        private void comboBoxStorico_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo($"../Dati/");
            comboBoxStorico.DataSource = dir.GetFileSystemInfos("*_Storico_Creg.txt");
            comboBoxStorico.DisplayMember = "Name";
            //comboBoxStorico.ValueMember = "FullName";
            comboBoxStorico.BackColor = Color.White;
            buttonStart.Enabled = true;
        }
    }
}