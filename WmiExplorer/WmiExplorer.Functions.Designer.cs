using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.Caching;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WmiExplorer.Classes;
using WmiExplorer.Forms;
using WmiExplorer.Properties;
using WmiExplorer.Sms;
using WmiExplorer.Updater;

namespace WmiExplorer
{
    partial class WmiExplorer
    {
        private static int _tempSplitterDistance;
        private BackgroundWorker _bwClassEnumWorker;
        private BackgroundWorker _bwInstanceEnumWorker;
        private string _changeLogPath;
        private ConnectionOptions _defaultConnection;
        private string _instanceMof = String.Empty;
        private ListViewColumnSorter _listClassesColumnSorter;
        private ListViewColumnSorter _listClassPropertiesColumnSorter;
        private ListViewColumnSorter _listMethodsColumnSorter;
        private ListViewColumnSorter _listSearchResultsColumnSorter;
        private bool _richTextSelectionResetRequired;
        private bool _searchErrorOccurred;
        private int _searchResultCount;

        private void AppendClassHelp(string helpText, FontStyle fontStyle = FontStyle.Regular, bool newLine = true, bool tabbed = true)
        {
            Font font;

            switch (fontStyle)
            {
                case FontStyle.Bold:
                    font = new Font("Arial", 10, fontStyle);
                    break;

                case FontStyle.Italic:
                    font = new Font("Arial", 9, fontStyle);
                    break;

                default:
                    font = new Font("Arial", 8, fontStyle);
                    break;
            }

            if (tabbed && fontStyle == FontStyle.Regular)
                helpText = "        " + helpText.Replace("\n", "\n       ");

            richTextBoxClassDetails.SelectionFont = font;
            richTextBoxClassDetails.SelectedText = newLine ? helpText + "\n" : helpText;
        }

        private void AppendMethodHelp(string helpText, FontStyle fontStyle = FontStyle.Regular, bool newLine = true, bool tabbed = true)
        {
            Font font;

            switch (fontStyle)
            {
                case FontStyle.Bold:
                    font = new Font("Arial", 10, fontStyle);
                    break;

                case FontStyle.Italic:
                    font = new Font("Arial", 9, fontStyle);
                    break;

                default:
                    font = new Font("Arial", 8, fontStyle);
                    break;
            }

            if (tabbed && fontStyle == FontStyle.Regular)
                helpText = "        " + helpText.Replace("\n", "\n       ");

            richTextBoxMethodDetails.SelectionFont = font;
            richTextBoxMethodDetails.SelectedText = newLine ? helpText + "\n" : helpText;
        }

