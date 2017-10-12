using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_CTPACK_Software
{
    public class Functions
    {
        public static double[,] MultiplyMatrix(double[,] A, double[,] B, int n, int m, int r)
        {
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
            double Somma = 0;
            for (int i = 0; i < A.Length-1; i++)
            {
                Somma += (A[i]+A[i+1])*((Time[i+1]-Time[i])/2);
            }

            return Somma;
        }

        public static Formato[] LetturaFormati()
        {
            Formato[] _Formato = new Formato[2];

            string Pathh = $@"Formati.config";
            StreamReader File = new StreamReader(Pathh);
            string M = File.ReadLine(); //riga 1, lettura riga con numero motori
            int NMotori = Convert.ToInt32(M[0]);
            Motore[] _Motore = new Motore[NMotori];
            string[] x1 = new string[20];//sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti

            for (int i = 0; i < (NMotori+1); i++)
            {
                string a = File.ReadLine(); //riga 2, legenda, quindi la salto
                x1[0] = File.ReadLine();
                x1 = x1[0].ToString().Split('\t');
                _Motore[i] = new Motore(x1[0], x1[1], x1[2], x1[3], x1[4], x1[5], x1[6], x1[7], x1[8], x1[9], x1[10], x1[11]); 
            }

            string F = File.ReadLine(); // lettura riga con numero formati
            int NFormati = Convert.ToInt32(F[0]);
            Formato[] _Formati = new Formato[NFormati];
            string[] x2 = new string[20];//sicuramente il file non ha più di 20 tab in una riga, la x mi serve per lo split infatti
            int IndiceMotore = 0;

            for (int i = 0; i < (NFormati + 1); i++)
            {
                string a = File.ReadLine(); //riga 2, legenda, quindi la salto
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
                _Formati[i] = new Formato(x2[0], _Motore[IndiceMotore], Convert.ToDouble(x2[2]), Convert.ToDouble(x2[3]), Convert.ToDouble(x2[4]), Convert.ToInt32(x2[5]), Convert.ToInt32(x2[6]), Convert.ToInt32(x2[7]), Convert.ToInt32(x2[8]));
            }

            //Chiudo il File
            File.Close();

            return _Formati;
        }
    }
}