namespace OPC_CTPACK_Software
{
    partial class Form0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form0));
            this.butAnalisi = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.comboBoxFormato = new System.Windows.Forms.ComboBox();
            this.butPath = new System.Windows.Forms.Button();
            this.butAvanti = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // butAnalisi
            // 
            this.butAnalisi.Location = new System.Drawing.Point(35, 29);
            this.butAnalisi.Margin = new System.Windows.Forms.Padding(2);
            this.butAnalisi.Name = "butAnalisi";
            this.butAnalisi.Size = new System.Drawing.Size(166, 92);
            this.butAnalisi.TabIndex = 0;
            this.butAnalisi.Text = "Start Analisi";
            this.butAnalisi.UseVisualStyleBackColor = true;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(239, 99);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(221, 22);
            this.textBoxPath.TabIndex = 1;
            // 
            // comboBoxFormato
            // 
            this.comboBoxFormato.FormattingEnabled = true;
            this.comboBoxFormato.Items.AddRange(new object[] {
            "Catena Choco Rolles formato 1",
            "Masse Choco Rolles formato 1"});
            this.comboBoxFormato.Location = new System.Drawing.Point(239, 29);
            this.comboBoxFormato.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxFormato.Name = "comboBoxFormato";
            this.comboBoxFormato.Size = new System.Drawing.Size(261, 24);
            this.comboBoxFormato.TabIndex = 2;
            // 
            // butPath
            // 
            this.butPath.Location = new System.Drawing.Point(465, 99);
            this.butPath.Margin = new System.Windows.Forms.Padding(2);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(35, 22);
            this.butPath.TabIndex = 3;
            this.butPath.Text = "...";
            this.butPath.UseVisualStyleBackColor = true;
            this.butPath.Click += new System.EventHandler(this.butPath_Click);
            // 
            // butAvanti
            // 
            this.butAvanti.Location = new System.Drawing.Point(425, 128);
            this.butAvanti.Name = "butAvanti";
            this.butAvanti.Size = new System.Drawing.Size(75, 23);
            this.butAvanti.TabIndex = 8;
            this.butAvanti.Text = "Avanti >";
            this.butAvanti.UseVisualStyleBackColor = true;
            this.butAvanti.Click += new System.EventHandler(this.butAvanti_Click);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 480);
            this.Controls.Add(this.butAvanti);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.comboBoxFormato);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.butAnalisi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form0";
            this.Text = "OPC";
            this.Load += new System.EventHandler(this.Form0_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAnalisi;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.ComboBox comboBoxFormato;
        private System.Windows.Forms.Button butPath;
        private System.Windows.Forms.Button butAvanti;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}