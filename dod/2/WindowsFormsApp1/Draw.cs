using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
    {
        class Draw
        {
            public static void DrawGrid(Graphics g, PictureBox pictureBox)
            {
                Pen gridPen = new Pen(Color.LightGray, 1);
                int gridSize = 20;

                for (int x = 0; x < pictureBox.Width; x += gridSize)
                {
                    g.DrawLine(gridPen, x, 0, x, pictureBox.Height);
                }

                for (int y = 0; y < pictureBox.Height; y += gridSize)
                {
                    g.DrawLine(gridPen, 0, y, pictureBox.Width, y);
                }
            }

            public static void DrawGraph(Graphics g, double[] xData, double[] yData, PictureBox pictureBox)
            {
                g.Clear(Color.White);
                DrawGrid(g, pictureBox);

                double xMin = xData[0];
                double xMax = xData[xData.Length - 1];
                double yMin = double.MaxValue;
                double yMax = double.MinValue;

                foreach (var y in yData)
                {
                    if (y < yMin) yMin = y;
                    if (y > yMax) yMax = y;
                }

                Pen graphPen = new Pen(Color.Red, 2);

                for (int i = 0; i < xData.Length - 1; i++)
                {
                    float x1 = ScaleX(xData[i], xMin, xMax, pictureBox.Width);
                    float y1 = ScaleY(yData[i], yMin, yMax, pictureBox.Height);
                    float x2 = ScaleX(xData[i + 1], xMin, xMax, pictureBox.Width);
                    float y2 = ScaleY(yData[i + 1], yMin, yMax, pictureBox.Height);

                    g.DrawLine(graphPen, x1, y1, x2, y2);
                }
            }

            private static float ScaleX(double x, double xMin, double xMax, int width)
            {
                return (float)(width * (x - xMin) / (xMax - xMin));
            }

            private static float ScaleY(double y, double yMin, double yMax, int height)
            {
                return (float)(height - height * (y - yMin) / (yMax - yMin));
            }
        }
    }