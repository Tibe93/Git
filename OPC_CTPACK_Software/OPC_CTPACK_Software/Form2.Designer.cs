namespace OPC_CTPACK_Software
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.butIndietro = new System.Windows.Forms.Button();
            this.butCalcola = new System.Windows.Forms.Button();
            this.butStorico = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelCreg = new System.Windows.Forms.Label();
            this.labelAllarme = new System.Windows.Forms.Label();
            this.pictureBoxAllarme = new System.Windows.Forms.PictureBox();
            this.chartCreg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllarme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCreg)).BeginInit();
            this.SuspendLayout();
            // 
            // butIndietro
            // 
            this.butIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIndietro.Location = new System.Drawing.Point(18, 695);
            this.butIndietro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butIndietro.Name = "butIndietro";
            this.butIndietro.Size = new System.Drawing.Size(112, 36);
            this.butIndietro.TabIndex = 9;
            this.butIndietro.Text = "< Indietro";
            this.butIndietro.UseVisualStyleBackColor = true;
            this.butIndietro.Click += new System.EventHandler(this.butIndietro_Click);
            // 
            // butCalcola
            // 
            this.butCalcola.Location = new System.Drawing.Point(18, 19);
            this.butCalcola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCalcola.Name = "butCalcola";
            this.butCalcola.Size = new System.Drawing.Size(216, 109);
            this.butCalcola.TabIndex = 10;
            this.butCalcola.Text = "Calcola";
            this.butCalcola.UseVisualStyleBackColor = true;
            this.butCalcola.Click += new System.EventHandler(this.butCalcola_Click);
            // 
            // butStorico
            // 
            this.butStorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butStorico.Location = new System.Drawing.Point(630, 695);
            this.butStorico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butStorico.Name = "butStorico";
            this.butStorico.Size = new System.Drawing.Size(112, 36);
            this.butStorico.TabIndex = 11;
            this.butStorico.Text = "Storico";
            this.butStorico.UseVisualStyleBackColor = true;
            this.butStorico.Click += new System.EventHandler(this.butStorico_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(328, 19);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 31);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(328, 94);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 31);
            this.textBox2.TabIndex = 13;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(243, 23);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(66, 25);
            this.labelTimer.TabIndex = 14;
            this.labelTimer.Text = "Timer";
            // 
            // labelCreg
            // 
            this.labelCreg.AutoSize = true;
            this.labelCreg.Location = new System.Drawing.Point(252, 95);
            this.labelCreg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreg.Name = "labelCreg";
            this.labelCreg.Size = new System.Drawing.Size(58, 25);
            this.labelCreg.TabIndex = 15;
            this.labelCreg.Text = "Creg";
            // 
            // labelAllarme
            // 
            this.labelAllarme.AutoSize = true;
            this.labelAllarme.Location = new System.Drawing.Point(488, 61);
            this.labelAllarme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAllarme.Name = "labelAllarme";
            this.labelAllarme.Size = new System.Drawing.Size(84, 25);
            this.labelAllarme.TabIndex = 16;
            this.labelAllarme.Text = "Allarme";
            // 
            // pictureBoxAllarme
            // 
            this.pictureBoxAllarme.Enabled = false;
            this.pictureBoxAllarme.Image = global::OPC_CTPACK_Software.Properties.Resources.e;
            this.pictureBoxAllarme.Location = new System.Drawing.Point(579, 19);
            this.pictureBoxAllarme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxAllarme.Name = "pictureBoxAllarme";
            this.pictureBoxAllarme.Size = new System.Drawing.Size(168, 109);
            this.pictureBoxAllarme.TabIndex = 17;
            this.pictureBoxAllarme.TabStop = false;
            // 
            // chartCreg
            // 
            this.chartCreg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartCreg.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartCreg.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartCreg.Legends.Add(legend1);
            this.chartCreg.Location = new System.Drawing.Point(18, 138);
            this.chartCreg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartCreg.MaximumSize = new System.Drawing.Size(3724, 3548);
            this.chartCreg.Name = "chartCreg";
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "SogliaPiu";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "Creg";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "SogliaMeno";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Lime;
            series4.Legend = "Legend1";
            series4.MarkerSize = 10;
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
            series4.Name = "CregAttuale";
            this.chartCreg.Series.Add(series1);
            this.chartCreg.Series.Add(series2);
            this.chartCreg.Series.Add(series3);
            this.chartCreg.Series.Add(series4);
            this.chartCreg.Size = new System.Drawing.Size(724, 548);
            this.chartCreg.TabIndex = 18;
            this.chartCreg.Text = "chart1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 750);
            this.Controls.Add(this.chartCreg);
            this.Controls.Add(this.pictureBoxAllarme);
            this.Controls.Add(this.labelAllarme);
            this.Controls.Add(this.labelCreg);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butStorico);
            this.Controls.Add(this.butCalcola);
            this.Controls.Add(this.butIndietro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Creg Attuale";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllarme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCreg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butIndietro;
        private System.Windows.Forms.Button butCalcola;
        private System.Windows.Forms.Button butStorico;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelCreg;
        private System.Windows.Forms.Label labelAllarme;
        private System.Windows.Forms.PictureBox pictureBoxAllarme;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCreg;
    }
}