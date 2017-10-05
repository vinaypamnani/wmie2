namespace WmiExplorer.Forms
{
    partial class Form_Update
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
            this.richTextBoxUpdate = new System.Windows.Forms.RichTextBox();
            this.buttonCancelHidden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxUpdate
            // 
            this.richTextBoxUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxUpdate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBoxUpdate.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxUpdate.Name = "richTextBoxUpdate";
            this.richTextBoxUpdate.ReadOnly = true;
            this.richTextBoxUpdate.Size = new System.Drawing.Size(471, 156);
            this.richTextBoxUpdate.TabIndex = 0;
            this.richTextBoxUpdate.Text = "";
            this.richTextBoxUpdate.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxUpdate_LinkClicked);
            // 
            // buttonCancelHidden
            // 
            this.buttonCancelHidden.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancelHidden.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelHidden.Location = new System.Drawing.Point(193, 174);
            this.buttonCancelHidden.Name = "buttonCancelHidden";
            this.buttonCancelHidden.Size = new System.Drawing.Size(100, 25);
            this.buttonCancelHidden.TabIndex = 1;
            this.buttonCancelHidden.Text = "OK";
            this.buttonCancelHidden.UseVisualStyleBackColor = true;
            this.buttonCancelHidden.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.buttonCancelHidden;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.richTextBoxUpdate);
            this.Controls.Add(this.buttonCancelHidden);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Update";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WMI Explorer Update";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxUpdate;
        private System.Windows.Forms.Button buttonCancelHidden;
    }
}