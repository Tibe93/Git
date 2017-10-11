using System;
using System.Collections.Generic;
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
    }
}