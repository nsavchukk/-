namespace WindowsFormsApp1
{
    
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLeftLimit = new System.Windows.Forms.TextBox();
            this.textBoxRightLimit = new System.Windows.Forms.TextBox();
            this.textBoxPointCount = new System.Windows.Forms.TextBox();
            this.comboBoxGraphType = new System.Windows.Forms.ComboBox();
            this.textBoxParameter = new System.Windows.Forms.TextBox();
            this.labelParameter = new System.Windows.Forms.Label();
            this.buttonPlot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.labelScale = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxGraph.Location = new System.Drawing.Point(2, 2);
            this.pictureBoxGraph.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(685, 335);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Click += new System.EventHandler(this.pictureBoxGraph_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 349);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ліва межа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(143, 349);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Права межа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(286, 349);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "К-сть точок";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(440, 349);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Вид Графіка";
            // 
            // textBoxLeftLimit
            // 
            this.textBoxLeftLimit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLeftLimit.Location = new System.Drawing.Point(8, 368);
            this.textBoxLeftLimit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLeftLimit.Name = "textBoxLeftLimit";
            this.textBoxLeftLimit.Size = new System.Drawing.Size(80, 24);
            this.textBoxLeftLimit.TabIndex = 5;
            // 
            // textBoxRightLimit
            // 
            this.textBoxRightLimit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRightLimit.Location = new System.Drawing.Point(143, 368);
            this.textBoxRightLimit.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRightLimit.Name = "textBoxRightLimit";
            this.textBoxRightLimit.Size = new System.Drawing.Size(80, 24);
            this.textBoxRightLimit.TabIndex = 6;
            // 
            // textBoxPointCount
            // 
            this.textBoxPointCount.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPointCount.Location = new System.Drawing.Point(286, 368);
            this.textBoxPointCount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPointCount.Name = "textBoxPointCount";
            this.textBoxPointCount.Size = new System.Drawing.Size(80, 24);
            this.textBoxPointCount.TabIndex = 7;
            // 
            // comboBoxGraphType
            // 
            this.comboBoxGraphType.FormattingEnabled = true;
            this.comboBoxGraphType.Location = new System.Drawing.Point(441, 369);
            this.comboBoxGraphType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxGraphType.Name = "comboBoxGraphType";
            this.comboBoxGraphType.Size = new System.Drawing.Size(116, 21);
            this.comboBoxGraphType.TabIndex = 8;
            this.comboBoxGraphType.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraphType_SelectedIndexChanged);
            // 
            // textBoxParameter
            // 
            this.textBoxParameter.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxParameter.Location = new System.Drawing.Point(9, 436);
            this.textBoxParameter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxParameter.Name = "textBoxParameter";
            this.textBoxParameter.Size = new System.Drawing.Size(80, 24);
            this.textBoxParameter.TabIndex = 10;
            // 
            // labelParameter
            // 
            this.labelParameter.AutoSize = true;
            this.labelParameter.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParameter.Location = new System.Drawing.Point(10, 416);
            this.labelParameter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelParameter.Name = "labelParameter";
            this.labelParameter.Size = new System.Drawing.Size(117, 17);
            this.labelParameter.TabIndex = 9;
            this.labelParameter.Text = "Параметр функції";
            // 
            // buttonPlot
            // 
            this.buttonPlot.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlot.Location = new System.Drawing.Point(146, 408);
            this.buttonPlot.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlot.Name = "buttonPlot";
            this.buttonPlot.Size = new System.Drawing.Size(293, 79);
            this.buttonPlot.TabIndex = 11;
            this.buttonPlot.Text = "Побудувати";
            this.buttonPlot.UseVisualStyleBackColor = true;
            this.buttonPlot.Click += new System.EventHandler(this.buttonPlot_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(443, 408);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 79);
            this.button1.TabIndex = 12;
            this.button1.Text = "Завершити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZoomIn.Location = new System.Drawing.Point(561, 408);
            this.buttonZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(84, 32);
            this.buttonZoomIn.TabIndex = 13;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZoomOut.Location = new System.Drawing.Point(561, 455);
            this.buttonZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(84, 32);
            this.buttonZoomOut.TabIndex = 14;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScale.Location = new System.Drawing.Point(10, 479);
            this.labelScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(117, 17);
            this.labelScale.TabIndex = 15;
            this.labelScale.Text = "Параметр функції";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(685, 513);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonPlot);
            this.Controls.Add(this.textBoxParameter);
            this.Controls.Add(this.labelParameter);
            this.Controls.Add(this.comboBoxGraphType);
            this.Controls.Add(this.textBoxPointCount);
            this.Controls.Add(this.textBoxRightLimit);
            this.Controls.Add(this.textBoxLeftLimit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxGraph);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Задорожний Полярні графіки";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelScale;

        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;

        private System.Windows.Forms.Label labelParameter;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox textBoxParameter;
        private System.Windows.Forms.Button buttonPlot;

        private System.Windows.Forms.TextBox textBoxPointCount;
        private System.Windows.Forms.ComboBox comboBoxGraphType;

        private System.Windows.Forms.TextBox textBoxRightLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox textBoxLeftLimit;

        private System.Windows.Forms.PictureBox pictureBoxGraph;

        #endregion
    }
}

