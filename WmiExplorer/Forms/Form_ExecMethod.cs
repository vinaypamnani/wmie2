using System;
using System.Drawing;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WmiExplorer.Classes;

namespace WmiExplorer.Forms
{
    public partial class Form_ExecMethod : Form
    {
        private ManagementObject _mObject;
        private MethodData _method;
        private string _clipboardText = String.Empty;

        public Form_ExecMethod(ManagementObject mObject, MethodData method)
        {
            _mObject = mObject;
            _method = method;
            InitializeComponent();
            //InitializeUi();
            InitializeForm();

        }

        private void InitializeForm()
        {
            // Update Form Title
            labelCaption.Text = _method.Name + " Method for \n" + _mObject.ClassPath.Path;
            toolStripLabel.Text = String.Empty;

            // Populate Input Parameters
            if (_method.InParameters == null ||_method.InParameters.Properties.Count == 0)
            {
                labelInput.Text = "This method doesn't have any Input Parameters.";
            }
            else
            {
                Label[] label = new Label[_method.InParameters.Properties.Count];
                TextBox[] textBox = new TextBox[_method.InParameters.Properties.Count];
                Control[] paramControls = new Control[_method.InParameters.Properties.Count];

                var i = 0;
                var maxLabelWidth = 0;
                foreach (PropertyData inParam in _method.InParameters.Properties)
                {
                    // Create a label
                    label[i] = new Label
                    {
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Text = inParam.Name + " (" + inParam.Type + ") :"
                    };

                    // Set location appropriately for the first property
                    if (i == 0)
                    {
                        label[i].Location = new Point(6, labelInput.Bottom + 10);
                    }
                    else
                    {
                        label[i].Location = new Point(6, label[i-1].Bottom + 15);
                    }

                    // Set Max Label width
                    if (label[i].PreferredWidth > maxLabelWidth)
                        maxLabelWidth = label[i].PreferredWidth;

                    // Create a new textbox or checkbox depending on type

                    if (inParam.Type == CimType.Boolean)
                    {
                        paramControls[i] = new CheckBox
                        {
                            Text = String.Empty,
                            Tag = inParam.Name,
                            Checked = false
                        };
                    }
                    else
                    {
                        if (inParam.Type == CimType.Object || inParam.Type == CimType.Reference)
                        {
                            paramControls[i] = new TextBox
                            {
                                Text = "Object parameter not supported",
                                ReadOnly = true,
                                Tag = inParam.Name
                            };
                        }
                        else
                        {
                            paramControls[i] = new TextBox
                            {
                                Text = String.Empty,
                                Tag = inParam.Name
                            };
                        }
                    }


                    // Add controls to Panel
                    panelInParams.Controls.Add(label[i]);
                    panelInParams.Controls.Add(paramControls[i]);

                    // Resize groupbox to adjust for the new property. Stop resizing after 5 properties.
                    if (i < 5)
                        groupBoxInParams.Height += (label[i].Height * 2);

                    i++;
                }

                // Set textbox location now that we have the max Label width
                for (i = 0; i < _method.InParameters.Properties.Count; i++)
                {
                    if (paramControls[i] is TextBox)
                    {
                        paramControls[i].Location = new Point(maxLabelWidth + 15, label[i].Top - 3);
                        paramControls[i].Width = panelInParams.Width - (maxLabelWidth + 40);
                    }

                    if (paramControls[i] is CheckBox)
                    {
                        paramControls[i].Location = new Point(maxLabelWidth + 15, label[i].Top - 3);
                    }
                }

            }

            // Reposition controls
            groupBoxOutParams.Location = new Point(groupBoxInParams.Left, groupBoxInParams.Bottom + 3);
            panelButtons.Location = new Point(groupBoxOutParams.Left, groupBoxOutParams.Bottom + 3);

            // Resize form
            this.Size = new Size(this.Width, labelCaption.Height + groupBoxInParams.Height + groupBoxOutParams.Height + panelButtons.Height + statusStrip.Height + 50);
            
        }

