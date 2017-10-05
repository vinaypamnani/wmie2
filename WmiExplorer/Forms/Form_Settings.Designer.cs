namespace WmiExplorer.Forms
{
    partial class Form_Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSettings_General = new System.Windows.Forms.GroupBox();
            this.checkBoxSettings_RememberEnumOptions = new System.Windows.Forms.CheckBox();
            this.checkBoxSettings_RememberRecentPaths = new System.Windows.Forms.CheckBox();
            this.checkBoxSettings_PreserveLayout = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings_Update = new System.Windows.Forms.GroupBox();
            this.labelUpdate_LastUpdateCheck = new System.Windows.Forms.Label();
            this.textBoxSettings_UpdateCheckInterval = new System.Windows.Forms.TextBox();
            this.labelUpdate_CheckInterval = new System.Windows.Forms.Label();
            this.checkBoxSettings_CheckForUpdates = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings_Caching = new System.Windows.Forms.GroupBox();
            this.textBoxSettings_CacheAge = new System.Windows.Forms.TextBox();
            this.labelCaching_CacheAge = new System.Windows.Forms.Label();
            this.buttonSettings_Save = new System.Windows.Forms.Button();
            this.buttonSettings_Cancel = new System.Windows.Forms.Button();
            this.groupBoxSettings_General.SuspendLayout();
            this.groupBoxSettings_Update.SuspendLayout();
            this.groupBoxSettings_Caching.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettings_General
            // 
            this.groupBoxSettings_General.Controls.Add(this.checkBoxSettings_RememberEnumOptions);
            this.groupBoxSettings_General.Controls.Add(this.checkBoxSettings_RememberRecentPaths);
            this.groupBoxSettings_General.Controls.Add(this.checkBoxSettings_PreserveLayout);
            this.groupBoxSettings_General.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings_General.Name = "groupBoxSettings_General";
            this.groupBoxSettings_General.Size = new System.Drawing.Size(460, 86);
            this.groupBoxSettings_General.TabIndex = 0;
            this.groupBoxSettings_General.TabStop = false;
            this.groupBoxSettings_General.Text = "General";
            // 
            // checkBoxSettings_RememberEnumOptions
            // 
            this.checkBoxSettings_RememberEnumOptions.AutoSize = true;
            this.checkBoxSettings_RememberEnumOptions.Checked = global::WmiExplorer.Properties.Settings.Default.bRememberEnumOptions;
            this.checkBoxSettings_RememberEnumOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSettings_RememberEnumOptions.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WmiExplorer.Properties.Settings.Default, "bRememberEnumOptions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSettings_RememberEnumOptions.Location = new System.Drawing.Point(6, 65);
            this.checkBoxSettings_RememberEnumOptions.Name = "checkBoxSettings_RememberEnumOptions";
            this.checkBoxSettings_RememberEnumOptions.Size = new System.Drawing.Size(271, 17);
            this.checkBoxSettings_RememberEnumOptions.TabIndex = 2;
            this.checkBoxSettings_RememberEnumOptions.Text = "Remember Class and Instance Enumeration Options";
            this.checkBoxSettings_RememberEnumOptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxSettings_RememberRecentPaths
            // 
            this.checkBoxSettings_RememberRecentPaths.AutoSize = true;
            this.checkBoxSettings_RememberRecentPaths.Checked = global::WmiExplorer.Properties.Settings.Default.bRememberRecentPaths;
            this.checkBoxSettings_RememberRecentPaths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSettings_RememberRecentPaths.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WmiExplorer.Properties.Settings.Default, "bRememberRecentPaths", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSettings_RememberRecentPaths.Location = new System.Drawing.Point(6, 42);
            this.checkBoxSettings_RememberRecentPaths.Name = "checkBoxSettings_RememberRecentPaths";
            this.checkBoxSettings_RememberRecentPaths.Size = new System.Drawing.Size(313, 17);
            this.checkBoxSettings_RememberRecentPaths.TabIndex = 1;
            this.checkBoxSettings_RememberRecentPaths.Text = "Remember previously connected Computer names and paths";
            this.checkBoxSettings_RememberRecentPaths.UseVisualStyleBackColor = true;
            // 
            // checkBoxSettings_PreserveLayout
            // 
            this.checkBoxSettings_PreserveLayout.AutoSize = true;
            this.checkBoxSettings_PreserveLayout.Checked = global::WmiExplorer.Properties.Settings.Default.bPreserveLayout;
            this.checkBoxSettings_PreserveLayout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSettings_PreserveLayout.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WmiExplorer.Properties.Settings.Default, "bPreserveLayout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSettings_PreserveLayout.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSettings_PreserveLayout.Name = "checkBoxSettings_PreserveLayout";
            this.checkBoxSettings_PreserveLayout.Size = new System.Drawing.Size(447, 17);
            this.checkBoxSettings_PreserveLayout.TabIndex = 0;
            this.checkBoxSettings_PreserveLayout.Text = "Remember UI Layout when application closes (Window Size, Location and Splitter Wi" +
    "dth)";
            this.checkBoxSettings_PreserveLayout.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettings_Update
            // 
            this.groupBoxSettings_Update.Controls.Add(this.labelUpdate_LastUpdateCheck);
            this.groupBoxSettings_Update.Controls.Add(this.textBoxSettings_UpdateCheckInterval);
            this.groupBoxSettings_Update.Controls.Add(this.labelUpdate_CheckInterval);
            this.groupBoxSettings_Update.Controls.Add(this.checkBoxSettings_CheckForUpdates);
            this.groupBoxSettings_Update.Location = new System.Drawing.Point(12, 156);
            this.groupBoxSettings_Update.Name = "groupBoxSettings_Update";
            this.groupBoxSettings_Update.Size = new System.Drawing.Size(460, 71);
            this.groupBoxSettings_Update.TabIndex = 1;
            this.groupBoxSettings_Update.TabStop = false;
            this.groupBoxSettings_Update.Text = "Application Updates";
            // 
            // labelUpdate_LastUpdateCheck
            // 
            this.labelUpdate_LastUpdateCheck.AutoSize = true;
            this.labelUpdate_LastUpdateCheck.Location = new System.Drawing.Point(240, 41);
            this.labelUpdate_LastUpdateCheck.Name = "labelUpdate_LastUpdateCheck";
            this.labelUpdate_LastUpdateCheck.Size = new System.Drawing.Size(105, 13);
            this.labelUpdate_LastUpdateCheck.TabIndex = 3;
            this.labelUpdate_LastUpdateCheck.Text = "Last Update Check: ";
            // 
            // textBoxSettings_UpdateCheckInterval
            // 
            this.textBoxSettings_UpdateCheckInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WmiExplorer.Properties.Settings.Default, "UpdateCheckIntervalInDays", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSettings_UpdateCheckInterval.Location = new System.Drawing.Point(174, 38);
            this.textBoxSettings_UpdateCheckInterval.Name = "textBoxSettings_UpdateCheckInterval";
            this.textBoxSettings_UpdateCheckInterval.Size = new System.Drawing.Size(60, 20);
            this.textBoxSettings_UpdateCheckInterval.TabIndex = 2;
            this.textBoxSettings_UpdateCheckInterval.Text = global::WmiExplorer.Properties.Settings.Default.UpdateCheckIntervalInDays;
            // 
            // labelUpdate_CheckInterval
            // 
            this.labelUpdate_CheckInterval.AutoSize = true;
            this.labelUpdate_CheckInterval.Location = new System.Drawing.Point(6, 41);
            this.labelUpdate_CheckInterval.Name = "labelUpdate_CheckInterval";
            this.labelUpdate_CheckInterval.Size = new System.Drawing.Size(162, 13);
            this.labelUpdate_CheckInterval.TabIndex = 1;
            this.labelUpdate_CheckInterval.Text = "Update Check Interval (In Days):";
            // 
            // checkBoxSettings_CheckForUpdates
            // 
            this.checkBoxSettings_CheckForUpdates.AutoSize = true;
            this.checkBoxSettings_CheckForUpdates.Checked = global::WmiExplorer.Properties.Settings.Default.bCheckForUpdates;
            this.checkBoxSettings_CheckForUpdates.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WmiExplorer.Properties.Settings.Default, "bCheckForUpdates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxSettings_CheckForUpdates.Location = new System.Drawing.Point(9, 19);
            this.checkBoxSettings_CheckForUpdates.Name = "checkBoxSettings_CheckForUpdates";
            this.checkBoxSettings_CheckForUpdates.Size = new System.Drawing.Size(227, 17);
            this.checkBoxSettings_CheckForUpdates.TabIndex = 0;
            this.checkBoxSettings_CheckForUpdates.Text = "Automatically check for updates on launch";
            this.checkBoxSettings_CheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettings_Caching
            // 
            this.groupBoxSettings_Caching.Controls.Add(this.textBoxSettings_CacheAge);
            this.groupBoxSettings_Caching.Controls.Add(this.labelCaching_CacheAge);
            this.groupBoxSettings_Caching.Location = new System.Drawing.Point(12, 104);
            this.groupBoxSettings_Caching.Name = "groupBoxSettings_Caching";
            this.groupBoxSettings_Caching.Size = new System.Drawing.Size(460, 46);
            this.groupBoxSettings_Caching.TabIndex = 2;
            this.groupBoxSettings_Caching.TabStop = false;
            this.groupBoxSettings_Caching.Text = "Caching";
            // 
            // textBoxSettings_CacheAge
            // 
            this.textBoxSettings_CacheAge.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WmiExplorer.Properties.Settings.Default, "CacheAgeInMinutes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSettings_CacheAge.Location = new System.Drawing.Point(133, 16);
            this.textBoxSettings_CacheAge.Name = "textBoxSettings_CacheAge";
            this.textBoxSettings_CacheAge.Size = new System.Drawing.Size(60, 20);
            this.textBoxSettings_CacheAge.TabIndex = 1;
            this.textBoxSettings_CacheAge.Text = global::WmiExplorer.Properties.Settings.Default.CacheAgeInMinutes;
            // 
            // labelCaching_CacheAge
            // 
            this.labelCaching_CacheAge.AutoSize = true;
            this.labelCaching_CacheAge.Location = new System.Drawing.Point(6, 19);
            this.labelCaching_CacheAge.Name = "labelCaching_CacheAge";
            this.labelCaching_CacheAge.Size = new System.Drawing.Size(121, 13);
            this.labelCaching_CacheAge.TabIndex = 0;
            this.labelCaching_CacheAge.Text = "Cache Age (In Minutes):";
            // 
            // buttonSettings_Save
            // 
            this.buttonSettings_Save.Location = new System.Drawing.Point(295, 241);
            this.buttonSettings_Save.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSettings_Save.Name = "buttonSettings_Save";
            this.buttonSettings_Save.Size = new System.Drawing.Size(75, 23);
            this.buttonSettings_Save.TabIndex = 3;
            this.buttonSettings_Save.Text = "Ok";
            this.buttonSettings_Save.UseVisualStyleBackColor = true;
            this.buttonSettings_Save.Click += new System.EventHandler(this.buttonSettings_Save_Click);
            // 
            // buttonSettings_Cancel
            // 
            this.buttonSettings_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSettings_Cancel.Location = new System.Drawing.Point(390, 241);
            this.buttonSettings_Cancel.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSettings_Cancel.Name = "buttonSettings_Cancel";
            this.buttonSettings_Cancel.Size = new System.Drawing.Size(75, 23);
            this.buttonSettings_Cancel.TabIndex = 4;
            this.buttonSettings_Cancel.Text = "Cancel";
            this.buttonSettings_Cancel.UseVisualStyleBackColor = true;
            this.buttonSettings_Cancel.Click += new System.EventHandler(this.buttonSettings_Cancel_Click);
            // 
            // Form_Settings
            // 
            this.AcceptButton = this.buttonSettings_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.buttonSettings_Cancel;
            this.ClientSize = new System.Drawing.Size(484, 276);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSettings_Cancel);
            this.Controls.Add(this.buttonSettings_Save);
            this.Controls.Add(this.groupBoxSettings_Caching);
            this.Controls.Add(this.groupBoxSettings_Update);
            this.Controls.Add(this.groupBoxSettings_General);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.groupBoxSettings_General.ResumeLayout(false);
            this.groupBoxSettings_General.PerformLayout();
            this.groupBoxSettings_Update.ResumeLayout(false);
            this.groupBoxSettings_Update.PerformLayout();
            this.groupBoxSettings_Caching.ResumeLayout(false);
            this.groupBoxSettings_Caching.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettings_General;
        private System.Windows.Forms.GroupBox groupBoxSettings_Update;
        private System.Windows.Forms.CheckBox checkBoxSettings_PreserveLayout;
        private System.Windows.Forms.CheckBox checkBoxSettings_RememberRecentPaths;
        private System.Windows.Forms.TextBox textBoxSettings_UpdateCheckInterval;
        private System.Windows.Forms.Label labelUpdate_CheckInterval;
        private System.Windows.Forms.CheckBox checkBoxSettings_CheckForUpdates;
        private System.Windows.Forms.GroupBox groupBoxSettings_Caching;
        private System.Windows.Forms.TextBox textBoxSettings_CacheAge;
        private System.Windows.Forms.Label labelCaching_CacheAge;
        private System.Windows.Forms.Button buttonSettings_Save;
        private System.Windows.Forms.Button buttonSettings_Cancel;
        private System.Windows.Forms.Label labelUpdate_LastUpdateCheck;
        private System.Windows.Forms.CheckBox checkBoxSettings_RememberEnumOptions;
    }
}