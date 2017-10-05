using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WmiExplorer.Properties;

namespace WmiExplorer.Forms
{
    public partial class Form_Update : Form
    {
        public Form_Update(bool bUpdateAvailable, string changelog)
        {
            InitializeComponent();

            if (bUpdateAvailable)
            {
                Font font = new Font("Arial", 10, FontStyle.Bold);
                richTextBoxUpdate.SelectionFont = font;
                richTextBoxUpdate.AppendText("A new version of WMI Explorer is available!\n");
                richTextBoxUpdate.AppendText(Settings.Default.UpdateUrl + "\n\n");
                richTextBoxUpdate.AppendText(changelog);
                richTextBoxUpdate.SelectionStart = 0;
                richTextBoxUpdate.ScrollToCaret();
            }
            else
            {
                Width = 400;
                Height = 200;
                richTextBoxUpdate.AppendText("You are running the latest version!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBoxUpdate_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
