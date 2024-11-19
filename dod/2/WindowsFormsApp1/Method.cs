using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Method
    {
        public static bool Gauss(double[,] A, double[] B, int N, ref double[] X)
        {
            for (int i = 0; i < N; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < N; k++)
                {
                    if (Math.Abs(A[k, i]) > Math.Abs(A[maxRow, i]))
                        maxRow = k;
                }

                for (int k = i; k < N; k++)
                {
                    double temp = A[maxRow, k];
                    A[maxRow, k] = A[i, k];
                    A[i, k] = temp;
                }
                double tempB = B[maxRow];
                B[maxRow] = B[i];
                B[i] = tempB;

                if (Math.Abs(A[i, i]) < 1e-10)
                {
                    MessageBox.Show("Система вироджена");
                    return false;
                }

                for (int k = i + 1; k < N; k++)
                {
                    double factor = A[k, i] / A[i, i];
                    B[k] -= factor * B[i];
                    for (int j = i; j < N; j++)
                        A[k, j] -= factor * A[i, j];
                }
            }

            for (int i = N - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < N; j++)
                    sum += A[i, j] * X[j];
                X[i] = (B[i] - sum) / A[i, i];
            }
            return true;
        }

        public static bool Aprox(double[] xe, double[] ye, int ne, ref double[] k, int m)
        {
            int mp1 = m + 1;
            double[] b = new double[mp1];
            double[,] a = new double[mp1, mp1];

            for (int i = 0; i < mp1; i++)
            {
                for (int j = 0; j < mp1; j++)
                {
                    a[i, j] = 0;
                    for (int p = 0; p < ne; p++)
                        a[i, j] += Math.Pow(xe[p], i + j);
                }

                b[i] = 0;
                for (int p = 0; p < ne; p++)
                    b[i] += ye[p] * Math.Pow(xe[p], i);
            }

            if (!Gauss(a, b, mp1, ref k))
                return false;
            return true;
        }

        public static void AprTab(double al, double bl, double[] k, int m, int ngr, ref double[] xg, ref double[] yg)
        {
            double h = (bl - al) / (ngr - 1);
            for (int i = 0; i < ngr; i++)
            {
                double x = al + i * h;
                double y = k[0];
                double xPow = 1;

                for (int j = 1; j <= m; j++)
                {
                    xPow *= x;
                    y += k[j] * xPow;
                }

                xg[i] = x;
                yg[i] = y;
            }
        }
    }
}

