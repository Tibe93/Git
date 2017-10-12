﻿using System;
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

        Form1 FormFiglio;

        public Form0()
        {
            this.FormFiglio = new Form1(this);
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            Formato[] F = Functions.LetturaFormati();
        }

        private void butPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void butAvanti_Click(object sender, EventArgs e)
        {
            FormFiglio.Visible = true;
            this.Visible = false;
        }
    }
}
