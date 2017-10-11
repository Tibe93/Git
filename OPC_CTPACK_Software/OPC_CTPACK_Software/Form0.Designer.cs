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
            this.butAnalisi = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxFormato = new System.Windows.Forms.ComboBox();
            this.butPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butAnalisi
            // 
            this.butAnalisi.Location = new System.Drawing.Point(35, 29);
            this.butAnalisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butAnalisi.Name = "butAnalisi";
            this.butAnalisi.Size = new System.Drawing.Size(166, 92);
            this.butAnalisi.TabIndex = 0;
            this.butAnalisi.Text = "Start Analisi";
            this.butAnalisi.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(239, 101);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 22);
            this.textBox1.TabIndex = 1;
            // 
            // comboBoxFormato
            // 
            this.comboBoxFormato.FormattingEnabled = true;
            this.comboBoxFormato.Items.AddRange(new object[] {
            "Catena Choco Rolles formato 1",
            "Masse Choco Rolles formato 1"});
            this.comboBoxFormato.Location = new System.Drawing.Point(239, 29);
            this.comboBoxFormato.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxFormato.Name = "comboBoxFormato";
            this.comboBoxFormato.Size = new System.Drawing.Size(261, 24);
            this.comboBoxFormato.TabIndex = 2;
            // 
            // butPath
            // 
            this.butPath.Location = new System.Drawing.Point(465, 101);
            this.butPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.butPath.Name = "butPath";
            this.butPath.Size = new System.Drawing.Size(34, 22);
            this.butPath.TabIndex = 3;
            this.butPath.Text = "...";
            this.butPath.UseVisualStyleBackColor = true;
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 166);
            this.Controls.Add(this.butPath);
            this.Controls.Add(this.comboBoxFormato);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butAnalisi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form0";
            this.Text = "Form0";
            this.Load += new System.EventHandler(this.Form0_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAnalisi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxFormato;
        private System.Windows.Forms.Button butPath;
    }
}