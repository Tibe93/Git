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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.butIndietro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butIndietro
            // 
            this.butIndietro.Location = new System.Drawing.Point(12, 445);
            this.butIndietro.Name = "butIndietro";
            this.butIndietro.Size = new System.Drawing.Size(75, 23);
            this.butIndietro.TabIndex = 9;
            this.butIndietro.Text = "< Indietro";
            this.butIndietro.UseVisualStyleBackColor = true;
            this.butIndietro.Click += new System.EventHandler(this.butIndietro_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 480);
            this.Controls.Add(this.butIndietro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butIndietro;
    }
}