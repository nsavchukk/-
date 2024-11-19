using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double[] XValues;
        private double[] YValues;
        private int N;
        private double NoiseLevel;
        private int Degree;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            try
            {
                N = Convert.ToInt32(textBox1.Text);
                NoiseLevel = Convert.ToDouble(textBox2.Text);
                Degree = Convert.ToInt32(textBox3.Text);

                if (Degree < 2 || Degree > 5)
                    throw new Exception("Неприпустиме значення m. Введіть m у діапазоні від 2 до 5.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Matrix.RowCount = N;
            XValues = new double[N];
            YValues = new double[N];

            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                XValues[i] = i;
                YValues[i] = Math.Pow(XValues[i], Degree) + NoiseLevel * (rnd.NextDouble() - 0.5) * 2;
                Matrix.Rows[i].Cells[0].Value = XValues[i];
                Matrix.Rows[i].Cells[1].Value = YValues[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < N; i++)
                {
                    XValues[i] = Convert.ToDouble(Matrix.Rows[i].Cells[0].Value);
                    YValues[i] = Convert.ToDouble(Matrix.Rows[i].Cells[1].Value);
                }

                double[] Coefficients = new double[Degree + 1];
                if (Method.Aprox(XValues, YValues, N, ref Coefficients, Degree))
                {
                    int numPoints = 100;
                    double[] XGraph = new double[numPoints];
                    double[] YGraph = new double[numPoints];
                    Method.AprTab(XValues[0], XValues[N - 1], Coefficients, Degree, numPoints, ref XGraph, ref YGraph);

                    DrawGraph(XGraph, YGraph);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawGraph(double[] xData, double[] yData)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            // Відображення сітки і осей
            DrawGrid(g);
            DrawAxes(g, 0, xData.Max(), 0, yData.Max());  // Ось починаються з 0, 0

            double xMin = 0;  // Початок осі X з 0
            double xMax = xData.Max();
            double yMin = 0;  // Початок осі Y з 0
            double yMax = yData.Max();

            Pen pen = new Pen(Color.Red, 2);
            for (int i = 0; i < xData.Length - 1; i++)
            {
                float x1 = ScaleX(xData[i], xMin, xMax);
                float y1 = ScaleY(yData[i], yMin, yMax);
                float x2 = ScaleX(xData[i + 1], xMin, xMax);
                float y2 = ScaleY(yData[i + 1], yMin, yMax);
                g.DrawLine(pen, x1, y1, x2, y2);
            }

            // Відображення точок з DataGridView синім кольором
            Brush blueBrush = Brushes.Blue;
            for (int i = 0; i < N; i++)
            {
                float x = ScaleX(XValues[i], xMin, xMax);
                float y = ScaleY(YValues[i], yMin, yMax);
                g.FillRectangle(blueBrush, x - 3, y - 3, 6, 6); // малюємо сині квадратики
            }
        }

        private void DrawAxes(Graphics g, double xMin, double xMax, double yMin, double yMax)
        {
            Pen axisPen = new Pen(Color.Black, 1);

            // Малювання осей з початку координат (0, 0)
            g.DrawLine(axisPen, ScaleX(xMin, xMin, xMax), ScaleY(0, yMin, yMax), ScaleX(xMax, xMin, xMax), ScaleY(0, yMin, yMax)); // X-axis
            g.DrawLine(axisPen, ScaleX(0, xMin, xMax), ScaleY(yMin, yMin, yMax), ScaleX(0, xMin, xMax), ScaleY(yMax, yMin, yMax)); // Y-axis

            // Додавання числових міток
            Font font = new Font("Arial", 8);
            Brush brush = Brushes.Black;
            int numTicks = 10;

            // X-axis ticks
            for (int i = 0; i <= numTicks; i++)
            {
                double x = xMin + i * (xMax - xMin) / numTicks;
                float xPos = ScaleX(x, xMin, xMax);
                g.DrawString(x.ToString("F2"), font, brush, xPos, pictureBox1.Height / 2 + 5);
            }

            // Y-axis ticks
            for (int i = 0; i <= numTicks; i++)
            {
                double y = yMin + i * (yMax - yMin) / numTicks;
                float yPos = ScaleY(y, yMin, yMax);
                g.DrawString(y.ToString("F2"), font, brush, pictureBox1.Width / 2 + 5, yPos);
            }
        }


        private void DrawGrid(Graphics g)
        {
            Pen gridPen = new Pen(Color.LightGray, 1);
            int gridSize = 20;

            for (int x = 0; x < pictureBox1.Width; x += gridSize)
            {
                g.DrawLine(gridPen, x, 0, x, pictureBox1.Height);
            }

            for (int y = 0; y < pictureBox1.Height; y += gridSize)
            {
                g.DrawLine(gridPen, 0, y, pictureBox1.Width, y);
            }
        }

        private float ScaleX(double x, double xMin, double xMax)
        {
            return (float)(pictureBox1.Width * (x - xMin) / (xMax - xMin));
        }


        private float ScaleY(double y, double yMin, double yMax)
        {
            return (float)(pictureBox1.Height - pictureBox1.Height * (y - yMin) / (yMax - yMin));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}