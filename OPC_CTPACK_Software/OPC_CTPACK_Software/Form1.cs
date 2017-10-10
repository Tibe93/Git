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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Motore M1 = new Motore("VPL-B1153F-C", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c","c");
            Formato F1 = new Formato("ChocoRolles", M1, 0, 100, 100, 100);
            //richTextBox1.Text = f1.ToString();
            Creg C1 = new Creg(F1, $@"C:\Users\CtPack\Desktop\Tiberia\Trend_Tibe\_Fossalta_Temperature_Termoregolate\");


        }
    }
}
