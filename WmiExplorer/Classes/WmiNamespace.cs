using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

namespace WmiExplorer.Classes
{
    internal class WmiNamespace
    {
        public int ClassCount = 0;
        public List<ListViewItem> Classes = new List<ListViewItem>();
        private readonly ManagementObject _wmiNamespace;
        private string _classFilter;            // Class Filter for current namespace
        private string _classFilterQuick;       // Quick Filter for current namespace
        private string _displayName;            // Display Name of the current namespace
        private string _enumerationStatus;      // Class Enumeration status of current namespace
        private DateTime _enumTime;             // Enumeration Time of current namespace
        private TimeSpan _enumTimeElapsed;      // Time taken to enumerate classes for current namespace
        private bool _isRootNode;               // Indicates if current namespace is the root node
        private string _path;                   // Path of the current namespace
        private string _relativePath;           // Relative Path of current namespace
        private string _serverName;             // Server name

        public WmiNamespace(ManagementObject actualNamespace)
        {
            _wmiNamespace = actualNamespace;
        }

        public string ClassFilter
        {
            get
            {
                if (_classFilter == null)
                    _classFilter = "%";

                return _classFilter;
            }
            set { _classFilter = value; }
        }

        public string ClassFilterQuick
        {
            get
            {
                if (_classFilterQuick == null)
                    _classFilterQuick = String.Empty;

                return _classFilterQuick;
            }
            set { _classFilterQuick = value; }
        }

        public string DisplayName
        {
            get
            {
                if (_displayName == null)
                {
                    if (IsRootNode)
                        _displayName = _wmiNamespace.Scope.Path.Path.ToUpper();
                    else
                        _displayName = RelativePath;
                }
                return _displayName;
            }
            set { _displayName = value; }
        }

        public string EnumerationStatus
        {
            get
            {
                if (String.IsNullOrEmpty(_enumerationStatus))
                    _enumerationStatus = "NoError";

                return _enumerationStatus;
            }
            set { _enumerationStatus = value; }
        }

        public DateTime EnumTime
        {
            get { return _enumTime; }
            set { _enumTime = value; }
        }

        public TimeSpan EnumTimeElapsed
        {
            get { return _enumTimeElapsed; }
            set { _enumTimeElapsed = value; }
        }

        // Indicates if current namespace has classes enumerated
        public bool IsEnumerated { get; set; }

        // Indicates if current namespace is currently being enumerated
        public bool IsEnumerating { get; set; }

        // Indicates if cancellation is requested for this namespace.
        public bool IsEnumerationCancelled { get; set; }

        // Indicates if current namespace has classes partially enumerated. This can occur if user cancels operation.
        public bool IsPartiallyEnumerated { get; set; }

        public bool IsRootNode
        {
            get
            {
                // Namespace in root node has Path.Path set to Empty string
                if (String.IsNullOrEmpty(_wmiNamespace.Path.Path))
                    _isRootNode = true;
                else
                    _isRootNode = false;

                return _isRootNode;
            }
        }

        public string Path
        {
            get
            {
                if (_path == null)
                {
                    if (IsRootNode)
                        _path = _wmiNamespace.Scope.Path.Path.ToUpper();
                    else
                        _path = "\\\\" + _wmiNamespace.Path.Server + "\\" + _wmiNamespace.GetPropertyValue("__Namespace") + "\\" + _wmiNamespace.GetPropertyValue("Name");
                }
                return _path;
            }
        }

        public string RelativePath
        {
            get
            {
                if (_relativePath == null)
                {
                    if (IsRootNode)
                        _relativePath = _wmiNamespace.Scope.Path.NamespacePath.ToUpper();
                    else
                        _relativePath = _wmiNamespace.GetPropertyValue("__NAMESPACE") + "\\" + _wmiNamespace.GetPropertyValue("Name");
                }
                return _relativePath;
            }
        }

        public string ServerName
        {
            get
            {
                if (_serverName == null)
                    _serverName = _wmiNamespace.Scope.Path.Server;

                return _serverName;
            }
            set { _serverName = value; }
        }

        /// <summary>
        /// Adds new list item to _classes. Called by ObserverHandler when NewObject arrives.
        /// </summary>
        /// <param name="listItemClass"></param>
        public void AddClass(ListViewItem listItemClass)
        {
            Classes.Add(listItemClass);
        }

        /// <summary>
        /// Resets contents of _classes
        /// </summary>
        public void ResetClasses()
        {
            ClassCount = Classes.Count;
            Classes = new List<ListViewItem>();
        }
    }
}