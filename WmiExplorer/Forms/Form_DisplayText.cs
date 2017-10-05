using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WmiExplorer.Forms
{
    public partial class Form_DisplayText : Form
    {
        public Form_DisplayText(string windowTitle, string caption, string text)
        {
            InitializeComponent();
            labelCaption.Font = new Font("Arial", 10, FontStyle.Bold);
            Text = windowTitle;
            labelCaption.Text = caption;
            richTextBox.Text = text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
