using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Windows.Forms;
using WmiExplorer.Classes;
using WmiExplorer.Forms;
using WmiExplorer.Properties;

namespace WmiExplorer
{
    public partial class WmiExplorer : Form
    {
        public static readonly CacheItemPolicy CachePolicy = new CacheItemPolicy();
        public static MemoryCache AppCache = new MemoryCache("AppCache");
        public static bool DebugMode = false;
        public static int DisplayDpi;

        public WmiExplorer()
        {
            InitializeComponent();
            Application.AddMessageFilter(new MouseWheelMessageFilter());
        }

        private delegate void LogCallback(string text);

        private delegate void SetStatusBar1Callback(String text, MessageCategory messagecategory, bool bLog = false);

        private delegate void SetStatusBar2Callback(String text, MessageCategory messagecategory, bool bLog = false);

        private delegate void SetStatusBar3Callback(string category, TimeSpan time);

        public void Log(string text)
        {
            if (textBoxLogging.InvokeRequired)
            {
                LogCallback d = Log; //LogCallback d = new LogCallback(Log);
                Invoke(d, new object[] { text });
            }
            else
            {
                textBoxLogging.AppendText(Environment.NewLine + DateTime.Now + " : " + text);
            }
        }

        private void buttonClassesRefresh_Click(object sender, EventArgs e)
        {
            if (treeNamespaces.SelectedNode == null)
                SetStatusBar1("No namespace is selected.", MessageCategory.Warn);
            else
                treeNamespaces_NodeMouseDoubleClick(sender, null);
        }

        private void buttonComputerConnect_Click(object sender, EventArgs e)
        {
            // Set computer name display text to NetBIOS name if using . or localhost or blank name
            if (textBoxComputerName.Text == "." || textBoxComputerName.Text == "localhost" || textBoxComputerName.Text == String.Empty)
                textBoxComputerName.Text = SystemInformation.ComputerName;

            WmiNode rootNode = new WmiNode
            {
                IsRootNode = true,
                UserSpecifiedPath = textBoxComputerName.Text.ToUpperInvariant()
            };

            rootNode.SetConnection(_defaultConnection);

            Connect(rootNode);
        }

        private void buttonHideNamespaces_Click(object sender, EventArgs e)
        {
            if (buttonHideNamespaces.Text == "-")
            {
                buttonHideNamespaces.Text = "+";
                treeNamespaces.Visible = false;
                groupBoxNamespaces.Text = "N";
                _tempSplitterDistance = splitContainerNamespaceClasses.SplitterDistance;
                splitContainerNamespaceClasses.SplitterDistance = 30;
                splitContainerNamespaceClasses.IsSplitterFixed = true;
            }
            else
            {
                buttonHideNamespaces.Text = "-";
                treeNamespaces.Visible = true;
                groupBoxNamespaces.Text = "Namespaces";
                splitContainerNamespaceClasses.SplitterDistance = _tempSplitterDistance;
                splitContainerNamespaceClasses.IsSplitterFixed = false;
            }
        }

