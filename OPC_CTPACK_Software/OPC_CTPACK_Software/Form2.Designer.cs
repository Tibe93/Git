﻿namespace OPC_CTPACK_Software
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
            this.textBoxCreg = new System.Windows.Forms.TextBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelCreg = new System.Windows.Forms.Label();
            this.pictureBoxAllarme = new System.Windows.Forms.PictureBox();
            this.chartCreg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butStop = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllarme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCreg)).BeginInit();
            this.SuspendLayout();
            // 
            // butIndietro
            // 
            this.butIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIndietro.Location = new System.Drawing.Point(12, 445);
            this.butIndietro.Name = "butIndietro";
            this.butIndietro.Size = new System.Drawing.Size(75, 23);
            this.butIndietro.TabIndex = 9;
            this.butIndietro.Text = "< Indietro";
            this.butIndietro.UseVisualStyleBackColor = true;
            this.butIndietro.Click += new System.EventHandler(this.butIndietro_Click);
            // 
            // butCalcola
            // 
            this.butCalcola.Location = new System.Drawing.Point(12, 12);
            this.butCalcola.Name = "butCalcola";
            this.butCalcola.Size = new System.Drawing.Size(144, 70);
            this.butCalcola.TabIndex = 10;
            this.butCalcola.Text = "Calcola";
            this.butCalcola.UseVisualStyleBackColor = true;
            this.butCalcola.Click += new System.EventHandler(this.butCalcola_Click);
            // 
            // butStorico
            // 
            this.butStorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butStorico.Location = new System.Drawing.Point(420, 445);
            this.butStorico.Name = "butStorico";
            this.butStorico.Size = new System.Drawing.Size(75, 23);
            this.butStorico.TabIndex = 11;
            this.butStorico.Text = "Storico";
            this.butStorico.UseVisualStyleBackColor = true;
            this.butStorico.Click += new System.EventHandler(this.butStorico_Click);
            // 
            // textBoxCreg
            // 
            this.textBoxCreg.Enabled = false;
            this.textBoxCreg.Location = new System.Drawing.Point(219, 60);
            this.textBoxCreg.Name = "textBoxCreg";
            this.textBoxCreg.Size = new System.Drawing.Size(100, 22);
            this.textBoxCreg.TabIndex = 13;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(162, 15);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(44, 17);
            this.labelTimer.TabIndex = 14;
            this.labelTimer.Text = "Timer";
            // 
            // labelCreg
            // 
            this.labelCreg.AutoSize = true;
            this.labelCreg.Location = new System.Drawing.Point(168, 61);
            this.labelCreg.Name = "labelCreg";
            this.labelCreg.Size = new System.Drawing.Size(38, 17);
            this.labelCreg.TabIndex = 15;
            this.labelCreg.Text = "Creg";
            // 
            // pictureBoxAllarme
            // 
            this.pictureBoxAllarme.Enabled = false;
            this.pictureBoxAllarme.Image = global::OPC_CTPACK_Software.Properties.Resources.e;
            this.pictureBoxAllarme.Location = new System.Drawing.Point(386, 12);
            this.pictureBoxAllarme.Name = "pictureBoxAllarme";
            this.pictureBoxAllarme.Size = new System.Drawing.Size(112, 70);
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
            this.chartCreg.Location = new System.Drawing.Point(12, 88);
            this.chartCreg.MaximumSize = new System.Drawing.Size(2483, 2271);
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
            this.chartCreg.Size = new System.Drawing.Size(483, 351);
            this.chartCreg.TabIndex = 18;
            this.chartCreg.Text = "chart1";
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(325, 12);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(55, 70);
            this.butStop.TabIndex = 19;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10 minuti",
            "1 ora",
            "4 ore"});
            this.comboBox1.Location = new System.Drawing.Point(219, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 480);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.chartCreg);
            this.Controls.Add(this.pictureBoxAllarme);
            this.Controls.Add(this.labelCreg);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.textBoxCreg);
            this.Controls.Add(this.butStorico);
            this.Controls.Add(this.butCalcola);
            this.Controls.Add(this.butIndietro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.TextBox textBoxCreg;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelCreg;
        private System.Windows.Forms.PictureBox pictureBoxAllarme;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCreg;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}