        private void Connect(WmiNode nodeToConnect)
        {
            var pathToConnect = nodeToConnect.UserSpecifiedPath;
            var userDisplayName = String.Empty;
            try
            {
                string namespacePath;
                var bNodeDisconnected = false;

                // Expand namespaces if hidden
                if (buttonHideNamespaces.Text == "+")
                    buttonHideNamespaces.PerformClick();

                // Parse the path
                if (pathToConnect.Contains("\\"))
                    namespacePath = pathToConnect;
                else
                    namespacePath = "\\\\" + pathToConnect + "\\root";

                if (nodeToConnect.Connection.Username == null)
                    userDisplayName = SystemInformation.UserDomainName + "\\" + SystemInformation.UserName;
                else
                    userDisplayName = nodeToConnect.Connection.Username;

                // Connect to Management Scope for root namespace
                ManagementPath mPath = new ManagementPath(namespacePath);
                ManagementScope mScope = new ManagementScope(mPath, nodeToConnect.Connection);
                mScope.Connect();

                // Get the Management Object for root namespace, and set the WmiNamespace object for the node
                ObjectGetOptions oOptions = new ObjectGetOptions();
                ManagementObject mObject = new ManagementObject(mScope, mPath, oOptions);
                nodeToConnect.WmiNamespace = new WmiNamespace(mObject);

                // Check if the node is already populated as Connected/Disconnected.
                foreach (var treeNode in (from TreeNode treeNode in treeNamespaces.Nodes
                                          where treeNode.Level == 0
                                          select treeNode))
                {
                    WmiNode currentWmiNode = treeNode.Tag as WmiNode;

                    // Check if the path is already connected and select the node
                    if (currentWmiNode != null && currentWmiNode.IsConnected && currentWmiNode.WmiNamespace != null)
                    {
                        if (currentWmiNode.WmiNamespace.Path == nodeToConnect.WmiNamespace.Path)
                        {
                            treeNamespaces.SelectedNode = treeNode;
                            treeNamespaces.Select();
                            SetStatusBar1(pathToConnect + " is already connected.", MessageCategory.Info, true);
                            SetStatusBar2(
                                "Right click " + nodeToConnect.WmiNamespace.Path + " and Disconnect before reconnecting.",
                                MessageCategory.Info);
                            return;
                        }
                    }

                    // Check if path is already populated as Disconnected and select the node
                    if (currentWmiNode != null && currentWmiNode.UserSpecifiedPath == pathToConnect && !currentWmiNode.IsConnected)
                    {
                        treeNamespaces.SelectedNode = treeNode;
                        bNodeDisconnected = true;
                        break;
                    }
                }

                // Check if connecting from disconnected state
                if (treeNamespaces.SelectedNode != null && bNodeDisconnected)
                {
                    // Set selected node values
                    // TODO: Investigate if this can be added to CreateTreeNodeFromWmiNode
                    treeNamespaces.SelectedNode.Name = nodeToConnect.WmiNamespace.Path;
                    treeNamespaces.SelectedNode.Text = nodeToConnect.WmiNamespace.DisplayName;
                    treeNamespaces.SelectedNode.Tag = nodeToConnect;

                    // Populate child nodes and expand tree
                    EnumerateChildNamespaces(treeNamespaces.SelectedNode);
                    treeNamespaces.SelectedNode.Expand();
                    treeNamespaces.Sort();
                }
                else
                {
                    // This is the first time we're connecting to this path

                    // Create a new tree node
                    TreeNode tnRoot = CreateTreeNodeFromWmiNode(nodeToConnect);

                    // Populate child nodes and expand tree
                    EnumerateChildNamespaces(tnRoot);
                    tnRoot.Expand();

                    // Sort and select node
                    treeNamespaces.Sort();
                    treeNamespaces.SelectedNode = tnRoot;

                    // Add node to treeview
                    treeNamespaces.Nodes.Add(tnRoot);
                }

                // Activate treeview
                treeNamespaces.Select();

                nodeToConnect.IsConnected = true;
                SetStatusBar1("Connected to " + pathToConnect + " using " + userDisplayName, MessageCategory.Info, true);

                // Save path to the RecentPaths after successful connection
                if (Settings.Default.bRememberRecentPaths && !Settings.Default.RecentPaths.Contains(pathToConnect))
                {
                    Settings.Default.RecentPaths.Add(pathToConnect.ToUpper());
                    Settings.Default.Save();
                }

                // Connect to SMS Client
                if (Settings.Default.bSmsMode && nodeToConnect.SmsClient != null && nodeToConnect.SmsClient.IsClientInstalled)
                {
                    Log("SMS Mode is enabled and SMS Client is installed.");
                    ConnectToSmsClient(nodeToConnect.SmsClient);
                }
                else if (Settings.Default.bSmsMode && nodeToConnect.SmsClient != null && !nodeToConnect.SmsClient.IsClientInstalled)
                {
                    Log("SMS Mode is enabled but SMS Client is NOT installed.");
                }
                else if (Settings.Default.bSmsMode && nodeToConnect.SmsClient == null)
                {
                    Log("SMS Mode is enabled but SMS Client is NOT installed.");
                }
                else if (!Settings.Default.bSmsMode && nodeToConnect.SmsClient != null && nodeToConnect.SmsClient.IsClientInstalled)
                {
                    Log("SMS Mode is NOT enabled but SMS Client is installed.");
                }
                else if (!Settings.Default.bSmsMode)
                {
                    Log("SMS Mode is NOT enabled");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                var errorMessage = "Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message;
                MessageBox.Show(errorMessage, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message);
            }
            catch (ManagementException ex)
            {
                var errorMessage = "Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message;
                MessageBox.Show(errorMessage, "WMI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message);
            }
            catch (COMException ex)
            {
                var errorMessage = "Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message;
                MessageBox.Show(errorMessage, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                var errorMessage = "Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log("Failed to connect to " + pathToConnect + " using " + userDisplayName + ". Error: " + ex.Message);
            }
        }

        private void ConnectToSmsClient(SmsClient smsClient)
        {
            try
            {
                ManagementScope mScope = new ManagementScope(smsClient.SmsClientClassPath, smsClient.Connection);
                ManagementClass smsClass = new ManagementClass(mScope, new ManagementPath(smsClient.SmsClientClassPath), new ObjectGetOptions());
                smsClass.Get();
                smsClient.SmsClientClass = smsClass;
                smsClient.IsConnected = true;
            }
            catch (Exception ex)
            {
                var errorMessage = "Failed to connect to SMS Client. Error: " + ex.Message;
                SetStatusBar2(errorMessage, MessageCategory.Error, true);
            }
        }

        private string CreateClassEnumQuery(string wqlFilter)
        {
            string queryString;

            if (String.IsNullOrEmpty(wqlFilter)) wqlFilter = "%";

            if (wqlFilter == "%" && checkBoxSystem.Checked && checkBoxCIM.Checked && checkBoxPerf.Checked && checkBoxMSFT.Checked)
            {
                queryString = "SELECT * FROM meta_class";
            }
            else
            {
                if (wqlFilter.StartsWith("!"))
                {
                    wqlFilter = wqlFilter.Substring(1);
                    wqlFilter = String.Format("%{0}%", wqlFilter);
                    queryString = String.Format("SELECT * FROM meta_class WHERE NOT __Class LIKE \"{0}\"", wqlFilter);
                }
                else
                {
                    wqlFilter = String.Format("%{0}%", wqlFilter);
                    queryString = String.Format("SELECT * FROM meta_class WHERE __Class LIKE \"{0}\"", wqlFilter);
                }
            }

            if (checkBoxSystem.Checked == false)
                queryString += " AND NOT __Class LIKE \"[_][_]%\"";

            if (checkBoxCIM.Checked == false)
                queryString += " AND NOT __Class LIKE \"CIM[_]%\"";

            if (checkBoxPerf.Checked == false)
                queryString += " AND NOT __Class LIKE \"Win32_Perf%\"";

            if (checkBoxMSFT.Checked == false)
                queryString += " AND NOT __Class LIKE \"MSFT[_]%\"";

            if (Settings.Default.EnumOptionsFlags.HasFlag(EnumOptions.ExcludeSmsCollections))
                queryString += " AND NOT __Class LIKE \"SMS_CM_RES_COLL_%\"";

            if (Settings.Default.EnumOptionsFlags.HasFlag(EnumOptions.ExcludeSmsInventory))
            {
                queryString += " AND NOT __Class LIKE \"SMS_G_System%\"";
                queryString += " AND NOT __Class LIKE \"SMS_GH_System%\"";
                queryString += " AND NOT __Class LIKE \"SMS_GEH_System%\"";
            }

            return queryString;
        }

        private string CreateQueryForSelectedClass(WmiClass wmiClass)
        {
            return "SELECT * FROM " + wmiClass.DisplayName;
        }

        private string CreateQueryForSelectedInstance(WmiInstance wmiInstance)
        {
            string queryString;
            var instanceRelPath = wmiInstance.RelativePath;

            if (instanceRelPath.Contains("=@"))
            {
                queryString = "SELECT * FROM " + wmiInstance.Instance.Path.ClassName;
            }
            else if (instanceRelPath.Contains("."))
            {
                var fromString = instanceRelPath.Substring(0, instanceRelPath.IndexOf(".", StringComparison.CurrentCultureIgnoreCase));
                var whereString = instanceRelPath.Substring(instanceRelPath.IndexOf(".", StringComparison.CurrentCultureIgnoreCase) + 1);
                whereString = whereString.Replace("\"", "'");
                whereString = whereString.Replace(",", " AND ");
                queryString = "SELECT * FROM " + fromString + " WHERE " + whereString;
            }
            else
            {
                queryString = "SELECT * FROM " + wmiInstance.Instance.Path.ClassName;
            }

            return queryString;
        }

        private void CreateSmsClientActionToolStripItem(SmsClientAction action, ToolStripMenuItem parentItem)
        {
            // Create tool strip menu item for the action
            ToolStripMenuItem item = new ToolStripMenuItem(action.DisplayName, null, InitiateAction)
            {
                Tag = action
            };

            // Add action item to parent item if it belongs to default group
            if (action.Group == "Default")
            {
                parentItem.DropDownItems.Add(item);
                return;
            }

            // Create tool strip menu item for the group
            ToolStripMenuItem groupItem;
            if (!parentItem.DropDownItems.ContainsKey(action.Group))
            {
                // Create new group
                groupItem = new ToolStripMenuItem(action.Group, null, null, action.Group);
                parentItem.DropDownItems.Add(groupItem);
            }
            else
            {
                // Get existing group
                groupItem = parentItem.DropDownItems[action.Group] as ToolStripMenuItem;
            }

            // Add item to group
            if (groupItem != null) groupItem.DropDownItems.Add(item);
        }

        private TreeNode CreateTreeNodeFromWmiNode(WmiNode wmiNode)
        {
            TreeNode tn = new TreeNode
            {
                Name = wmiNode.WmiNamespace.Path,
                Text = wmiNode.WmiNamespace.DisplayName,
                Tag = wmiNode
            };

            return tn;
        }

        private void EnumClassWorker_DoWork(TreeNode currentNode, string queryString)
        {
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;

            // This should never happen, but check anyway.
            if (currentWmiNode == null)
            {
                string message = "Failed to enumerate classes from " + currentNode.Text + ". ERROR: DoWork - Current WmiNode is null.";
                NotifyNodeError(currentNode, message);
                return;
            }

            WmiNamespace currentNamespace = currentWmiNode.WmiNamespace;
            ManagementScope scope = new ManagementScope(currentNamespace.Path, Helpers.GetRootNodeCredentials(currentNode));
            ObjectQuery query = new ObjectQuery(queryString);

            EnumerationOptions eOption = new EnumerationOptions
            {
                EnumerateDeep = true,
                UseAmendedQualifiers = true
            };

            ManagementOperationObserver observer = new ManagementOperationObserver();
            ObserverHandler handler = new ObserverHandler(currentNamespace);
            observer.ObjectReady += new ObjectReadyEventHandler(handler.NewObject);
            observer.Completed += new CompletedEventHandler(handler.Done);

            ManagementObjectSearcher queryAllClasses = new ManagementObjectSearcher(scope, query, eOption);
            queryAllClasses.Get(observer);

            while (!handler.IsComplete)
            {
                Thread.Sleep(100);

                // Check if cancellation is requested for the current Namespace
                if (_bwClassEnumWorker.CancellationPending && currentNamespace.IsEnumerationCancelled)
                {
                    observer.Cancel();
                    return;
                }
            }
        }

        private void EnumClassWorker_RunWorkerCompleted(RunWorkerCompletedEventArgs e, TreeNode currentNode)
        {
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;

            // This should never happen, but check anyway.
            if (currentWmiNode == null)
            {
                string message = "Failed to enumerate classes from " + currentNode.Text + ". ERROR: RunWorkerCompleted - Current WmiNode is null.";
                NotifyNodeError(currentNode, message);
                return;
            }

            WmiNamespace currentNamespace = currentWmiNode.WmiNamespace;

            // Error occured
            if (e.Error != null)
            {
                currentNamespace.IsEnumerating = false;
                currentNamespace.EnumerationStatus = e.Error.Message;
                string message = "Failed to enumerate classes from " + currentNamespace.DisplayName + ". ERROR: " + e.Error.Message;
                NotifyNodeError(currentNode, message);
                return;
            }

            // No error and no cancellation
            if (!e.Cancelled && e.Error == null)
            {
                // Get Cached Classes
                var cachedItem = AppCache[currentNamespace.Path];

                if (cachedItem != null)
                {
                    // Get list of cached classes
                    List<ListViewItem> lc = (List<ListViewItem>)cachedItem;

                    // If current node is still selected, populate classes. Else, just update the log
                    if (treeNamespaces.SelectedNode == currentNode)
                    {
                        PopulateListClasses(lc);
                        tabClasses.Text = "Classes (" + currentNamespace.ClassCount + ")";

                        if (currentNamespace.IsPartiallyEnumerated)
                        {
                            SetStatusBar1(
                                "Retrieved " + lc.Count + " classes from " + currentNamespace.DisplayName +
                                " before operation was cancelled.", MessageCategory.Warn);
                            SetStatusBar2("", MessageCategory.None);
                        }
                        else
                        {
                            SetStatusBar1(
                                "Retrieved " + lc.Count + " classes from " + currentNamespace.DisplayName +
                                " that match specified criteria.", MessageCategory.Info);
                            SetStatusBar2("", MessageCategory.None);
                        }

                        SetStatusBar3("Enumerate Classes", currentNamespace.EnumTimeElapsed);
                    }

                    // Log and update color without updating the Status bar
                    if (currentNamespace.IsPartiallyEnumerated)
                    {
                        Log("Retrieved " + lc.Count + " classes from " + currentNamespace.DisplayName +
                            " before operation was cancelled in " + currentNamespace.EnumTimeElapsed.TotalSeconds + " seconds");
                        currentNode.BackColor = ColorCategory.Warn;
                    }
                    else
                    {
                        Log("Retrieved " + lc.Count + " classes from " + currentNamespace.DisplayName +
                            " that match specified criteria in " + currentNamespace.EnumTimeElapsed.TotalSeconds + " seconds");
                        currentNode.BackColor = ColorCategory.Info;
                    }
                }
                else
                {
                    // There's nothing in cache. Even for namespaces with 0 classes, CachedClasses still gets an entry, so we should never reach here
                    Log("Failed to enumerate classes. Error: No items found");
                }
            }
        }

        private void EnumerateChildNamespaces(TreeNode currentNode)
        {
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;

            if (currentWmiNode == null)
            {
                SetStatusBar1("Unexpected Error. EnumerateChildNamespaces - Current WmiNode is null.", MessageCategory.Error, true);
                SetStatusBar2("", MessageCategory.None);
                return;
            }

            // If current namespace is already expanded, do nothing and return
            if (currentWmiNode.IsExpanded)
            {
                SetStatusBar1("Double click on namespace to enumerate classes...", MessageCategory.Info);
                SetStatusBar2("", MessageCategory.Info);
                return;
            }

            // If Expansion Errored out previously, do nothing and return - Error is displayed in node's Tooltip
            // TODO: Do we need to allow enumerating child namespaces again despite previous error?
            if (currentWmiNode.ExpansionStatus != "NoError") return;

            Cursor = Cursors.WaitCursor;

            try
            {
                ManagementScope mScope = new ManagementScope(currentWmiNode.WmiNamespace.Path, Helpers.GetRootNodeCredentials(currentNode));

                //mScope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM __Namespace");
                ManagementObjectSearcher namespaces = new ManagementObjectSearcher(mScope, query);

                // Get child namespaces, and add them to the selected node.
                foreach (ManagementObject instance in namespaces.Get())
                {
                    WmiNode childWmiNode = new WmiNode(instance);
                    TreeNode tn = CreateTreeNodeFromWmiNode(childWmiNode);
                    currentNode.Nodes.Add(tn);

                    // Set SmsClient if client namespace exists
                    if (childWmiNode.WmiNamespace.DisplayName.ToUpperInvariant()
                        .Equals("ROOT\\CCM", StringComparison.InvariantCultureIgnoreCase))
                    {
                        currentWmiNode.SmsClient = new SmsClient(childWmiNode.WmiNamespace.Path, Helpers.GetRootNodeCredentials(currentNode));
                    }
                }

                currentWmiNode.IsExpanded = true;
                currentNode.Expand();

                SetStatusBar1("Enumerated " + currentNode.Nodes.Count + " child namespaces. Double click on namespace to enumerate classes...",
                    MessageCategory.Info);

                SetStatusBar2("", MessageCategory.Info);
            }
            catch (Exception ex)
            {
                currentWmiNode.ExpansionStatus = ex.Message;
                currentNode.ToolTipText = ex.Message;
                currentNode.BackColor = ColorCategory.Error;
                SetStatusBar1("Failed to enumerate child namespaces for " + currentWmiNode.WmiNamespace.DisplayName + ". ERROR: " + ex.Message, MessageCategory.Error, true);
                SetStatusBar2("", MessageCategory.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void EnumerateClasses()
        {
            // Get current node and namespace
            TreeNode currentNode = treeNamespaces.SelectedNode;
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;

            // Check for NullReferenceException
            if (currentWmiNode == null)
            {
                string message = "Failed to enumerate classes from " + currentNode.Text + ". EnumerateClasses - Current WmiNode is null.";
                NotifyNodeError(currentNode, message);
                return;
            }

            WmiNamespace currentNamespace = currentWmiNode.WmiNamespace;
            currentNode.BackColor = ColorCategory.Action;

            // Expand selected namespace's tree node, if it was already expanded. Collapse if it was already collapsed.
            if (!currentNode.IsExpanded)
                currentNode.Expand();
            else
                currentNode.Collapse();

            // Check if current namespace is already being enumerated
            if (currentNamespace.IsEnumerating)
            {
                SetStatusBar1("Enumerating Classes from " + currentNamespace.DisplayName + ". Please wait before trying again...", MessageCategory.Action);
                SetStatusBar2("", MessageCategory.None);
                return;
            }

            // Update status
            SetStatusBar1("Enumerating Classes from " + currentNamespace.DisplayName, MessageCategory.Action);
            SetStatusBar2("", MessageCategory.None);

            // Set Class Filter to %, if it's blank or *
            if (textBoxClassFilter.Text == "" || textBoxClassFilter.Text == "*")
                textBoxClassFilter.Text = "%";

            textBoxClassQuickFilter.Text = String.Empty;

            if (radioModeAsync.Checked)
                EnumerateClassesAsync(currentNode, currentNamespace);
            else
                EnumerateClassesSync(currentNode, currentNamespace);
        }

        private void EnumerateClassesAsync(TreeNode currentNode, WmiNamespace currentNamespace)
        {
            try
            {
                string queryString = CreateClassEnumQuery(textBoxClassFilter.Text);

                _bwClassEnumWorker = new BackgroundWorker { WorkerSupportsCancellation = true };
                _bwClassEnumWorker.DoWork += (obj, e) => EnumClassWorker_DoWork(currentNode, queryString);
                _bwClassEnumWorker.RunWorkerCompleted += (obj, e) => EnumClassWorker_RunWorkerCompleted(e, currentNode);

                // Start work
                _bwClassEnumWorker.RunWorkerAsync(currentNode);
            }
            catch (Exception ex)
            {
                currentNamespace.IsEnumerating = false;
                string message = "Failed to enumerate classes from " + currentNamespace.DisplayName + ". ERROR: " + ex.Message;
                NotifyNodeError(currentNode, message);
            }
        }

        private void EnumerateClassesFromCache(WmiNamespace currentNamespace)
        {
            // Do nothing if current namespace is not enumerated
            if (!currentNamespace.IsEnumerated) return;

            TreeNode currentNode = treeNamespaces.SelectedNode;
            Stopwatch stopwatch = new Stopwatch();
            Cursor = Cursors.WaitCursor;

            try
            {
                // Get cached classes for current namespace
                var cachedItem = AppCache[currentNamespace.Path];
                if (cachedItem != null)
                {
                    // Get cached classes and add to list
                    List<ListViewItem> lc = (List<ListViewItem>)cachedItem;
                    PopulateListClasses(lc);
                    tabClasses.Text = "Classes (" + currentNamespace.ClassCount + ")";

                    if (currentNamespace.IsPartiallyEnumerated)
                        SetStatusBar1("Showing " + lc.Count + " cached classes (partial results) for " + currentNamespace.DisplayName + " from " + currentNamespace.EnumTime.ToString("HH:mm:ss"),
                            MessageCategory.Cache, true);
                    else
                        SetStatusBar1("Showing " + lc.Count + " cached classes for " + currentNamespace.DisplayName + " from " + currentNamespace.EnumTime.ToString("HH:mm:ss"),
                            MessageCategory.Cache, true);
                }
                else
                {
                    currentNode.BackColor = ColorCategory.Warn;
                    SetStatusBar1("Cache Expired for " + currentNamespace.DisplayName + ". Double click namespace to enumerate classes.",
                        MessageCategory.Warn, true);
                }
            }
            catch (Exception)
            {
                SetStatusBar1("Error retrieving Cached Classes for " + currentNamespace.DisplayName + ". Double click on Namespace to enumerate Classes",
                    MessageCategory.Warn);
                Log("Error retrieving Cached Classes for " + currentNamespace.DisplayName);
            }
            finally
            {
                Cursor = Cursors.Default;
                stopwatch.Stop();
                SetStatusBar3("Enumerate Cached Classes", stopwatch.Elapsed);
            }
        }

        private void EnumerateClassesSync(TreeNode currentNode, WmiNamespace currentNamespace)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Cursor = Cursors.WaitCursor;

            try
            {
                string queryString = CreateClassEnumQuery(textBoxClassFilter.Text);

                ManagementScope scope = new ManagementScope(currentNamespace.Path, Helpers.GetRootNodeCredentials(currentNode));
                ObjectQuery query = new ObjectQuery(queryString);

                EnumerationOptions eOption = new EnumerationOptions
                {
                    EnumerateDeep = true,
                    UseAmendedQualifiers = true
                };

                ManagementObjectSearcher queryAllClasses = new ManagementObjectSearcher(scope, query, eOption);
                foreach (ManagementClass mClass in (from ManagementClass mClass in queryAllClasses.Get()
                                                    orderby mClass.Path.ClassName
                                                    select mClass))
                {
                    WmiClass wmiClass = new WmiClass(mClass);
                    ListViewItem li = new ListViewItem
                    {
                        Name = wmiClass.Path,
                        Text = wmiClass.DisplayName,
                        ToolTipText = wmiClass.Description,
                        Tag = wmiClass
                    };

                    // Add Lazy Properties, Description, and Path columns
                    li.SubItems.Add(wmiClass.HasLazyProperties.ToString());
                    li.SubItems.Add(wmiClass.Description);
                    li.SubItems.Add(wmiClass.Path);

                    currentNamespace.AddClass(li);
                }

                // Mark current Namespace as Enumerated
                currentNamespace.IsEnumerated = true;
                currentNode.BackColor = ColorCategory.Info;

                // Populate list classes
                PopulateListClasses(currentNamespace.Classes);
                tabClasses.Text = "Classes (" + currentNamespace.Classes.Count + ")";
                SetStatusBar1(
                                "Retrieved " + currentNamespace.Classes.Count + " classes from " + currentNamespace.DisplayName +
                                " that match specified criteria.", MessageCategory.Info, true);
                SetStatusBar2("", MessageCategory.None);

                // Add classes to cache
                CacheItem ci = new CacheItem(currentNamespace.Path, currentNamespace.Classes);
                AppCache.Set(ci, CachePolicy);
                currentNamespace.ResetClasses();
            }
            catch (Exception ex)
            {
                var message = "Failed to enumerate classes from " + currentNamespace.DisplayName + ". ERROR: " + ex.Message;
                NotifyNodeError(currentNode, message);
            }
            finally
            {
                Cursor = Cursors.Default;
                stopwatch.Stop();
                SetStatusBar3("Enumerate Classes", stopwatch.Elapsed);
                currentNamespace.EnumTime = DateTime.Now;
                currentNamespace.EnumTimeElapsed = stopwatch.Elapsed;
            }
        }

        private void EnumerateInstances()
        {
            TreeNode currentNode = treeNamespaces.SelectedNode;
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;
            ListViewItem currentListViewItem = listClasses.SelectedItems[0];
            WmiClass currentClass = currentListViewItem.Tag as WmiClass;

            if (currentWmiNode == null || currentClass == null)
            {
                string message = "Failed to enumerate instances from " + currentListViewItem.Text + ". EnumerateInstances - Current Class is null.";
                NotifyClassError(currentListViewItem, message);
                return;
            }

            // Check if current class is already being enumerated
            if (currentClass.IsEnumerating)
            {
                SetStatusBar2("Enumerating Instances from " + currentClass.DisplayName + ". Please wait before trying again...", MessageCategory.Action);
                return;
            }

            // Update status
            SetStatusBar2("Enumerating Instances from " + currentClass.DisplayName, MessageCategory.Action);
            currentListViewItem.BackColor = ColorCategory.Action;

            // Set Instance Filter to blank, if it's * or %
            //if (textBoxInstanceFilterQuick.Text == "*" || textBoxInstanceFilterQuick.Text == "%")
            //    textBoxInstanceFilterQuick.Text = String.Empty;

            // Reset instance filter for current Class
            textBoxInstanceFilterQuick.Text = String.Empty;

            if (radioModeAsync.Checked)
                EnumerateInstancesAsync(currentNode, currentClass, currentListViewItem);
            else
                EnumerateInstancesSync(currentClass, currentListViewItem);
        }

        private void EnumerateInstancesAsync(TreeNode currentNode, WmiClass currentClass, ListViewItem currentListViewItem)
        {
            try
            {
                _bwInstanceEnumWorker = new BackgroundWorker { WorkerSupportsCancellation = true };
                _bwInstanceEnumWorker.DoWork += (obj, e) => EnumInstanceWorker_DoWork(currentNode, currentListViewItem);
                _bwInstanceEnumWorker.RunWorkerCompleted += (obj, e) => EnumInstanceWorker_RunWorkerCompleted(e, currentListViewItem);

                _bwInstanceEnumWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                string message = "Failed to enumerate instances from " + currentClass.DisplayName + ". ERROR: " + ex.Message;
                currentListViewItem.BackColor = ColorCategory.Error;
                //currentListViewItem.ToolTipText = message;
                currentClass.IsEnumerating = false;
                SetStatusBar2(message, MessageCategory.Error, true);
            }
        }

        private void EnumerateInstancesFromCache(WmiClass currentClass)
        {
            if (!currentClass.IsEnumerated)
            {
                SetStatusBar2("Double click on Class to enumerate Instances", MessageCategory.Info);
                return;
            }

            ListViewItem currentItem = listClasses.SelectedItems[0];
            Stopwatch stopwatch = new Stopwatch();
            Cursor = Cursors.WaitCursor;

            try
            {
                var cachedItem = AppCache[currentClass.Path];
                if (cachedItem != null)
                {
                    // Get cached classes and add to list
                    List<ListViewItem> lc = (List<ListViewItem>)cachedItem;
                    PopulateListInstances(lc);
                    tabInstances.Text = "Instances (" + currentClass.InstanceCount + ")";

                    if (currentClass.IsPartiallyEnumerated)
                        SetStatusBar2(
                            "Showing " + lc.Count + " cached instances (partial results) for " +
                            currentClass.DisplayName + " from " + currentClass.EnumTime.ToString("HH:mm:ss"),
                            MessageCategory.Cache, true);
                    else
                        SetStatusBar2(
                            "Showing " + lc.Count + " cached instances for " + currentClass.DisplayName + " from " +
                            currentClass.EnumTime.ToString("HH:mm:ss"),
                            MessageCategory.Cache, true);
                }
                else
                {
                    currentItem.BackColor = ColorCategory.Warn;
                    SetStatusBar2(
                        "Cache Expired for " + currentClass.DisplayName +
                        ". Double click on Class to enumerate Instances.", MessageCategory.Warn, true);
                }
            }
            catch (Exception ex)
            {
                SetStatusBar2(
                    "Error retrieving Cached Instances for " + currentClass.DisplayName +
                    ". Double click on Namespace to enumerate Instances", MessageCategory.Warn);
                Log("Error retrieving Cached Instances for " + currentClass.DisplayName + ". Error: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                stopwatch.Stop();
                SetStatusBar3("Enumerate Cached Instances", stopwatch.Elapsed);
            }
        }

        private void EnumerateInstancesSync(WmiClass currentClass, ListViewItem currentListViewItem)
        {
            // Start enumerating
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Cursor = Cursors.WaitCursor;

            try
            {
                ObjectGetOptions options = new ObjectGetOptions { UseAmendedQualifiers = false };
                EnumerationOptions eOption = new EnumerationOptions
                {
                    EnumerateDeep = true,
                    UseAmendedQualifiers = false
                };

                ManagementPath mPath = new ManagementPath(currentClass.Path);
                ManagementScope mScope = new ManagementScope(mPath, Helpers.GetRootNodeCredentials(treeNamespaces.SelectedNode));
                ManagementClass mClass = new ManagementClass(mScope, mPath, options);

                foreach (ManagementObject mInstance in (from ManagementObject mObject in mClass.GetInstances(eOption)
                                                        orderby mObject.Path.ClassName
                                                        select mObject))
                {
                    WmiInstance wmiInstance = new WmiInstance(mInstance);
                    ListViewItem li = new ListViewItem
                    {
                        Name = wmiInstance.Path,
                        Text = wmiInstance.RelativePath,
                        ToolTipText = wmiInstance.RelativePath,
                        Tag = wmiInstance
                    };

                    currentClass.AddInstance(li);
                }

                // Mark current class as Enumerated
                currentClass.IsEnumerated = true;
                currentListViewItem.BackColor = ColorCategory.Info;

                // Populate list
                PopulateListInstances(currentClass.Instances);
                tabInstances.Text = "Instances (" + currentClass.Instances.Count + ")";
                SetStatusBar2(
                            "Retrieved " + currentClass.Instances.Count + " instances from " + currentClass.DisplayName,
                            MessageCategory.Info);

                // Add item to cache
                CacheItem ci = new CacheItem(currentClass.Path, currentClass.Instances);
                AppCache.Set(ci, CachePolicy);
                currentClass.ResetInstances();
            }
            catch (Exception ex)
            {
                string message = "Failed to enumerate instances from " + currentClass.DisplayName + ". ERROR: " +
                                 ex.Message;
                currentListViewItem.BackColor = ColorCategory.Error;
                //currentListViewItem.ToolTipText = message;
                SetStatusBar2(message, MessageCategory.Error, true);
            }
            finally
            {
                stopwatch.Stop();
                currentClass.EnumTime = DateTime.Now;
                currentClass.EnumTimeElapsed = stopwatch.Elapsed;
                Cursor = Cursors.Default;
                SetStatusBar3("Enumerate Instances", currentClass.EnumTimeElapsed);
            }
        }

        private void EnumInstanceWorker_DoWork(TreeNode currentNode, ListViewItem currentListViewItem)
        {
            WmiNode currentWmiNode = currentNode.Tag as WmiNode;
            WmiClass currentClass = currentListViewItem.Tag as WmiClass;

            // Check for NullReferenceException
            if (currentClass == null || currentWmiNode == null)
            {
                string message = "Failed to enumerate instances from " + currentListViewItem.Text + ". DoWork - Current Node/Class is null.";
                NotifyClassError(currentListViewItem, message);
                return;
            }

            ObjectGetOptions options = new ObjectGetOptions { UseAmendedQualifiers = false };
            EnumerationOptions eOption = new EnumerationOptions
            {
                EnumerateDeep = true,
                UseAmendedQualifiers = false
            };

            ManagementPath mPath = new ManagementPath(currentClass.Path);
            ManagementScope mScope = new ManagementScope(mPath, Helpers.GetRootNodeCredentials(currentNode));
            ManagementClass mClass = new ManagementClass(mScope, mPath, options);

            ManagementOperationObserver observer = new ManagementOperationObserver();
            ObserverHandler handler = new ObserverHandler(currentClass);
            observer.ObjectReady += new ObjectReadyEventHandler(handler.NewObject);
            observer.Completed += new CompletedEventHandler(handler.Done);

            mClass.GetInstances(observer, eOption);

            while (!handler.IsComplete)
            {
                Thread.Sleep(100);

                // Check if cancellation is requested for the current Class
                if (_bwInstanceEnumWorker.CancellationPending && currentClass.IsEnumerationCancelled)
                {
                    observer.Cancel();
                    return;
                }
            }
        }

        private void EnumInstanceWorker_RunWorkerCompleted(RunWorkerCompletedEventArgs e, ListViewItem currentListViewItem)
        {
            WmiClass currentClass = currentListViewItem.Tag as WmiClass;

            // Check for NullReferenceException
            if (currentClass == null)
            {
                string message = "Failed to enumerate instances from " + currentListViewItem.Text + ". RunWorkerCompleted - Current Class is null.";
                NotifyClassError(currentListViewItem, message);
                return;
            }

            // Error Occurred for Background Worker
            if (e.Error != null)
            {
                currentClass.IsEnumerating = false;
                currentClass.EnumerationStatus = e.Error.Message;
                string message = "Failed to enumerate classes from " + currentClass.DisplayName + ". ERROR: " + e.Error.Message;
                NotifyClassError(currentListViewItem, message);
                return;
            }

            // Get results
            var cachedItem = AppCache[currentClass.Path];

            if (cachedItem != null)
            {
                List<ListViewItem> lc = (List<ListViewItem>)cachedItem;

                // If current class is still selected, populate instances
                if (listClasses.SelectedItems[0] == currentListViewItem)
                {
                    PopulateListInstances(lc);
                    tabInstances.Text = "Instances (" + currentClass.InstanceCount + ")";

                    if (currentClass.IsPartiallyEnumerated)
                    {
                        SetStatusBar2(
                            "Retrieved " + lc.Count + " instances from " + currentClass.DisplayName +
                            " before operation was cancelled.", MessageCategory.Warn);
                    }
                    else
                    {
                        SetStatusBar2(
                            "Retrieved " + lc.Count + " instances from " + currentClass.DisplayName,
                            MessageCategory.Info);
                    }

                    SetStatusBar3("Enumerate Instances", currentClass.EnumTimeElapsed);
                }

                // Log and update color regardless of whether the current class is still selected
                if (currentClass.IsPartiallyEnumerated)
                {
                    Log("Retrieved " + lc.Count + " instances from " + currentClass.DisplayName +
                        " before operation was cancelled in " + currentClass.EnumTimeElapsed.TotalSeconds + " seconds");
                    currentListViewItem.BackColor = ColorCategory.Warn;
                }
                else
                {
                    Log("Retrieved " + lc.Count + " instances from " + currentClass.DisplayName +
                        " in " + currentClass.EnumTimeElapsed.TotalSeconds + " seconds");
                    currentListViewItem.BackColor = ColorCategory.Info;
                }
            }
            else
            {
                // There's nothing in cache.
                Log("Failed to enumerate instances. Error: No items found in the Cache.");
            }
        }

        private void ExecuteQuery(string queryText)
        {
            TreeNode currentnode = treeNamespaces.SelectedNode;

            if (currentnode == null)
            {
                SetStatusBar2("Please select a namespace before running a query.", MessageCategory.Warn);
                return;
            }

            WmiNode currentWmiNode = treeNamespaces.SelectedNode.Tag as WmiNode;
            if (currentWmiNode != null && currentWmiNode.IsRootNode && !currentWmiNode.IsConnected)
            {
                SetStatusBar1("Please connect to " + currentWmiNode.UserSpecifiedPath + " before attempting to run a query.", MessageCategory.Warn);
                return;
            }

            if (String.IsNullOrEmpty(queryText))
            {
                SetStatusBar2("Invalid Query!", MessageCategory.Error);
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Set Status bar
            SetStatusBar2("Executing query...", MessageCategory.Action);
            Cursor = Cursors.WaitCursor;

            try
            {
                ManagementScope mScope = new ManagementScope(currentWmiNode.WmiNamespace.Path, Helpers.GetRootNodeCredentials(currentnode));
                ObjectQuery query = new ObjectQuery(queryText);
                ManagementObjectSearcher queryResults = new ManagementObjectSearcher(mScope, query);
                queryResults.Options.EnumerateDeep = true;
                queryResults.Options.DirectRead = true;

                int i = 0;

                ResetListQueryResults();
                dataGridQueryResults.DataSource = null;

                listQueryResults.BeginUpdate();

                DataTable dt = new DataTable();

                foreach (ManagementObject instance in queryResults.Get())
                {
                    // Populate list
                    ListViewItem li = new ListViewItem();
                    if (instance.Path.RelativePath == String.Empty)
                    {
                        li.Name = instance.GetPropertyValue("__CLASS").ToString();
                        li.Text = "instance of " + instance.GetPropertyValue("__CLASS");
                        li.ToolTipText = "instance of " + instance.GetPropertyValue("__CLASS");
                        li.Tag = instance;
                    }
                    else
                    {
                        li.Name = instance.Path.Path;
                        li.Text = instance.Path.RelativePath;
                        li.ToolTipText = instance.Path.RelativePath;
                        li.Tag = instance;
                    }

                    listQueryResults.Items.Add(li);

                    // Populate Data Grid
                    DataRow dr = dt.NewRow();
                    foreach (PropertyData p in instance.Properties)
                    {
                        // Add Column headers if this is the first row (i=0).
                        if (i == 0)
                            dt.Columns.Add(p.Name);

                        // Add property values to each cell in the row.
                        if (p.Value == null)
                            dr[p.Name] = String.Empty;
                        else if (p.IsArray)
                            dr[p.Name] = p.Type + " []";
                        else
                            dr[p.Name] = p.Value.ToString();
                    }

                    // Add row to the table, and increase counter.
                    dt.Rows.Add(dr);
                    i++;
                }

                dataGridQueryResults.DataSource = dt;
                dataGridQueryResults.AutoResizeColumns();

                listQueryResults.Sorting = SortOrder.Ascending;
                listQueryResults.Sort();
                listQueryResults.ResizeColumns();

                SetStatusBar2("Successfully ran query, and retrieved " + i + " instances", MessageCategory.Info, true);
                groupBoxQueryResults.Text = "Results (" + i + ")";
            }
            catch (Exception ex)
            {
                SetStatusBar2("Error running query against " + treeNamespaces.SelectedNode.Text + " namespace. " + ex.Message,
                    MessageCategory.Error, true);
            }
            finally
            {
                listQueryResults.EndUpdate();
                Cursor = Cursors.Default;
                stopwatch.Stop();
                SetStatusBar3("Execute Query", stopwatch.Elapsed);
            }
        }

        private void GeneratePsScript()
        {
            if (!radioScriptPs.Checked) return;
            if (listClasses.SelectedItems.Count == 0) return;

            WmiClass wmiClass = listClasses.SelectedItems[0].Tag as WmiClass;
            if (wmiClass == null)
            {
                SetStatusBar2("Failed to generate script. ERROR: GeneratePsScript - Current Class is null", MessageCategory.Error, true);
                return;
            }

            string className = wmiClass.DisplayName;
            string namespaceName = wmiClass.Class.Path.NamespacePath;

            StringBuilder script = new StringBuilder();

            script.Append("$computer = $env:COMPUTERNAME").AppendLine();
            script.Append("$namespace = \"" + namespaceName + "\"").AppendLine();
            script.Append("$classname = \"" + className + "\"").AppendLine();
            script.AppendLine();
            script.Append("Write-Output \"=====================================\"").AppendLine();
            script.Append("Write-Output \"COMPUTER : $computer \"").AppendLine();
            script.Append("Write-Output \"CLASS    : $classname \"").AppendLine();
            script.Append("Write-Output \"=====================================\"").AppendLine();
            script.AppendLine();
            script.Append("Get-WmiObject -Class $classname -ComputerName $computer -Namespace $namespace |").AppendLine();
            script.Append("    Select-Object * -ExcludeProperty PSComputerName, Scope, Path, Options, ClassPath, Properties, SystemProperties, Qualifiers, Site, Container |").AppendLine();
            script.Append("    Format-List -Property [a-z]*").AppendLine();

            textBoxScript.Text = script.ToString();
        }

        private void GenerateVbScript()
        {
            if (!radioScriptVbs.Checked) return;
            if (listClasses.SelectedItems.Count == 0) return;

            WmiClass wmiClass = listClasses.SelectedItems[0].Tag as WmiClass;
            if (wmiClass == null)
            {
                SetStatusBar2("Failed to generate script. ERROR: GenerateVbScript - Current Class is null", MessageCategory.Error, true);
                return;
            }

            string className = wmiClass.DisplayName;
            string namespaceName = wmiClass.Class.Path.NamespacePath;
            string queryText = "SELECT * FROM " + className;

            StringBuilder script = new StringBuilder();

            script.Append("On Error Resume Next").AppendLine();
            script.AppendLine();

            script.Append("Const wbemFlagReturnImmediately = &h10").AppendLine();
            script.Append("Const wbemFlagForwardOnly = &h20").AppendLine();
            script.AppendLine();

            script.Append("Set wshNetwork = WScript.CreateObject(\"WScript.Network\")").AppendLine();
            script.Append("strComputer = wshNetwork.ComputerName").AppendLine();
            script.AppendLine();
            script.Append("strQuery = \"" + queryText + "\"").AppendLine();
            script.AppendLine();
            script.Append("WScript.StdOut.WriteLine \"\"").AppendLine();
            script.Append("WScript.StdOut.WriteLine \"=====================================\"").AppendLine();
            script.Append("WScript.StdOut.WriteLine \"COMPUTER : \" & strComputer").AppendLine();
            script.Append("WScript.StdOut.WriteLine \"CLASS    : " + namespaceName + ":" + className + "\"").AppendLine();
            script.Append("WScript.StdOut.WriteLine \"QUERY    : \" & strQuery").AppendLine();
            script.Append("WScript.StdOut.WriteLine \"=====================================\"").AppendLine();
            script.Append("WScript.StdOut.WriteLine \"\"").AppendLine();
            script.AppendLine();
            script.Append("Set objWMIService = GetObject(\"winmgmts:\\\\\" & strComputer & \"\\" + namespaceName + "\")").AppendLine();
            script.Append("Set colItems = objWMIService.ExecQuery(strQuery, \"WQL\", wbemFlagReturnImmediately + wbemFlagForwardOnly)").AppendLine();
            script.AppendLine();
            script.Append("For Each objItem in colItems").AppendLine();
            script.AppendLine();
            foreach (PropertyData property in wmiClass.Class.Properties)
            {
                if (property.IsArray)
                {
                    script.Append("    str" + property.Name + " = Join(objItem." + property.Name + ", \",\")").AppendLine();
                    script.Append("    WScript.StdOut.WriteLine \"" + property.Name + ": \" &  str" + property.Name).AppendLine();
                }
                else
                {
                    script.Append("    WScript.StdOut.WriteLine \"" + property.Name + ": \" & objItem." + property.Name).AppendLine();
                }
            }

            script.Append("    WScript.StdOut.WriteLine \"\"").AppendLine();
            script.AppendLine();
            script.Append("Next").AppendLine();

            textBoxScript.Text = script.ToString();
        }

        private ToolStripMenuItem GetClientActionsContextMenuItem()
        {
            ToolStripMenuItem smsClientActionsMenuItem = new ToolStripMenuItem("SMS Client &Actions");

            // Create tool strip item for each public static property of SmsClientAction Type
            SmsClientActions smsClientActions = new SmsClientActions();
            foreach (var prop in smsClientActions.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(prop => prop.PropertyType.Name == "SmsClientAction")
                .OrderBy(prop => prop.Name))
            {
                CreateSmsClientActionToolStripItem(prop.GetValue(null, null) as SmsClientAction, smsClientActionsMenuItem);
            }

            smsClientActionsMenuItem.DropDownItems.SortToolStripItemCollection();

            return smsClientActionsMenuItem;
        }

        private ToolStripMenuItem GetMethodsContextMenuItem(bool returnStaticMethods)
        {
            ToolStripMenuItem executeMethods = new ToolStripMenuItem("Execute Method");

            WmiClass wmiClass = listClasses.SelectedItems[0].Tag as WmiClass;

            foreach (MethodData method in wmiClass.Class.Methods)
            {
                bool methodStatic = false;

                foreach (QualifierData qualifier in method.Qualifiers)
                {
                    if (qualifier.Name.Equals("Static", StringComparison.CurrentCultureIgnoreCase))
                    {
                        methodStatic = true;
                        break;
                    }
                }

                // Static Methods when right clicking on a class
                if (methodStatic && returnStaticMethods)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(method.Name, null, InvokeClassMethod);
                    item.Tag = method;
                    executeMethods.DropDownItems.Add(item);
                }

                // Non static methods when right clicking on an instance
                if (!methodStatic && !returnStaticMethods)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(method.Name, null, InvokeInstanceMethod);
                    item.Tag = method;
                    executeMethods.DropDownItems.Add(item);
                }
            }

            executeMethods.DropDownItems.SortToolStripItemCollection();
            return executeMethods;
        }

        private void GetPropertyHelp(PropertyData property, out bool enumAvailable, out string propertyHelp)
        {
            enumAvailable = false;

            StringBuilder helpBuilder = new StringBuilder();

            string propDesc = String.Empty;
            string propQualifiers = String.Empty;
            object propEnum = null;
            object propEnumMap = null;
            bool enumBitMap = false;

            foreach (QualifierData qualifier in property.Qualifiers)
            {
                if (qualifier.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                    propDesc = qualifier.Value.ToString();

                if (qualifier.Name.Equals("values", StringComparison.CurrentCultureIgnoreCase))
                    propEnum = qualifier.Value;

                if (qualifier.Name.Equals("valuemap", StringComparison.CurrentCultureIgnoreCase))
                    propEnumMap = qualifier.Value;

                if (qualifier.Name.Equals("bitvalues", StringComparison.CurrentCultureIgnoreCase))
                {
                    propEnum = qualifier.Value;
                    enumBitMap = true;
                }

                if (qualifier.Name.Equals("bitmap", StringComparison.CurrentCultureIgnoreCase))
                    propEnumMap = qualifier.Value;

                if (qualifier.Name.Equals("bits", StringComparison.CurrentCultureIgnoreCase))
                {
                    propEnum = qualifier.Value;
                    enumBitMap = true;
                }

                if (qualifier.Name.Equals("enumeration", StringComparison.CurrentCultureIgnoreCase))
                    propEnum = qualifier.Value;

                if (qualifier.Name.Equals("stringenumeration", StringComparison.CurrentCultureIgnoreCase))
                    propEnum = qualifier.Value;

                propQualifiers += qualifier.Name + ", ";
            }

            // Qualifiers
            propQualifiers = propQualifiers.Substring(0, propQualifiers.Length - 2);
            helpBuilder.AppendLine("\nQualifiers: " + propQualifiers);

            // Description
            if (propDesc != String.Empty)
                helpBuilder.AppendLine("\n" + propDesc);
            else
                helpBuilder.AppendLine("\n[Description Not Available]");

            // Enumerations
            if (propEnum != null)
            {
                enumAvailable = true;
                helpBuilder.AppendLine(enumBitMap ? "\nPossible Bit Values: " : "\nPossible Enumeration Values: ");

                if (propEnum is String[])
                {
                    String[] tempPropEnum = propEnum as String[];

                    if (propEnumMap is String[])
                    {
                        String[] tempPropEnumMap = propEnumMap as String[];

                        for (int i = 0; i < tempPropEnum.Length; i++)
                        {
                            //TODO: This could fail if the number of elements in Values and ValueMap qualifiers are not same.
                            if (tempPropEnumMap[i] == tempPropEnum[i])
                                helpBuilder.AppendLine(tempPropEnum[i]);
                            else
                            {
                                if (enumBitMap)
                                    helpBuilder.AppendLine("Bit " + tempPropEnumMap[i] + " - " + tempPropEnum[i]);
                                else
                                    helpBuilder.AppendLine(tempPropEnumMap[i] + " - " + tempPropEnum[i]);
                            }
                        }
                    }
                    else if (propEnumMap is int[])
                    {
                        int[] tempPropEnumMap = propEnumMap as int[];

                        for (int i = 0; i < tempPropEnum.Length; i++)
                        {
                            //TODO: This could fail if the number of elements in Values and ValueMap qualifiers are not same.
                            if (tempPropEnumMap[i].ToString() == tempPropEnum[i])
                                helpBuilder.AppendLine(tempPropEnum[i]);
                            else
                            {
                                if (enumBitMap)
                                    helpBuilder.AppendLine("Bit " + tempPropEnumMap[i] + " - " + tempPropEnum[i]);
                                else
                                    helpBuilder.AppendLine(tempPropEnumMap[i] + " - " + tempPropEnum[i]);
                            }
                        }
                    }
                    else
                    {
                        foreach (string s in propEnum as String[])
                            helpBuilder.AppendLine(s);
                    }
                }

                if (propEnum is int[])
                {
                    foreach (int i in propEnum as int[])
                        helpBuilder.AppendLine(i.ToString(CultureInfo.InvariantCulture));
                }

                if (propEnum is String)
                {
                    foreach (string s in ((String)propEnum).Split(','))
                        helpBuilder.AppendLine(s);
                }
            }

            propertyHelp = helpBuilder.ToString();
        }

        private string GetPropertyNameWithType(PropertyData property)
        {
            var propName = property.Name;
            var propType = property.Type.ToString();
            bool propKey = false;

            foreach (QualifierData qualifier in property.Qualifiers)
            {
                if (qualifier.Name.Equals("key", StringComparison.CurrentCultureIgnoreCase))
                    propKey = true;
            }

            if (propKey) propName = "*" + propName;
            if (property.IsArray) propType += " []";

            // Display name
            string propNameWithType = propName + " - " + propType;

            return propNameWithType;
        }

        private void InitializeEnumOptions()
        {
            checkBoxSystem.Tag = EnumOptions.IncludeSystem;
            checkBoxCIM.Tag = EnumOptions.IncludeCim;
            checkBoxPerf.Tag = EnumOptions.IncludePerf;
            checkBoxMSFT.Tag = EnumOptions.IncludeMsft;
            checkNullProps.Tag = EnumOptions.ShowNullInstanceValues;
            checkSystemProps.Tag = EnumOptions.ShowSystemProperties;
        }

        private void InitializeForm()
        {
            // Start stopwatch to get Application load time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Setup default connection options
            _defaultConnection = new ConnectionOptions
            {
                EnablePrivileges = true,
                Impersonation = ImpersonationLevel.Impersonate,
                Authentication = AuthenticationLevel.Default,
                Username = null,
                SecurePassword = null
            };

            // Assign column sorter to listClasses, listClassProperties and listMethods
            _listClassesColumnSorter = new ListViewColumnSorter { SortColumn = 0, Order = SortOrder.Ascending };
            _listClassPropertiesColumnSorter = new ListViewColumnSorter { SortColumn = 0, Order = SortOrder.Ascending };
            _listMethodsColumnSorter = new ListViewColumnSorter { SortColumn = 0, Order = SortOrder.Ascending };
            _listSearchResultsColumnSorter = new ListViewColumnSorter { SortColumn = 0, Order = SortOrder.Ascending };
            listClasses.ListViewItemSorter = _listClassesColumnSorter;
            listClassProperties.ListViewItemSorter = _listClassPropertiesColumnSorter;
            listMethods.ListViewItemSorter = _listMethodsColumnSorter;
            listSearchResults.ListViewItemSorter = _listSearchResultsColumnSorter;

            // Check if Settings need to be updated on App Update
            if (Settings.Default.bUpgradeSettings)
                Utilities.UpdateSettings();

            Log("CLR Version: " + Environment.Version);

            // Check .NET Version
            // RTM build of .NET 4.5 = 4.0.30319.17929
            // RTM build of .NET 4.5 January 2013 Update= 4.0.30319.18033
            // RTM build of .NET 4.5.1 October 2013 Update= 4.0.30319.18408
            // RTM build of .NET 4.5.2 May 2014 Update = 4.0.30319.34209
            if (Environment.Version >= new Version(4, 0, 30319, 17929) && Environment.Version < new Version(4, 0, 30319, 18033))
            {
                if (MessageBox.Show(
                    "You are running .NET 4.5 but .NET 4.5.1 is NOT installed. " +
                    "Please install .NET 4.5.1 to fix a known issue (Bad Layout in Query tab) in WMI Explorer.\n\n" +
                    "Would you like to download .NET 4.5.1 now ?",
                    "WMI Explorer - Known Issue Detected",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation
                    ) == DialogResult.Yes)
                {
                    Process.Start("http://msdn.microsoft.com/en-us/library/5a4x27ek(v=vs.110).aspx");
                    Close();
                }
            }

            // Initialize Form UI
            InitializeFormUi();

            // Check for update if Update check is enabled. Make sure this is called after InitializeFormUi()
            _changeLogPath = Environment.GetEnvironmentVariable("TEMP") + "\\WmieChangelog.TXT";
            if (Settings.Default.bCheckForUpdates)
                UpdateCheck();

            // Set Cache Policy
            CachePolicy.SlidingExpiration = TimeSpan.FromMinutes(Convert.ToDouble(Settings.Default.CacheAgeInMinutes));

            stopwatch.Stop();
            Log("Application Load Time = " + stopwatch.Elapsed);
        }

        private void InitializeFormUi()
        {
            // Resize Query layout based on current DPI settings
            Graphics g = this.CreateGraphics();
            DisplayDpi = Convert.ToInt32(g.DpiX);
            if (DisplayDpi > 96)
            {
                splitContainerQuery.SplitterDistance += (DisplayDpi - 96);
                splitContainerQuery.Panel1MinSize = splitContainerQuery.SplitterDistance;
            }

            // Log current display DPI setting
            Log("Display DPI Settings: " + DisplayDpi.ToString(CultureInfo.InvariantCulture) + "dpi");

#if DEBUG
            Text = "WMI Explorer (Beta Debug Build)";
#endif

            // Check if we're running Elevated
            if (Utilities.CheckIfElevated())
                Text += " (Administrator)";

            // Remove Debug tabs
            tabControlClasses.Controls.Remove(tabDebug1);
            tabControlInstances.Controls.Remove(tabDebug2);

            // Set all Status Labels to blank strings
            toolStripLabel1.Text = String.Empty;
            toolStripLabel2.Text = String.Empty;
            toolStripLabel3.Text = String.Empty;
            toolStripLabelUpdateNotification.Text = String.Empty;

            // Restore Window Placement
            if (Settings.Default.bPreserveLayout)
            {
                WindowPlacement.SetPlacement(this.Handle, Settings.Default.WindowPlacement);
                splitContainerNamespaceClasses.SplitterDistance = Settings.Default.SplitterDistanceNamespaces;
                splitContainerClassesInstances.SplitterDistance = Settings.Default.SplitterDistanceClasses;
                splitContainerInstancesProperties.SplitterDistance = Settings.Default.SplitterDistanceInstances;
            }

            // Load Recent Paths if RememberRecentPaths is set to true
            if (Settings.Default.bRememberRecentPaths)
                LoadRecentPaths();

            // Initialize EnumOptions for enumeration checkboxes
            InitializeEnumOptions();

            // Populate enumeration mode and options
            if (Settings.Default.bRememberEnumOptions)
            {
                // Select checkboxes
                PopulateEnumCheckboxes();

                // Set Enum Mode
                if (Settings.Default.bEnumModeAsync)
                    radioModeAsync.Checked = true;
                else
                    radioModeSync.Checked = true;
            }
            else
                radioModeAsync.Checked = true;

            // SMS Mode
            menuItemFile_SmsMode.Checked = Settings.Default.bSmsMode;

            // Hide list view and show datagrid view for query results
            splitContainerQueryResults.Visible = radioQueryOutListView.Checked;
            dataGridQueryResults = new DataGridView
            {
                Parent = groupBoxQueryResults,
                Dock = DockStyle.Fill,
                Visible = radioQueryOutDataGrid.Checked
            };

            // Resize property grid description area to 6 lines
            ResizePropertyGridDescription(propertyGridInstance, 6);
        }

        private void InitiateAction(object sender, EventArgs e)
        {
            TreeNode currentNode = treeNamespaces.SelectedNode;
            SmsClient smsClient = Helpers.GetSmsClient(currentNode);
            var actionItem = (ToolStripMenuItem)sender;
            SmsClientAction action = actionItem.Tag as SmsClientAction;

            if (action != null)
            {
                try
                {
                    ManagementBaseObject inParams = smsClient.SmsClientClass.GetMethodParameters("TriggerSchedule");
                    inParams["sScheduleId"] = action.Id;
                    ManagementBaseObject outParams = smsClient.SmsClientClass.InvokeMethod("TriggerSchedule", inParams, null);

                    if (outParams != null)
                    {
                        SetStatusBar2("Successfully triggered " + action.DisplayName + " action.", MessageCategory.Sms, true);
                        //MessageBox.Show("Successfully triggered " + action.DisplayName + ".",
                        //    "Initiate Client Action",
                        //    MessageBoxButtons.OK,
                        //    MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    SetStatusBar2("Failed to trigger " + action.DisplayName + " action. Error: " + ex.Message, MessageCategory.Error, true);
                    //MessageBox.Show("Failed to trigger " + action.DisplayName + ". Error: " + ex.Message,
                    //    "Initiate Client Action",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Error);
                }
            }
        }

        private void InvokeClassMethod(object sender, EventArgs e)
        {
            ManagementClass mClass = (listClasses.SelectedItems[0].Tag as WmiClass).Class;
            MethodData method = ((ToolStripMenuItem)sender).Tag as MethodData;

            Form_ExecMethod execMethodForm = new Form_ExecMethod(mClass, method);
            execMethodForm.CenterForm(this).Show(this);
        }

        private void InvokeInstanceMethod(object sender, EventArgs e)
        {
            ManagementObject mObject = (listInstances.SelectedItems[0].Tag as WmiInstance).Instance;
            MethodData method = ((ToolStripMenuItem)sender).Tag as MethodData;

            Form_ExecMethod execMethodForm = new Form_ExecMethod(mObject, method);
            execMethodForm.CenterForm(this).Show(this);
        }

        private void LoadRecentPaths()
        {
            // Initialize RecentPaths if it's null
            if (Settings.Default.RecentPaths == null)
                Settings.Default.RecentPaths = new StringCollection();

            // Populate nodes as Disconnected
            foreach (var path in Settings.Default.RecentPaths)
            {
                WmiNode wmiNode = new WmiNode { IsRootNode = true, UserSpecifiedPath = path };
                wmiNode.SetConnection(_defaultConnection);

                TreeNode treeNode = new TreeNode
                {
                    Name = wmiNode.UserSpecifiedPath,
                    Text = wmiNode.UserSpecifiedPath + " (Disconnected)",
                    Tag = wmiNode
                };

                treeNamespaces.Nodes.Add(treeNode);
            }
        }

        private void LogSettings()
        {
            textBoxLogging.Text += "\r\n";
            Log("Application Settings:\r\n" + Utilities.GetSettings());
        }

        private void NotifyClassError(ListViewItem currentListViewItem, string message)
        {
            currentListViewItem.BackColor = ColorCategory.Error;
            SetStatusBar2(message, MessageCategory.Error, true);
        }

        private void NotifyNodeError(TreeNode treeNode, string message)
        {
            treeNode.BackColor = ColorCategory.Error;
            treeNode.ToolTipText = message;
            SetStatusBar1(message, MessageCategory.Error, true);
            SetStatusBar2(String.Empty, MessageCategory.Error);
        }

        private void PopulateClassProperties(WmiClass wmiClass)
        {
            ResetListClassProperties();
            listClassProperties.BeginUpdate();

            string superClass = String.Empty;
            if (wmiClass.Class.Derivation != null)
            {
                foreach (String cls in wmiClass.Class.Derivation)
                {
                    superClass += cls + ", ";
                }
            }

            if (superClass != String.Empty)
            {
                superClass = superClass.Substring(0, superClass.Length - 2);
                AppendClassHelp("\n" + wmiClass.DisplayName + " Class : " + superClass, FontStyle.Bold);
            }
            else
                AppendClassHelp("\n" + wmiClass.DisplayName + " Class", FontStyle.Bold);

            string classDesc = listClasses.SelectedItems[0].SubItems[2].Text;

            if (String.IsNullOrEmpty(classDesc))
                AppendClassHelp("\n[Class Description Not Available]");
            else
                AppendClassHelp("\n" + classDesc);

            //AppendClassHelp("\nSyntax:", FontStyle.Bold);
            //AppendClassHelp("\n" + wmiClass.GetClassMof());

            AppendClassHelp("\nClass Qualifiers:\n", FontStyle.Bold);

            foreach (QualifierData qualifier in wmiClass.Class.Qualifiers)
            {
                if (qualifier.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                    AppendClassHelp(qualifier.Name);
                else
                    AppendClassHelp(qualifier.Name + " - " + qualifier.Value);
            }

            AppendClassHelp("\nProperties:", FontStyle.Bold);

            if (wmiClass.Class.Properties.Count > 0)
            {
                foreach (PropertyData property in wmiClass.Class.Properties)
                {
                    string propName = property.Name;
                    string propDesc = String.Empty;
                    bool propLazy = false;
                    string propType = property.Type.ToString();
                    if (property.IsArray) propType += " []";

                    foreach (QualifierData qualifier in property.Qualifiers)
                    {
                        if (qualifier.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                            propDesc = qualifier.Value.ToString();

                        if (qualifier.Name.Equals("lazy", StringComparison.CurrentCultureIgnoreCase))
                            propLazy = true;
                    }

                    AppendClassHelp("\n" + GetPropertyNameWithType(property), FontStyle.Italic);

                    bool propEnumAvailable;
                    string propHelp;
                    GetPropertyHelp(property, out propEnumAvailable, out propHelp);

                    AppendClassHelp(propHelp);

                    // Add to list
                    ListViewItem listItem = new ListViewItem
                    {
                        Name = propName,
                        Text = propName,
                        ToolTipText = propDesc,
                        Tag = property
                    };
                    listItem.SubItems.Add(propType);
                    listItem.SubItems.Add(propEnumAvailable.ToString());
                    listItem.SubItems.Add(propLazy.ToString());
                    listItem.SubItems.Add(propDesc);

                    listClassProperties.Items.Add(listItem);
                }
            }
            else
                AppendClassHelp("\nThis class has no Properties.");

            listClassProperties.Sorting = SortOrder.Ascending;
            listClassProperties.Sort();
            listClassProperties.ResizeColumns();
            listClassProperties.SetSortIcon(_listClassPropertiesColumnSorter.SortColumn, _listClassPropertiesColumnSorter.Order);
            listClassProperties.EndUpdate();

            AppendClassHelp("\nSearch Online Documentation:", FontStyle.Bold);
            AppendClassHelp("http://www.bing.com/search?q=" + wmiClass.DisplayName + "+WMI+Class", FontStyle.Regular, true, false);

            //AppendClassHelp("\nStandard WMI Qualifiers:", FontStyle.Bold);
            //AppendClassHelp("http://msdn.microsoft.com/en-us/library/aa393650(v=vs.85).aspx", FontStyle.Regular, true, false);

            tabProperties.Text = "Properties (" + wmiClass.Class.Properties.Count + ")";
        }

        private void PopulateEnumCheckboxes()
        {
            EnumOptions flags = Settings.Default.EnumOptionsFlags;

            if (flags == EnumOptions.None)
                return;

            if (flags.HasFlag(EnumOptions.IncludeSystem))
                checkBoxSystem.Checked = true;

            if (flags.HasFlag(EnumOptions.IncludeCim))
                checkBoxCIM.Checked = true;

            if (flags.HasFlag(EnumOptions.IncludePerf))
                checkBoxPerf.Checked = true;

            if (flags.HasFlag(EnumOptions.IncludeMsft))
                checkBoxMSFT.Checked = true;

            if (flags.HasFlag(EnumOptions.ShowNullInstanceValues))
                checkNullProps.Checked = true;

            if (flags.HasFlag(EnumOptions.ShowSystemProperties))
                checkSystemProps.Checked = true;
        }

        private void PopulateInstanceProperties(ListViewItem currentListViewItem, bool refreshObject = false)
        {
            WmiInstance wmiInstance = currentListViewItem.Tag as WmiInstance;
            if (wmiInstance == null)
            {
                currentListViewItem.BackColor = ColorCategory.Error;
                const string message = "Failed to display Properties for selected instance. PopulateInstanceProperties - Current Instance is null.";
                SetStatusBar2(message, MessageCategory.Error, true);
                return;
            }

            try
            {
                ManagementBaseObjectW mObjectW;

                if (refreshObject)
                {
                    ManagementObject mObject = new ManagementObject(wmiInstance.Path);
                    mObjectW = new ManagementBaseObjectW(mObject)
                    {
                        IncludeNullProperties = checkNullProps.Checked,
                        IncludeSystemProperties = checkSystemProps.Checked
                    };
                }
                else
                {
                    mObjectW = new ManagementBaseObjectW(wmiInstance.Instance)
                    {
                        IncludeNullProperties = checkNullProps.Checked,
                        IncludeSystemProperties = checkSystemProps.Checked
                    };
                }

                // Some objects don't allow refreshing. Call GetText to see if we get an error, and set the Mof to be used for Show/Copy MOF
                _instanceMof = mObjectW.GetText(TextFormat.Mof).Replace("\n", "\r\n");

                propertyGridInstance.SelectedObject = mObjectW;
                currentListViewItem.BackColor = ColorCategory.Info;
            }
            catch (Exception ex)
            {
                string message = String.Format("Failed to {0}. Error: {1}", refreshObject ? "Refresh Object" : "Populate Instance Properties", ex.Message);
                if (!refreshObject) currentListViewItem.BackColor = ColorCategory.Error;
                SetStatusBar2(message, MessageCategory.Error);
            }
        }

        private void PopulateListClasses(List<ListViewItem> items, string filterText = "", bool notFilter = false)
        {
            ResetListClasses();
            listClasses.BeginUpdate();

            if (String.IsNullOrEmpty(filterText))
            {
                listClasses.Items.AddRange(items.ToArray());
            }
            else
            {
                foreach (ListViewItem l in items)
                {
                    if (notFilter && !l.Text.ToLower().Contains(filterText))
                        listClasses.Items.Add(l);

                    if (!notFilter & l.Text.ToLower().Contains(filterText))
                        listClasses.Items.Add(l);
                }
            }

            listClasses.Sort();
            listClasses.SetSortIcon(_listClassesColumnSorter.SortColumn, _listClassesColumnSorter.Order);
            listClasses.EndUpdate();

            // Ensure previously selected item is visible in the list by scrolling to it.
            if (listClasses.SelectedItems.Count > 0)
                listClasses.EnsureVisible(listClasses.SelectedItems[0].Index);
        }

        private void PopulateListInstances(List<ListViewItem> items, string filterText = "", bool notFilter = false)
        {
            ResetListInstances();
            listInstances.BeginUpdate();

            if (String.IsNullOrEmpty(filterText))
            {
                listInstances.Items.AddRange(items.ToArray());
            }
            else
            {
                foreach (ListViewItem l in items)
                {
                    if (notFilter && !l.Text.ToLower().Contains(filterText))
                        listInstances.Items.Add(l);

                    if (!notFilter && l.Text.ToLower().Contains(filterText))
                        listInstances.Items.Add(l);
                }
            }

            listInstances.Sorting = SortOrder.Ascending;
            listInstances.Sort();
            listInstances.ResizeColumns();
            listInstances.EndUpdate();

            // Ensure previously selected item is visible in the list by scrolling to it.
            if (listInstances.SelectedItems.Count > 0)
                listInstances.EnsureVisible(listInstances.SelectedItems[0].Index);
        }

        private void PopulateMethodHelp(MethodData methodData)
        {
            ResetListMethodParams();

            AppendMethodHelp("\n" + methodData.Name + " method of the " + methodData.Origin + " class", FontStyle.Bold);
            string methodDesc = listMethods.SelectedItems[0].SubItems[2].Text;

            if (String.IsNullOrEmpty(methodDesc))
                AppendMethodHelp("\n[Method Description Not Available]");
            else
                AppendMethodHelp("\n" + methodDesc);

            AppendMethodHelp("\nExecution:\n", FontStyle.Bold);

            string methodStatic = listMethods.SelectedItems[0].SubItems[1].Text;

            AppendMethodHelp(
                methodStatic.Equals("True", StringComparison.CurrentCultureIgnoreCase)
                    ? "This method is static, which means you can use this method without creating an instance of this class. To execute this method, right click on the Class."
                    : "This method is not static, which means you need an instance of this class to execute this method. To execute this method, right click on the Instance.");

            // Method In Params
            AppendMethodHelp("\nInput Parameters:", FontStyle.Bold);

            if (methodData.InParameters != null)
            {
                if (methodData.InParameters.Properties.Count == 0)
                    AppendMethodHelp("\nThis method has no Input parameters.");

                foreach (PropertyData inParam in methodData.InParameters.Properties)
                {
                    string paramId = String.Empty;
                    string paramDesc = String.Empty;
                    string paramType = String.Empty;
                    bool paramOptional = false;

                    foreach (QualifierData qualifier in inParam.Qualifiers)
                    {
                        if (qualifier.Name.Equals("ID", StringComparison.CurrentCultureIgnoreCase))
                            paramId = qualifier.Value.ToString();

                        if (qualifier.Name.Equals("CIMTYPE", StringComparison.CurrentCultureIgnoreCase))
                            paramType = qualifier.Value.ToString();

                        if (qualifier.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                            paramDesc = qualifier.Value.ToString();

                        if (qualifier.Name.Equals("Optional", StringComparison.CurrentCultureIgnoreCase))
                            paramOptional = true;
                    }

                    if (inParam.IsArray) paramType += " []";

                    string paramDisplayName = inParam.Name + " - " + paramType;
                    if (paramOptional) paramDisplayName = "(Optional) " + paramDisplayName;

                    AppendMethodHelp("\n" + paramDisplayName, FontStyle.Italic);

                    bool enumAvailable = false;
                    string propHelp = String.Empty;
                    GetPropertyHelp(inParam, out enumAvailable, out propHelp);
                    AppendMethodHelp(propHelp);

                    ListViewItem listItem = new ListViewItem
                    {
                        Name = paramId,
                        Text = paramId,
                        ToolTipText = paramDesc,
                        Tag = inParam
                    };

                    listItem.SubItems.Add(inParam.Name);
                    listItem.SubItems.Add(paramType);
                    listItem.SubItems.Add(paramDesc);

                    listMethodParamsIn.Items.Add(listItem);
                }
            }
            else
            {
                AppendMethodHelp("\nThis method has no Input parameters.");
            }

            // Method Out Params
            AppendMethodHelp("\nOutput Parameters:", FontStyle.Bold);

            if (methodData.OutParameters != null)
            {
                if (methodData.OutParameters.Properties.Count == 0)
                    AppendMethodHelp("\nThis method has no Output parameters.");

                foreach (PropertyData outParam in methodData.OutParameters.Properties)
                {
                    string paramDesc = String.Empty;
                    string paramType = String.Empty;
                    bool paramOptional = false;

                    foreach (QualifierData qualifier in outParam.Qualifiers)
                    {
                        if (qualifier.Name.Equals("CIMTYPE", StringComparison.CurrentCultureIgnoreCase))
                            paramType = qualifier.Value.ToString();

                        if (qualifier.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                            paramDesc = qualifier.Value.ToString();

                        if (qualifier.Name.Equals("Optional", StringComparison.CurrentCultureIgnoreCase))
                            paramOptional = true;
                    }

                    if (outParam.IsArray) paramType += " []";

                    string paramDisplayName = outParam.Name + " - " + paramType;
                    if (paramOptional) paramDisplayName = "(Optional) " + paramDisplayName;

                    AppendMethodHelp("\n" + paramDisplayName, FontStyle.Italic);

                    bool enumAvailable = false;
                    string propHelp = String.Empty;
                    GetPropertyHelp(outParam, out enumAvailable, out propHelp);
                    AppendMethodHelp(propHelp);

                    ListViewItem listItem = new ListViewItem
                    {
                        Name = outParam.Name,
                        Text = outParam.Name,
                        ToolTipText = paramDesc,
                        Tag = outParam
                    };

                    listItem.SubItems.Add(paramType);
                    listItem.SubItems.Add(paramDesc);

                    listMethodParamsOut.Items.Add(listItem);
                }
            }
            else
            {
                AppendMethodHelp("\nThis method has no Output parameters.");
            }

            // Sort and Resize Columns for In Params
            listMethodParamsIn.Sorting = SortOrder.Ascending;
            listMethodParamsIn.Sort();
            listMethodParamsIn.ResizeColumns();

            // Sort and Resize Columns for Out Params
            listMethodParamsOut.Sorting = SortOrder.Ascending;
            listMethodParamsOut.Sort();
            listMethodParamsOut.ResizeColumns();

            AppendMethodHelp("\nSearch Online Documentation:", FontStyle.Bold);
            AppendMethodHelp("http://www.bing.com/search?q=" + methodData.Name + "+Method+of+the+" + methodData.Origin + "+Class", FontStyle.Regular, true, false);
        }

        private void PopulateMethods(WmiClass wmiClass)
        {
            ResetListMethods();

            var cachedItem = AppCache[wmiClass.Path + "_Methods"];
            if (cachedItem != null)
            {
                // Get cached methods and add to list
                ListViewItem[] lc = (ListViewItem[])cachedItem;
                listMethods.Items.AddRange(lc);
                tabMethods.Text = "Methods (" + wmiClass.Class.Methods.Count + ")";
            }
            else
            {
                foreach (MethodData method in wmiClass.Class.Methods)
                {
                    string methodDesc = String.Empty;
                    bool methodStatic = false;

                    foreach (QualifierData qualifier in method.Qualifiers)
                    {
                        if (qualifier.Name.Equals("Static", StringComparison.CurrentCultureIgnoreCase))
                            methodStatic = true;

                        if (qualifier.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                            methodDesc = qualifier.Value.ToString();
                    }

                    ListViewItem li = new ListViewItem
                    {
                        Name = method.Name,
                        Text = method.Name,
                        ToolTipText = methodDesc,
                        Tag = method
                    };
                    li.SubItems.Add(methodStatic.ToString());
                    li.SubItems.Add(methodDesc);

                    listMethods.Items.Add(li);
                }

                // Add to cache
                ListViewItem[] methods = new ListViewItem[listMethods.Items.Count];
                listMethods.Items.CopyTo(methods, 0);
                CacheItem cacheItem = new CacheItem(wmiClass.Path + "_Methods", methods);
                AppCache.Set(cacheItem, CachePolicy);
            }

            listMethods.Sorting = SortOrder.Ascending;
            listMethods.Sort();
            listMethods.ResizeColumns();
            listMethods.SetSortIcon(_listMethodsColumnSorter.SortColumn, _listMethodsColumnSorter.Order);
            tabMethods.Text = "Methods (" + wmiClass.Class.Methods.Count + ")";
        }

        private void RenameClassTabsToDefault()
        {
            tabInstances.Text = "Instances";
            tabProperties.Text = "Properties";
            tabMethods.Text = "Methods";
            textBoxInstanceFilterQuick.Text = String.Empty;
        }

        private void RenameNamespaceTabsToDefault()
        {
            tabClasses.Text = "Classes";
            RenameClassTabsToDefault();
        }

        private void ResetListClasses()
        {
            // Clear list view and add columns.
            listClasses.Clear();
            listClasses.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listClasses.Columns.Add("Lazy Properties", 50, HorizontalAlignment.Left);
            listClasses.Columns.Add("Description", 150, HorizontalAlignment.Left);
            listClasses.Columns.Add("Path", 150, HorizontalAlignment.Left);
        }

        private void ResetListClassProperties()
        {
            listClassProperties.Clear();
            listClassProperties.Columns.Add("Property Name", -2, HorizontalAlignment.Left);
            listClassProperties.Columns.Add("Type", -2, HorizontalAlignment.Left);
            listClassProperties.Columns.Add("Enumeration Available", -2, HorizontalAlignment.Left);
            listClassProperties.Columns.Add("Lazy", -2, HorizontalAlignment.Left);
            listClassProperties.Columns.Add("Description", -2, HorizontalAlignment.Left);
            listClassProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            richTextBoxClassDetails.Clear();
        }

        private void ResetListInstances()
        {
            listInstances.Clear();
            listInstances.Columns.Add("Instances", -2, HorizontalAlignment.Left);
        }

        private void ResetListMethodParams()
        {
            // Clear In Params
            listMethodParamsIn.Clear();
            listMethodParamsIn.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listMethodParamsIn.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listMethodParamsIn.Columns.Add("Type", -2, HorizontalAlignment.Left);
            listMethodParamsIn.Columns.Add("Description", -2, HorizontalAlignment.Left);
            listMethodParamsIn.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // Clear Out Params
            listMethodParamsOut.Clear();
            listMethodParamsOut.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listMethodParamsOut.Columns.Add("Type", -2, HorizontalAlignment.Left);
            listMethodParamsOut.Columns.Add("Description", -2, HorizontalAlignment.Left);
            listMethodParamsOut.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            // Clear Help Text
            richTextBoxMethodDetails.Clear();
        }

        private void ResetListMethods()
        {
            listMethods.Clear();
            listMethods.Columns.Add("Method Name", -2, HorizontalAlignment.Left);
            listMethods.Columns.Add("Static", -2, HorizontalAlignment.Left);
            listMethods.Columns.Add("Description", -2, HorizontalAlignment.Left);
            listMethods.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ResetListMethodParams();
            richTextBoxMethodDetails.Clear();
        }

        private void ResetListQueryResults()
        {
            listQueryResults.Clear();
            listQueryResults.Columns.Add("Results", 150, HorizontalAlignment.Left);
            groupBoxQueryResults.Text = "Results";
        }

        private void ResizePropertyGridDescription(PropertyGrid grid, int lines)
        {
            try
            {
                var info = grid.GetType().GetProperty("Controls");
                var collection = (Control.ControlCollection)info.GetValue(grid, null);

                foreach (var control in collection)
                {
                    var type = control.GetType();

                    if ("DocComment" == type.Name)
                    {
                        const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
                        var field = type.BaseType.GetField("userSized", Flags);
                        field.SetValue(control, true);

                        info = type.GetProperty("Lines");
                        info.SetValue(control, lines, null);

                        grid.HelpVisible = true;
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                Log("Error resizing Property Description: " + ex.Message);
            }
        }

        private void SearchClasses(string searchPattern, WmiNode currentWmiNode)
        {
            string sNamespace = currentWmiNode.WmiNamespace.Path;
            ConnectionOptions connection = Helpers.GetRootNodeCredentials(treeNamespaces.SelectedNode);
            bool bRecurse = checkBoxSearchRecurse.Checked;

            // Clear list view
            listSearchResults.Clear();
            listSearchResults.Columns.Add("Class Name", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Lazy Properties", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Path", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Description", -2, HorizontalAlignment.Left);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Cursor = Cursors.WaitCursor;
            SetStatusBar2("Searching classes in " + sNamespace + " that match search pattern: " + searchPattern, MessageCategory.Action, true);

            listSearchResults.BeginUpdate();

            string queryString = CreateClassEnumQuery(searchPattern);
            SearchClassesRecurse(sNamespace, queryString, bRecurse, connection);

            listSearchResults.Sorting = SortOrder.Ascending;
            listSearchResults.Sort();
            listSearchResults.ResizeColumns();
            listSearchResults.SetSortIcon(_listSearchResultsColumnSorter.SortColumn, _listSearchResultsColumnSorter.Order);
            listSearchResults.EndUpdate();

            Cursor = Cursors.Default;
            stopwatch.Stop();
            SetStatusBar3("Search Classes", stopwatch.Elapsed);

            if (!_searchErrorOccurred)
            {
                SetStatusBar2("Search completed successfully and found " + _searchResultCount + " results.", MessageCategory.Info);
            }
            else
            {
                SetStatusBar2("Search completed with errors and found " + _searchResultCount + " results.", MessageCategory.Warn);
            }
        }

        private void SearchClassesRecurse(string sNamespace, string queryString, bool bRecurse, ConnectionOptions connection)
        {
            // Skip root\directory\ldap namespace from search
            if (sNamespace.ToLower().Contains("root\\directory\\ldap"))
            {
                Log("Skipping ROOT\\directory\\LDAP namespace as it can take a very long time");
                return;
            }

            SetStatusBar2("Searching classes in " + sNamespace + "...", MessageCategory.Action);

            try
            {
                ManagementScope scope = new ManagementScope(sNamespace, connection);
                ObjectQuery query = new ObjectQuery(queryString);
                EnumerationOptions eOptions = new EnumerationOptions { EnumerateDeep = true, UseAmendedQualifiers = true };

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query, eOptions);
                foreach (ManagementClass mClass in (from ManagementClass mClass in searcher.Get()
                                                    orderby mClass.Path.ClassName
                                                    select mClass))
                {
                    _searchResultCount++;
                    WmiClass wmiClass = new WmiClass(mClass);

                    ListViewItem li = new ListViewItem
                    {
                        Name = wmiClass.Path,
                        Text = wmiClass.DisplayName,
                        ToolTipText = wmiClass.Description
                    };
                    li.SubItems.Add(wmiClass.HasLazyProperties.ToString());
                    li.SubItems.Add(wmiClass.Path);
                    li.SubItems.Add(wmiClass.Description);

                    // Add item to list view
                    listSearchResults.Items.Add(li);
                }

                if (bRecurse)
                {
                    // Get and search child namespaces
                    query = new ObjectQuery("SELECT * FROM __Namespace");
                    searcher = new ManagementObjectSearcher(scope, query);
                    foreach (ManagementObject mObject in searcher.Get())
                    {
                        sNamespace = "\\\\" + mObject.Path.Server + "\\" + mObject.Path.NamespacePath + "\\" + mObject.GetPropertyValue("Name");
                        SearchClassesRecurse(sNamespace, queryString, true, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusBar2("Error searching classes within " + sNamespace + " namespace. " + ex.Message, MessageCategory.Error, true);
                _searchErrorOccurred = true;
            }
        }

        private void SearchMethods(string searchPattern, WmiNode currentWmiNode)
        {
            string sNamespace = currentWmiNode.WmiNamespace.Path;
            ConnectionOptions connection = Helpers.GetRootNodeCredentials(treeNamespaces.SelectedNode);
            bool bRecurse = checkBoxSearchRecurse.Checked;

            // Clear list view
            listSearchResults.Clear();
            listSearchResults.Columns.Add("Method Name", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Class", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Static", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Namespace", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Description", -2, HorizontalAlignment.Left);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Cursor = Cursors.WaitCursor;
            SetStatusBar2("Searching methods in " + sNamespace + " that match search pattern: " + searchPattern, MessageCategory.Action, true);

            listSearchResults.BeginUpdate();

            string queryString = CreateClassEnumQuery("%");
            SearchMethodsRecurse(sNamespace, queryString, searchPattern, bRecurse, connection);

            listSearchResults.Sorting = SortOrder.Ascending;
            listSearchResults.Sort();
            listSearchResults.ResizeColumns();
            listSearchResults.SetSortIcon(_listSearchResultsColumnSorter.SortColumn, _listSearchResultsColumnSorter.Order);
            listSearchResults.EndUpdate();

            Cursor = Cursors.Default;
            stopwatch.Stop();
            SetStatusBar3("Search Methods", stopwatch.Elapsed);

            if (!_searchErrorOccurred)
            {
                SetStatusBar2("Search completed successfully and found " + _searchResultCount + " results.", MessageCategory.Info);
            }
            else
            {
                SetStatusBar2("Search completed with errors and found " + _searchResultCount + " results.", MessageCategory.Warn);
            }
        }

        private void SearchMethodsRecurse(string sNamespace, string queryString, string searchPattern, bool bRecurse, ConnectionOptions connection)
        {
            // Skip root\directory\ldap namespace from search
            if (sNamespace.ToLower().Contains("root\\directory\\ldap"))
            {
                Log("Skipping ROOT\\directory\\LDAP namespace as it can take a very long time");
                return;
            }

            SetStatusBar2("Searching methods in " + sNamespace + "...", MessageCategory.Action);

            try
            {
                ManagementScope scope = new ManagementScope(sNamespace, connection);
                ObjectQuery query = new ObjectQuery(queryString);
                EnumerationOptions eOptions = new EnumerationOptions { EnumerateDeep = true, UseAmendedQualifiers = true };

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query, eOptions);
                foreach (ManagementClass mClass in (from ManagementClass mClass in searcher.Get()
                                                    orderby mClass.Path.ClassName
                                                    select mClass))
                {
                    if (mClass.Methods.Count == 0) continue;

                    foreach (MethodData method in mClass.Methods)
                    {
                        if (method.Name.ToLower().Contains(searchPattern.ToLower()) || searchPattern == "%")
                        {
                            _searchResultCount++;
                            string methodDesc = String.Empty;
                            bool methodStatic = false;

                            // Set method Static and Description.
                            foreach (QualifierData qd in method.Qualifiers)
                            {
                                if (qd.Name.Equals("Static", StringComparison.CurrentCultureIgnoreCase))
                                    methodStatic = true;

                                if (qd.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                                    methodDesc = qd.Value.ToString();
                            }

                            ListViewItem li = new ListViewItem
                            {
                                Name = mClass.Path.NamespacePath + "_" + mClass.Path.ClassName + "_" + method.Name,
                                Text = method.Name,
                                ToolTipText = methodDesc
                            };

                            li.SubItems.Add(mClass.Path.ClassName);
                            li.SubItems.Add(methodStatic.ToString());
                            li.SubItems.Add(sNamespace);
                            li.SubItems.Add(methodDesc);

                            listSearchResults.Items.Add(li);
                        }
                    }
                }

                if (bRecurse)
                {
                    // Get and search child namespaces
                    query = new ObjectQuery("SELECT * FROM __Namespace");
                    searcher = new ManagementObjectSearcher(scope, query);
                    foreach (ManagementObject mObject in searcher.Get())
                    {
                        sNamespace = "\\\\" + mObject.Path.Server + "\\" + mObject.Path.NamespacePath + "\\" + mObject.GetPropertyValue("Name");
                        SearchMethodsRecurse(sNamespace, queryString, searchPattern, true, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusBar2("Error searching methods within " + sNamespace + " namespace. " + ex.Message, MessageCategory.Error, true);
                _searchErrorOccurred = true;
            }
        }

        private void SearchProperties(string searchPattern, WmiNode currentWmiNode)
        {
            string sNamespace = currentWmiNode.WmiNamespace.Path;
            ConnectionOptions connection = Helpers.GetRootNodeCredentials(treeNamespaces.SelectedNode);
            bool bRecurse = checkBoxSearchRecurse.Checked;

            // Clear list view
            listSearchResults.Clear();
            listSearchResults.Columns.Add("Property Name", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Class", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Lazy", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Namespace", -2, HorizontalAlignment.Left);
            listSearchResults.Columns.Add("Description", -2, HorizontalAlignment.Left);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Cursor = Cursors.WaitCursor;
            SetStatusBar2("Searching properties in " + sNamespace + " that match search pattern: " + searchPattern, MessageCategory.Action, true);

            listSearchResults.BeginUpdate();

            string queryString = CreateClassEnumQuery("%");
            SearchPropertiesRecurse(sNamespace, queryString, searchPattern, bRecurse, connection);

            listSearchResults.Sorting = SortOrder.Ascending;
            listSearchResults.Sort();
            listSearchResults.ResizeColumns();
            listSearchResults.SetSortIcon(_listSearchResultsColumnSorter.SortColumn, _listSearchResultsColumnSorter.Order);
            listSearchResults.EndUpdate();

            Cursor = Cursors.Default;
            stopwatch.Stop();
            SetStatusBar3("Search Properties", stopwatch.Elapsed);

            if (!_searchErrorOccurred)
            {
                SetStatusBar2("Search completed successfully and found " + _searchResultCount + " results.", MessageCategory.Info);
            }
            else
            {
                SetStatusBar2("Search completed with errors and found " + _searchResultCount + " results.", MessageCategory.Warn);
            }
        }

        private void SearchPropertiesRecurse(string sNamespace, string queryString, string searchPattern, bool bRecurse, ConnectionOptions connection)
        {
            // Skip root\directory\ldap namespace from search
            if (sNamespace.ToLower().Contains("root\\directory\\ldap"))
            {
                Log("Skipping ROOT\\directory\\LDAP namespace as it can take a very long time");
                return;
            }

            SetStatusBar2("Searching properties in " + sNamespace + "...", MessageCategory.Action);

            try
            {
                ManagementScope scope = new ManagementScope(sNamespace, connection);
                ObjectQuery query = new ObjectQuery(queryString);
                EnumerationOptions eOptions = new EnumerationOptions { EnumerateDeep = true, UseAmendedQualifiers = true };

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query, eOptions);
                foreach (ManagementClass mClass in (from ManagementClass mClass in searcher.Get()
                                                    orderby mClass.Path.ClassName
                                                    select mClass))
                {
                    if (mClass.Properties.Count == 0) continue;

                    foreach (PropertyData property in mClass.Properties)
                    {
                        if (property.Name.ToLower().Contains(searchPattern.ToLower()) || searchPattern == "%")
                        {
                            _searchResultCount++;
                            string propDesc = String.Empty;
                            bool propLazy = false;

                            // Set method Static and Description.
                            foreach (QualifierData qd in property.Qualifiers)
                            {
                                if (qd.Name.Equals("lazy", StringComparison.CurrentCultureIgnoreCase))
                                    propLazy = true;

                                if (qd.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase))
                                    propDesc = qd.Value.ToString();
                            }

                            ListViewItem li = new ListViewItem
                            {
                                Name = mClass.Path.NamespacePath + "_" + mClass.Path.ClassName + "_" + property.Name,
                                Text = property.Name,
                                ToolTipText = propDesc
                            };

                            li.SubItems.Add(mClass.Path.ClassName);
                            li.SubItems.Add(propLazy.ToString());
                            li.SubItems.Add(sNamespace);
                            li.SubItems.Add(propDesc);

                            listSearchResults.Items.Add(li);
                        }
                    }
                }

                if (bRecurse)
                {
                    // Get and search child namespaces
                    query = new ObjectQuery("SELECT * FROM __Namespace");
                    searcher = new ManagementObjectSearcher(scope, query);
                    foreach (ManagementObject mObject in searcher.Get())
                    {
                        sNamespace = "\\\\" + mObject.Path.Server + "\\" + mObject.Path.NamespacePath + "\\" + mObject.GetPropertyValue("Name");
                        SearchPropertiesRecurse(sNamespace, queryString, searchPattern, true, connection);
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusBar2("Error searching methods within " + sNamespace + " namespace. " + ex.Message, MessageCategory.Error, true);
                _searchErrorOccurred = true;
            }
        }

        private void UpdateCheck()
        {
            if (Settings.Default.LastUpdateCheck > DateTime.Now.AddDays((-(Convert.ToInt32(Settings.Default.UpdateCheckIntervalInDays)))))
            {
                Log("Update Check - Last Update Check was within configured interval: " +
                    Settings.Default.LastUpdateCheck);

                if (Settings.Default.bUpdateAvailable)
                {
                    Log("Update Check - New version is available as per last check. Click on \"Update Available\" for more information.");
                    UpdateNotify(true);
                }
                else
                {
                    Log("Update Check - Running the latest version as per last check!");
                    //UpdateNotify(false);
                }
            }
            else
            {
                UpdateCheckAsync();
            }
        }

        private void UpdateCheckAsync(bool manualRequest = false)
        {
            BackgroundWorker bwUpdateCheckWorker = new BackgroundWorker();
            bwUpdateCheckWorker.DoWork += UpdateCheckWorker_DoWork;
            //bwUpdateCheckWorker.RunWorkerCompleted += UpdateCheckWorker_RunWorkerCompleted;
            bwUpdateCheckWorker.RunWorkerCompleted += (obj, e) => UpdateCheckWorker_RunWorkerCompleted(e, manualRequest);
            bwUpdateCheckWorker.RunWorkerAsync();
        }

        private void UpdateCheckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Update update;
            UpdaterService updaterService = new UpdaterService();

            try
            {
                update = updaterService.CheckForUpdatesAsync(Settings.Default.UpdateCheckUrl, UpdateFilter.Stable);
                if (update != null && update.ChangeLogUrl != null)
                {
                    var changeLog = updaterService.GetChangeLog(update.ChangeLogUrl);
                    File.WriteAllText(_changeLogPath, changeLog);
                }
            }
            catch (Exception ex)
            {
                Log("Update Check - Error: " + ex.Message);
                Log("Update Check - Trying backup URL.");
                update = updaterService.CheckForUpdatesAsync(Settings.Default.UpdateCheckUrlBackup, UpdateFilter.Stable);
                if (update != null && update.ChangeLogUrl != null)
                {
                    var changeLog = updaterService.GetChangeLog(update.ChangeLogUrl);
                    File.WriteAllText(_changeLogPath, changeLog);
                }
            }

            e.Result = update;
        }

        private void UpdateCheckWorker_RunWorkerCompleted(RunWorkerCompletedEventArgs e, bool manualRequest)
        {
            // Save Last Update Check time
            Settings.Default.LastUpdateCheck = DateTime.Now;
            Settings.Default.Save();

            if (e.Error != null)
            {
                Log("Update Check - Error: " + e.Error.Message);
                SetStatusBar1("Update Check Failed! See log tab for more information.", MessageCategory.Error);
                SetStatusBar2(String.Empty, MessageCategory.None);
                return;
            }

            try
            {
                var update = (Update)e.Result;
                if (update != null)
                {
                    UpdateNotify(true);
                    Log("Update Check - New Version is available: " + update.Version);
                    Settings.Default.bUpdateAvailable = true;
                    Settings.Default.UpdateUrl = update.Url.ToString();
                    Settings.Default.Save();
                }
                else
                {
                    Log("Update Check - Running the latest version!");
                    Settings.Default.bUpdateAvailable = false;
                    Settings.Default.Save();

                    if (manualRequest)
                        UpdateNotify(false);
                }
            }
            catch (Exception ex)
            {
                Log("Update Check - Error: " + ex.Message);
            }
        }

        private void UpdateNotify(bool bUpdateAvailable)
        {
            toolStripLabelUpdateNotification.Text = bUpdateAvailable ? "Update Available" : "No Update Available";
            toolStripLabelUpdateNotification.Tag = bUpdateAvailable;
        }
    }
}