using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace WmiExplorer.Classes
{
    internal class WmiClass
    {
        public List<ListViewItem> Instances = new List<ListViewItem>();
        private string _description;
        private string _displayName;
        private string _enumerationStatus;
        private DateTime _enumTime;
        private TimeSpan _enumTimeElapsed;
        private bool _hasLazyProperties;
        private string _instanceFilterQuick;
        private string _namespacePath;
        private string _path;
        private string _relativePath;

        public WmiClass(ManagementClass actualClass)
        {
            Class = actualClass;
        }

        public ManagementClass Class { get; set; }

        public string Description
        {
            get
            {
                try
                {
                    foreach (QualifierData q in from QualifierData q in Class.Qualifiers where q.Name.Equals("Description", StringComparison.CurrentCultureIgnoreCase) select q)
                    {
                        _description = Class.GetQualifierValue("Description").ToString();
                    }
                }
                catch (ManagementException ex)
                {
                    if ((ex.ErrorCode).ToString() == "NotFound")
                        _description = String.Empty;
                    else
                        _description = "Error getting Class Description";
                }

                return _description;
            }
        }

        public string DisplayName
        {
            get
            {
                if (_displayName == null)
                    _displayName = Class.ClassPath.ClassName;

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

        public bool HasLazyProperties
        {
            get
            {
                foreach (PropertyData pd in Class.Properties)
                {
                    foreach (QualifierData qd in pd.Qualifiers)
                    {
                        if (qd.Name.Equals("lazy", StringComparison.CurrentCultureIgnoreCase))
                        {
                            _hasLazyProperties = true;
                            return _hasLazyProperties;
                        }
                    }
                }

                return _hasLazyProperties;
            }
        }

        public int InstanceCount { get; set; }

        public string InstanceFilterQuick
        {
            get
            {
                if (_instanceFilterQuick == null)
                    _instanceFilterQuick = String.Empty;

                return _instanceFilterQuick;
            }
            set { _instanceFilterQuick = value; }
        }

        // Indicates if class has instances enumerated
        public bool IsEnumerated { get; set; }

        // Indicates if class is currently being enumerated
        public bool IsEnumerating { get; set; }

        // Indicates if cancellation is requested for this class.
        public bool IsEnumerationCancelled { get; set; }

        // Indicates if class has instances partially enumerated. This can occur if user cancels operation.
        public bool IsPartiallyEnumerated { get; set; }

        public string NamespacePath
        {
            get
            {
                if (_namespacePath == null)
                    _namespacePath = Class.Scope.Path.Path;

                return _namespacePath;
            }
        }

        public string Path
        {
            get
            {
                if (_path == null)
                    _path = Class.Path.Path;
                return _path;
            }
        }

        public string RelativePath
        {
            get
            {
                if (_relativePath == null)
                    _relativePath = Class.Path.RelativePath;

                return _relativePath;
            }
        }

        public void AddInstance(ListViewItem listItemInstance)
        {
            Instances.Add(listItemInstance);
        }

        public string GetClassMof(bool bAmended = false)
        {
            Class.Options.UseAmendedQualifiers = bAmended;
            Class.Get();
            return Class.GetText(TextFormat.Mof).Replace("\n", "\r\n");
        }

        public void ResetInstances()
        {
            InstanceCount = Instances.Count;
            Instances = new List<ListViewItem>();
        }
    }
}