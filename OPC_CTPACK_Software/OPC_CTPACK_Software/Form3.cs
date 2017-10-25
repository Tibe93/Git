using System;
using System.Collections;
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
            // Inserisco i path di tutti i file presenti nella cartella Dati che finiscono per "*_Storico_Creg.txt", nella comboBox
            DirectoryInfo dir = new DirectoryInfo(Global.PathStorico);
            //comboBoxStorico.DataSource 
            ArrayList Item = new ArrayList();
            Item.AddRange(dir.GetFileSystemInfos("*_Storico_Creg.txt"));
            foreach (System.IO.FileInfo s in Item)
            {
                comboBoxStorico.Items.Add(s);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Operazioni sulla grafica
            //this.WindowState = FormWindowState.Maximized;
            chartStorico.Visible = true;

            chartStorico.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm";
            chartStorico.ChartAreas["ChartArea1"].AxisX2.LabelStyle.Format = "dd/MM/yyyy HH:mm";

            // Rimuovo il i punti del grafico precedente
            foreach (var series in chartStorico.Series)
            {
                series.Points.Clear();
            }

            int NumeroCregMax = 100;
            DateTime[] Tempo = new DateTime[NumeroCregMax];
            double[] StoricoCreg = new double[NumeroCregMax];
            int Tolleranza;
            double CregTeo;

            // Apro il file selezionato nella comboBox, cioè quello di qui voglio vedere lo storico dei creg, e lo stampo
            string Pathh = $"{Global.PathStorico}{ comboBoxStorico.SelectedItem }";
            StreamReader File = new StreamReader(Pathh); // CONTROLLO LETTURA
            Tolleranza = Convert.ToInt32(File.ReadLine().Split('\t')[1]); //leggo la tolleranza dal file
            string[] x = new string[10];
            // A seconda del file selezionato nella comboBox differenzio i file alle diverse velocità da quello TOT(totale)
            // che mostra lo storico completo anche al variare della velocità
            if (comboBoxStorico.SelectedItem.ToString().Substring(0,3).Equals("TOT"))
            {
                string a = File.ReadLine(); //spazio, quindi lo salto
                a = File.ReadLine(); //legenda, quindi la salto
                int i = 0;
                while (!(File.EndOfStream))
                {
                    x[0] = File.ReadLine();
                    x = x[0].ToString().Split('\t');
                    Tempo[i] = Convert.ToDateTime(x[0]);
                    StoricoCreg[i] = Convert.ToDouble(x[1]);
                    CregTeo = Convert.ToDouble(x[2]);

                    chartStorico.Series["GStorico"].Points.AddXY(Tempo[i], StoricoCreg[i]);
                    chartStorico.Series["GLimitNeg"].Points.AddXY(Tempo[i], (CregTeo - (CregTeo * Tolleranza) / 100));
                    chartStorico.Series["GLimitPos"].Points.AddXY(Tempo[i], (CregTeo + (CregTeo * Tolleranza) / 100));

                    i++;
                }
            }
            else
            {
                CregTeo = Convert.ToDouble(File.ReadLine().Split('\t')[1]); //leggo il creg teorico dal file
                string b = File.ReadLine(); //spazio, quindi lo salto
                b = File.ReadLine(); //legenda, quindi la salto
                int i = 0;
                while (!(File.EndOfStream))
                {
                    x[0] = File.ReadLine();
                    x = x[0].ToString().Split('\t');
                    Tempo[i] = Convert.ToDateTime(x[0]);
                    StoricoCreg[i] = Convert.ToDouble(x[1]);

                    chartStorico.Series["GStorico"].Points.AddXY(Tempo[i], StoricoCreg[i]);
                    chartStorico.Series["GLimitNeg"].Points.AddXY(Tempo[i], (CregTeo - (CregTeo * Tolleranza) / 100));
                    chartStorico.Series["GLimitPos"].Points.AddXY(Tempo[i], (CregTeo + (CregTeo * Tolleranza) / 100));

                    i++;
                }
            }
            // Chiudo il File
            File.Close();

        }

        private void comboBoxStorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Operazioni sulla grafica
            comboBoxStorico.BackColor = Color.White;
            buttonStart.Enabled = true;
        }
    }
}