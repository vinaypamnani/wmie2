using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using WmiExplorer.Properties;

namespace WmiExplorer.Forms
{
    public partial class Form_Settings : Form
    {
        private readonly string _currentCacheAge;

        public Form_Settings()
        {
            InitializeComponent();
            _currentCacheAge = textBoxSettings_CacheAge.Text;
        }

        private void buttonSettings_Save_Click(object sender, EventArgs e)
        {
            bool restartRequired = false;

            if (Settings.Default.CacheAgeInMinutes != _currentCacheAge)
            {
                if (MessageBox.Show(
                    "New Cache Age will take effect after restarting WMI Explorer.\n\n" +
                    "Would you like to restart WMI Explorer now ?",
                    "WMI Explorer - Restart Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    ) == DialogResult.Yes)
                {
                    restartRequired = true;
                }
            }

            Settings.Default.Save();

            if (restartRequired)
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }

            Close();
        }

        private void buttonSettings_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            labelUpdate_LastUpdateCheck.Text += Settings.Default.LastUpdateCheck.ToString(CultureInfo.InvariantCulture);
        }
    }
}
