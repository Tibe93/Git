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
    public partial class Form3 : Form
    {
        Form2 FormPadre;
        Start_Creg CregInit;

        public Form3(Form2 FormPadre, Start_Creg CregInit)
        {
            this.FormPadre = FormPadre;
            this.CregInit = CregInit;
            InitializeComponent();
        }
    }
}
