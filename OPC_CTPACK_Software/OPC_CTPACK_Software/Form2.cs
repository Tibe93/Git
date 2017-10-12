using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPC_CTPACK_Software
{
    public partial class Form2 : Form
    {
        Form1 FormPadre;
        Form3 FormFiglio;
        Start_Creg CregInit;

        public Form2(Form1 FormPadre,Start_Creg CregInit)
        {
            this.FormPadre = FormPadre;
            this.FormFiglio = new Form3(this, this.CregInit);
            this.CregInit = CregInit;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormPadre.Close();
        }

        private void butIndietro_Click(object sender, EventArgs e)
        {
            this.FormPadre.Visible = true;
            this.Visible = false;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            FormFiglio.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            butAvanti.Enabled = true;
        }
    }
}
