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
    public partial class Form0 : Form
    {
        public static string Percorso;
        Form1 FormFiglio;

        public Form0()
        {
            this.FormFiglio = new Form1(this);
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void butPath_Click(object sender, EventArgs e)
        {
            
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {

            FormFiglio.Visible = true;
            this.Visible = false;
        }
    }
}
