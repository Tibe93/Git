namespace OPC_CTPACK_Software
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.chartStorico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxStorico = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartStorico)).BeginInit();
            this.SuspendLayout();
            // 
            // chartStorico
            // 
            this.chartStorico.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartStorico.ChartAreas.Add(chartArea1);
            this.chartStorico.Location = new System.Drawing.Point(-20, 126);
            this.chartStorico.Name = "chartStorico";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "GStorico";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "GLimitNeg";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "GLimitPos";
            this.chartStorico.Series.Add(series1);
            this.chartStorico.Series.Add(series2);
            this.chartStorico.Series.Add(series3);
            this.chartStorico.Size = new System.Drawing.Size(768, 612);
            this.chartStorico.TabIndex = 0;
            this.chartStorico.Text = "chart1";
            // 
            // comboBoxStorico
            // 
            this.comboBoxStorico.BackColor = System.Drawing.Color.LightGreen;
            this.comboBoxStorico.FormattingEnabled = true;
            this.comboBoxStorico.Location = new System.Drawing.Point(80, 60);
            this.comboBoxStorico.Name = "comboBoxStorico";
            this.comboBoxStorico.Size = new System.Drawing.Size(515, 33);
            this.comboBoxStorico.TabIndex = 1;
            this.comboBoxStorico.Text = "Selezionare lo storico che si vuole visualizzare";
            this.comboBoxStorico.SelectedIndexChanged += new System.EventHandler(this.comboBoxStorico_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(601, 60);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(108, 60);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 750);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxStorico);
            this.Controls.Add(this.chartStorico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Storico";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartStorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartStorico;
        private System.Windows.Forms.ComboBox comboBoxStorico;
        private System.Windows.Forms.Button buttonStart;
    }
}