namespace WmiExplorer.Forms
{
    partial class Form_ExecMethod
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
            this.groupBoxInParams = new System.Windows.Forms.GroupBox();
            this.panelInParams = new System.Windows.Forms.Panel();
            this.labelInput = new System.Windows.Forms.Label();
            this.groupBoxOutParams = new System.Windows.Forms.GroupBox();
            this.propertyGridOutParams = new System.Windows.Forms.PropertyGrid();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCopyOutput = new System.Windows.Forms.Button();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelCaption = new System.Windows.Forms.Label();
            this.groupBoxInParams.SuspendLayout();
            this.panelInParams.SuspendLayout();
            this.groupBoxOutParams.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInParams
            // 
            this.groupBoxInParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInParams.Controls.Add(this.panelInParams);
            this.groupBoxInParams.Location = new System.Drawing.Point(12, 48);
            this.groupBoxInParams.Name = "groupBoxInParams";
            this.groupBoxInParams.Size = new System.Drawing.Size(410, 54);
            this.groupBoxInParams.TabIndex = 0;
            this.groupBoxInParams.TabStop = false;
            this.groupBoxInParams.Text = "Input Parameters";
            // 
            // panelInParams
            // 
            this.panelInParams.AutoScroll = true;
            this.panelInParams.Controls.Add(this.labelInput);
            this.panelInParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInParams.Location = new System.Drawing.Point(3, 16);
            this.panelInParams.Name = "panelInParams";
            this.panelInParams.Size = new System.Drawing.Size(404, 35);
            this.panelInParams.TabIndex = 0;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(3, 5);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(157, 13);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "Specify Input Parameter values:";
            // 
            // groupBoxOutParams
            // 
            this.groupBoxOutParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOutParams.Controls.Add(this.propertyGridOutParams);
            this.groupBoxOutParams.Location = new System.Drawing.Point(12, 108);
            this.groupBoxOutParams.Name = "groupBoxOutParams";
            this.groupBoxOutParams.Size = new System.Drawing.Size(410, 150);
            this.groupBoxOutParams.TabIndex = 1;
            this.groupBoxOutParams.TabStop = false;
            this.groupBoxOutParams.Text = "Output Parameters";
            // 
            // propertyGridOutParams
            // 
            this.propertyGridOutParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridOutParams.HelpVisible = false;
            this.propertyGridOutParams.Location = new System.Drawing.Point(3, 16);
            this.propertyGridOutParams.Name = "propertyGridOutParams";
            this.propertyGridOutParams.Size = new System.Drawing.Size(404, 131);
            this.propertyGridOutParams.TabIndex = 0;
            this.propertyGridOutParams.TabStop = false;
            this.propertyGridOutParams.ToolbarVisible = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.buttonClose);
            this.panelButtons.Controls.Add(this.buttonCopyOutput);
            this.panelButtons.Controls.Add(this.buttonExecute);
            this.panelButtons.Location = new System.Drawing.Point(12, 257);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(410, 42);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(329, 9);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCopyOutput
            // 
            this.buttonCopyOutput.Location = new System.Drawing.Point(166, 9);
            this.buttonCopyOutput.Name = "buttonCopyOutput";
            this.buttonCopyOutput.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyOutput.TabIndex = 1;
            this.buttonCopyOutput.Text = "Copy Output";
            this.buttonCopyOutput.UseVisualStyleBackColor = true;
            this.buttonCopyOutput.Click += new System.EventHandler(this.buttonCopyOutput_Click);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(248, 9);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonExecute.TabIndex = 0;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 300);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(434, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripLabel.Text = "toolStripStatusLabel";
            // 
            // labelCaption
            // 
            this.labelCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCaption.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelCaption.Location = new System.Drawing.Point(0, -1);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Padding = new System.Windows.Forms.Padding(5);
            this.labelCaption.Size = new System.Drawing.Size(434, 46);
            this.labelCaption.TabIndex = 4;
            this.labelCaption.Text = "Title";
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_ExecMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(434, 322);
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxOutParams);
            this.Controls.Add(this.groupBoxInParams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ExecMethod";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Execute Method ";
            this.groupBoxInParams.ResumeLayout(false);
            this.panelInParams.ResumeLayout(false);
            this.panelInParams.PerformLayout();
            this.groupBoxOutParams.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInParams;
        private System.Windows.Forms.Panel panelInParams;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.GroupBox groupBoxOutParams;
        private System.Windows.Forms.PropertyGrid propertyGridOutParams;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCopyOutput;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel;
        private System.Windows.Forms.Label labelCaption;
    }
}