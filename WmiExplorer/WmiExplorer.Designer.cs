using System.Windows.Forms;

namespace WmiExplorer
{
    partial class WmiExplorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WmiExplorer));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFile_ConnectAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFile_Preferences = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFile_SmsMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLaunch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLaunch_DcomCnfg = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLaunch_WmiMgmt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLaunch_WbemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp_Documentation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp_CheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabelUpdateNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxComputer = new System.Windows.Forms.GroupBox();
            this.buttonComputerConnect = new System.Windows.Forms.Button();
            this.textBoxComputerName = new System.Windows.Forms.TextBox();
            this.groupBoxClassOptions = new System.Windows.Forms.GroupBox();
            this.buttonClassesRefresh = new System.Windows.Forms.Button();
            this.checkBoxMSFT = new System.Windows.Forms.CheckBox();
            this.checkBoxPerf = new System.Windows.Forms.CheckBox();
            this.checkBoxCIM = new System.Windows.Forms.CheckBox();
            this.checkBoxSystem = new System.Windows.Forms.CheckBox();
            this.textBoxClassFilter = new System.Windows.Forms.TextBox();
            this.labelClassFilter = new System.Windows.Forms.Label();
            this.groupBoxQuery1 = new System.Windows.Forms.GroupBox();
            this.buttonQueryExecute1 = new System.Windows.Forms.Button();
            this.labelQuery = new System.Windows.Forms.Label();
            this.textBoxQuery1 = new System.Windows.Forms.TextBox();
            this.splitContainerNamespaceClasses = new System.Windows.Forms.SplitContainer();
            this.groupBoxNamespaces = new System.Windows.Forms.GroupBox();
            this.buttonHideNamespaces = new System.Windows.Forms.Button();
            this.treeNamespaces = new System.Windows.Forms.TreeView();
            this.tabControlClasses = new System.Windows.Forms.TabControl();
            this.tabClasses = new System.Windows.Forms.TabPage();
            this.splitContainerClassesInstances = new System.Windows.Forms.SplitContainer();
            this.tableLayoutClasses = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxClassQuickFilter = new System.Windows.Forms.TextBox();
            this.groupBoxClasses = new System.Windows.Forms.GroupBox();
            this.listClasses = new System.Windows.Forms.ListView();
            this.labelClassQuickFilter = new System.Windows.Forms.Label();
            this.tabControlInstances = new System.Windows.Forms.TabControl();
            this.tabInstances = new System.Windows.Forms.TabPage();
            this.groupBoxInstanceOptions = new System.Windows.Forms.GroupBox();
            this.buttonRefreshObject = new System.Windows.Forms.Button();
            this.buttonInstancesRefresh = new System.Windows.Forms.Button();
            this.checkNullProps = new System.Windows.Forms.CheckBox();
            this.checkSystemProps = new System.Windows.Forms.CheckBox();
            this.textBoxInstanceFilterQuick = new System.Windows.Forms.TextBox();
            this.labelInstanceFilter = new System.Windows.Forms.Label();
            this.splitContainerInstancesProperties = new System.Windows.Forms.SplitContainer();
            this.groupBoxInstances = new System.Windows.Forms.GroupBox();
            this.listInstances = new System.Windows.Forms.ListView();
            this.propertyGridInstance = new System.Windows.Forms.PropertyGrid();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.splitContainerClassProperties = new System.Windows.Forms.SplitContainer();
            this.groupBoxClassProperties = new System.Windows.Forms.GroupBox();
            this.listClassProperties = new System.Windows.Forms.ListView();
            this.richTextBoxClassDetails = new System.Windows.Forms.RichTextBox();
            this.tabMethods = new System.Windows.Forms.TabPage();
            this.splitContainerMethodsTab = new System.Windows.Forms.SplitContainer();
            this.splitContainerMethodsParams = new System.Windows.Forms.SplitContainer();
            this.groupBoxClassMethods = new System.Windows.Forms.GroupBox();
            this.listMethods = new System.Windows.Forms.ListView();
            this.tableLayoutMethods = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMethodsParamsIn = new System.Windows.Forms.GroupBox();
            this.listMethodParamsIn = new System.Windows.Forms.ListView();
            this.groupBoxMethodsParamsOut = new System.Windows.Forms.GroupBox();
            this.listMethodParamsOut = new System.Windows.Forms.ListView();
            this.richTextBoxMethodDetails = new System.Windows.Forms.RichTextBox();
            this.tabQueryResults = new System.Windows.Forms.TabPage();
            this.splitContainerQuery = new System.Windows.Forms.SplitContainer();
            this.tableLayoutQuery = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxQueryOutput = new System.Windows.Forms.GroupBox();
            this.radioQueryOutDataGrid = new System.Windows.Forms.RadioButton();
            this.radioQueryOutListView = new System.Windows.Forms.RadioButton();
            this.groupBoxQuery2 = new System.Windows.Forms.GroupBox();
            this.textBoxQuery2 = new System.Windows.Forms.TextBox();
            this.buttonQueryExecute2 = new System.Windows.Forms.Button();
            this.groupBoxQueryResults = new System.Windows.Forms.GroupBox();
            this.splitContainerQueryResults = new System.Windows.Forms.SplitContainer();
            this.listQueryResults = new System.Windows.Forms.ListView();
            this.propertyGridQueryResults = new System.Windows.Forms.PropertyGrid();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.tableLayoutScript = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxScriptLanguage = new System.Windows.Forms.GroupBox();
            this.radioScriptPs = new System.Windows.Forms.RadioButton();
            this.radioScriptVbs = new System.Windows.Forms.RadioButton();
            this.groupBoxScriptOutput = new System.Windows.Forms.GroupBox();
            this.radioScriptOutTxt = new System.Windows.Forms.RadioButton();
            this.radioScriptOutCmd = new System.Windows.Forms.RadioButton();
            this.groupBoxScriptExecute = new System.Windows.Forms.GroupBox();
            this.buttonScriptSave = new System.Windows.Forms.Button();
            this.buttonScriptRun = new System.Windows.Forms.Button();
            this.groupBoxScript = new System.Windows.Forms.GroupBox();
            this.textBoxScript = new System.Windows.Forms.TextBox();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.textBoxLogging = new System.Windows.Forms.TextBox();
            this.tabDebug2 = new System.Windows.Forms.TabPage();
            this.tableLayoutDebug2 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridDebugWmiInstance = new System.Windows.Forms.PropertyGrid();
            this.propertyGridDebugWmiClass = new System.Windows.Forms.PropertyGrid();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.tableLayoutSearch = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.radioSearchProperties = new System.Windows.Forms.RadioButton();
            this.checkBoxSearchRecurse = new System.Windows.Forms.CheckBox();
            this.radioSearchMethods = new System.Windows.Forms.RadioButton();
            this.radioSearchClasses = new System.Windows.Forms.RadioButton();
            this.labelSearch2 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchPattern = new System.Windows.Forms.TextBox();
            this.labelSearch1 = new System.Windows.Forms.Label();
            this.groupBoxSearchResults = new System.Windows.Forms.GroupBox();
            this.listSearchResults = new System.Windows.Forms.ListView();
            this.tabDebug1 = new System.Windows.Forms.TabPage();
            this.tableLayoutDebug1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyGridDebugWmiNamespace = new System.Windows.Forms.PropertyGrid();
            this.propertyGridDebugWmiNode = new System.Windows.Forms.PropertyGrid();
            this.groupBoxCallingMode = new System.Windows.Forms.GroupBox();
            this.radioModeSync = new System.Windows.Forms.RadioButton();
            this.radioModeAsync = new System.Windows.Forms.RadioButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveScriptDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBoxComputer.SuspendLayout();
            this.groupBoxClassOptions.SuspendLayout();
            this.groupBoxQuery1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNamespaceClasses)).BeginInit();
            this.splitContainerNamespaceClasses.Panel1.SuspendLayout();
            this.splitContainerNamespaceClasses.Panel2.SuspendLayout();
            this.splitContainerNamespaceClasses.SuspendLayout();
            this.groupBoxNamespaces.SuspendLayout();
            this.tabControlClasses.SuspendLayout();
            this.tabClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassesInstances)).BeginInit();
            this.splitContainerClassesInstances.Panel1.SuspendLayout();
            this.splitContainerClassesInstances.Panel2.SuspendLayout();
            this.splitContainerClassesInstances.SuspendLayout();
            this.tableLayoutClasses.SuspendLayout();
            this.groupBoxClasses.SuspendLayout();
            this.tabControlInstances.SuspendLayout();
            this.tabInstances.SuspendLayout();
            this.groupBoxInstanceOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInstancesProperties)).BeginInit();
            this.splitContainerInstancesProperties.Panel1.SuspendLayout();
            this.splitContainerInstancesProperties.Panel2.SuspendLayout();
            this.splitContainerInstancesProperties.SuspendLayout();
            this.groupBoxInstances.SuspendLayout();
            this.tabProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassProperties)).BeginInit();
            this.splitContainerClassProperties.Panel1.SuspendLayout();
            this.splitContainerClassProperties.Panel2.SuspendLayout();
            this.splitContainerClassProperties.SuspendLayout();
            this.groupBoxClassProperties.SuspendLayout();
            this.tabMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMethodsTab)).BeginInit();
            this.splitContainerMethodsTab.Panel1.SuspendLayout();
            this.splitContainerMethodsTab.Panel2.SuspendLayout();
            this.splitContainerMethodsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMethodsParams)).BeginInit();
            this.splitContainerMethodsParams.Panel1.SuspendLayout();
            this.splitContainerMethodsParams.Panel2.SuspendLayout();
            this.splitContainerMethodsParams.SuspendLayout();
            this.groupBoxClassMethods.SuspendLayout();
            this.tableLayoutMethods.SuspendLayout();
            this.groupBoxMethodsParamsIn.SuspendLayout();
            this.groupBoxMethodsParamsOut.SuspendLayout();
            this.tabQueryResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQuery)).BeginInit();
            this.splitContainerQuery.Panel1.SuspendLayout();
            this.splitContainerQuery.Panel2.SuspendLayout();
            this.splitContainerQuery.SuspendLayout();
            this.tableLayoutQuery.SuspendLayout();
            this.groupBoxQueryOutput.SuspendLayout();
            this.groupBoxQuery2.SuspendLayout();
            this.groupBoxQueryResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQueryResults)).BeginInit();
            this.splitContainerQueryResults.Panel1.SuspendLayout();
            this.splitContainerQueryResults.Panel2.SuspendLayout();
            this.splitContainerQueryResults.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.tableLayoutScript.SuspendLayout();
            this.groupBoxScriptLanguage.SuspendLayout();
            this.groupBoxScriptOutput.SuspendLayout();
            this.groupBoxScriptExecute.SuspendLayout();
            this.groupBoxScript.SuspendLayout();
            this.tabLogging.SuspendLayout();
            this.tabDebug2.SuspendLayout();
            this.tableLayoutDebug2.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tableLayoutSearch.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxSearchResults.SuspendLayout();
            this.tabDebug1.SuspendLayout();
            this.tableLayoutDebug1.SuspendLayout();
            this.groupBoxCallingMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemLaunch,
            this.menuItemHelp,
            this.toolStripLabelUpdateNotification});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile_ConnectAs,
            this.menuItemFile_Preferences,
            this.menuItemFile_SmsMode,
            this.menuItemFile_Exit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemFile_ConnectAs
            // 
            this.menuItemFile_ConnectAs.Name = "menuItemFile_ConnectAs";
            this.menuItemFile_ConnectAs.Size = new System.Drawing.Size(176, 22);
            this.menuItemFile_ConnectAs.Text = "Connect &As...";
            this.menuItemFile_ConnectAs.ToolTipText = "Connect as alternate credentials";
            this.menuItemFile_ConnectAs.Click += new System.EventHandler(this.menuItemFile_ConnectAs_Click);
            // 
            // menuItemFile_Preferences
            // 
            this.menuItemFile_Preferences.Name = "menuItemFile_Preferences";
            this.menuItemFile_Preferences.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuItemFile_Preferences.Size = new System.Drawing.Size(176, 22);
            this.menuItemFile_Preferences.Text = "&Preferences";
            this.menuItemFile_Preferences.Click += new System.EventHandler(this.menuItemFile_Preferences_Click);
            // 
            // menuItemFile_SmsMode
            // 
            this.menuItemFile_SmsMode.Checked = global::WmiExplorer.Properties.Settings.Default.bSmsMode;
            this.menuItemFile_SmsMode.CheckOnClick = true;
            this.menuItemFile_SmsMode.Name = "menuItemFile_SmsMode";
            this.menuItemFile_SmsMode.Size = new System.Drawing.Size(176, 22);
            this.menuItemFile_SmsMode.Text = "Enable &SMS Mode";
            this.menuItemFile_SmsMode.ToolTipText = "Enables SMS (Configuration Manager) Mode";
            this.menuItemFile_SmsMode.CheckedChanged += new System.EventHandler(this.menuItemFile_SmsMode_CheckedChanged);
            // 
            // menuItemFile_Exit
            // 
            this.menuItemFile_Exit.Name = "menuItemFile_Exit";
            this.menuItemFile_Exit.Size = new System.Drawing.Size(176, 22);
            this.menuItemFile_Exit.Text = "E&xit";
            this.menuItemFile_Exit.Click += new System.EventHandler(this.menuItemFile_Exit_Click);
            // 
            // menuItemLaunch
            // 
            this.menuItemLaunch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLaunch_DcomCnfg,
            this.menuItemLaunch_WmiMgmt,
            this.menuItemLaunch_WbemTest});
            this.menuItemLaunch.Name = "menuItemLaunch";
            this.menuItemLaunch.Size = new System.Drawing.Size(58, 20);
            this.menuItemLaunch.Text = "&Launch";
            // 
            // menuItemLaunch_DcomCnfg
            // 
            this.menuItemLaunch_DcomCnfg.Name = "menuItemLaunch_DcomCnfg";
            this.menuItemLaunch_DcomCnfg.Size = new System.Drawing.Size(211, 22);
            this.menuItemLaunch_DcomCnfg.Text = "&DCOM Config";
            this.menuItemLaunch_DcomCnfg.Click += new System.EventHandler(this.menuItemLaunch_DcomCnfg_Click);
            // 
            // menuItemLaunch_WmiMgmt
            // 
            this.menuItemLaunch_WmiMgmt.Name = "menuItemLaunch_WmiMgmt";
            this.menuItemLaunch_WmiMgmt.Size = new System.Drawing.Size(211, 22);
            this.menuItemLaunch_WmiMgmt.Text = "WMI &Control (WmiMgmt)";
            this.menuItemLaunch_WmiMgmt.Click += new System.EventHandler(this.menuItemLaunch_WmiMgmt_Click);
            // 
            // menuItemLaunch_WbemTest
            // 
            this.menuItemLaunch_WbemTest.Name = "menuItemLaunch_WbemTest";
            this.menuItemLaunch_WbemTest.Size = new System.Drawing.Size(211, 22);
            this.menuItemLaunch_WbemTest.Text = "WMI &Tester (WbemTest)";
            this.menuItemLaunch_WbemTest.Click += new System.EventHandler(this.menuItemLaunch_WbemTest_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelp_Documentation,
            this.menuItemHelp_CheckUpdate,
            this.menuItemHelp_About});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemHelp_Documentation
            // 
            this.menuItemHelp_Documentation.Name = "menuItemHelp_Documentation";
            this.menuItemHelp_Documentation.Size = new System.Drawing.Size(173, 22);
            this.menuItemHelp_Documentation.Text = "&Documentation";
            this.menuItemHelp_Documentation.Click += new System.EventHandler(this.menuItemHelp_Documentation_Click);
            // 
            // menuItemHelp_CheckUpdate
            // 
            this.menuItemHelp_CheckUpdate.Name = "menuItemHelp_CheckUpdate";
            this.menuItemHelp_CheckUpdate.Size = new System.Drawing.Size(173, 22);
            this.menuItemHelp_CheckUpdate.Text = "Check For &Updates";
            this.menuItemHelp_CheckUpdate.Click += new System.EventHandler(this.menuItemHelp_CheckUpdate_Click);
            // 
            // menuItemHelp_About
            // 
            this.menuItemHelp_About.Name = "menuItemHelp_About";
            this.menuItemHelp_About.Size = new System.Drawing.Size(173, 22);
            this.menuItemHelp_About.Text = "&About";
            this.menuItemHelp_About.Click += new System.EventHandler(this.menuItemHelp_About_Click);
            // 
            // toolStripLabelUpdateNotification
            // 
            this.toolStripLabelUpdateNotification.IsLink = true;
            this.toolStripLabelUpdateNotification.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toolStripLabelUpdateNotification.Name = "toolStripLabelUpdateNotification";
            this.toolStripLabelUpdateNotification.Size = new System.Drawing.Size(96, 20);
            this.toolStripLabelUpdateNotification.Text = "Update Available";
            this.toolStripLabelUpdateNotification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLabelUpdateNotification.Click += new System.EventHandler(this.toolStripLabelUpdateNotification_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 707);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 17);
            this.toolStripLabel1.Text = "StatusBar1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(62, 17);
            this.toolStripLabel2.Text = "StatusBar2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(869, 17);
            this.toolStripLabel3.Spring = true;
            this.toolStripLabel3.Text = "StatusBar3";
            this.toolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 5;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxComputer, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxClassOptions, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxQuery1, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.splitContainerNamespaceClasses, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxCallingMode, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1008, 683);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // groupBoxComputer
            // 
            this.groupBoxComputer.Controls.Add(this.buttonComputerConnect);
            this.groupBoxComputer.Controls.Add(this.textBoxComputerName);
            this.groupBoxComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComputer.Location = new System.Drawing.Point(4, 3);
            this.groupBoxComputer.Name = "groupBoxComputer";
            this.groupBoxComputer.Size = new System.Drawing.Size(214, 54);
            this.groupBoxComputer.TabIndex = 0;
            this.groupBoxComputer.TabStop = false;
            this.groupBoxComputer.Text = "Computer";
            // 
            // buttonComputerConnect
            // 
            this.buttonComputerConnect.Location = new System.Drawing.Point(130, 19);
            this.buttonComputerConnect.Name = "buttonComputerConnect";
            this.buttonComputerConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonComputerConnect.TabIndex = 1;
            this.buttonComputerConnect.Text = "Connect";
            this.buttonComputerConnect.UseVisualStyleBackColor = true;
            this.buttonComputerConnect.Click += new System.EventHandler(this.buttonComputerConnect_Click);
            // 
            // textBoxComputerName
            // 
            this.textBoxComputerName.Location = new System.Drawing.Point(6, 21);
            this.textBoxComputerName.Name = "textBoxComputerName";
            this.textBoxComputerName.Size = new System.Drawing.Size(118, 20);
            this.textBoxComputerName.TabIndex = 0;
            this.textBoxComputerName.Text = ".";
            this.toolTip.SetToolTip(this.textBoxComputerName, "Computer Name or Path");
            this.textBoxComputerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxComputerName_KeyDown);
            // 
            // groupBoxClassOptions
            // 
            this.groupBoxClassOptions.Controls.Add(this.buttonClassesRefresh);
            this.groupBoxClassOptions.Controls.Add(this.checkBoxMSFT);
            this.groupBoxClassOptions.Controls.Add(this.checkBoxPerf);
            this.groupBoxClassOptions.Controls.Add(this.checkBoxCIM);
            this.groupBoxClassOptions.Controls.Add(this.checkBoxSystem);
            this.groupBoxClassOptions.Controls.Add(this.textBoxClassFilter);
            this.groupBoxClassOptions.Controls.Add(this.labelClassFilter);
            this.groupBoxClassOptions.Location = new System.Drawing.Point(344, 3);
            this.groupBoxClassOptions.Name = "groupBoxClassOptions";
            this.groupBoxClassOptions.Size = new System.Drawing.Size(571, 54);
            this.groupBoxClassOptions.TabIndex = 2;
            this.groupBoxClassOptions.TabStop = false;
            this.groupBoxClassOptions.Text = "Class Enumeration Options";
            // 
            // buttonClassesRefresh
            // 
            this.buttonClassesRefresh.Location = new System.Drawing.Point(455, 19);
            this.buttonClassesRefresh.Name = "buttonClassesRefresh";
            this.buttonClassesRefresh.Size = new System.Drawing.Size(104, 23);
            this.buttonClassesRefresh.TabIndex = 5;
            this.buttonClassesRefresh.Text = "Refresh Classes";
            this.toolTip.SetToolTip(this.buttonClassesRefresh, "Refresh list of classes for the selected namespace");
            this.buttonClassesRefresh.UseVisualStyleBackColor = true;
            this.buttonClassesRefresh.Click += new System.EventHandler(this.buttonClassesRefresh_Click);
            // 
            // checkBoxMSFT
            // 
            this.checkBoxMSFT.AutoSize = true;
            this.checkBoxMSFT.Location = new System.Drawing.Point(310, 32);
            this.checkBoxMSFT.Name = "checkBoxMSFT";
            this.checkBoxMSFT.Size = new System.Drawing.Size(132, 17);
            this.checkBoxMSFT.TabIndex = 4;
            this.checkBoxMSFT.Tag = "";
            this.checkBoxMSFT.Text = "Include MSFT Classes";
            this.checkBoxMSFT.UseVisualStyleBackColor = true;
            this.checkBoxMSFT.CheckedChanged += new System.EventHandler(this.checkBoxEnumOptions_CheckedChanged);
            // 
            // checkBoxPerf
            // 
            this.checkBoxPerf.AutoSize = true;
            this.checkBoxPerf.Location = new System.Drawing.Point(310, 14);
            this.checkBoxPerf.Name = "checkBoxPerf";
            this.checkBoxPerf.Size = new System.Drawing.Size(122, 17);
            this.checkBoxPerf.TabIndex = 3;
            this.checkBoxPerf.Tag = "";
            this.checkBoxPerf.Text = "Include Perf Classes";
            this.checkBoxPerf.UseVisualStyleBackColor = true;
            this.checkBoxPerf.CheckedChanged += new System.EventHandler(this.checkBoxEnumOptions_CheckedChanged);
            // 
            // checkBoxCIM
            // 
            this.checkBoxCIM.AutoSize = true;
            this.checkBoxCIM.Location = new System.Drawing.Point(167, 32);
            this.checkBoxCIM.Name = "checkBoxCIM";
            this.checkBoxCIM.Size = new System.Drawing.Size(122, 17);
            this.checkBoxCIM.TabIndex = 2;
            this.checkBoxCIM.Tag = "";
            this.checkBoxCIM.Text = "Include CIM Classes";
            this.checkBoxCIM.UseVisualStyleBackColor = true;
            this.checkBoxCIM.CheckedChanged += new System.EventHandler(this.checkBoxEnumOptions_CheckedChanged);
            // 
            // checkBoxSystem
            // 
            this.checkBoxSystem.AutoSize = true;
            this.checkBoxSystem.Location = new System.Drawing.Point(167, 14);
            this.checkBoxSystem.Name = "checkBoxSystem";
            this.checkBoxSystem.Size = new System.Drawing.Size(137, 17);
            this.checkBoxSystem.TabIndex = 1;
            this.checkBoxSystem.Tag = "";
            this.checkBoxSystem.Text = "Include System Classes";
            this.checkBoxSystem.UseVisualStyleBackColor = true;
            this.checkBoxSystem.CheckedChanged += new System.EventHandler(this.checkBoxEnumOptions_CheckedChanged);
            // 
            // textBoxClassFilter
            // 
            this.textBoxClassFilter.Location = new System.Drawing.Point(46, 22);
            this.textBoxClassFilter.Name = "textBoxClassFilter";
            this.textBoxClassFilter.Size = new System.Drawing.Size(115, 20);
            this.textBoxClassFilter.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxClassFilter, resources.GetString("textBoxClassFilter.ToolTip"));
            this.textBoxClassFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClassFilter_KeyDown);
            // 
            // labelClassFilter
            // 
            this.labelClassFilter.AutoSize = true;
            this.labelClassFilter.Location = new System.Drawing.Point(6, 25);
            this.labelClassFilter.Name = "labelClassFilter";
            this.labelClassFilter.Size = new System.Drawing.Size(32, 13);
            this.labelClassFilter.TabIndex = 0;
            this.labelClassFilter.Text = "Filter:";
            // 
            // groupBoxQuery1
            // 
            this.groupBoxQuery1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.groupBoxQuery1, 3);
            this.groupBoxQuery1.Controls.Add(this.buttonQueryExecute1);
            this.groupBoxQuery1.Controls.Add(this.labelQuery);
            this.groupBoxQuery1.Controls.Add(this.textBoxQuery1);
            this.groupBoxQuery1.Location = new System.Drawing.Point(4, 626);
            this.groupBoxQuery1.Name = "groupBoxQuery1";
            this.groupBoxQuery1.Size = new System.Drawing.Size(1000, 54);
            this.groupBoxQuery1.TabIndex = 6;
            this.groupBoxQuery1.TabStop = false;
            this.groupBoxQuery1.Text = "WQL Query (Selected Object)";
            // 
            // buttonQueryExecute1
            // 
            this.buttonQueryExecute1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQueryExecute1.Location = new System.Drawing.Point(908, 19);
            this.buttonQueryExecute1.Name = "buttonQueryExecute1";
            this.buttonQueryExecute1.Size = new System.Drawing.Size(86, 23);
            this.buttonQueryExecute1.TabIndex = 0;
            this.buttonQueryExecute1.Text = "Execute";
            this.buttonQueryExecute1.UseVisualStyleBackColor = true;
            this.buttonQueryExecute1.Click += new System.EventHandler(this.buttonQueryExecute1_Click);
            // 
            // labelQuery
            // 
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new System.Drawing.Point(6, 23);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new System.Drawing.Size(35, 13);
            this.labelQuery.TabIndex = 1;
            this.labelQuery.Text = "Query";
            // 
            // textBoxQuery1
            // 
            this.textBoxQuery1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuery1.Location = new System.Drawing.Point(47, 21);
            this.textBoxQuery1.Name = "textBoxQuery1";
            this.textBoxQuery1.ReadOnly = true;
            this.textBoxQuery1.Size = new System.Drawing.Size(855, 20);
            this.textBoxQuery1.TabIndex = 1;
            // 
            // splitContainerNamespaceClasses
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.splitContainerNamespaceClasses, 3);
            this.splitContainerNamespaceClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerNamespaceClasses.Location = new System.Drawing.Point(4, 63);
            this.splitContainerNamespaceClasses.Name = "splitContainerNamespaceClasses";
            // 
            // splitContainerNamespaceClasses.Panel1
            // 
            this.splitContainerNamespaceClasses.Panel1.Controls.Add(this.groupBoxNamespaces);
            // 
            // splitContainerNamespaceClasses.Panel2
            // 
            this.splitContainerNamespaceClasses.Panel2.Controls.Add(this.tabControlClasses);
            this.splitContainerNamespaceClasses.Size = new System.Drawing.Size(1000, 557);
            this.splitContainerNamespaceClasses.SplitterDistance = 216;
            this.splitContainerNamespaceClasses.TabIndex = 7;
            this.splitContainerNamespaceClasses.TabStop = false;
            this.splitContainerNamespaceClasses.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerNamespaceClasses_SplitterMoved);
            // 
            // groupBoxNamespaces
            // 
            this.groupBoxNamespaces.Controls.Add(this.buttonHideNamespaces);
            this.groupBoxNamespaces.Controls.Add(this.treeNamespaces);
            this.groupBoxNamespaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNamespaces.Location = new System.Drawing.Point(0, 0);
            this.groupBoxNamespaces.Name = "groupBoxNamespaces";
            this.groupBoxNamespaces.Size = new System.Drawing.Size(216, 557);
            this.groupBoxNamespaces.TabIndex = 0;
            this.groupBoxNamespaces.TabStop = false;
            this.groupBoxNamespaces.Text = "Namespaces";
            // 
            // buttonHideNamespaces
            // 
            this.buttonHideNamespaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHideNamespaces.Location = new System.Drawing.Point(191, 18);
            this.buttonHideNamespaces.Name = "buttonHideNamespaces";
            this.buttonHideNamespaces.Size = new System.Drawing.Size(20, 20);
            this.buttonHideNamespaces.TabIndex = 1;
            this.buttonHideNamespaces.Text = "-";
            this.buttonHideNamespaces.UseVisualStyleBackColor = true;
            this.buttonHideNamespaces.Click += new System.EventHandler(this.buttonHideNamespaces_Click);
            this.buttonHideNamespaces.MouseHover += new System.EventHandler(this.buttonHideNamespaces_MouseHover);
            // 
            // treeNamespaces
            // 
            this.treeNamespaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeNamespaces.HideSelection = false;
            this.treeNamespaces.Location = new System.Drawing.Point(3, 16);
            this.treeNamespaces.Name = "treeNamespaces";
            this.treeNamespaces.ShowNodeToolTips = true;
            this.treeNamespaces.Size = new System.Drawing.Size(210, 538);
            this.treeNamespaces.TabIndex = 0;
            this.treeNamespaces.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeNamespaces_BeforeSelect);
            this.treeNamespaces.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeNamespaces_AfterSelect);
            this.treeNamespaces.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeNamespaces_NodeMouseClick);
            this.treeNamespaces.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeNamespaces_NodeMouseDoubleClick);
            // 
            // tabControlClasses
            // 
            this.tabControlClasses.Controls.Add(this.tabClasses);
            this.tabControlClasses.Controls.Add(this.tabSearch);
            this.tabControlClasses.Controls.Add(this.tabDebug1);
            this.tabControlClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlClasses.Location = new System.Drawing.Point(0, 0);
            this.tabControlClasses.Name = "tabControlClasses";
            this.tabControlClasses.SelectedIndex = 0;
            this.tabControlClasses.Size = new System.Drawing.Size(780, 557);
            this.tabControlClasses.TabIndex = 0;
            // 
            // tabClasses
            // 
            this.tabClasses.BackColor = System.Drawing.SystemColors.Control;
            this.tabClasses.Controls.Add(this.splitContainerClassesInstances);
            this.tabClasses.Location = new System.Drawing.Point(4, 22);
            this.tabClasses.Name = "tabClasses";
            this.tabClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tabClasses.Size = new System.Drawing.Size(772, 531);
            this.tabClasses.TabIndex = 0;
            this.tabClasses.Text = "Classes";
            // 
            // splitContainerClassesInstances
            // 
            this.splitContainerClassesInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerClassesInstances.Location = new System.Drawing.Point(3, 3);
            this.splitContainerClassesInstances.Name = "splitContainerClassesInstances";
            // 
            // splitContainerClassesInstances.Panel1
            // 
            this.splitContainerClassesInstances.Panel1.Controls.Add(this.tableLayoutClasses);
            // 
            // splitContainerClassesInstances.Panel2
            // 
            this.splitContainerClassesInstances.Panel2.Controls.Add(this.tabControlInstances);
            this.splitContainerClassesInstances.Size = new System.Drawing.Size(766, 525);
            this.splitContainerClassesInstances.SplitterDistance = 199;
            this.splitContainerClassesInstances.TabIndex = 0;
            this.splitContainerClassesInstances.TabStop = false;
            // 
            // tableLayoutClasses
            // 
            this.tableLayoutClasses.ColumnCount = 2;
            this.tableLayoutClasses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutClasses.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutClasses.Controls.Add(this.textBoxClassQuickFilter, 1, 0);
            this.tableLayoutClasses.Controls.Add(this.groupBoxClasses, 0, 1);
            this.tableLayoutClasses.Controls.Add(this.labelClassQuickFilter, 0, 0);
            this.tableLayoutClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutClasses.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutClasses.Name = "tableLayoutClasses";
            this.tableLayoutClasses.RowCount = 2;
            this.tableLayoutClasses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutClasses.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutClasses.Size = new System.Drawing.Size(199, 525);
            this.tableLayoutClasses.TabIndex = 0;
            // 
            // textBoxClassQuickFilter
            // 
            this.textBoxClassQuickFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassQuickFilter.Location = new System.Drawing.Point(76, 3);
            this.textBoxClassQuickFilter.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textBoxClassQuickFilter.Name = "textBoxClassQuickFilter";
            this.textBoxClassQuickFilter.Size = new System.Drawing.Size(117, 20);
            this.textBoxClassQuickFilter.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxClassQuickFilter, "Quick Filter for displayed classes. This filter is applied after classes are enum" +
        "erated and filters the list after specifying atleast 3 characters.");
            this.textBoxClassQuickFilter.TextChanged += new System.EventHandler(this.textBoxClassQuickFilter_TextChanged);
            // 
            // groupBoxClasses
            // 
            this.groupBoxClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutClasses.SetColumnSpan(this.groupBoxClasses, 2);
            this.groupBoxClasses.Controls.Add(this.listClasses);
            this.groupBoxClasses.Location = new System.Drawing.Point(3, 28);
            this.groupBoxClasses.Name = "groupBoxClasses";
            this.groupBoxClasses.Size = new System.Drawing.Size(193, 494);
            this.groupBoxClasses.TabIndex = 2;
            this.groupBoxClasses.TabStop = false;
            this.groupBoxClasses.Text = "Classes";
            // 
            // listClasses
            // 
            this.listClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listClasses.FullRowSelect = true;
            this.listClasses.HideSelection = false;
            this.listClasses.Location = new System.Drawing.Point(3, 16);
            this.listClasses.MultiSelect = false;
            this.listClasses.Name = "listClasses";
            this.listClasses.ShowItemToolTips = true;
            this.listClasses.Size = new System.Drawing.Size(187, 475);
            this.listClasses.TabIndex = 0;
            this.listClasses.UseCompatibleStateImageBehavior = false;
            this.listClasses.View = System.Windows.Forms.View.Details;
            this.listClasses.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listClasses.SelectedIndexChanged += new System.EventHandler(this.listClasses_SelectedIndexChanged);
            this.listClasses.DoubleClick += new System.EventHandler(this.listClasses_DoubleClick);
            this.listClasses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listClasses_MouseClick);
            // 
            // labelClassQuickFilter
            // 
            this.labelClassQuickFilter.AutoSize = true;
            this.labelClassQuickFilter.Location = new System.Drawing.Point(3, 6);
            this.labelClassQuickFilter.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.labelClassQuickFilter.Name = "labelClassQuickFilter";
            this.labelClassQuickFilter.Size = new System.Drawing.Size(63, 13);
            this.labelClassQuickFilter.TabIndex = 6;
            this.labelClassQuickFilter.Text = "Quick Filter:";
            // 
            // tabControlInstances
            // 
            this.tabControlInstances.Controls.Add(this.tabInstances);
            this.tabControlInstances.Controls.Add(this.tabProperties);
            this.tabControlInstances.Controls.Add(this.tabMethods);
            this.tabControlInstances.Controls.Add(this.tabQueryResults);
            this.tabControlInstances.Controls.Add(this.tabScript);
            this.tabControlInstances.Controls.Add(this.tabLogging);
            this.tabControlInstances.Controls.Add(this.tabDebug2);
            this.tabControlInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInstances.Location = new System.Drawing.Point(0, 0);
            this.tabControlInstances.Name = "tabControlInstances";
            this.tabControlInstances.SelectedIndex = 0;
            this.tabControlInstances.Size = new System.Drawing.Size(563, 525);
            this.tabControlInstances.TabIndex = 0;
            this.tabControlInstances.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlInstances_Selected);
            // 
            // tabInstances
            // 
            this.tabInstances.BackColor = System.Drawing.SystemColors.Control;
            this.tabInstances.Controls.Add(this.groupBoxInstanceOptions);
            this.tabInstances.Controls.Add(this.splitContainerInstancesProperties);
            this.tabInstances.Location = new System.Drawing.Point(4, 22);
            this.tabInstances.Name = "tabInstances";
            this.tabInstances.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstances.Size = new System.Drawing.Size(555, 499);
            this.tabInstances.TabIndex = 0;
            this.tabInstances.Text = "Instances";
            // 
            // groupBoxInstanceOptions
            // 
            this.groupBoxInstanceOptions.Controls.Add(this.buttonRefreshObject);
            this.groupBoxInstanceOptions.Controls.Add(this.buttonInstancesRefresh);
            this.groupBoxInstanceOptions.Controls.Add(this.checkNullProps);
            this.groupBoxInstanceOptions.Controls.Add(this.checkSystemProps);
            this.groupBoxInstanceOptions.Controls.Add(this.textBoxInstanceFilterQuick);
            this.groupBoxInstanceOptions.Controls.Add(this.labelInstanceFilter);
            this.groupBoxInstanceOptions.Location = new System.Drawing.Point(6, 6);
            this.groupBoxInstanceOptions.Name = "groupBoxInstanceOptions";
            this.groupBoxInstanceOptions.Size = new System.Drawing.Size(544, 54);
            this.groupBoxInstanceOptions.TabIndex = 0;
            this.groupBoxInstanceOptions.TabStop = false;
            this.groupBoxInstanceOptions.Text = "Instance Options";
            // 
            // buttonRefreshObject
            // 
            this.buttonRefreshObject.Location = new System.Drawing.Point(442, 20);
            this.buttonRefreshObject.Name = "buttonRefreshObject";
            this.buttonRefreshObject.Size = new System.Drawing.Size(94, 23);
            this.buttonRefreshObject.TabIndex = 4;
            this.buttonRefreshObject.Text = "Refresh Object";
            this.toolTip.SetToolTip(this.buttonRefreshObject, "Refresh selected instance. This is generally useful for populating values of lazy" +
        " properties.");
            this.buttonRefreshObject.UseVisualStyleBackColor = true;
            this.buttonRefreshObject.Click += new System.EventHandler(this.buttonRefreshObject_Click);
            // 
            // buttonInstancesRefresh
            // 
            this.buttonInstancesRefresh.Location = new System.Drawing.Point(323, 20);
            this.buttonInstancesRefresh.Name = "buttonInstancesRefresh";
            this.buttonInstancesRefresh.Size = new System.Drawing.Size(113, 23);
            this.buttonInstancesRefresh.TabIndex = 3;
            this.buttonInstancesRefresh.Text = "Refresh Instances";
            this.toolTip.SetToolTip(this.buttonInstancesRefresh, "Refresh list of instances for the selected class");
            this.buttonInstancesRefresh.UseVisualStyleBackColor = true;
            this.buttonInstancesRefresh.Click += new System.EventHandler(this.buttonInstancesRefresh_Click);
            // 
            // checkNullProps
            // 
            this.checkNullProps.AutoSize = true;
            this.checkNullProps.Location = new System.Drawing.Point(180, 15);
            this.checkNullProps.Name = "checkNullProps";
            this.checkNullProps.Size = new System.Drawing.Size(109, 17);
            this.checkNullProps.TabIndex = 1;
            this.checkNullProps.Text = "Show Null Values";
            this.toolTip.SetToolTip(this.checkNullProps, "Show properties witn NULL values");
            this.checkNullProps.UseVisualStyleBackColor = true;
            this.checkNullProps.CheckedChanged += new System.EventHandler(this.checkBoxEnumOptions_CheckedChanged);
            // 
            // checkSystemProps
            // 
            this.checkSystemProps.AutoSize = true;
            this.checkSystemProps.Location = new System.Drawing.Point(180, 33);
            this.checkSystemProps.Name = "checkSystemProps";
            this.checkSystemProps.Size = new System.Drawing.Size(140, 17);
            this.checkSystemProps.TabIndex = 2;
            this.checkSystemProps.Text = "Show System Properties";
            this.toolTip.SetToolTip(this.checkSystemProps, "Show System Properties");
            this.checkSystemProps.UseVisualStyleBackColor = true;
            this.checkSystemProps.CheckedChanged += new System.EventHandler(this.checkBoxEnumOptions_CheckedChanged);
            // 
            // textBoxInstanceFilterQuick
            // 
            this.textBoxInstanceFilterQuick.Location = new System.Drawing.Point(75, 22);
            this.textBoxInstanceFilterQuick.Name = "textBoxInstanceFilterQuick";
            this.textBoxInstanceFilterQuick.Size = new System.Drawing.Size(99, 20);
            this.textBoxInstanceFilterQuick.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxInstanceFilterQuick, "Quick Filter for displayed Instances. This filter is applied after instances are " +
        "enumerated and filters the list after specifying atleast 3 characters.");
            this.textBoxInstanceFilterQuick.TextChanged += new System.EventHandler(this.textBoxInstanceFilterQuick_TextChanged);
            // 
            // labelInstanceFilter
            // 
            this.labelInstanceFilter.AutoSize = true;
            this.labelInstanceFilter.Location = new System.Drawing.Point(6, 25);
            this.labelInstanceFilter.Name = "labelInstanceFilter";
            this.labelInstanceFilter.Size = new System.Drawing.Size(63, 13);
            this.labelInstanceFilter.TabIndex = 7;
            this.labelInstanceFilter.Text = "Quick Filter:";
            // 
            // splitContainerInstancesProperties
            // 
            this.splitContainerInstancesProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerInstancesProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerInstancesProperties.Location = new System.Drawing.Point(6, 67);
            this.splitContainerInstancesProperties.Name = "splitContainerInstancesProperties";
            // 
            // splitContainerInstancesProperties.Panel1
            // 
            this.splitContainerInstancesProperties.Panel1.Controls.Add(this.groupBoxInstances);
            this.splitContainerInstancesProperties.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainerInstancesProperties.Panel2
            // 
            this.splitContainerInstancesProperties.Panel2.Controls.Add(this.propertyGridInstance);
            this.splitContainerInstancesProperties.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainerInstancesProperties.Size = new System.Drawing.Size(546, 426);
            this.splitContainerInstancesProperties.SplitterDistance = 179;
            this.splitContainerInstancesProperties.TabIndex = 0;
            this.splitContainerInstancesProperties.TabStop = false;
            // 
            // groupBoxInstances
            // 
            this.groupBoxInstances.AutoSize = true;
            this.groupBoxInstances.Controls.Add(this.listInstances);
            this.groupBoxInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInstances.Location = new System.Drawing.Point(3, 3);
            this.groupBoxInstances.Name = "groupBoxInstances";
            this.groupBoxInstances.Size = new System.Drawing.Size(169, 416);
            this.groupBoxInstances.TabIndex = 0;
            this.groupBoxInstances.TabStop = false;
            this.groupBoxInstances.Text = "Instances";
            // 
            // listInstances
            // 
            this.listInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listInstances.FullRowSelect = true;
            this.listInstances.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listInstances.HideSelection = false;
            this.listInstances.Location = new System.Drawing.Point(3, 16);
            this.listInstances.MultiSelect = false;
            this.listInstances.Name = "listInstances";
            this.listInstances.ShowItemToolTips = true;
            this.listInstances.Size = new System.Drawing.Size(163, 397);
            this.listInstances.TabIndex = 0;
            this.listInstances.UseCompatibleStateImageBehavior = false;
            this.listInstances.View = System.Windows.Forms.View.Details;
            this.listInstances.SelectedIndexChanged += new System.EventHandler(this.listInstances_SelectedIndexChanged);
            this.listInstances.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listInstances_MouseClick);
            // 
            // propertyGridInstance
            // 
            this.propertyGridInstance.ContextMenuStrip = this.contextMenu;
            this.propertyGridInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridInstance.Location = new System.Drawing.Point(3, 3);
            this.propertyGridInstance.Name = "propertyGridInstance";
            this.propertyGridInstance.Size = new System.Drawing.Size(353, 416);
            this.propertyGridInstance.TabIndex = 0;
            this.propertyGridInstance.ToolbarVisible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // tabProperties
            // 
            this.tabProperties.BackColor = System.Drawing.SystemColors.Control;
            this.tabProperties.Controls.Add(this.splitContainerClassProperties);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(555, 499);
            this.tabProperties.TabIndex = 4;
            this.tabProperties.Text = "Properties";
            // 
            // splitContainerClassProperties
            // 
            this.splitContainerClassProperties.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerClassProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerClassProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerClassProperties.Location = new System.Drawing.Point(3, 3);
            this.splitContainerClassProperties.Name = "splitContainerClassProperties";
            this.splitContainerClassProperties.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerClassProperties.Panel1
            // 
            this.splitContainerClassProperties.Panel1.Controls.Add(this.groupBoxClassProperties);
            this.splitContainerClassProperties.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainerClassProperties.Panel2
            // 
            this.splitContainerClassProperties.Panel2.Controls.Add(this.richTextBoxClassDetails);
            this.splitContainerClassProperties.Size = new System.Drawing.Size(549, 493);
            this.splitContainerClassProperties.SplitterDistance = 284;
            this.splitContainerClassProperties.TabIndex = 2;
            // 
            // groupBoxClassProperties
            // 
            this.groupBoxClassProperties.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxClassProperties.Controls.Add(this.listClassProperties);
            this.groupBoxClassProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxClassProperties.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClassProperties.Name = "groupBoxClassProperties";
            this.groupBoxClassProperties.Size = new System.Drawing.Size(539, 274);
            this.groupBoxClassProperties.TabIndex = 1;
            this.groupBoxClassProperties.TabStop = false;
            this.groupBoxClassProperties.Text = "Class Properties";
            // 
            // listClassProperties
            // 
            this.listClassProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listClassProperties.FullRowSelect = true;
            this.listClassProperties.HideSelection = false;
            this.listClassProperties.Location = new System.Drawing.Point(3, 16);
            this.listClassProperties.MultiSelect = false;
            this.listClassProperties.Name = "listClassProperties";
            this.listClassProperties.ShowItemToolTips = true;
            this.listClassProperties.Size = new System.Drawing.Size(533, 255);
            this.listClassProperties.TabIndex = 0;
            this.listClassProperties.UseCompatibleStateImageBehavior = false;
            this.listClassProperties.View = System.Windows.Forms.View.Details;
            this.listClassProperties.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listClassProperties.SelectedIndexChanged += new System.EventHandler(this.listProps_SelectedIndexChanged);
            // 
            // richTextBoxClassDetails
            // 
            this.richTextBoxClassDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxClassDetails.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxClassDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxClassDetails.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxClassDetails.Name = "richTextBoxClassDetails";
            this.richTextBoxClassDetails.ReadOnly = true;
            this.richTextBoxClassDetails.Size = new System.Drawing.Size(545, 201);
            this.richTextBoxClassDetails.TabIndex = 0;
            this.richTextBoxClassDetails.Text = "";
            this.richTextBoxClassDetails.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxClassDetails_LinkClicked);
            this.richTextBoxClassDetails.Click += new System.EventHandler(this.richTextBox_Click);
            // 
            // tabMethods
            // 
            this.tabMethods.BackColor = System.Drawing.SystemColors.Control;
            this.tabMethods.Controls.Add(this.splitContainerMethodsTab);
            this.tabMethods.Location = new System.Drawing.Point(4, 22);
            this.tabMethods.Name = "tabMethods";
            this.tabMethods.Padding = new System.Windows.Forms.Padding(3);
            this.tabMethods.Size = new System.Drawing.Size(555, 499);
            this.tabMethods.TabIndex = 1;
            this.tabMethods.Text = "Methods";
            // 
            // splitContainerMethodsTab
            // 
            this.splitContainerMethodsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMethodsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMethodsTab.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMethodsTab.Name = "splitContainerMethodsTab";
            this.splitContainerMethodsTab.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMethodsTab.Panel1
            // 
            this.splitContainerMethodsTab.Panel1.Controls.Add(this.splitContainerMethodsParams);
            // 
            // splitContainerMethodsTab.Panel2
            // 
            this.splitContainerMethodsTab.Panel2.Controls.Add(this.richTextBoxMethodDetails);
            this.splitContainerMethodsTab.Size = new System.Drawing.Size(549, 493);
            this.splitContainerMethodsTab.SplitterDistance = 381;
            this.splitContainerMethodsTab.TabIndex = 0;
            // 
            // splitContainerMethodsParams
            // 
            this.splitContainerMethodsParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMethodsParams.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMethodsParams.Name = "splitContainerMethodsParams";
            this.splitContainerMethodsParams.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMethodsParams.Panel1
            // 
            this.splitContainerMethodsParams.Panel1.Controls.Add(this.groupBoxClassMethods);
            this.splitContainerMethodsParams.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainerMethodsParams.Panel2
            // 
            this.splitContainerMethodsParams.Panel2.Controls.Add(this.tableLayoutMethods);
            this.splitContainerMethodsParams.Size = new System.Drawing.Size(545, 377);
            this.splitContainerMethodsParams.SplitterDistance = 225;
            this.splitContainerMethodsParams.TabIndex = 2;
            // 
            // groupBoxClassMethods
            // 
            this.groupBoxClassMethods.Controls.Add(this.listMethods);
            this.groupBoxClassMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxClassMethods.Location = new System.Drawing.Point(3, 3);
            this.groupBoxClassMethods.Name = "groupBoxClassMethods";
            this.groupBoxClassMethods.Size = new System.Drawing.Size(539, 219);
            this.groupBoxClassMethods.TabIndex = 0;
            this.groupBoxClassMethods.TabStop = false;
            this.groupBoxClassMethods.Text = "Methods";
            // 
            // listMethods
            // 
            this.listMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMethods.FullRowSelect = true;
            this.listMethods.HideSelection = false;
            this.listMethods.Location = new System.Drawing.Point(3, 16);
            this.listMethods.MultiSelect = false;
            this.listMethods.Name = "listMethods";
            this.listMethods.ShowItemToolTips = true;
            this.listMethods.Size = new System.Drawing.Size(533, 200);
            this.listMethods.TabIndex = 0;
            this.listMethods.UseCompatibleStateImageBehavior = false;
            this.listMethods.View = System.Windows.Forms.View.Details;
            this.listMethods.SelectedIndexChanged += new System.EventHandler(this.listMethods_SelectedIndexChanged);
            // 
            // tableLayoutMethods
            // 
            this.tableLayoutMethods.ColumnCount = 2;
            this.tableLayoutMethods.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMethods.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMethods.Controls.Add(this.groupBoxMethodsParamsIn, 0, 0);
            this.tableLayoutMethods.Controls.Add(this.groupBoxMethodsParamsOut, 1, 0);
            this.tableLayoutMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMethods.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMethods.Name = "tableLayoutMethods";
            this.tableLayoutMethods.RowCount = 1;
            this.tableLayoutMethods.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMethods.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutMethods.Size = new System.Drawing.Size(545, 148);
            this.tableLayoutMethods.TabIndex = 1;
            // 
            // groupBoxMethodsParamsIn
            // 
            this.groupBoxMethodsParamsIn.Controls.Add(this.listMethodParamsIn);
            this.groupBoxMethodsParamsIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMethodsParamsIn.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMethodsParamsIn.Name = "groupBoxMethodsParamsIn";
            this.groupBoxMethodsParamsIn.Size = new System.Drawing.Size(266, 142);
            this.groupBoxMethodsParamsIn.TabIndex = 2;
            this.groupBoxMethodsParamsIn.TabStop = false;
            this.groupBoxMethodsParamsIn.Text = "In Params";
            // 
            // listMethodParamsIn
            // 
            this.listMethodParamsIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMethodParamsIn.FullRowSelect = true;
            this.listMethodParamsIn.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listMethodParamsIn.HideSelection = false;
            this.listMethodParamsIn.Location = new System.Drawing.Point(3, 16);
            this.listMethodParamsIn.Name = "listMethodParamsIn";
            this.listMethodParamsIn.ShowItemToolTips = true;
            this.listMethodParamsIn.Size = new System.Drawing.Size(260, 123);
            this.listMethodParamsIn.TabIndex = 0;
            this.listMethodParamsIn.UseCompatibleStateImageBehavior = false;
            this.listMethodParamsIn.View = System.Windows.Forms.View.Details;
            this.listMethodParamsIn.SelectedIndexChanged += new System.EventHandler(this.listProps_SelectedIndexChanged);
            // 
            // groupBoxMethodsParamsOut
            // 
            this.groupBoxMethodsParamsOut.Controls.Add(this.listMethodParamsOut);
            this.groupBoxMethodsParamsOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMethodsParamsOut.Location = new System.Drawing.Point(275, 3);
            this.groupBoxMethodsParamsOut.Name = "groupBoxMethodsParamsOut";
            this.groupBoxMethodsParamsOut.Size = new System.Drawing.Size(267, 142);
            this.groupBoxMethodsParamsOut.TabIndex = 3;
            this.groupBoxMethodsParamsOut.TabStop = false;
            this.groupBoxMethodsParamsOut.Text = "Out Params";
            // 
            // listMethodParamsOut
            // 
            this.listMethodParamsOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMethodParamsOut.FullRowSelect = true;
            this.listMethodParamsOut.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listMethodParamsOut.HideSelection = false;
            this.listMethodParamsOut.Location = new System.Drawing.Point(3, 16);
            this.listMethodParamsOut.Name = "listMethodParamsOut";
            this.listMethodParamsOut.ShowItemToolTips = true;
            this.listMethodParamsOut.Size = new System.Drawing.Size(261, 123);
            this.listMethodParamsOut.TabIndex = 0;
            this.listMethodParamsOut.UseCompatibleStateImageBehavior = false;
            this.listMethodParamsOut.View = System.Windows.Forms.View.Details;
            this.listMethodParamsOut.SelectedIndexChanged += new System.EventHandler(this.listProps_SelectedIndexChanged);
            // 
            // richTextBoxMethodDetails
            // 
            this.richTextBoxMethodDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMethodDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMethodDetails.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxMethodDetails.Name = "richTextBoxMethodDetails";
            this.richTextBoxMethodDetails.ReadOnly = true;
            this.richTextBoxMethodDetails.Size = new System.Drawing.Size(545, 104);
            this.richTextBoxMethodDetails.TabIndex = 0;
            this.richTextBoxMethodDetails.Text = "";
            this.richTextBoxMethodDetails.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxMethodDetails_LinkClicked);
            this.richTextBoxMethodDetails.Click += new System.EventHandler(this.richTextBox_Click);
            // 
            // tabQueryResults
            // 
            this.tabQueryResults.BackColor = System.Drawing.SystemColors.Control;
            this.tabQueryResults.Controls.Add(this.splitContainerQuery);
            this.tabQueryResults.Location = new System.Drawing.Point(4, 22);
            this.tabQueryResults.Name = "tabQueryResults";
            this.tabQueryResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueryResults.Size = new System.Drawing.Size(555, 499);
            this.tabQueryResults.TabIndex = 5;
            this.tabQueryResults.Text = "Query";
            // 
            // splitContainerQuery
            // 
            this.splitContainerQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerQuery.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerQuery.Location = new System.Drawing.Point(3, 3);
            this.splitContainerQuery.Name = "splitContainerQuery";
            this.splitContainerQuery.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerQuery.Panel1
            // 
            this.splitContainerQuery.Panel1.Controls.Add(this.tableLayoutQuery);
            this.splitContainerQuery.Panel1MinSize = 100;
            // 
            // splitContainerQuery.Panel2
            // 
            this.splitContainerQuery.Panel2.Controls.Add(this.groupBoxQueryResults);
            this.splitContainerQuery.Size = new System.Drawing.Size(549, 493);
            this.splitContainerQuery.SplitterDistance = 100;
            this.splitContainerQuery.SplitterWidth = 1;
            this.splitContainerQuery.TabIndex = 0;
            // 
            // tableLayoutQuery
            // 
            this.tableLayoutQuery.ColumnCount = 2;
            this.tableLayoutQuery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutQuery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutQuery.Controls.Add(this.groupBoxQueryOutput, 0, 0);
            this.tableLayoutQuery.Controls.Add(this.groupBoxQuery2, 0, 0);
            this.tableLayoutQuery.Controls.Add(this.buttonQueryExecute2, 1, 1);
            this.tableLayoutQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutQuery.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutQuery.Name = "tableLayoutQuery";
            this.tableLayoutQuery.RowCount = 2;
            this.tableLayoutQuery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutQuery.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutQuery.Size = new System.Drawing.Size(549, 100);
            this.tableLayoutQuery.TabIndex = 0;
            // 
            // groupBoxQueryOutput
            // 
            this.groupBoxQueryOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxQueryOutput.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxQueryOutput.Controls.Add(this.radioQueryOutDataGrid);
            this.groupBoxQueryOutput.Controls.Add(this.radioQueryOutListView);
            this.groupBoxQueryOutput.Location = new System.Drawing.Point(432, 3);
            this.groupBoxQueryOutput.Name = "groupBoxQueryOutput";
            this.groupBoxQueryOutput.Size = new System.Drawing.Size(114, 64);
            this.groupBoxQueryOutput.TabIndex = 2;
            this.groupBoxQueryOutput.TabStop = false;
            this.groupBoxQueryOutput.Text = "Output View";
            // 
            // radioQueryOutDataGrid
            // 
            this.radioQueryOutDataGrid.AutoSize = true;
            this.radioQueryOutDataGrid.Checked = true;
            this.radioQueryOutDataGrid.Location = new System.Drawing.Point(6, 19);
            this.radioQueryOutDataGrid.Name = "radioQueryOutDataGrid";
            this.radioQueryOutDataGrid.Size = new System.Drawing.Size(70, 17);
            this.radioQueryOutDataGrid.TabIndex = 0;
            this.radioQueryOutDataGrid.TabStop = true;
            this.radioQueryOutDataGrid.Text = "Data Grid";
            this.radioQueryOutDataGrid.UseVisualStyleBackColor = true;
            this.radioQueryOutDataGrid.CheckedChanged += new System.EventHandler(this.radioQueryOutDataGrid_CheckedChanged);
            // 
            // radioQueryOutListView
            // 
            this.radioQueryOutListView.AutoSize = true;
            this.radioQueryOutListView.Location = new System.Drawing.Point(6, 42);
            this.radioQueryOutListView.Name = "radioQueryOutListView";
            this.radioQueryOutListView.Size = new System.Drawing.Size(67, 17);
            this.radioQueryOutListView.TabIndex = 1;
            this.radioQueryOutListView.Text = "List View";
            this.radioQueryOutListView.UseVisualStyleBackColor = true;
            this.radioQueryOutListView.CheckedChanged += new System.EventHandler(this.radioQueryOutListView_CheckedChanged);
            // 
            // groupBoxQuery2
            // 
            this.groupBoxQuery2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQuery2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxQuery2.Controls.Add(this.textBoxQuery2);
            this.groupBoxQuery2.Location = new System.Drawing.Point(3, 3);
            this.groupBoxQuery2.Name = "groupBoxQuery2";
            this.tableLayoutQuery.SetRowSpan(this.groupBoxQuery2, 2);
            this.groupBoxQuery2.Size = new System.Drawing.Size(423, 94);
            this.groupBoxQuery2.TabIndex = 1;
            this.groupBoxQuery2.TabStop = false;
            this.groupBoxQuery2.Text = "WQL Query";
            // 
            // textBoxQuery2
            // 
            this.textBoxQuery2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQuery2.Location = new System.Drawing.Point(3, 16);
            this.textBoxQuery2.Multiline = true;
            this.textBoxQuery2.Name = "textBoxQuery2";
            this.textBoxQuery2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxQuery2.Size = new System.Drawing.Size(417, 75);
            this.textBoxQuery2.TabIndex = 0;
            // 
            // buttonQueryExecute2
            // 
            this.buttonQueryExecute2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQueryExecute2.Location = new System.Drawing.Point(432, 73);
            this.buttonQueryExecute2.Name = "buttonQueryExecute2";
            this.buttonQueryExecute2.Size = new System.Drawing.Size(114, 24);
            this.buttonQueryExecute2.TabIndex = 0;
            this.buttonQueryExecute2.Text = "Execute";
            this.buttonQueryExecute2.UseVisualStyleBackColor = true;
            this.buttonQueryExecute2.Click += new System.EventHandler(this.buttonQueryExecute2_Click);
            // 
            // groupBoxQueryResults
            // 
            this.groupBoxQueryResults.Controls.Add(this.splitContainerQueryResults);
            this.groupBoxQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxQueryResults.Location = new System.Drawing.Point(0, 0);
            this.groupBoxQueryResults.Name = "groupBoxQueryResults";
            this.groupBoxQueryResults.Size = new System.Drawing.Size(549, 392);
            this.groupBoxQueryResults.TabIndex = 0;
            this.groupBoxQueryResults.TabStop = false;
            this.groupBoxQueryResults.Text = "Results";
            // 
            // splitContainerQueryResults
            // 
            this.splitContainerQueryResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerQueryResults.Location = new System.Drawing.Point(3, 16);
            this.splitContainerQueryResults.Name = "splitContainerQueryResults";
            // 
            // splitContainerQueryResults.Panel1
            // 
            this.splitContainerQueryResults.Panel1.Controls.Add(this.listQueryResults);
            this.splitContainerQueryResults.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainerQueryResults.Panel2
            // 
            this.splitContainerQueryResults.Panel2.Controls.Add(this.propertyGridQueryResults);
            this.splitContainerQueryResults.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainerQueryResults.Size = new System.Drawing.Size(543, 373);
            this.splitContainerQueryResults.SplitterDistance = 177;
            this.splitContainerQueryResults.SplitterWidth = 1;
            this.splitContainerQueryResults.TabIndex = 1;
            // 
            // listQueryResults
            // 
            this.listQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listQueryResults.FullRowSelect = true;
            this.listQueryResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listQueryResults.HideSelection = false;
            this.listQueryResults.Location = new System.Drawing.Point(3, 3);
            this.listQueryResults.MultiSelect = false;
            this.listQueryResults.Name = "listQueryResults";
            this.listQueryResults.ShowItemToolTips = true;
            this.listQueryResults.Size = new System.Drawing.Size(167, 363);
            this.listQueryResults.TabIndex = 0;
            this.listQueryResults.UseCompatibleStateImageBehavior = false;
            this.listQueryResults.View = System.Windows.Forms.View.Details;
            this.listQueryResults.SelectedIndexChanged += new System.EventHandler(this.listQueryResults_SelectedIndexChanged);
            // 
            // propertyGridQueryResults
            // 
            this.propertyGridQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridQueryResults.Location = new System.Drawing.Point(3, 3);
            this.propertyGridQueryResults.Name = "propertyGridQueryResults";
            this.propertyGridQueryResults.Size = new System.Drawing.Size(355, 363);
            this.propertyGridQueryResults.TabIndex = 0;
            this.propertyGridQueryResults.ToolbarVisible = false;
            // 
            // tabScript
            // 
            this.tabScript.BackColor = System.Drawing.SystemColors.Control;
            this.tabScript.Controls.Add(this.tableLayoutScript);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(555, 499);
            this.tabScript.TabIndex = 6;
            this.tabScript.Text = "Script";
            // 
            // tableLayoutScript
            // 
            this.tableLayoutScript.ColumnCount = 3;
            this.tableLayoutScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutScript.Controls.Add(this.groupBoxScriptLanguage, 0, 0);
            this.tableLayoutScript.Controls.Add(this.groupBoxScriptOutput, 1, 0);
            this.tableLayoutScript.Controls.Add(this.groupBoxScriptExecute, 2, 0);
            this.tableLayoutScript.Controls.Add(this.groupBoxScript, 0, 1);
            this.tableLayoutScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutScript.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutScript.Name = "tableLayoutScript";
            this.tableLayoutScript.RowCount = 2;
            this.tableLayoutScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutScript.Size = new System.Drawing.Size(549, 493);
            this.tableLayoutScript.TabIndex = 0;
            // 
            // groupBoxScriptLanguage
            // 
            this.groupBoxScriptLanguage.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxScriptLanguage.Controls.Add(this.radioScriptPs);
            this.groupBoxScriptLanguage.Controls.Add(this.radioScriptVbs);
            this.groupBoxScriptLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxScriptLanguage.Location = new System.Drawing.Point(3, 3);
            this.groupBoxScriptLanguage.Name = "groupBoxScriptLanguage";
            this.groupBoxScriptLanguage.Size = new System.Drawing.Size(169, 49);
            this.groupBoxScriptLanguage.TabIndex = 1;
            this.groupBoxScriptLanguage.TabStop = false;
            this.groupBoxScriptLanguage.Text = "Script Language";
            // 
            // radioScriptPs
            // 
            this.radioScriptPs.AutoSize = true;
            this.radioScriptPs.Location = new System.Drawing.Point(78, 19);
            this.radioScriptPs.Name = "radioScriptPs";
            this.radioScriptPs.Size = new System.Drawing.Size(78, 17);
            this.radioScriptPs.TabIndex = 1;
            this.radioScriptPs.TabStop = true;
            this.radioScriptPs.Text = "PowerShell";
            this.radioScriptPs.UseVisualStyleBackColor = true;
            this.radioScriptPs.CheckedChanged += new System.EventHandler(this.radioScriptPs_CheckedChanged);
            // 
            // radioScriptVbs
            // 
            this.radioScriptVbs.AutoSize = true;
            this.radioScriptVbs.Location = new System.Drawing.Point(6, 19);
            this.radioScriptVbs.Name = "radioScriptVbs";
            this.radioScriptVbs.Size = new System.Drawing.Size(66, 17);
            this.radioScriptVbs.TabIndex = 0;
            this.radioScriptVbs.TabStop = true;
            this.radioScriptVbs.Text = "VBScript";
            this.radioScriptVbs.UseVisualStyleBackColor = true;
            this.radioScriptVbs.CheckedChanged += new System.EventHandler(this.radioScriptVbs_CheckedChanged);
            // 
            // groupBoxScriptOutput
            // 
            this.groupBoxScriptOutput.Controls.Add(this.radioScriptOutTxt);
            this.groupBoxScriptOutput.Controls.Add(this.radioScriptOutCmd);
            this.groupBoxScriptOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxScriptOutput.Location = new System.Drawing.Point(178, 3);
            this.groupBoxScriptOutput.Name = "groupBoxScriptOutput";
            this.groupBoxScriptOutput.Size = new System.Drawing.Size(169, 49);
            this.groupBoxScriptOutput.TabIndex = 2;
            this.groupBoxScriptOutput.TabStop = false;
            this.groupBoxScriptOutput.Text = "Output Format";
            // 
            // radioScriptOutTxt
            // 
            this.radioScriptOutTxt.AutoSize = true;
            this.radioScriptOutTxt.Location = new System.Drawing.Point(117, 19);
            this.radioScriptOutTxt.Name = "radioScriptOutTxt";
            this.radioScriptOutTxt.Size = new System.Drawing.Size(46, 17);
            this.radioScriptOutTxt.TabIndex = 1;
            this.radioScriptOutTxt.Text = "Text";
            this.radioScriptOutTxt.UseVisualStyleBackColor = true;
            // 
            // radioScriptOutCmd
            // 
            this.radioScriptOutCmd.AutoSize = true;
            this.radioScriptOutCmd.Checked = true;
            this.radioScriptOutCmd.Location = new System.Drawing.Point(6, 19);
            this.radioScriptOutCmd.Name = "radioScriptOutCmd";
            this.radioScriptOutCmd.Size = new System.Drawing.Size(108, 17);
            this.radioScriptOutCmd.TabIndex = 0;
            this.radioScriptOutCmd.TabStop = true;
            this.radioScriptOutCmd.Text = "Command Prompt";
            this.radioScriptOutCmd.UseVisualStyleBackColor = true;
            // 
            // groupBoxScriptExecute
            // 
            this.groupBoxScriptExecute.Controls.Add(this.buttonScriptSave);
            this.groupBoxScriptExecute.Controls.Add(this.buttonScriptRun);
            this.groupBoxScriptExecute.Location = new System.Drawing.Point(353, 3);
            this.groupBoxScriptExecute.Name = "groupBoxScriptExecute";
            this.groupBoxScriptExecute.Size = new System.Drawing.Size(177, 49);
            this.groupBoxScriptExecute.TabIndex = 3;
            this.groupBoxScriptExecute.TabStop = false;
            this.groupBoxScriptExecute.Text = "Execute";
            // 
            // buttonScriptSave
            // 
            this.buttonScriptSave.Enabled = false;
            this.buttonScriptSave.Location = new System.Drawing.Point(95, 20);
            this.buttonScriptSave.Name = "buttonScriptSave";
            this.buttonScriptSave.Size = new System.Drawing.Size(75, 23);
            this.buttonScriptSave.TabIndex = 1;
            this.buttonScriptSave.Text = "Save Script";
            this.buttonScriptSave.UseVisualStyleBackColor = true;
            this.buttonScriptSave.Click += new System.EventHandler(this.buttonScriptSave_Click);
            // 
            // buttonScriptRun
            // 
            this.buttonScriptRun.Enabled = false;
            this.buttonScriptRun.Location = new System.Drawing.Point(6, 20);
            this.buttonScriptRun.Name = "buttonScriptRun";
            this.buttonScriptRun.Size = new System.Drawing.Size(83, 23);
            this.buttonScriptRun.TabIndex = 0;
            this.buttonScriptRun.Text = "Run Script";
            this.buttonScriptRun.UseVisualStyleBackColor = true;
            this.buttonScriptRun.Click += new System.EventHandler(this.buttonScriptRun_Click);
            // 
            // groupBoxScript
            // 
            this.tableLayoutScript.SetColumnSpan(this.groupBoxScript, 3);
            this.groupBoxScript.Controls.Add(this.textBoxScript);
            this.groupBoxScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxScript.Location = new System.Drawing.Point(3, 58);
            this.groupBoxScript.Name = "groupBoxScript";
            this.groupBoxScript.Size = new System.Drawing.Size(544, 432);
            this.groupBoxScript.TabIndex = 4;
            this.groupBoxScript.TabStop = false;
            this.groupBoxScript.Text = "Script";
            // 
            // textBoxScript
            // 
            this.textBoxScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxScript.Location = new System.Drawing.Point(3, 16);
            this.textBoxScript.Multiline = true;
            this.textBoxScript.Name = "textBoxScript";
            this.textBoxScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxScript.Size = new System.Drawing.Size(538, 413);
            this.textBoxScript.TabIndex = 0;
            // 
            // tabLogging
            // 
            this.tabLogging.Controls.Add(this.textBoxLogging);
            this.tabLogging.Location = new System.Drawing.Point(4, 22);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogging.Size = new System.Drawing.Size(555, 499);
            this.tabLogging.TabIndex = 2;
            this.tabLogging.Text = "Logging";
            this.tabLogging.UseVisualStyleBackColor = true;
            // 
            // textBoxLogging
            // 
            this.textBoxLogging.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxLogging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogging.Location = new System.Drawing.Point(3, 3);
            this.textBoxLogging.Multiline = true;
            this.textBoxLogging.Name = "textBoxLogging";
            this.textBoxLogging.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogging.Size = new System.Drawing.Size(549, 493);
            this.textBoxLogging.TabIndex = 0;
            // 
            // tabDebug2
            // 
            this.tabDebug2.Controls.Add(this.tableLayoutDebug2);
            this.tabDebug2.Location = new System.Drawing.Point(4, 22);
            this.tabDebug2.Name = "tabDebug2";
            this.tabDebug2.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug2.Size = new System.Drawing.Size(555, 499);
            this.tabDebug2.TabIndex = 3;
            this.tabDebug2.Text = "Debug";
            this.tabDebug2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutDebug2
            // 
            this.tableLayoutDebug2.ColumnCount = 2;
            this.tableLayoutDebug2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDebug2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDebug2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDebug2.Controls.Add(this.propertyGridDebugWmiInstance, 1, 0);
            this.tableLayoutDebug2.Controls.Add(this.propertyGridDebugWmiClass, 0, 0);
            this.tableLayoutDebug2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutDebug2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutDebug2.Name = "tableLayoutDebug2";
            this.tableLayoutDebug2.RowCount = 1;
            this.tableLayoutDebug2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDebug2.Size = new System.Drawing.Size(549, 493);
            this.tableLayoutDebug2.TabIndex = 1;
            // 
            // propertyGridDebugWmiInstance
            // 
            this.propertyGridDebugWmiInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridDebugWmiInstance.Location = new System.Drawing.Point(277, 3);
            this.propertyGridDebugWmiInstance.Name = "propertyGridDebugWmiInstance";
            this.propertyGridDebugWmiInstance.Size = new System.Drawing.Size(269, 487);
            this.propertyGridDebugWmiInstance.TabIndex = 2;
            // 
            // propertyGridDebugWmiClass
            // 
            this.propertyGridDebugWmiClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridDebugWmiClass.Location = new System.Drawing.Point(3, 3);
            this.propertyGridDebugWmiClass.Name = "propertyGridDebugWmiClass";
            this.propertyGridDebugWmiClass.Size = new System.Drawing.Size(268, 487);
            this.propertyGridDebugWmiClass.TabIndex = 1;
            // 
            // tabSearch
            // 
            this.tabSearch.BackColor = System.Drawing.SystemColors.Control;
            this.tabSearch.Controls.Add(this.tableLayoutSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(772, 531);
            this.tabSearch.TabIndex = 1;
            this.tabSearch.Text = "Search";
            // 
            // tableLayoutSearch
            // 
            this.tableLayoutSearch.ColumnCount = 1;
            this.tableLayoutSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSearch.Controls.Add(this.groupBoxSearch, 0, 0);
            this.tableLayoutSearch.Controls.Add(this.groupBoxSearchResults, 0, 1);
            this.tableLayoutSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSearch.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSearch.Name = "tableLayoutSearch";
            this.tableLayoutSearch.RowCount = 2;
            this.tableLayoutSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSearch.Size = new System.Drawing.Size(766, 525);
            this.tableLayoutSearch.TabIndex = 0;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.radioSearchProperties);
            this.groupBoxSearch.Controls.Add(this.checkBoxSearchRecurse);
            this.groupBoxSearch.Controls.Add(this.radioSearchMethods);
            this.groupBoxSearch.Controls.Add(this.radioSearchClasses);
            this.groupBoxSearch.Controls.Add(this.labelSearch2);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchPattern);
            this.groupBoxSearch.Controls.Add(this.labelSearch1);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearch.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(760, 84);
            this.groupBoxSearch.TabIndex = 1;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search Options";
            // 
            // radioSearchProperties
            // 
            this.radioSearchProperties.AutoSize = true;
            this.radioSearchProperties.Location = new System.Drawing.Point(152, 39);
            this.radioSearchProperties.Name = "radioSearchProperties";
            this.radioSearchProperties.Size = new System.Drawing.Size(72, 17);
            this.radioSearchProperties.TabIndex = 2;
            this.radioSearchProperties.Text = "Properties";
            this.radioSearchProperties.UseVisualStyleBackColor = true;
            // 
            // checkBoxSearchRecurse
            // 
            this.checkBoxSearchRecurse.AutoSize = true;
            this.checkBoxSearchRecurse.Location = new System.Drawing.Point(516, 41);
            this.checkBoxSearchRecurse.Name = "checkBoxSearchRecurse";
            this.checkBoxSearchRecurse.Size = new System.Drawing.Size(74, 17);
            this.checkBoxSearchRecurse.TabIndex = 4;
            this.checkBoxSearchRecurse.Text = "Recursive";
            this.checkBoxSearchRecurse.UseVisualStyleBackColor = true;
            // 
            // radioSearchMethods
            // 
            this.radioSearchMethods.AutoSize = true;
            this.radioSearchMethods.Location = new System.Drawing.Point(80, 39);
            this.radioSearchMethods.Name = "radioSearchMethods";
            this.radioSearchMethods.Size = new System.Drawing.Size(66, 17);
            this.radioSearchMethods.TabIndex = 1;
            this.radioSearchMethods.Text = "Methods";
            this.radioSearchMethods.UseVisualStyleBackColor = true;
            // 
            // radioSearchClasses
            // 
            this.radioSearchClasses.AutoSize = true;
            this.radioSearchClasses.Checked = true;
            this.radioSearchClasses.Location = new System.Drawing.Point(13, 39);
            this.radioSearchClasses.Name = "radioSearchClasses";
            this.radioSearchClasses.Size = new System.Drawing.Size(61, 17);
            this.radioSearchClasses.TabIndex = 0;
            this.radioSearchClasses.TabStop = true;
            this.radioSearchClasses.Text = "Classes";
            this.radioSearchClasses.UseVisualStyleBackColor = true;
            // 
            // labelSearch2
            // 
            this.labelSearch2.AutoSize = true;
            this.labelSearch2.Location = new System.Drawing.Point(10, 64);
            this.labelSearch2.Name = "labelSearch2";
            this.labelSearch2.Size = new System.Drawing.Size(641, 13);
            this.labelSearch2.TabIndex = 3;
            this.labelSearch2.Text = "\"Include\" checkboxes in Class Options apply to Search Results as well. NOTE: Recu" +
    "rsively Searching Properties can take a long time.\r\n";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(596, 37);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(102, 23);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearchPattern
            // 
            this.textBoxSearchPattern.Location = new System.Drawing.Point(230, 38);
            this.textBoxSearchPattern.Name = "textBoxSearchPattern";
            this.textBoxSearchPattern.Size = new System.Drawing.Size(280, 20);
            this.textBoxSearchPattern.TabIndex = 3;
            this.textBoxSearchPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchPattern_KeyDown);
            // 
            // labelSearch1
            // 
            this.labelSearch1.AutoSize = true;
            this.labelSearch1.Location = new System.Drawing.Point(7, 20);
            this.labelSearch1.Name = "labelSearch1";
            this.labelSearch1.Size = new System.Drawing.Size(601, 13);
            this.labelSearch1.TabIndex = 0;
            this.labelSearch1.Text = "Select namespace, and specify search criteria to find all matching classes/method" +
    "s/properties within the selected namespace:";
            // 
            // groupBoxSearchResults
            // 
            this.groupBoxSearchResults.Controls.Add(this.listSearchResults);
            this.groupBoxSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearchResults.Location = new System.Drawing.Point(3, 93);
            this.groupBoxSearchResults.Name = "groupBoxSearchResults";
            this.groupBoxSearchResults.Size = new System.Drawing.Size(760, 429);
            this.groupBoxSearchResults.TabIndex = 2;
            this.groupBoxSearchResults.TabStop = false;
            this.groupBoxSearchResults.Text = "Search Results";
            // 
            // listSearchResults
            // 
            this.listSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSearchResults.FullRowSelect = true;
            this.listSearchResults.HideSelection = false;
            this.listSearchResults.Location = new System.Drawing.Point(3, 16);
            this.listSearchResults.MultiSelect = false;
            this.listSearchResults.Name = "listSearchResults";
            this.listSearchResults.ShowItemToolTips = true;
            this.listSearchResults.Size = new System.Drawing.Size(754, 410);
            this.listSearchResults.TabIndex = 0;
            this.listSearchResults.UseCompatibleStateImageBehavior = false;
            this.listSearchResults.View = System.Windows.Forms.View.Details;
            this.listSearchResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // tabDebug1
            // 
            this.tabDebug1.Controls.Add(this.tableLayoutDebug1);
            this.tabDebug1.Location = new System.Drawing.Point(4, 22);
            this.tabDebug1.Name = "tabDebug1";
            this.tabDebug1.Size = new System.Drawing.Size(772, 531);
            this.tabDebug1.TabIndex = 2;
            this.tabDebug1.Text = "Debug";
            this.tabDebug1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutDebug1
            // 
            this.tableLayoutDebug1.ColumnCount = 2;
            this.tableLayoutDebug1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDebug1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDebug1.Controls.Add(this.propertyGridDebugWmiNamespace, 1, 0);
            this.tableLayoutDebug1.Controls.Add(this.propertyGridDebugWmiNode, 0, 0);
            this.tableLayoutDebug1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutDebug1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutDebug1.Name = "tableLayoutDebug1";
            this.tableLayoutDebug1.RowCount = 1;
            this.tableLayoutDebug1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDebug1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 531F));
            this.tableLayoutDebug1.Size = new System.Drawing.Size(772, 531);
            this.tableLayoutDebug1.TabIndex = 0;
            // 
            // propertyGridDebugWmiNamespace
            // 
            this.propertyGridDebugWmiNamespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDebugWmiNamespace.Location = new System.Drawing.Point(389, 3);
            this.propertyGridDebugWmiNamespace.Name = "propertyGridDebugWmiNamespace";
            this.propertyGridDebugWmiNamespace.Size = new System.Drawing.Size(380, 525);
            this.propertyGridDebugWmiNamespace.TabIndex = 1;
            // 
            // propertyGridDebugWmiNode
            // 
            this.propertyGridDebugWmiNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDebugWmiNode.Location = new System.Drawing.Point(3, 3);
            this.propertyGridDebugWmiNode.Name = "propertyGridDebugWmiNode";
            this.propertyGridDebugWmiNode.Size = new System.Drawing.Size(380, 525);
            this.propertyGridDebugWmiNode.TabIndex = 2;
            // 
            // groupBoxCallingMode
            // 
            this.groupBoxCallingMode.Controls.Add(this.radioModeSync);
            this.groupBoxCallingMode.Controls.Add(this.radioModeAsync);
            this.groupBoxCallingMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCallingMode.Location = new System.Drawing.Point(224, 3);
            this.groupBoxCallingMode.Name = "groupBoxCallingMode";
            this.groupBoxCallingMode.Size = new System.Drawing.Size(114, 54);
            this.groupBoxCallingMode.TabIndex = 1;
            this.groupBoxCallingMode.TabStop = false;
            this.groupBoxCallingMode.Text = "Mode";
            // 
            // radioModeSync
            // 
            this.radioModeSync.AutoSize = true;
            this.radioModeSync.Location = new System.Drawing.Point(7, 31);
            this.radioModeSync.Name = "radioModeSync";
            this.radioModeSync.Size = new System.Drawing.Size(87, 17);
            this.radioModeSync.TabIndex = 1;
            this.radioModeSync.TabStop = true;
            this.radioModeSync.Text = "Synchronous";
            this.toolTip.SetToolTip(this.radioModeSync, "Synchronous enumeration of classes and instances. This can freeze the UI when enu" +
        "merating a large number of objects.");
            this.radioModeSync.UseVisualStyleBackColor = true;
            // 
            // radioModeAsync
            // 
            this.radioModeAsync.AutoSize = true;
            this.radioModeAsync.Checked = global::WmiExplorer.Properties.Settings.Default.bEnumModeAsync;
            this.radioModeAsync.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WmiExplorer.Properties.Settings.Default, "bEnumModeAsync", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radioModeAsync.Location = new System.Drawing.Point(7, 14);
            this.radioModeAsync.Name = "radioModeAsync";
            this.radioModeAsync.Size = new System.Drawing.Size(92, 17);
            this.radioModeAsync.TabIndex = 0;
            this.radioModeAsync.TabStop = true;
            this.radioModeAsync.Text = "Asynchronous";
            this.toolTip.SetToolTip(this.radioModeAsync, resources.GetString("radioModeAsync.ToolTip"));
            this.radioModeAsync.UseVisualStyleBackColor = true;
            // 
            // saveScriptDialog
            // 
            this.saveScriptDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveScriptDialog_FileOk);
            // 
            // WmiExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(18, 45);
            this.Name = "WmiExplorer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMI Explorer 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WmiExplorer_FormClosing);
            this.Load += new System.EventHandler(this.WmiExplorer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WmiExplorer_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.groupBoxComputer.ResumeLayout(false);
            this.groupBoxComputer.PerformLayout();
            this.groupBoxClassOptions.ResumeLayout(false);
            this.groupBoxClassOptions.PerformLayout();
            this.groupBoxQuery1.ResumeLayout(false);
            this.groupBoxQuery1.PerformLayout();
            this.splitContainerNamespaceClasses.Panel1.ResumeLayout(false);
            this.splitContainerNamespaceClasses.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNamespaceClasses)).EndInit();
            this.splitContainerNamespaceClasses.ResumeLayout(false);
            this.groupBoxNamespaces.ResumeLayout(false);
            this.tabControlClasses.ResumeLayout(false);
            this.tabClasses.ResumeLayout(false);
            this.splitContainerClassesInstances.Panel1.ResumeLayout(false);
            this.splitContainerClassesInstances.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassesInstances)).EndInit();
            this.splitContainerClassesInstances.ResumeLayout(false);
            this.tableLayoutClasses.ResumeLayout(false);
            this.tableLayoutClasses.PerformLayout();
            this.groupBoxClasses.ResumeLayout(false);
            this.tabControlInstances.ResumeLayout(false);
            this.tabInstances.ResumeLayout(false);
            this.groupBoxInstanceOptions.ResumeLayout(false);
            this.groupBoxInstanceOptions.PerformLayout();
            this.splitContainerInstancesProperties.Panel1.ResumeLayout(false);
            this.splitContainerInstancesProperties.Panel1.PerformLayout();
            this.splitContainerInstancesProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInstancesProperties)).EndInit();
            this.splitContainerInstancesProperties.ResumeLayout(false);
            this.groupBoxInstances.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.splitContainerClassProperties.Panel1.ResumeLayout(false);
            this.splitContainerClassProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassProperties)).EndInit();
            this.splitContainerClassProperties.ResumeLayout(false);
            this.groupBoxClassProperties.ResumeLayout(false);
            this.tabMethods.ResumeLayout(false);
            this.splitContainerMethodsTab.Panel1.ResumeLayout(false);
            this.splitContainerMethodsTab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMethodsTab)).EndInit();
            this.splitContainerMethodsTab.ResumeLayout(false);
            this.splitContainerMethodsParams.Panel1.ResumeLayout(false);
            this.splitContainerMethodsParams.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMethodsParams)).EndInit();
            this.splitContainerMethodsParams.ResumeLayout(false);
            this.groupBoxClassMethods.ResumeLayout(false);
            this.tableLayoutMethods.ResumeLayout(false);
            this.groupBoxMethodsParamsIn.ResumeLayout(false);
            this.groupBoxMethodsParamsOut.ResumeLayout(false);
            this.tabQueryResults.ResumeLayout(false);
            this.splitContainerQuery.Panel1.ResumeLayout(false);
            this.splitContainerQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQuery)).EndInit();
            this.splitContainerQuery.ResumeLayout(false);
            this.tableLayoutQuery.ResumeLayout(false);
            this.groupBoxQueryOutput.ResumeLayout(false);
            this.groupBoxQueryOutput.PerformLayout();
            this.groupBoxQuery2.ResumeLayout(false);
            this.groupBoxQuery2.PerformLayout();
            this.groupBoxQueryResults.ResumeLayout(false);
            this.splitContainerQueryResults.Panel1.ResumeLayout(false);
            this.splitContainerQueryResults.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerQueryResults)).EndInit();
            this.splitContainerQueryResults.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.tableLayoutScript.ResumeLayout(false);
            this.groupBoxScriptLanguage.ResumeLayout(false);
            this.groupBoxScriptLanguage.PerformLayout();
            this.groupBoxScriptOutput.ResumeLayout(false);
            this.groupBoxScriptOutput.PerformLayout();
            this.groupBoxScriptExecute.ResumeLayout(false);
            this.groupBoxScript.ResumeLayout(false);
            this.groupBoxScript.PerformLayout();
            this.tabLogging.ResumeLayout(false);
            this.tabLogging.PerformLayout();
            this.tabDebug2.ResumeLayout(false);
            this.tableLayoutDebug2.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tableLayoutSearch.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxSearchResults.ResumeLayout(false);
            this.tabDebug1.ResumeLayout(false);
            this.tableLayoutDebug1.ResumeLayout(false);
            this.groupBoxCallingMode.ResumeLayout(false);
            this.groupBoxCallingMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem menuItemLaunch;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp_Documentation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelUpdateNotification;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.GroupBox groupBoxComputer;
        private System.Windows.Forms.Button buttonComputerConnect;
        private System.Windows.Forms.TextBox textBoxComputerName;
        private System.Windows.Forms.GroupBox groupBoxClassOptions;
        private System.Windows.Forms.Button buttonClassesRefresh;
        private System.Windows.Forms.CheckBox checkBoxMSFT;
        private System.Windows.Forms.CheckBox checkBoxPerf;
        private System.Windows.Forms.CheckBox checkBoxCIM;
        private System.Windows.Forms.CheckBox checkBoxSystem;
        private System.Windows.Forms.TextBox textBoxClassFilter;
        private System.Windows.Forms.Label labelClassFilter;
        private System.Windows.Forms.GroupBox groupBoxQuery1;
        private System.Windows.Forms.Button buttonQueryExecute1;
        private System.Windows.Forms.Label labelQuery;
        private System.Windows.Forms.TextBox textBoxQuery1;
        private System.Windows.Forms.SplitContainer splitContainerNamespaceClasses;
        private System.Windows.Forms.GroupBox groupBoxNamespaces;
        private System.Windows.Forms.TreeView treeNamespaces;
        private System.Windows.Forms.TabControl tabControlClasses;
        private System.Windows.Forms.TabPage tabClasses;
        private System.Windows.Forms.SplitContainer splitContainerClassesInstances;
        private System.Windows.Forms.TabControl tabControlInstances;
        private System.Windows.Forms.TabPage tabInstances;
        private System.Windows.Forms.GroupBox groupBoxInstanceOptions;
        private System.Windows.Forms.Button buttonRefreshObject;
        private System.Windows.Forms.Button buttonInstancesRefresh;
        private System.Windows.Forms.CheckBox checkNullProps;
        private System.Windows.Forms.CheckBox checkSystemProps;
        private System.Windows.Forms.TextBox textBoxInstanceFilterQuick;
        private System.Windows.Forms.Label labelInstanceFilter;
        private System.Windows.Forms.SplitContainer splitContainerInstancesProperties;
        private System.Windows.Forms.GroupBox groupBoxInstances;
        private System.Windows.Forms.ListView listInstances;
        private System.Windows.Forms.PropertyGrid propertyGridInstance;
        private System.Windows.Forms.TabPage tabMethods;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.TextBox textBoxLogging;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutClasses;
        private System.Windows.Forms.TextBox textBoxClassQuickFilter;
        private System.Windows.Forms.GroupBox groupBoxClasses;
        private System.Windows.Forms.ListView listClasses;
        private System.Windows.Forms.Label labelClassQuickFilter;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile_Preferences;
        private System.Windows.Forms.Button buttonHideNamespaces;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage tabDebug2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDebug2;
        private System.Windows.Forms.PropertyGrid propertyGridDebugWmiInstance;
        private System.Windows.Forms.PropertyGrid propertyGridDebugWmiClass;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.GroupBox groupBoxClassProperties;
        private System.Windows.Forms.SplitContainer splitContainerClassProperties;
        private System.Windows.Forms.RichTextBox richTextBoxClassDetails;
        private System.Windows.Forms.ListView listClassProperties;
        private System.Windows.Forms.SplitContainer splitContainerMethodsTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMethods;
        private System.Windows.Forms.GroupBox groupBoxClassMethods;
        private System.Windows.Forms.ListView listMethods;
        private System.Windows.Forms.GroupBox groupBoxMethodsParamsIn;
        private System.Windows.Forms.ListView listMethodParamsIn;
        private System.Windows.Forms.GroupBox groupBoxMethodsParamsOut;
        private System.Windows.Forms.ListView listMethodParamsOut;
        private System.Windows.Forms.RichTextBox richTextBoxMethodDetails;
        private System.Windows.Forms.TabPage tabQueryResults;
        private System.Windows.Forms.SplitContainer splitContainerQuery;
        private System.Windows.Forms.GroupBox groupBoxQueryResults;
        private System.Windows.Forms.SplitContainer splitContainerQueryResults;
        private System.Windows.Forms.PropertyGrid propertyGridQueryResults;
        private System.Windows.Forms.ListView listQueryResults;
        private System.Windows.Forms.TableLayoutPanel tableLayoutQuery;
        private System.Windows.Forms.Button buttonQueryExecute2;
        private System.Windows.Forms.GroupBox groupBoxQueryOutput;
        private System.Windows.Forms.RadioButton radioQueryOutDataGrid;
        private System.Windows.Forms.RadioButton radioQueryOutListView;
        private System.Windows.Forms.GroupBox groupBoxQuery2;
        private System.Windows.Forms.TextBox textBoxQuery2;
        private System.Windows.Forms.DataGridView dataGridQueryResults;
        private TabPage tabDebug1;
        private TableLayoutPanel tableLayoutDebug1;
        private PropertyGrid propertyGridDebugWmiNamespace;
        private PropertyGrid propertyGridDebugWmiNode;
        private TableLayoutPanel tableLayoutSearch;
        private GroupBox groupBoxSearch;
        private RadioButton radioSearchProperties;
        private CheckBox checkBoxSearchRecurse;
        private RadioButton radioSearchMethods;
        private RadioButton radioSearchClasses;
        private Label labelSearch2;
        private Button buttonSearch;
        private TextBox textBoxSearchPattern;
        private Label labelSearch1;
        private GroupBox groupBoxSearchResults;
        private ListView listSearchResults;
        private TabPage tabScript;
        private TableLayoutPanel tableLayoutScript;
        private GroupBox groupBoxScriptLanguage;
        private RadioButton radioScriptPs;
        private RadioButton radioScriptVbs;
        private GroupBox groupBoxScriptOutput;
        private RadioButton radioScriptOutTxt;
        private RadioButton radioScriptOutCmd;
        private GroupBox groupBoxScriptExecute;
        private Button buttonScriptSave;
        private Button buttonScriptRun;
        private GroupBox groupBoxScript;
        private TextBox textBoxScript;
        private SaveFileDialog saveScriptDialog;
        private ToolStripMenuItem menuItemLaunch_DcomCnfg;
        private ToolStripMenuItem menuItemLaunch_WbemTest;
        private ToolStripMenuItem menuItemLaunch_WmiMgmt;
        private ToolStripMenuItem menuItemHelp_CheckUpdate;
        private GroupBox groupBoxCallingMode;
        private RadioButton radioModeSync;
        private RadioButton radioModeAsync;
        private ToolStripMenuItem menuItemFile_ConnectAs;
        private ToolStripMenuItem menuItemFile_SmsMode;
        private ToolStripMenuItem menuItemHelp_About;
        private SplitContainer splitContainerMethodsParams;
    }
}

