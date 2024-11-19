using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double currentScaleFactor = 1.0; // Фактор масштабування
        private double[] lastPhiValues; // Останні обчислені значення φ
        private double[] lastRValues; // Останні обчислені значення r

        // Змінні для панорамування
        private bool isPanning = false;
        private Point lastMousePosition;
        private float offsetX = 0;
        private float offsetY = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();

            // Дозволити PictureBox отримувати фокус для обробки подій миші
            pictureBoxGraph.Focus();
            pictureBoxGraph.MouseWheel += pictureBoxGraph_MouseWheel;
            pictureBoxGraph.MouseDown += pictureBoxGraph_MouseDown;
            pictureBoxGraph.MouseMove += pictureBoxGraph_MouseMove;
            pictureBoxGraph.MouseUp += pictureBoxGraph_MouseUp;
            pictureBoxGraph.Paint += pictureBoxGraph_Paint;
            pictureBoxGraph.Click += pictureBoxGraph_Click;

            // Додати підтримку прокрутки миші на формі
            this.MouseWheel += Form1_MouseWheel;
        }

        private void InitializeComboBox()
        {
            comboBoxGraphType.Items.AddRange(new object[] {
                "Кардіоїда",
                "Полярна троянда",
                "Гіперболічна спіраль",
                "Архімедова спіраль"
            });

            if (comboBoxGraphType.Items.Count > 0)
                comboBoxGraphType.SelectedIndex = 0;

            labelParameter.Text = "Параметр (a):";
        }

        private void comboBoxGraphType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGraph = comboBoxGraphType.SelectedItem.ToString();
            switch (selectedGraph)
            {
                case "Архімедова спіраль":
                    labelParameter.Visible = false;
                    textBoxParameter.Visible = false;
                    break;
                case "Кардіоїда":
                case "Гіперболічна спіраль":
                    labelParameter.Visible = true;
                    textBoxParameter.Visible = true;
                    labelParameter.Text = "Параметр (a):";
                    break;
                case "Полярна троянда":
                    labelParameter.Visible = true;
                    textBoxParameter.Visible = true;
                    labelParameter.Text = "Параметр (k):";
                    break;
                default:
                    labelParameter.Visible = true;
                    textBoxParameter.Visible = true;
                    labelParameter.Text = "Параметр:";
                    break;
            }
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            try
            {
                double leftLimit = double.Parse(textBoxLeftLimit.Text);
                double rightLimit = double.Parse(textBoxRightLimit.Text);
                int pointCount = int.Parse(textBoxPointCount.Text);
                double parameter = double.Parse(textBoxParameter.Text);

                string graphType = GetSelectedGraphType();
                if (string.IsNullOrEmpty(graphType))
                {
                    MessageBox.Show("Будь ласка, виберіть тип графіка.");
                    return;
                }

                // Обчислення точок
                double[] phiValues = new double[pointCount];
                double[] rValues = new double[pointCount];
                double step = (rightLimit - leftLimit) / (pointCount - 1);

                for (int i = 0; i < pointCount; i++)
                {
                    phiValues[i] = leftLimit + i * step;
                    rValues[i] = CalculateR(phiValues[i], graphType, parameter);
                }

                lastPhiValues = phiValues;
                lastRValues = rValues;

                // Скидання масштабу та зсувів
                currentScaleFactor = 1.0;
                offsetX = 0;
                offsetY = 0;
                UpdateScaleLabel();

                // Перемалювати графік
                pictureBoxGraph.Invalidate();
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Кут φ не може дорівнювати нулю для гіперболічної спіралі.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message);
            }
        }

        private string GetSelectedGraphType()
        {
            if (comboBoxGraphType.SelectedItem == null)
                return string.Empty;

            string selected = comboBoxGraphType.SelectedItem.ToString();
            switch (selected)
            {
                case "Архімедова спіраль":
                    return "ArchimedeanSpiral";
                case "Кардіоїда":
                    return "Cardioid";
                case "Полярна троянда":
                    return "PolarRose";
                case "Гіперболічна спіраль":
                    return "HyperbolicSpiral";
                default:
                    return string.Empty;
            }
        }

        private double CalculateR(double phi, string graphType, double aOrK)
        {
            switch (graphType)
            {
                case "ArchimedeanSpiral":
                    return aOrK * phi;
                case "Cardioid":
                    return aOrK * (1 + Math.Cos(phi));
                case "PolarRose":
                    return Math.Cos(aOrK * phi);
                case "HyperbolicSpiral":
                    return aOrK / phi;
                default:
                    throw new ArgumentException("Невідомий тип графіка.");
            }
        }

        private void DrawGrid(Graphics g, float centerX, float centerY, double scale, double maxR)
        {
            using (Pen gridPen = new Pen(Color.LightGray, 1))
            {
                gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                // Концентричні кола (сітка)
                int numCircles = 10;
                for (int i = 1; i <= numCircles; i++)
                {
                    float radius = (float)(i * maxR / numCircles * scale);
                    g.DrawEllipse(gridPen, centerX - radius, centerY - radius, radius * 2, radius * 2);
                }

                // Радіальні лінії (сітка)
                int numRadialLines = 12; // Кількість радіальних ліній (наприклад, кожні 30°)
                for (int i = 0; i < numRadialLines; i++)
                {
                    double angle = i * (2 * Math.PI / numRadialLines);
                    float x = centerX + (float)(maxR * Math.Cos(angle) * scale);
                    float y = centerY - (float)(maxR * Math.Sin(angle) * scale);
                    g.DrawLine(gridPen, centerX, centerY, x, y);
                }
            }
        }

        private void DrawAxes(Graphics g, float centerX, float centerY, double scale, double maxR)
        {
            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                // Ось X: від лівого до правого краю PictureBox
                g.DrawLine(axisPen, 0, centerY, pictureBoxGraph.Width, centerY);

                // Ось Y: від верхнього до нижнього краю PictureBox
                g.DrawLine(axisPen, centerX, 0, centerX, pictureBoxGraph.Height);
            }

            // Додавання стрілок на кінцях осей
            using (Pen arrowPen = new Pen(Color.Black, 2))
            {
                // Стрілка для осі X
                DrawArrow(g, arrowPen, new PointF(pictureBoxGraph.Width - 10, centerY), new PointF(pictureBoxGraph.Width, centerY));

                // Стрілка для осі Y
                DrawArrow(g, arrowPen, new PointF(centerX, 10), new PointF(centerX, 0));
            }

            // Додавання міток на осях
            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Font font = new Font("Arial", 10))
            {
                // Мітка "X" біля правої стрілки
                g.DrawString("X", font, textBrush, pictureBoxGraph.Width - 25, centerY + 5);

                // Мітка "Y" біля верхньої стрілки
                g.DrawString("Y", font, textBrush, centerX + 5, 5);
            }

            // Додавання відміток на сітці
            using (Brush textBrush = new SolidBrush(Color.Gray))
            using (Font font = new Font("Arial", 8))
            {
                int numCircles = 10;
                for (int i = 1; i <= numCircles; i++)
                {
                    double r = i * maxR / numCircles;
                    string label = r.ToString("0.##");

                    g.DrawString(label, font, textBrush, centerX + (float)(r * scale) - 10, centerY + 5);

                    g.DrawString(label, font, textBrush, centerX + 5, centerY - (float)(r * scale) - 10);

                    g.DrawString($"-{label}", font, textBrush, centerX - (float)(r * scale) - 15, centerY + 5);

                    g.DrawString($"-{label}", font, textBrush, centerX + 5, centerY + (float)(r * scale) + 5);
                }

                // Відмітки для кутів
                int numRadialLines = 12;
                for (int i = 0; i < numRadialLines; i++)
                {
                    double angle = i * (2 * Math.PI / numRadialLines);
                    double degrees = angle * (180.0 / Math.PI);
                    string label = $"{degrees}°";

                    float x = centerX + (float)(maxR * Math.Cos(angle) * scale);
                    float y = centerY - (float)(maxR * Math.Sin(angle) * scale);

                    g.DrawString(label, font, textBrush, x - 10, y - 10);
                }
            }
        }

        private void DrawArrow(Graphics g, Pen pen, PointF p1, PointF p2)
        {
            const float arrowSize = 6f;
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            double angle = Math.Atan2(dy, dx);

            PointF arrowP1 = new PointF(
                p2.X - arrowSize * (float)Math.Cos(angle - Math.PI / 6),
                p2.Y - arrowSize * (float)Math.Sin(angle - Math.PI / 6)
            );

            PointF arrowP2 = new PointF(
                p2.X - arrowSize * (float)Math.Cos(angle + Math.PI / 6),
                p2.Y - arrowSize * (float)Math.Sin(angle + Math.PI / 6)
            );

            g.DrawLine(pen, p2, arrowP1);
            g.DrawLine(pen, p2, arrowP2);
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            if (currentScaleFactor < 5.0) // Максимальний масштаб 5x
            {
                currentScaleFactor *= 1.2; // Збільшення масштабу на 20%
                RedrawGraph();
                UpdateScaleLabel();
            }
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            if (currentScaleFactor > 0.2) // Мінімальний масштаб 0.2x
            {
                currentScaleFactor /= 1.2; // Зменшення масштабу на 20%
                RedrawGraph();
                UpdateScaleLabel();
            }
        }

        private void RedrawGraph()
        {
            if (lastPhiValues == null || lastRValues == null)
                return;

            pictureBoxGraph.Invalidate();
        }

        private void UpdateScaleLabel()
        {
            labelScale.Text = $"Масштаб: {currentScaleFactor:0.##}x";
        }

        private void pictureBoxGraph_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (currentScaleFactor < 5.0) // Максимальний масштаб 5x
                {
                    currentScaleFactor *= 1.2; // Збільшення масштабу на 20%
                    RedrawGraph();
                    UpdateScaleLabel();
                }
            }
            else
            {
                if (currentScaleFactor > 0.2) // Мінімальний масштаб 0.2x
                {
                    currentScaleFactor /= 1.2; // Зменшення масштабу на 20%
                    RedrawGraph();
                    UpdateScaleLabel();
                }
            }
        }

        private void pictureBoxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = true;
                lastMousePosition = e.Location;
                pictureBoxGraph.Cursor = Cursors.Hand;
            }
        }

        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                // Обчислення різниці руху миші
                float deltaX = e.X - lastMousePosition.X;
                float deltaY = e.Y - lastMousePosition.Y;

                // Оновлення зсувів
                offsetX += deltaX;
                offsetY += deltaY;

                // Оновлення останньої позиції миші
                lastMousePosition = e.Location;

                // Перемалювати графік
                pictureBoxGraph.Invalidate();
            }
        }

        private void pictureBoxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = false;
                pictureBoxGraph.Cursor = Cursors.Default;
            }
        }

        private void pictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            if (lastPhiValues == null || lastRValues == null)
                return;

            // Очищення графіка
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            // Центр координат з урахуванням зсувів
            float centerX = pictureBoxGraph.Width / 2f + offsetX;
            float centerY = pictureBoxGraph.Height / 2f + offsetY;

            // Масштабування
            double maxR = 0;
            foreach (var value in lastRValues)
            {
                if (Math.Abs(value) > maxR)
                    maxR = Math.Abs(value);
            }

            // Запобігання ділення на нуль
            if (maxR == 0)
                maxR = 1;

            // Використання фактора масштабування
            double scale = (Math.Min(pictureBoxGraph.Width, pictureBoxGraph.Height) * 0.45) / maxR * currentScaleFactor;

            // Малювання сітки
            DrawGrid(e.Graphics, centerX, centerY, scale, maxR);

            // Малювання осей координат
            DrawAxes(e.Graphics, centerX, centerY, scale, maxR);

            // Перетворення полярних координат у декартові
            PointF[] points = new PointF[lastPhiValues.Length];
            for (int i = 0; i < lastPhiValues.Length; i++)
            {
                double x = lastRValues[i] * Math.Cos(lastPhiValues[i]);
                double y = lastRValues[i] * Math.Sin(lastPhiValues[i]);
                points[i] = new PointF(
                    centerX + (float)(x * scale),
                    centerY - (float)(y * scale)
                );
            }

            if (points.Length > 1)
            {
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    e.Graphics.DrawLines(pen, points);
                }
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            pictureBoxGraph.Focus();
        }

        private void pictureBoxGraph_Click(object sender, EventArgs e)
        {
            pictureBoxGraph.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Дійсно бажаєте вийти?", "Вихід",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}