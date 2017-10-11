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
    public partial class Form1 : Form
    {
        Form0 FormPadre;

        public Form1(Form0 FormPadre)
        {
            InitializeComponent();
            this.FormPadre = FormPadre;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Motore M1 = new Motore("VPL-B1153F-C", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c","c");
            Formato F1 = new Formato("ChocoRolles", M1, 70, 1, 0.01, 0.075);
            Creg C1 = new Creg(F1, $@"C:\Users\CtPack\Desktop\Tiberia\Trend_Tibe\_Fossalta_Temperature_Termoregolate\",2);
            */
        }

        private void butIndietro_Click(object sender, EventArgs e)
        {
            this.FormPadre.Visible = true;
            this.Visible = false;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            //Si aprira il Form2
        }

        private void butCalcolo_Click(object sender, EventArgs e)
        {
            
        }
    }
}
