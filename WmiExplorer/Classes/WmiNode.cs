using System;
using System.Management;
using WmiExplorer.Sms;

namespace WmiExplorer.Classes
{
    internal class WmiNode
    {
        private ConnectionOptions _connection;

        private string _expansionStatus;

        private string _userSpecifiedPath;

        // Constructor to create Root Node
        public WmiNode()
        {
        }

        // Constructor to create Wmi Node for the specified namespace
        public WmiNode(ManagementObject wmiNamespace)
        {
            WmiNamespace = new WmiNamespace(wmiNamespace);
            //_connection = wmiNamespace.Scope.Options;
        }

        public ConnectionOptions Connection
        {
            get { return _connection; }
        }

        public string ExpansionStatus
        {
            get
            {
                if (String.IsNullOrEmpty(_expansionStatus))
                    _expansionStatus = "NoError";

                return _expansionStatus;
            }
            set { _expansionStatus = value; }
        }

        public bool IsConnected { get; set; }

        public bool IsExpanded { get; set; }

        public bool IsRootNode { get; set; }

        public SmsClient SmsClient { get; set; }

        public string UserSpecifiedPath
        {
            get { return _userSpecifiedPath; }
            set
            {
                _userSpecifiedPath = IsRootNode ? value : "NotApplicable";
            }
        }

        public WmiNamespace WmiNamespace { get; set; }

        public void SetConnection(ConnectionOptions value)
        {
            _connection = value;
        }
    }
}