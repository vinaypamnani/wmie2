using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WmiExplorer
{
    
    public sealed partial class Form_ShowMof : Form
    {
        public Form_ShowMof(string mofText)
        {
            InitializeComponent();
            textBoxShowMOF.Text = "\r\n" + mofText;
        }

        private void buttonCloseMOF_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
