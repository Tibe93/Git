namespace OPC_CTPACK_Software
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.butCalcolo = new System.Windows.Forms.Button();
            this.labelTolleranza = new System.Windows.Forms.Label();
            this.labelBs = new System.Windows.Forms.Label();
            this.labelBv = new System.Windows.Forms.Label();
            this.textBoxTolleranza = new System.Windows.Forms.TextBox();
            this.textBoxBs = new System.Windows.Forms.TextBox();
            this.textBoxBv = new System.Windows.Forms.TextBox();
            this.butAvanti = new System.Windows.Forms.Button();
            this.butIndietro = new System.Windows.Forms.Button();
            this.chartCreg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartCreg)).BeginInit();
            this.SuspendLayout();
            // 
            // butCalcolo
            // 
            this.butCalcolo.Location = new System.Drawing.Point(12, 13);
            this.butCalcolo.Name = "butCalcolo";
            this.butCalcolo.Size = new System.Drawing.Size(121, 80);
            this.butCalcolo.TabIndex = 0;
            this.butCalcolo.Text = "Start Calcolo";
            this.butCalcolo.UseVisualStyleBackColor = true;
            this.butCalcolo.Click += new System.EventHandler(this.butCalcolo_Click);
            // 
            // labelTolleranza
            // 
            this.labelTolleranza.AutoSize = true;
            this.labelTolleranza.Location = new System.Drawing.Point(139, 16);
            this.labelTolleranza.Name = "labelTolleranza";
            this.labelTolleranza.Size = new System.Drawing.Size(75, 17);
            this.labelTolleranza.TabIndex = 1;
            this.labelTolleranza.Text = "Tolleranza";
            // 
            // labelBs
            // 
            this.labelBs.AutoSize = true;
            this.labelBs.Location = new System.Drawing.Point(165, 45);
            this.labelBs.Name = "labelBs";
            this.labelBs.Size = new System.Drawing.Size(24, 17);
            this.labelBs.TabIndex = 2;
            this.labelBs.Text = "Bs";
            // 
            // labelBv
            // 
            this.labelBv.AutoSize = true;
            this.labelBv.Location = new System.Drawing.Point(165, 74);
            this.labelBv.Name = "labelBv";
            this.labelBv.Size = new System.Drawing.Size(24, 17);
            this.labelBv.TabIndex = 3;
            this.labelBv.Text = "Bv";
            // 
            // textBoxTolleranza
            // 
            this.textBoxTolleranza.Location = new System.Drawing.Point(222, 13);
            this.textBoxTolleranza.Name = "textBoxTolleranza";
            this.textBoxTolleranza.Size = new System.Drawing.Size(100, 22);
            this.textBoxTolleranza.TabIndex = 4;
            // 
            // textBoxBs
            // 
            this.textBoxBs.Location = new System.Drawing.Point(222, 42);
            this.textBoxBs.Name = "textBoxBs";
            this.textBoxBs.ReadOnly = true;
            this.textBoxBs.Size = new System.Drawing.Size(100, 22);
            this.textBoxBs.TabIndex = 5;
            // 
            // textBoxBv
            // 
            this.textBoxBv.Location = new System.Drawing.Point(222, 70);
            this.textBoxBv.Name = "textBoxBv";
            this.textBoxBv.ReadOnly = true;
            this.textBoxBv.Size = new System.Drawing.Size(100, 22);
            this.textBoxBv.TabIndex = 6;
            // 
            // butAvanti
            // 
            this.butAvanti.Enabled = false;
            this.butAvanti.Location = new System.Drawing.Point(247, 334);
            this.butAvanti.Name = "butAvanti";
            this.butAvanti.Size = new System.Drawing.Size(75, 23);
            this.butAvanti.TabIndex = 7;
            this.butAvanti.Text = "Avanti >";
            this.butAvanti.UseVisualStyleBackColor = true;
            this.butAvanti.Click += new System.EventHandler(this.butAvanti_Click);
            // 
            // butIndietro
            // 
            this.butIndietro.Location = new System.Drawing.Point(12, 334);
            this.butIndietro.Name = "butIndietro";
            this.butIndietro.Size = new System.Drawing.Size(75, 23);
            this.butIndietro.TabIndex = 8;
            this.butIndietro.Text = "< Indietro";
            this.butIndietro.UseVisualStyleBackColor = true;
            this.butIndietro.Click += new System.EventHandler(this.butIndietro_Click);
            // 
            // chartCreg
            // 
            chartArea4.Name = "ChartArea1";
            this.chartCreg.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartCreg.Legends.Add(legend4);
            this.chartCreg.Location = new System.Drawing.Point(13, 100);
            this.chartCreg.Name = "chartCreg";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartCreg.Series.Add(series4);
            this.chartCreg.Size = new System.Drawing.Size(309, 228);
            this.chartCreg.TabIndex = 9;
            this.chartCreg.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 369);
            this.Controls.Add(this.chartCreg);
            this.Controls.Add(this.butIndietro);
            this.Controls.Add(this.butAvanti);
            this.Controls.Add(this.textBoxBv);
            this.Controls.Add(this.textBoxBs);
            this.Controls.Add(this.textBoxTolleranza);
            this.Controls.Add(this.labelBv);
            this.Controls.Add(this.labelBs);
            this.Controls.Add(this.labelTolleranza);
            this.Controls.Add(this.butCalcolo);
            this.Name = "Form1";
            this.Text = "Creg Preliminare";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartCreg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCalcolo;
        private System.Windows.Forms.Label labelTolleranza;
        private System.Windows.Forms.Label labelBs;
        private System.Windows.Forms.Label labelBv;
        private System.Windows.Forms.TextBox textBoxTolleranza;
        private System.Windows.Forms.TextBox textBoxBs;
        private System.Windows.Forms.TextBox textBoxBv;
        private System.Windows.Forms.Button butAvanti;
        private System.Windows.Forms.Button butIndietro;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCreg;
    }
}

