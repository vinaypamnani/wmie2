using System;
using System.Management;
using System.Windows.Forms;
using WmiExplorer.Classes;

namespace WmiExplorer.Forms
{
    public partial class Form_ConnectAs : Form
    {
        public ConnectionOptions Connection;
        public string Path;
        public bool Cancelled;

        public Form_ConnectAs(string path = "")
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(path))
            {
                textBoxPath.Text = path;
                textBoxPath.ReadOnly = true;
                textBoxUsername.Select();
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPath.Text))
            {
                MessageBox.Show("No path specified. Please specify a remote computer/path to connect to. ",
                    "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Path = textBoxPath.Text.ToUpperInvariant();
            Connection = new ConnectionOptions
            {
                EnablePrivileges = true,
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Default,
                Username = textBoxUsername.Text,
                SecurePassword = textBoxPassword.Text.StringToSecureString()
            };

            if (String.IsNullOrEmpty(textBoxUsername.Text))
            {
                MessageBox.Show("No username specified. Logged on user's credentials will be used. ",
                    "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Connection.Username = null;
                Connection.SecurePassword = null;
            }

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            Close();
        }
    }
}