        private void buttonHideNamespaces_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonHideNamespaces,
                buttonHideNamespaces.Text == "+" ? "Show Namespaces" : "Hide Namespaces");
        }

        private void buttonInstancesRefresh_Click(object sender, EventArgs e)
        {
            if (listClasses.SelectedItems.Count != 0)
                listClasses_DoubleClick(sender, e);
            else
                SetStatusBar2("No class is selected", MessageCategory.Warn);
        }

        private void buttonQueryExecute1_Click(object sender, EventArgs e)
        {
            tabControlInstances.SelectTab(tabQueryResults);
            textBoxQuery2.Text = textBoxQuery1.Text;
            buttonQueryExecute2.PerformClick();
        }

        private void buttonQueryExecute2_Click(object sender, EventArgs e)
        {
            ExecuteQuery(textBoxQuery2.Text);
        }

        private void buttonRefreshObject_Click(object sender, EventArgs e)
        {
            if (listInstances.SelectedItems.Count == 0)
            {
                SetStatusBar2("No instance is selected. ", MessageCategory.Warn);
                return;
            }

            ListViewItem currentListViewItem = listInstances.SelectedItems[0];
            PopulateInstanceProperties(currentListViewItem, true);
        }

        private void buttonScriptRun_Click(object sender, EventArgs e)
        {
            const string cmd = "cmd.exe";
            string args;
            string tempPath = Environment.GetEnvironmentVariable("TEMP");

            if (radioScriptVbs.Checked)
            {
                string scriptPath = tempPath + "\\temp_script.vbs";
                string outPath = tempPath + "\\temp_script_vbs_out.txt";
                File.WriteAllText(scriptPath, textBoxScript.Text);

                if (radioScriptOutCmd.Checked)
                {
                    args = " /k cscript.exe //E:VBScript //NoLogo " + scriptPath;
                    Utilities.LaunchProgram(cmd, args, false);
                }

                if (radioScriptOutTxt.Checked)
                {
                    args = " /c cscript.exe //E:VBScript //NoLogo " + scriptPath + " > " + outPath;
                    Utilities.LaunchProgram(cmd, args, true);
                    Utilities.LaunchProgram("Notepad.exe", outPath, false);
                }
            }

            if (radioScriptPs.Checked)
            {
                string scriptPath = tempPath + "\\temp_script.ps1";
                string outPath = tempPath + "\\temp_script_ps1_out.txt";
                File.WriteAllText(scriptPath, textBoxScript.Text);

                if (radioScriptOutCmd.Checked)
                {
                    args = " /k powershell.exe -ExecutionPolicy Bypass -NoLogo -NoExit " + scriptPath;
                    Utilities.LaunchProgram(cmd, args, false);
                }

                if (radioScriptOutTxt.Checked)
                {
                    args = " /c powershell.exe -ExecutionPolicy Bypass -NoLogo " + scriptPath + " > " + outPath;
                    Utilities.LaunchProgram(cmd, args, true);
                    Utilities.LaunchProgram("Notepad.exe", outPath, false);
                }
            }
        }

        private void buttonScriptSave_Click(object sender, EventArgs e)
        {
            saveScriptDialog.InitialDirectory = Environment.CurrentDirectory;
            saveScriptDialog.FileName = listClasses.SelectedItems[0].Text;

            if (radioScriptVbs.Checked)
            {
                saveScriptDialog.Filter = "VBScript files (*.vbs)|*.vbs|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveScriptDialog.ShowDialog();
            }
            else if (radioScriptPs.Checked)
            {
                saveScriptDialog.Filter = "Powershell Script files (*.ps1)|*.ps1|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveScriptDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Script Language Selected.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (treeNamespaces.SelectedNode != null)
            {
                string searchPattern = textBoxSearchPattern.Text;
                if (String.IsNullOrEmpty(searchPattern))
                {
                    SetStatusBar2("Error: Search String is Empty.", MessageCategory.Warn);
                    return;
                }

                WmiNode currentWmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;
                if (currentWmiNode == null)
                {
                    SetStatusBar2("Error: Current WmiNode is null.", MessageCategory.Error, true);
                    return;
                }

                if (currentWmiNode.IsRootNode && !currentWmiNode.IsConnected)
                {
                    SetStatusBar2("Please connect to " + currentWmiNode.UserSpecifiedPath + " before searching.", MessageCategory.Warn, true);
                    return;
                }

                // Reset search result counter and error
                _searchResultCount = 0;
                _searchErrorOccurred = false;

                if (radioSearchClasses.Checked)
                    SearchClasses(searchPattern, currentWmiNode);

                if (radioSearchMethods.Checked)
                    SearchMethods(searchPattern, currentWmiNode);

                if (radioSearchProperties.Checked)
                    SearchProperties(searchPattern, currentWmiNode);
            }
            else
            {
                SetStatusBar2("No Namespace selected.", MessageCategory.Warn);
            }
        }

        private void checkBoxEnumOptions_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var checkbox = (CheckBox)sender;
                var currentflag = (EnumOptions)checkbox.Tag;

                if (checkbox.Checked)
                    Settings.Default.EnumOptionsFlags |= currentflag;
                else
                    Settings.Default.EnumOptionsFlags ^= currentflag;

                // Re-populate instance properties if Instance Enumeration options changed.
                if (listInstances.SelectedItems.Count == 0) return;
                PopulateInstanceProperties(listInstances.SelectedItems[0]);
            }
            catch (Exception ex)
            {
                Log("checkBoxEnumOptions_CheckedChanged - Failed to get the enumeration options. Error: " + ex.Message);
            }
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            // Clear current items
            contextMenu.Items.Clear();
            e.Cancel = false;

            // if context menu is being displayed for treeNamespaces Tree View
            if (contextMenu.SourceControl == treeNamespaces)
            {
                if (treeNamespaces.SelectedNode != null)
                {
                    WmiNode currentWmiNode = (WmiNode)treeNamespaces.SelectedNode.Tag;

                    // Disconnected nodes
                    if (Helpers.IsNodeDisconnected(treeNamespaces.SelectedNode))
                    {
                        ToolStripItem defaultItemDisconnected = new ToolStripMenuItem("&Connect", null, contextMenuItemConnectPath_Click);
                        defaultItemDisconnected.Font = new Font(defaultItemDisconnected.Font, defaultItemDisconnected.Font.Style | FontStyle.Bold);
                        contextMenu.Items.Add(defaultItemDisconnected);
                        contextMenu.Items.Add("&Connect As", null, contextMenuItemConnectAsPath_Click);
                        contextMenu.Items.Add("&Remove", null, contextMenuItemRemovePath_Click);
                        return;
                    }

                    // All nodes default item
                    ToolStripItem defaultItem = new ToolStripMenuItem("&Enumerate Classes", null, contextMenuItemGetClasses_Click);
                    defaultItem.Font = new Font(defaultItem.Font, defaultItem.Font.Style | FontStyle.Bold);
                    contextMenu.Items.Add(defaultItem);

                    // Root Nodes
                    if (currentWmiNode.IsRootNode)
                    {
                        contextMenu.Items.Add("Show WMI &Provider Host Information", null, contextMenuItemShowProviderInfo_Click);
                        contextMenu.Items.Add("&Disconnect", null, contextMenuItemDisconnectPath_Click);
                        contextMenu.Items.Add("Disconnect and &Remove", null, contextMenuItemDisconnectRemovePath_Click);
                    }

                    // SMS Provider Node
                    if (Settings.Default.bSmsMode &&
                        currentWmiNode.WmiNamespace.DisplayName.StartsWith("ROOT\\SMS\\SITE_",
                            StringComparison.InvariantCultureIgnoreCase))
                    {
                        var excludeSmsCollections = new ToolStripMenuItem("Exclude SMS &Collection Classes", null, contextMenuItemExcludeSmsCollections_Click);
                        var excludeSmsInventory = new ToolStripMenuItem("Exclude SMS &Inventory Classes", null, contextMenuItemExcludeSmsInventory_Click);
                        excludeSmsCollections.Checked = Settings.Default.EnumOptionsFlags.HasFlag(EnumOptions.ExcludeSmsCollections);
                        excludeSmsInventory.Checked = Settings.Default.EnumOptionsFlags.HasFlag(EnumOptions.ExcludeSmsInventory);
                        contextMenu.Items.Add(excludeSmsCollections);
                        contextMenu.Items.Add(excludeSmsInventory);
                    }

                    // SMS Client Actions
                    if (Settings.Default.bSmsMode && Helpers.GetSmsClient(treeNamespaces.SelectedNode) != null && Helpers.GetSmsClient(treeNamespaces.SelectedNode).IsClientInstalled)
                    {
                        if (currentWmiNode.WmiNamespace.DisplayName.Equals("ROOT\\CCM", StringComparison.InvariantCultureIgnoreCase))
                        {
                            var smsClientActionsToolStripItem = GetClientActionsContextMenuItem();
                            contextMenu.Items.Add(smsClientActionsToolStripItem);
                        }
                    }

                    // Currently Enumerating Nodes
                    if (currentWmiNode.WmiNamespace.IsEnumerating)
                        contextMenu.Items.Add("&Cancel Enumeration", null, contextMenuItemCancelEnumNamespace_Click);

                    // All nodes
                    contextMenu.Items.Add("Copy Path", null, contextMenuItemCopyNamespacePath_Click);
                    contextMenu.Items.Add("Copy Relative Path", null, contextMenuItemCopyNamespaceRelativePath_Click);
                }
            }

            // if context menu is being displayed for listClasses list
            if (contextMenu.SourceControl == listClasses)
            {
                if (listClasses.SelectedItems.Count != 0)
                {
                    WmiClass currentWmiClass = ((WmiClass)listClasses.SelectedItems[0].Tag);
                    // All classes default item
                    ToolStripItem defaultItem = new ToolStripMenuItem("&Enumerate Instances", null, listClasses_DoubleClick);
                    defaultItem.Font = new Font(defaultItem.Font, defaultItem.Font.Style | FontStyle.Bold);
                    contextMenu.Items.Add(defaultItem);

                    // Currently Enumerating Classes
                    if (currentWmiClass.IsEnumerating)
                    {
                        contextMenu.Items.Add("&Cancel Enumeration", null, contextMenuItemCancelEnumClass_Click);
                    }

                    contextMenu.Items.Add("Show MOF", null, contextMenuItemShowClassMof_Click);
                    contextMenu.Items.Add("Show MOF (Amended Qualifiers)", null, contextMenuItemShowClassMofAmended_Click);
                    contextMenu.Items.Add("Copy MOF", null, contextMenuItemCopyClassMof_Click);
                    contextMenu.Items.Add("Copy Path", null, contextMenuItemCopyClassPath_Click);
                    contextMenu.Items.Add("Copy Relative Path", null, contextMenuItemCopyClassRelativePath_Click);

                    var executeMethodsToolStripItem = GetMethodsContextMenuItem(true);
                    if (executeMethodsToolStripItem.HasDropDownItems)
                        contextMenu.Items.Add(executeMethodsToolStripItem);
                }
            }

            // if context menu is being displayed for listInstances list
            if (contextMenu.SourceControl == listInstances)
            {
                if (listInstances.SelectedItems.Count != 0)
                {
                    contextMenu.Items.Add("Show MOF", null, contextMenuItemShowInstanceMof_Click);
                    contextMenu.Items.Add("Copy MOF", null, contextMenuItemCopyInstanceMof_Click);
                    contextMenu.Items.Add("Copy Path", null, contextMenuItemCopyInstancePath_Click);
                    contextMenu.Items.Add("Copy Relative Path", null, contextMenuItemCopyInstanceRelativePath_Click);

                    var executeMethodsToolStripItem = GetMethodsContextMenuItem(false);
                    if (executeMethodsToolStripItem.HasDropDownItems)
                        contextMenu.Items.Add(executeMethodsToolStripItem);
                }
            }

            // if context menu is being displayed for instance property grid
            if (contextMenu.SourceControl == propertyGridInstance && propertyGridInstance.SelectedGridItem != null)
            {
                contextMenu.Items.Add("Copy Name and Value", null, contextMenuItemCopyPropertyNameValue_Click);
                contextMenu.Items.Add("Copy Value", null, contextMenuItemCopyPropertyValue_Click);
                contextMenu.Items.Add("Copy Description", null, contextMenuItemCopyPropertyDescription_Click);
            }
        }

        private void contextMenuItemCancelEnumClass_Click(object sender, EventArgs e)
        {
            if (_bwInstanceEnumWorker == null) return;

            WmiClass currentClass = listClasses.SelectedItems[0].Tag as WmiClass;

            if (currentClass == null)
            {
                SetStatusBar2("Unable to cancel Enumeration: NullReferenceException", MessageCategory.Error, true);
                return;
            }

            if (currentClass.IsEnumerating)
            {
                currentClass.IsEnumerationCancelled = true;
                currentClass.IsEnumerating = false;
                _bwInstanceEnumWorker.CancelAsync();
                SetStatusBar2("Cancelling enumeration for " + currentClass.DisplayName, MessageCategory.Warn, true);
            }
            else
            {
                SetStatusBar1("Cancellation skipped. Enumeration already completed.", MessageCategory.Info);
            }
        }

        private void contextMenuItemCancelEnumNamespace_Click(object sender, EventArgs e)
        {
            if (_bwClassEnumWorker == null) return;

            WmiNode currentWmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;
            if (currentWmiNode == null)
            {
                SetStatusBar1("Unable to cancel enumeration: NullReferenceException", MessageCategory.Error, true);
                return;
            }

            if (currentWmiNode.WmiNamespace.IsEnumerating)
            {
                currentWmiNode.WmiNamespace.IsEnumerationCancelled = true;
                currentWmiNode.WmiNamespace.IsEnumerating = false;
                _bwClassEnumWorker.CancelAsync();
                SetStatusBar1("Cancelling enumeration for " + currentWmiNode.WmiNamespace.DisplayName, MessageCategory.Warn, true);
            }
            else
            {
                SetStatusBar1("Cancellation skipped. Enumeration already completed.", MessageCategory.Info);
            }
        }

        private void contextMenuItemConnectAsPath_Click(object sender, EventArgs e)
        {
            WmiNode namespaceNode = treeNamespaces.SelectedNode.Tag as WmiNode;
            if (namespaceNode != null)
            {
                using (Form_ConnectAs connectAsForm = new Form_ConnectAs(namespaceNode.UserSpecifiedPath))
                {
                    connectAsForm.ShowDialog(this);

                    if (connectAsForm.Cancelled) return;

                    if (connectAsForm.Connection != null)
                    {
                        namespaceNode.SetConnection(connectAsForm.Connection);
                    }
                    else
                    {
                        MessageBox.Show("Failed to set credentials. Using logged on user's credentials.", "Credentials Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        namespaceNode.SetConnection(_defaultConnection);
                    }

                    Connect(namespaceNode);
                }
            }
        }

        private void contextMenuItemConnectPath_Click(object sender, EventArgs e)
        {
            WmiNode namespaceNode = treeNamespaces.SelectedNode.Tag as WmiNode;
            if (namespaceNode != null)
                Connect(namespaceNode);
        }

        private void contextMenuItemCopyClassMof_Click(object sender, EventArgs e)
        {
            string mof = ((WmiClass)listClasses.SelectedItems[0].Tag).GetClassMof();
            if (mof != null)
                Clipboard.SetText(mof);
        }

        private void contextMenuItemCopyClassPath_Click(object sender, EventArgs e)
        {
            var path = ((WmiClass)listClasses.SelectedItems[0].Tag).Path;
            if (path != null)
                Clipboard.SetText(path);
        }

        private void contextMenuItemCopyClassRelativePath_Click(object sender, EventArgs e)
        {
            var relativePath = ((WmiNode)treeNamespaces.SelectedNode.Tag).WmiNamespace.RelativePath;
            if (relativePath != null)
            {
                relativePath += ":" + ((WmiClass)listClasses.SelectedItems[0].Tag).RelativePath;
                Clipboard.SetText(relativePath);
            }
        }

        private void contextMenuItemCopyInstanceMof_Click(object sender, EventArgs e)
        {
            if (_instanceMof != String.Empty)
                Clipboard.SetText(_instanceMof);
        }

        private void contextMenuItemCopyInstancePath_Click(object sender, EventArgs e)
        {
            var path = ((WmiInstance)listInstances.SelectedItems[0].Tag).Path;
            if (path != null)
                Clipboard.SetText(path);
        }

        private void contextMenuItemCopyInstanceRelativePath_Click(object sender, EventArgs e)
        {
            var relativePath = ((WmiNode)treeNamespaces.SelectedNode.Tag).WmiNamespace.RelativePath;
            if (relativePath != null)
            {
                relativePath += ":" + ((WmiInstance)listInstances.SelectedItems[0].Tag).RelativePath;
                Clipboard.SetText(relativePath);
            }
        }

        private void contextMenuItemCopyNamespacePath_Click(object sender, EventArgs e)
        {
            string path = ((WmiNode)treeNamespaces.SelectedNode.Tag).WmiNamespace.Path;
            if (path != null)
                Clipboard.SetText(path);
        }

        private void contextMenuItemCopyNamespaceRelativePath_Click(object sender, EventArgs e)
        {
            var relativePath = ((WmiNode)treeNamespaces.SelectedNode.Tag).WmiNamespace.RelativePath;
            if (relativePath != null)
                Clipboard.SetText(relativePath);
        }

        private void contextMenuItemCopyPropertyDescription_Click(object sender, EventArgs e)
        {
            if (propertyGridInstance.SelectedGridItem.PropertyDescriptor == null)
                return;

            if (propertyGridInstance.SelectedGridItem.PropertyDescriptor.Category == "Misc")
            {
                if (propertyGridInstance.SelectedGridItem.Value is ManagementBaseObjectW)
                    MessageBox.Show("Copy Description Operation on an Array Element is Not Allowed. Expand the Object to Copy Description of Desired Property."
                        , "Not Supported"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                else
                    MessageBox.Show("Copy Description Operation on an Array Element is Not Allowed."
                        , "Not Supported"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
            }
            else
            {
                var txtToCopy = propertyGridInstance.SelectedGridItem.PropertyDescriptor.DisplayName;
                txtToCopy += Environment.NewLine + propertyGridInstance.SelectedGridItem.PropertyDescriptor.Description;
                txtToCopy = txtToCopy.Replace("\n", "\r\n");
                Clipboard.SetText(txtToCopy);
            }
        }

        private void contextMenuItemCopyPropertyNameValue_Click(object sender, EventArgs e)
        {
            var nameValue = String.Empty;

            if (propertyGridInstance.SelectedGridItem.PropertyDescriptor == null)
                return;

            if (propertyGridInstance.SelectedGridItem.Value != null && propertyGridInstance.SelectedGridItem.Value.ToString() != String.Empty)
            {
                if (propertyGridInstance.SelectedGridItem.Value is ManagementBaseObjectW)
                {
                    if (propertyGridInstance.SelectedGridItem.PropertyDescriptor.Category == "Misc")
                        MessageBox.Show("Copy Value Operation on an element of Embedded Object is Not Allowed. Expand the Object to Copy the Value of Desired Property."
                            , "Not Supported"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    else
                    {
                        nameValue = propertyGridInstance.SelectedGridItem.PropertyDescriptor.DisplayName;
                        nameValue += " = ";
                        nameValue += propertyGridInstance.SelectedGridItem.Value.ToString();
                    }
                }
                else
                {
                    nameValue = propertyGridInstance.SelectedGridItem.PropertyDescriptor.DisplayName;
                    nameValue += " = ";
                    nameValue += propertyGridInstance.SelectedGridItem.Value.ToString();
                }
            }
            else
            {
                nameValue = propertyGridInstance.SelectedGridItem.PropertyDescriptor.DisplayName;
                nameValue += " = null";
            }

            if (nameValue != String.Empty)
                Clipboard.SetText(nameValue);
        }

        private void contextMenuItemCopyPropertyValue_Click(object sender, EventArgs e)
        {
            if (propertyGridInstance.SelectedGridItem.PropertyDescriptor == null)
                return;

            if (propertyGridInstance.SelectedGridItem.Value != null && propertyGridInstance.SelectedGridItem.Value.ToString() != String.Empty)
            {
                if (propertyGridInstance.SelectedGridItem.Value is ManagementBaseObjectW)
                {
                    if (propertyGridInstance.SelectedGridItem.PropertyDescriptor.Category == "Misc")
                        MessageBox.Show("Copy Value Operation on an element of Embedded Object is Not Allowed. Expand the Object to Copy the Value of Desired Property."
                            , "Not Supported"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    else
                        Clipboard.SetText(propertyGridInstance.SelectedGridItem.Value.ToString());
                }
                else
                    Clipboard.SetText(propertyGridInstance.SelectedGridItem.Value.ToString());
            }
        }

        private void contextMenuItemDisconnectPath_Click(object sender, EventArgs e)
        {
            var nodeToDisconnect = ((WmiNode)treeNamespaces.SelectedNode.Tag).UserSpecifiedPath;

            // Clear all UI elements
            ResetListClasses();
            ResetListInstances();
            ResetListMethods();
            ResetListClassProperties();
            ResetListQueryResults();
            RenameNamespaceTabsToDefault();
            RenameClassTabsToDefault();
            dataGridQueryResults.DataSource = null;
            propertyGridInstance.SelectedObject = null;
            propertyGridQueryResults.SelectedObject = null;
            textBoxQuery1.Text = String.Empty;
            textBoxQuery2.Text = String.Empty;
            textBoxClassQuickFilter.Text = String.Empty;
            textBoxInstanceFilterQuick.Text = String.Empty;

            ((WmiNode)treeNamespaces.SelectedNode.Tag).IsConnected = false;
            ((WmiNode)treeNamespaces.SelectedNode.Tag).IsExpanded = false;

            treeNamespaces.SelectedNode.Text = nodeToDisconnect + " (Disconnected)";
            treeNamespaces.SelectedNode.Nodes.Clear();

            foreach (var element in AppCache)
            {
                if (element.Key.Contains(((WmiNode)treeNamespaces.SelectedNode.Tag).WmiNamespace.Path))
                {
                    AppCache.Remove(element.Key);
                }
            }

            SetStatusBar1(nodeToDisconnect + " Disconnected", MessageCategory.Info, true);
            SetStatusBar2(String.Empty, MessageCategory.None);
        }

        private void contextMenuItemDisconnectRemovePath_Click(object sender, EventArgs e)
        {
            contextMenuItemDisconnectPath_Click(sender, e);
            contextMenuItemRemovePath_Click(sender, e);
        }

        private void contextMenuItemExcludeSmsCollections_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;

            if (t.Checked)
            {
                Settings.Default.EnumOptionsFlags ^= EnumOptions.ExcludeSmsCollections;
                t.Checked = false;
            }
            else
            {
                Settings.Default.EnumOptionsFlags |= EnumOptions.ExcludeSmsCollections;
                t.Checked = true;
            }

            Settings.Default.Save();
        }

        private void contextMenuItemExcludeSmsInventory_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;

            if (t.Checked)
            {
                Settings.Default.EnumOptionsFlags ^= EnumOptions.ExcludeSmsInventory;
                t.Checked = false;
            }
            else
            {
                Settings.Default.EnumOptionsFlags |= EnumOptions.ExcludeSmsInventory;
                t.Checked = true;
            }

            Settings.Default.Save();
        }

        private void contextMenuItemGetClasses_Click(object sender, EventArgs e)
        {
            ResetListInstances();
            ResetListClassProperties();
            ResetListMethods();
            RenameClassTabsToDefault();

            EnumerateClasses();
        }

        private void contextMenuItemRemovePath_Click(object sender, EventArgs e)
        {
            string nodeToRemove = ((WmiNode)treeNamespaces.SelectedNode.Tag).UserSpecifiedPath;
            if (Settings.Default.RecentPaths.Contains(nodeToRemove))
            {
                Settings.Default.RecentPaths.Remove(nodeToRemove);
                Settings.Default.Save();
            }
            Log(nodeToRemove + " Removed");
            treeNamespaces.SelectedNode.Remove();
        }

        private void contextMenuItemShowClassMof_Click(object sender, EventArgs e)
        {
            var mof = ((WmiClass)listClasses.SelectedItems[0].Tag).GetClassMof();
            Form_ShowMof mofForm = new Form_ShowMof(mof);
            mofForm.CenterForm(this).Show(this);
        }

        private void contextMenuItemShowClassMofAmended_Click(object sender, EventArgs e)
        {
            var mof = ((WmiClass)listClasses.SelectedItems[0].Tag).GetClassMof(true);
            Form_ShowMof mofForm = new Form_ShowMof(mof);
            mofForm.CenterForm(this).Show(this);
        }

        private void contextMenuItemShowInstanceMof_Click(object sender, EventArgs e)
        {
            Form_ShowMof mofForm = new Form_ShowMof(_instanceMof);
            mofForm.CenterForm(this).Show(this);
        }

        private void contextMenuItemShowProviderInfo_Click(object sender, EventArgs e)
        {
            const string msftProvidersQuery = "SELECT * FROM MSFT_Providers";

            StringBuilder output = new StringBuilder();
            var caption = "WMI Provider Process Information";

            try
            {
                WmiNode rootWmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;

                if (rootWmiNode == null)
                {
                    SetStatusBar1("Unable to get WMI Provider Process information: NullReferenceException", MessageCategory.Error, true);
                    SetStatusBar2(String.Empty, MessageCategory.None);
                    return;
                }

                Cursor = Cursors.WaitCursor;

                if (rootWmiNode.WmiNamespace.ServerName.Equals(".", StringComparison.InvariantCultureIgnoreCase))
                    caption += " for localhost";
                else
                    caption += " for " + rootWmiNode.WmiNamespace.ServerName;

                output.AppendLine(String.Empty);

                ManagementScope mScope = new ManagementScope("\\\\" + rootWmiNode.WmiNamespace.ServerName + "\\ROOT\\CIMV2", Helpers.GetRootNodeCredentials(treeNamespaces.SelectedNode));
                ObjectQuery query = new ObjectQuery(msftProvidersQuery);
                ManagementObjectSearcher queryResults = new ManagementObjectSearcher(mScope, query);
                queryResults.Options.EnumerateDeep = false;

                foreach (var instance in (from ManagementBaseObject i in queryResults.Get()
                                          orderby i.GetPropertyValue("HostProcessIdentifier")
                                          select i))
                {
                    output.AppendLine("Process ID " + instance.GetPropertyValue("HostProcessIdentifier"));
                    output.AppendLine("    - Used by Provider " + instance.GetPropertyValue("provider"));
                    output.AppendLine("    - Associated with Namespace " + instance.GetPropertyValue("namespace"));

                    var user = instance.GetPropertyValue("user").ToString();
                    if (!String.IsNullOrEmpty(user))
                        output.AppendLine("    - By User " + user);

                    var hostingGroup = instance.GetPropertyValue("hostinggroup").ToString();
                    if (!String.IsNullOrEmpty(hostingGroup))
                        output.AppendLine("    - Under Hosting Group " + hostingGroup);

                    output.AppendLine(String.Empty);
                }
            }
            catch (Exception ex)
            {
                output.AppendLine("Error getting WMI Provider details. " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            using (Form_DisplayText displayForm = new Form_DisplayText("WMI Providers", caption, output.ToString()))
            {
                displayForm.ShowDialog(this);
            }
        }

        private void listClasses_DoubleClick(object sender, EventArgs e)
        {
            EnumerateInstances();
        }

        private void listClasses_MouseClick(object sender, MouseEventArgs e)
        {
            // Display context menu on Right Click
            if (e.Button == MouseButtons.Right)
            {
                ListView listView = sender as ListView;

                // ReSharper disable PossibleNullReferenceException
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                // ReSharper restore PossibleNullReferenceException

                if (item != null)
                {
                    item.Selected = true;
                    contextMenu.Show(listView, e.Location);
                }
            }

            // Generate script if Scripts tab is selected
            if (tabControlInstances.SelectedTab == tabScript)
            {
                GenerateVbScript();
                GeneratePsScript();
            }

            // Create class query
            WmiClass currentWmiClass = listClasses.SelectedItems[0].Tag as WmiClass;
            if (currentWmiClass != null)
                textBoxQuery1.Text = CreateQueryForSelectedClass(currentWmiClass);
        }

        private void listClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SelectedIndexChanged occurs twice, so bail out if nothing is selected
            if (listClasses.SelectedItems.Count == 0)
            {
                // Clear UI
                ResetListInstances();
                propertyGridInstance.SelectedObject = null;
                RenameClassTabsToDefault();
                ResetListMethods();
                ResetListClassProperties();
                buttonScriptRun.Enabled = false;
                buttonScriptSave.Enabled = false;
                textBoxScript.Text = String.Empty;
                return;
            }

            ListViewItem currentItem = listClasses.SelectedItems[0];
            if (currentItem == null) return;

            WmiClass currentWmiClass = currentItem.Tag as WmiClass;
            if (currentWmiClass == null)
            {
                SetStatusBar2("Unexpected error. Currently selected class has a null value.", MessageCategory.Error, true);
                return;
            }

            // Check if current class is already being enumerated
            if (currentWmiClass.IsEnumerating)
            {
                SetStatusBar2("Enumerating Instances from " + currentWmiClass.DisplayName + "...", MessageCategory.Action);
                ResetListInstances();
                return;
            }

            // Set Instance Filter
            textBoxInstanceFilterQuick.Text = currentWmiClass.InstanceFilterQuick;

            // Enable script buttons
            buttonScriptRun.Enabled = true;
            buttonScriptSave.Enabled = true;

            PopulateClassProperties(currentWmiClass);
            PopulateMethods(currentWmiClass);
            EnumerateInstancesFromCache(currentWmiClass);

            // Display properties if DebugMode
            if (DebugMode)
                propertyGridDebugWmiClass.SelectedObject = listClasses.SelectedItems[0].Tag;
        }

        private void listInstances_MouseClick(object sender, MouseEventArgs e)
        {
            // Display context menu on Right Click
            if (e.Button == MouseButtons.Right)
            {
                ListView listView = sender as ListView;

                // ReSharper disable PossibleNullReferenceException
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                // ReSharper restore PossibleNullReferenceException

                if (item != null)
                {
                    item.Selected = true;
                    contextMenu.Show(listView, e.Location);
                }
            }

            // Create query for selected instance
            WmiInstance currentWmiInstance = listInstances.SelectedItems[0].Tag as WmiInstance;
            if (currentWmiInstance != null)
                textBoxQuery1.Text = CreateQueryForSelectedInstance(listInstances.SelectedItems[0].Tag as WmiInstance);
        }

        private void listInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SelectedIndexChange doccurs twice, so bail out if nothing is selected
            if (listInstances.SelectedItems.Count == 0)
            {
                propertyGridInstance.SelectedObject = null;
                return;
            }

            // Display properties if DebugMode
            if (DebugMode)
                propertyGridDebugWmiInstance.SelectedObject = listInstances.SelectedItems[0].Tag;

            // Display instance properties
            PopulateInstanceProperties(listInstances.SelectedItems[0]);
        }

        private void listMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMethods.SelectedItems.Count == 0)
            {
                ResetListMethodParams();
                return;
            }

            PopulateMethodHelp(listMethods.SelectedItems[0].Tag as MethodData);
        }

        private void listProps_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lvSender = (ListView)sender;
            RichTextBox rtb;
            string textToSearch;
            _richTextSelectionResetRequired = true;

            if (lvSender.SelectedItems.Count == 0)
            {
                if (lvSender == listClassProperties)
                    richTextBoxClassDetails.SelectionBackColor = SystemColors.Control;
                else
                    richTextBoxMethodDetails.SelectionBackColor = SystemColors.Control;
                return;
            }

            if (lvSender == listClassProperties)
            {
                rtb = richTextBoxClassDetails;
                textToSearch = listClassProperties.SelectedItems[0].Text + " - " + listClassProperties.SelectedItems[0].SubItems[1].Text;
            }
            else if (lvSender == listMethodParamsIn)
            {
                rtb = richTextBoxMethodDetails;
                textToSearch = listMethodParamsIn.SelectedItems[0].SubItems[1].Text + " - " + listMethodParamsIn.SelectedItems[0].SubItems[2].Text;
            }
            else if (lvSender == listMethodParamsOut)
            {
                rtb = richTextBoxMethodDetails;
                textToSearch = listMethodParamsOut.SelectedItems[0].Text + " - " + listMethodParamsOut.SelectedItems[0].SubItems[1].Text;
            }
            else
                return;

            // Reset start index and highlighting
            int startindex = 0;
            rtb.SelectionBackColor = SystemColors.Control;

            if (textToSearch.Length > 0)
                startindex = Utilities.FindTextInRichTextBox(textToSearch.Trim(), 0, 0, rtb);

            // If string was found in the RichTextBox, highlight it
            if (startindex >= 0)
            {
                // Set the highlight color as yellow
                rtb.SelectionBackColor = Color.Yellow;

                // Find the end index. End Index = number of characters in textbox
                int endindex = textToSearch.Length;

                // Highlight the search string
                rtb.Select(startindex, endindex);
                rtb.ScrollToCaret();
            }
        }

        private void listQueryResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listQueryResults.SelectedItems.Count == 0)
            {
                propertyGridQueryResults.SelectedObject = null;
                return;
            }

            ManagementObject mObject = listQueryResults.SelectedItems[0].Tag as ManagementObject;

            ManagementBaseObjectW mObjectW = new ManagementBaseObjectW(mObject)
            {
                IncludeNullProperties = checkNullProps.Checked,
                IncludeSystemProperties = checkSystemProps.Checked
            };

            propertyGridQueryResults.SelectedObject = mObjectW;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lvSender = (ListView)sender;
            ListViewColumnSorter lvColumnSorter;

            if (lvSender == listMethods)
                lvColumnSorter = _listMethodsColumnSorter;
            else if (lvSender == listClassProperties)
                lvColumnSorter = _listClassPropertiesColumnSorter;
            else if (lvSender == listClasses)
                lvColumnSorter = _listClassesColumnSorter;
            else if (lvSender == listSearchResults)
                lvColumnSorter = _listSearchResultsColumnSorter;
            else
                return;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                lvColumnSorter.Order = lvColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvColumnSorter.SortColumn = e.Column;
                lvColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvSender.Sort();
            lvSender.SetSortIcon(lvColumnSorter.SortColumn, lvColumnSorter.Order);
        }

        private void menuItemFile_ConnectAs_Click(object sender, EventArgs e)
        {
            using (Form_ConnectAs connectAsForm = new Form_ConnectAs())
            {
                connectAsForm.ShowDialog(this);

                if (connectAsForm.Cancelled) return;

                WmiNode rootNode = new WmiNode
                {
                    IsRootNode = true,
                    UserSpecifiedPath = connectAsForm.Path
                };

                if (connectAsForm.Connection != null)
                {
                    rootNode.SetConnection(connectAsForm.Connection);
                }
                else
                {
                    MessageBox.Show("Failed to set credentials. Using logged on user's credentials.", "Credentials Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rootNode.SetConnection(_defaultConnection);
                }

                Connect(rootNode);
            }
        }

        private void menuItemFile_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemFile_Preferences_Click(object sender, EventArgs e)
        {
            using (Form_Settings settingsForm = new Form_Settings())
            {
                settingsForm.ShowDialog(this);
            }
        }

        private void menuItemFile_SmsMode_CheckedChanged(object sender, EventArgs e)
        {
            // Save current setting
            Settings.Default.bSmsMode = menuItemFile_SmsMode.Checked;
            Settings.Default.Save();

            // return if nothing is selected
            if (treeNamespaces.SelectedNode == null)
                return;

            // Connect to Sms Client
            TreeNode rootNode = treeNamespaces.SelectedNode.GetRootNode();
            WmiNode rootWmiNode = rootNode.Tag as WmiNode;

            if (rootWmiNode != null && rootWmiNode.SmsClient != null && rootWmiNode.SmsClient.IsClientInstalled && Settings.Default.bSmsMode)
            {
                ConnectToSmsClient(rootWmiNode.SmsClient);
            }
        }

        private void menuItemHelp_About_Click(object sender, EventArgs e)
        {
            using (Form_About aboutForm = new Form_About())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void menuItemHelp_CheckUpdate_Click(object sender, EventArgs e)
        {
            UpdateCheckAsync(true);
        }

        private void menuItemHelp_Documentation_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/vinaypamnani/wmie2/wiki");
        }

        private void menuItemLaunch_DcomCnfg_Click(object sender, EventArgs e)
        {
            Utilities.LaunchProgram("dcomcnfg.exe");
        }

        private void menuItemLaunch_WbemTest_Click(object sender, EventArgs e)
        {
            Utilities.LaunchProgram("wbemtest.exe");
        }

        private void menuItemLaunch_WmiMgmt_Click(object sender, EventArgs e)
        {
            Utilities.LaunchProgram("wmimgmt.msc");
        }

        private void radioQueryOutDataGrid_CheckedChanged(object sender, EventArgs e)
        {
            dataGridQueryResults.Visible = radioQueryOutDataGrid.Checked;
        }

        private void radioQueryOutListView_CheckedChanged(object sender, EventArgs e)
        {
            splitContainerQueryResults.Visible = radioQueryOutListView.Checked;
        }

        private void radioScriptPs_CheckedChanged(object sender, EventArgs e)
        {
            GeneratePsScript();
        }

        private void radioScriptVbs_CheckedChanged(object sender, EventArgs e)
        {
            GenerateVbScript();
        }

        private void richTextBox_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;

            if (_richTextSelectionResetRequired)
            {
                int firstVisibleChar = rtb.GetCharIndexFromPosition(new Point(0, 0));
                rtb.SelectAll();
                rtb.SelectionBackColor = SystemColors.Control;
                rtb.DeselectAll();
                rtb.SelectionStart = firstVisibleChar;
                rtb.ScrollToCaret();
                _richTextSelectionResetRequired = false;
            }
        }

        private void richTextBoxClassDetails_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void richTextBoxMethodDetails_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void saveScriptDialog_FileOk(object sender, CancelEventArgs e)
        {
            string scriptPath = saveScriptDialog.FileName;
            try
            {
                File.WriteAllText(scriptPath, textBoxScript.Text);
            }
            catch (Exception ex)
            {
                SetStatusBar2("Error saving script to " + scriptPath + ": " + ex.Message, MessageCategory.Error, true);
            }
        }

        private void SetStatusBar(ToolStripStatusLabel toolStripLabel, String text, MessageCategory messagecategory, bool bLog = false)
        {
            if (text != "")
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
                    toolStripLabel.BackColor = ColorCategory.Info;
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

            if (bLog)
                Log(text);
        }

        private void SetStatusBar1(String text, MessageCategory messagecategory, bool bLog = false)
        {
            if (statusStrip.InvokeRequired)
            {
                SetStatusBar1Callback d = SetStatusBar1; //SetStatusBar1Callback d = new SetStatusBar1Callback(SetStatusBar1);
                Invoke(d, new object[] { text, messagecategory, bLog });
            }
            else
            {
                SetStatusBar(toolStripLabel1, text, messagecategory, bLog);
            }
        }

        private void SetStatusBar2(String text, MessageCategory messagecategory, bool bLog = false)
        {
            if (statusStrip.InvokeRequired)
            {
                SetStatusBar2Callback d = SetStatusBar2; //SetStatusBar2Callback d = new SetStatusBar2Callback(SetStatusBar2);
                Invoke(d, new object[] { text, messagecategory, bLog });
            }
            else
            {
                SetStatusBar(toolStripLabel2, text, messagecategory, bLog);
            }
        }

        private void SetStatusBar3(string operation, TimeSpan time)
        {
            if (statusStrip.InvokeRequired)
            {
                SetStatusBar3Callback d = SetStatusBar3; //SetStatusBar3Callback d = new SetStatusBar3Callback(SetStatusBar3);
                Invoke(d, new object[] { operation, time });
            }
            else
            {
                toolStripLabel3.Text = "Time to " + operation + ": " + time.ToString(@"mm\:ss\.fff");
            }
        }

        private void splitContainerNamespaceClasses_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (buttonHideNamespaces.Text == "+")
            {
                splitContainerNamespaceClasses.SplitterDistance = 30;
            }
        }

        private void tabControlInstances_Selected(object sender, TabControlEventArgs e)
        {
            // Scroll to the last line when Logging tab is selected
            if (tabControlInstances.SelectedTab == tabLogging)
            {
                // ReSharper disable InconsistentNaming
                const int WM_VSCROLL = 0x115;
                const int SB_BOTTOM = 7;
                // ReSharper restore InconsistentNaming

                NativeMethods.SendMessage(textBoxLogging.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
            }
        }

        private void textBoxClassFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonClassesRefresh.PerformClick();
        }

        private void textBoxClassQuickFilter_TextChanged(object sender, EventArgs e)
        {
            // Do nothing and return if no node is selected
            if (treeNamespaces.SelectedNode == null) return;

            TreeNode currentNode = treeNamespaces.SelectedNode;
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;
            if (currentWmiNode == null || currentWmiNode.WmiNamespace == null)
            {
                SetStatusBar1("Failed to filter results. ERROR: TextChanged - Current Namespace is null", MessageCategory.Error, true);
                return;
            }

            // Do nothing and return if current namespace is not enumerated
            WmiNamespace currentNamespace = currentWmiNode.WmiNamespace;
            if (!currentNamespace.IsEnumerated) return;

            // Parse filter text
            string filterText = textBoxClassQuickFilter.Text.ToLower();
            bool notFilter = false;
            if (filterText.StartsWith("!") && filterText.Length > 1)
            {
                filterText = filterText.Substring(1);
                notFilter = true;
            }

            // Don't do anything if filter Text is not atleast 3 characters
            if (filterText.Length > 0 && filterText.Length < 3) return;

            // Clear UI Elements
            ResetListInstances();
            ResetListClassProperties();
            ResetListMethods();
            RenameClassTabsToDefault();
            propertyGridInstance.SelectedObject = null;

            var cachedItem = AppCache[currentNamespace.Path];
            if (cachedItem != null)
            {
                List<ListViewItem> lc = cachedItem as List<ListViewItem>;
                PopulateListClasses(lc, filterText, notFilter);
                SetStatusBar1("Showing " + listClasses.Items.Count + "/" + currentNamespace.ClassCount + " matching cached classes from " + currentNamespace.DisplayName, MessageCategory.Cache);
            }
            else
            {
                SetStatusBar1("Cache Expired for " + currentNamespace.DisplayName, MessageCategory.Warn, true);
                SetStatusBar2("Double click namespace to refresh classes.", MessageCategory.Warn);
            }
        }

        private void textBoxComputerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonComputerConnect.PerformClick();
        }

        private void textBoxInstanceFilterQuick_TextChanged(object sender, EventArgs e)
        {
            // Do nothing and return if no Class is selected.
            if (listClasses.SelectedItems.Count == 0) return;

            WmiClass currentWmiClass = listClasses.SelectedItems[0].Tag as WmiClass;
            if (currentWmiClass == null)
            {
                SetStatusBar2("Failed to filter results. ERROR: TextChanged - Current Class is null", MessageCategory.Error, true);
                return;
            }

            // Do nothing and return if selected class is not enumerated
            if (!currentWmiClass.IsEnumerated) return;

            // Save filter text
            string filterText = textBoxInstanceFilterQuick.Text.ToLower();
            currentWmiClass.InstanceFilterQuick = filterText;

            // Parse filter text
            bool notFilter = false;
            if (filterText.StartsWith("!") && filterText.Length > 1)
            {
                filterText = filterText.Substring(1);
                notFilter = true;
            }

            // Don't do anything if filter Text is not atleast 3 characters
            if (filterText.Length > 0 && filterText.Length < 3) return;

            // Clear UI Elements
            propertyGridInstance.SelectedObject = null;

            var cachedItem = AppCache[currentWmiClass.Path];
            if (cachedItem != null)
            {
                List<ListViewItem> lc = cachedItem as List<ListViewItem>;
                PopulateListInstances(lc, filterText, notFilter);
                SetStatusBar2("Showing " + listInstances.Items.Count + "/" + currentWmiClass.InstanceCount + " mathing instances from " + currentWmiClass.DisplayName, MessageCategory.Cache);
            }
            else
            {
                SetStatusBar2("Failed to filter results. Cache Expired for " + currentWmiClass.DisplayName, MessageCategory.Warn, true);
            }
        }

        private void textBoxSearchPattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }

        private void toolStripLabelUpdateNotification_Click(object sender, EventArgs e)
        {
            var changeLog = File.Exists(_changeLogPath) ? File.ReadAllText(_changeLogPath) : "Change Log Not Available";
            bool bUpdateAvailable = (bool)toolStripLabelUpdateNotification.Tag;

            if (bUpdateAvailable)
            {
                using (Form_Update updateForm = new Form_Update(bUpdateAvailable, changeLog))
                {
                    updateForm.ShowDialog(this);
                }
                //string caption = "A new version of WMI Explorer is available!";
                //string updateUrl = "To download the latest version, visit the link below:\n" + Settings.Default.UpdateUrl;
                //changeLog = updateUrl + "\n\n" + changeLog;
                //using (Form_DisplayText displayForm = new Form_DisplayText("WMI Explorer Update", caption, changeLog))
                //{
                //    displayForm.ShowDialog(this);
                //}
            }
            else
            {
                MessageBox.Show(
                    "You are running version " + Assembly.GetExecutingAssembly().GetName().Version + "\n\n" +
                    "This is the latest version!",
                    "WMI Explorer Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }

            // Log(File.Exists(_changeLogPath) ? File.ReadAllText(_changeLogPath) : "Change Log not available");
            //Process.Start(Settings.Default.UpdateUrl);
        }

        private void treeNamespaces_AfterSelect(object sender, TreeViewEventArgs e)
        {
            WmiNode selectedWmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;
            if (selectedWmiNode == null)
            {
                const string message = "Unexpected Error. treeNamespaces_AfterSelect - Current WMI Node is null.";
                NotifyNodeError(treeNamespaces.SelectedNode, message);
                return;
            }

            // Check if we've selected a DISCONNECTED node
            if (Helpers.IsNodeDisconnected(treeNamespaces.SelectedNode))
            {
                SetStatusBar1(selectedWmiNode.UserSpecifiedPath + " is not connected. Right click to connect.", MessageCategory.Info);
                textBoxClassQuickFilter.Text = String.Empty;
                textBoxClassFilter.Text = String.Empty;
                return;
            }

            ResetListClasses();
            ResetListInstances();
            ResetListClassProperties();
            ResetListMethods();
            RenameNamespaceTabsToDefault();
            propertyGridInstance.SelectedObject = null;

            WmiNamespace selectedNamespace = selectedWmiNode.WmiNamespace;

            // Populate child namespaces, after clicking on a namespace
            EnumerateChildNamespaces(treeNamespaces.SelectedNode);

            // Enumerate classes from cache, if they exist in cache
            EnumerateClassesFromCache(selectedNamespace);

            // Set quick filter text back so that items are filtered again
            textBoxClassQuickFilter.Text = selectedNamespace.ClassFilterQuick;
            textBoxClassFilter.Text = selectedNamespace.ClassFilter;

            // Check if current namespace is already being enumerated
            if (selectedNamespace.IsEnumerating)
            {
                SetStatusBar1("Enumerating Classes from " + selectedNamespace.DisplayName + "...", MessageCategory.Action);
                SetStatusBar2("", MessageCategory.None);
            }

            if (DebugMode)
            {
                propertyGridDebugWmiNode.SelectedObject = selectedWmiNode;
                propertyGridDebugWmiNamespace.SelectedObject = selectedNamespace;
            }
        }

        private void treeNamespaces_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If selected node is null, do nothing and return
            if (treeNamespaces.SelectedNode == null) return;

            // Save filter text before moving away from the namespace
            WmiNode selectedWmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;
            if (selectedWmiNode != null && selectedWmiNode.WmiNamespace != null)
            {
                selectedWmiNode.WmiNamespace.ClassFilterQuick = textBoxClassQuickFilter.Text;
                selectedWmiNode.WmiNamespace.ClassFilter = textBoxClassFilter.Text;
            }
        }

        private void treeNamespaces_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeNamespaces.SelectedNode = e.Node;
                contextMenu.Show(treeNamespaces, e.Location);
            }
        }

        private void treeNamespaces_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Check if we've double clicked a DISCONNECTED node
            if (Helpers.IsNodeDisconnected(treeNamespaces.SelectedNode))
            {
                WmiNode wmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;
                if (wmiNode != null)
                    Connect(wmiNode);

                return;
            }

            ResetListInstances();
            ResetListClassProperties();
            ResetListMethods();
            RenameClassTabsToDefault();

            EnumerateClasses();
        }

        private void WmiExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show namespaces again so that splitter distance is saved properly
            if (buttonHideNamespaces.Text == "+")
                buttonHideNamespaces.PerformClick();

            // Save Window Placement
            if (Settings.Default.bPreserveLayout)
            {
                Settings.Default.WindowPlacement = WindowPlacement.GetPlacement(Handle);
                Settings.Default.SplitterDistanceNamespaces = splitContainerNamespaceClasses.SplitterDistance;
                Settings.Default.SplitterDistanceClasses = splitContainerClassesInstances.SplitterDistance;
                Settings.Default.SplitterDistanceInstances = splitContainerInstancesProperties.SplitterDistance;
            }

            // Save Settings
            Settings.Default.Save();
        }

        private void WmiExplorer_KeyDown(object sender, KeyEventArgs e)
        {
            // Log Settings on Ctrl+Shift+S
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
                LogSettings();

            // Enable/Disable Debug Mode on Ctrl+Shift+D
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                if (DebugMode)
                {
                    DebugMode = false;
                    tabControlClasses.Controls.Remove(tabDebug1);
                    tabControlInstances.Controls.Remove(tabDebug2);
                }
                else
                {
                    DebugMode = true;
                    tabControlClasses.Controls.Add(tabDebug1);
                    tabControlInstances.Controls.Add(tabDebug2);
                }
            }
        }

        private void WmiExplorer_Load(object sender, EventArgs e)
        {
            InitializeForm();
            ProcessCommandLineArgs();
        }
    }
}