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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.comboBoxFormato = new System.Windows.Forms.ComboBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.butPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartCreg)).BeginInit();
            this.SuspendLayout();
            // 
            // butCalcolo
            // 
            this.butCalcolo.Enabled = false;
            this.butCalcolo.Location = new System.Drawing.Point(12, 12);
            this.butCalcolo.Name = "butCalcolo";
            this.butCalcolo.Size = new System.Drawing.Size(121, 54);
            this.butCalcolo.TabIndex = 0;
            this.butCalcolo.Text = "Start Calcolo";
            this.butCalcolo.UseVisualStyleBackColor = true;
            this.butCalcolo.Click += new System.EventHandler(this.butCalcolo_Click);
            // 
            // labelTolleranza
            // 
            this.labelTolleranza.AutoSize = true;
            this.labelTolleranza.Location = new System.Drawing.Point(12, 78);
            this.labelTolleranza.Name = "labelTolleranza";
            this.labelTolleranza.Size = new System.Drawing.Size(75, 17);
            this.labelTolleranza.TabIndex = 1;
            this.labelTolleranza.Text = "Tolleranza";
            // 
            // labelBs
            // 
            this.labelBs.AutoSize = true;
            this.labelBs.Location = new System.Drawing.Point(207, 78);
            this.labelBs.Name = "labelBs";
            this.labelBs.Size = new System.Drawing.Size(24, 17);
            this.labelBs.TabIndex = 2;
            this.labelBs.Text = "Bs";
            // 
            // labelBv
            // 
            this.labelBv.AutoSize = true;
            this.labelBv.Location = new System.Drawing.Point(352, 78);
            this.labelBv.Name = "labelBv";
            this.labelBv.Size = new System.Drawing.Size(24, 17);
            this.labelBv.TabIndex = 3;
            this.labelBv.Text = "Bv";
            // 
            // textBoxTolleranza
            // 
            this.textBoxTolleranza.Enabled = false;
            this.textBoxTolleranza.Location = new System.Drawing.Point(93, 75);
            this.textBoxTolleranza.Name = "textBoxTolleranza";
            this.textBoxTolleranza.Size = new System.Drawing.Size(112, 22);
            this.textBoxTolleranza.TabIndex = 4;
            this.textBoxTolleranza.Text = "Inserire un Intero";
            this.textBoxTolleranza.Click += new System.EventHandler(this.textBoxTolleranza_Click);
            this.textBoxTolleranza.TextChanged += new System.EventHandler(this.textBoxTolleranza_TextChanged);
            this.textBoxTolleranza.Leave += new System.EventHandler(this.textBoxTolleranza_Leave);
            // 
            // textBoxBs
            // 
            this.textBoxBs.Location = new System.Drawing.Point(237, 75);
            this.textBoxBs.Name = "textBoxBs";
            this.textBoxBs.ReadOnly = true;
            this.textBoxBs.Size = new System.Drawing.Size(115, 22);
            this.textBoxBs.TabIndex = 5;
            // 
            // textBoxBv
            // 
            this.textBoxBv.Location = new System.Drawing.Point(380, 75);
            this.textBoxBv.Name = "textBoxBv";
            this.textBoxBv.ReadOnly = true;
            this.textBoxBv.Size = new System.Drawing.Size(115, 22);
            this.textBoxBv.TabIndex = 6;
            // 
            // butAvanti
            // 
            this.butAvanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAvanti.Enabled = false;
            this.butAvanti.Location = new System.Drawing.Point(420, 445);
            this.butAvanti.Name = "butAvanti";
            this.butAvanti.Size = new System.Drawing.Size(75, 23);
            this.butAvanti.TabIndex = 7;
            this.butAvanti.Text = "Avanti >";
            this.butAvanti.UseVisualStyleBackColor = true;
            this.butAvanti.Click += new System.EventHandler(this.butAvanti_Click);
            // 
            // butIndietro
            // 
            this.butIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIndietro.Location = new System.Drawing.Point(12, 445);
            this.butIndietro.Name = "butIndietro";
            this.butIndietro.Size = new System.Drawing.Size(75, 23);
            this.butIndietro.TabIndex = 8;
            this.butIndietro.Text = "< Indietro";
            this.butIndietro.UseVisualStyleBackColor = true;
            this.butIndietro.Click += new System.EventHandler(this.butIndietro_Click);
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
            this.chartCreg.Location = new System.Drawing.Point(12, 103);
            this.chartCreg.MaximumSize = new System.Drawing.Size(2483, 2256);
            this.chartCreg.Name = "chartCreg";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Creg";
            this.chartCreg.Series.Add(series1);
            this.chartCreg.Size = new System.Drawing.Size(483, 336);
            this.chartCreg.TabIndex = 9;
            this.chartCreg.Text = "chart1";
            this.chartCreg.Visible = false;
            // 
            // comboBoxFormato
            // 
            this.comboBoxFormato.BackColor = System.Drawing.Color.LightGreen;
            this.comboBoxFormato.FormattingEnabled = true;
            this.comboBoxFormato.Location = new System.Drawing.Point(136, 12);
            this.comboBoxFormato.Name = "comboBoxFormato";
            this.comboBoxFormato.Size = new System.Drawing.Size(359, 24);
            this.comboBoxFormato.TabIndex = 10;
            this.comboBoxFormato.Text = "Selezionare Cinematismo/Formato";
            this.comboBoxFormato.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormato_SelectedIndexChanged);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Enabled = false;
            this.textBoxPath.Location = new System.Drawing.Point(136, 44);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(324, 22);
            this.textBoxPath.TabIndex = 11;
            this.textBoxPath.Text = "Inserire Path Salvataggio .CSV";
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // butPath
            // 
            this.butPath.Enabled = false;
            this.butPath.Location = new System.Drawing.Point(466, 44);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(29, 22);
            this.butPath.TabIndex = 12;
            this.butPath.Text = "...";
            this.butPath.UseVisualStyleBackColor = true;
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 480);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.comboBoxFormato);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Creg Preliminare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.ComboBox comboBoxFormato;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button butPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

