namespace WmiExplorer
{
    sealed partial class Form_ShowMof
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
            this.textBoxShowMOF = new System.Windows.Forms.TextBox();
            this.buttonCloseMof = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxShowMOF
            // 
            this.textBoxShowMOF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxShowMOF.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxShowMOF.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxShowMOF.Location = new System.Drawing.Point(12, 13);
            this.textBoxShowMOF.Multiline = true;
            this.textBoxShowMOF.Name = "textBoxShowMOF";
            this.textBoxShowMOF.ReadOnly = true;
            this.textBoxShowMOF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxShowMOF.Size = new System.Drawing.Size(510, 253);
            this.textBoxShowMOF.TabIndex = 0;
            this.textBoxShowMOF.TabStop = false;
            this.textBoxShowMOF.WordWrap = false;
            // 
            // buttonCloseMof
            // 
            this.buttonCloseMof.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCloseMof.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCloseMof.Location = new System.Drawing.Point(227, 274);
            this.buttonCloseMof.Name = "buttonCloseMof";
            this.buttonCloseMof.Size = new System.Drawing.Size(75, 25);
            this.buttonCloseMof.TabIndex = 1;
            this.buttonCloseMof.Text = "Close";
            this.buttonCloseMof.UseVisualStyleBackColor = true;
            this.buttonCloseMof.Click += new System.EventHandler(this.buttonCloseMOF_Click);
            // 
            // Form_ShowMof
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonCloseMof;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.buttonCloseMof);
            this.Controls.Add(this.textBoxShowMOF);
            this.Name = "Form_ShowMof";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxShowMOF;
        private System.Windows.Forms.Button buttonCloseMof;
    }
}