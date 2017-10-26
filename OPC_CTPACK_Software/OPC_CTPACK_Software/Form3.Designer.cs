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
            this.chartStorico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartStorico.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.Name = "ChartArea1";
            this.chartStorico.ChartAreas.Add(chartArea1);
            this.chartStorico.Location = new System.Drawing.Point(1, 39);
            this.chartStorico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartStorico.MaximumSize = new System.Drawing.Size(2497, 2312);
            this.chartStorico.Name = "chartStorico";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Lime;
            series1.Name = "GStorico";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "GLimitNeg";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "GLimitPos";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartStorico.Series.Add(series1);
            this.chartStorico.Series.Add(series2);
            this.chartStorico.Series.Add(series3);
            this.chartStorico.Size = new System.Drawing.Size(504, 440);
            this.chartStorico.TabIndex = 0;
            this.chartStorico.Text = "chart1";
            this.chartStorico.Visible = false;
            // 
            // comboBoxStorico
            // 
            this.comboBoxStorico.BackColor = System.Drawing.Color.LightGreen;
            this.comboBoxStorico.FormattingEnabled = true;
            this.comboBoxStorico.Location = new System.Drawing.Point(11, 11);
            this.comboBoxStorico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxStorico.Name = "comboBoxStorico";
            this.comboBoxStorico.Size = new System.Drawing.Size(409, 24);
            this.comboBoxStorico.TabIndex = 1;
            this.comboBoxStorico.Text = "Selezionare lo storico che si vuole visualizzare";
            this.comboBoxStorico.SelectedIndexChanged += new System.EventHandler(this.comboBoxStorico_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(424, 11);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 24);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(507, 480);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxStorico);
            this.Controls.Add(this.chartStorico);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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