        private void InitializeUi()
        {
            Label[] label = new Label[10];
            TextBox[] textBox = new TextBox[10];

            // Add Input Parameters
            for (var i = 1; i <= 7; i++)
            {
                if (i == 1)
                {
                    label[i] = new Label
                    {
                        Location = new Point(6, labelInput.Bottom + 10),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Text = "Property Name: "
                    };
                }
                else
                {
                    label[i] = new Label
                    {
                        Location = new Point(6, label[i-1].Bottom + 15),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Text = "Property Name: "
                    };
                }
                

                textBox[i] = new TextBox
                {
                    Location = new Point(label[i].Width + 30, label[i].Top - 3),
                    Width = 200,
                    Text = String.Empty
                };

                panelInParams.Controls.Add(label[i]);
                panelInParams.Controls.Add(textBox[i]);

                groupBoxInParams.Height += (label[i].Height * 2);
                
            }

            // Add Output Parameters

            GroupBox groupBoxOutParamsTest = new GroupBox();
            groupBoxOutParamsTest.Location = new Point(groupBoxInParams.Left, groupBoxInParams.Bottom + 10);
            groupBoxOutParamsTest.Size = new Size(groupBoxInParams.Width, 150);
            groupBoxOutParamsTest.Text = "Output Parameters";

            PropertyGrid outParamsPropertyGrid = new PropertyGrid();
            outParamsPropertyGrid.Dock = DockStyle.Fill;
            outParamsPropertyGrid.HelpVisible = false;
            outParamsPropertyGrid.ToolbarVisible = false;

            groupBoxOutParamsTest.Controls.Add(outParamsPropertyGrid);
            this.Controls.Add(groupBoxOutParamsTest);
            
            // Resize form
            this.Size = new Size(this.Width, groupBoxInParams.Height + groupBoxOutParamsTest.Height + 25);

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            ExecuteMethod();
        }

        private void ExecuteMethod()
        {
            string returnString = String.Empty;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SetStatusBar("Executing method...", MessageCategory.Action);

                ManagementBaseObject inParams = _mObject.GetMethodParameters(_method.Name);

                foreach (Control control in panelInParams.Controls)
                {
                    if (control is TextBox)
                    {
                        inParams[control.Tag.ToString()] = control.Text;
                    }

                    if (control is CheckBox)
                    {
                        inParams[control.Tag.ToString()] = ((CheckBox) control).Checked.ToString();
                    }
                    
                }
                
                ManagementBaseObject outParams = _mObject.InvokeMethod(_method.Name, inParams, null);

                if (outParams != null && outParams.Properties.Count > 0)
                {
                    ManagementBaseObjectW outParamsW = new ManagementBaseObjectW(outParams);
                    propertyGridOutParams.SelectedObject = outParamsW;
                    _clipboardText = outParams.GetText(TextFormat.Mof).Replace("\n", "\r\n");
                    SetStatusBar("Successfully executed method.", MessageCategory.Info);
                }
                else
                {
                    SetStatusBar("Successfully executed method. No output parameters.", MessageCategory.Info);
                }

                returnString = "Successfully executed method " + _method.Name + " of object " + _mObject.Path.RelativePath;

            }
            catch (Exception ex)
            {
                SetStatusBar("Method Execution Failed. Error: " + ex.Message, MessageCategory.Error);
                returnString = "Failed to execute method " + _method.Name + " of object " + _mObject.Path.RelativePath + ". Error: " + ex.Message;
            }
            finally
            {
                WmiExplorer parentForm = (WmiExplorer) this.Owner;
                parentForm.Log(returnString);
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonCopyOutput_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_clipboardText))
                Clipboard.SetText(_clipboardText);
        }

        private void SetStatusBar(string text, MessageCategory messagecategory)
        {
            if (text != String.Empty)
            {
                toolStripLabel.BorderSides = ToolStripStatusLabelBorderSides.All;
                toolStripLabel.BorderStyle = Border3DStyle.SunkenInner;
            }
            else
            {
                toolStripLabel.BorderSides = ToolStripStatusLabelBorderSides.None;
                toolStripLabel.BorderStyle = Border3DStyle.Flat;
            }

            toolStripLabel.Text = text;

            switch (messagecategory)
            {
                case MessageCategory.Info:
                    toolStripLabel.BackColor = Color.LightSteelBlue;
                    break;

                case MessageCategory.Action:
                    toolStripLabel.BackColor = ColorCategory.Action;
                    break;

                case MessageCategory.Warn:
                    toolStripLabel.BackColor = ColorCategory.Warn;
                    break;

                case MessageCategory.Cache:
                    toolStripLabel.BackColor = ColorCategory.Cache;
                    break;

                case MessageCategory.Error:
                    toolStripLabel.BackColor = ColorCategory.Error;
                    break;

                case MessageCategory.Sms:
                    toolStripLabel.BackColor = ColorCategory.Sms;
                    break;

                case MessageCategory.None:
                    toolStripLabel.BackColor = ColorCategory.None;
                    break;

                default:
                    toolStripLabel.BackColor = ColorCategory.Unknown;
                    break;
            }
        }
    }
}
