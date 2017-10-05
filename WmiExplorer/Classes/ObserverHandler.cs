using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace WmiExplorer.Classes
{
    internal class ObserverHandler
    {
        private readonly bool _isClass;
        private readonly bool _isNamespace;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly WmiClass _wmiClass;
        private readonly WmiNamespace _wmiNamespace;

        /// <summary>
        /// Constructor for observer working on retrieving classes for a Namespace
        /// </summary>
        /// <param name="wmiNamespace">Instance of WmiNamespace for which to enumerate classes</param>
        public ObserverHandler(WmiNamespace wmiNamespace)
        {
            _wmiNamespace = wmiNamespace;
            _wmiNamespace.IsEnumerating = true;
            _isNamespace = true;
            _stopwatch.Start();
        }

        /// <summary>
        /// Constructor for observer working on retrieving instances for a Class
        /// </summary>
        /// <param name="wmiClass">Instance of WmiClass for which to enumerate instances</param>
        public ObserverHandler(WmiClass wmiClass)
        {
            _wmiClass = wmiClass;
            _wmiClass.IsEnumerating = true;
            _isClass = true;
            _stopwatch.Start();
        }

        public bool IsComplete { get; private set; }

        public void Done(object sender, CompletedEventArgs e)
        {
            _stopwatch.Stop();

            if (_isNamespace)
            {
                if (e.Status == ManagementStatus.CallCanceled)
                {
                    _wmiNamespace.IsPartiallyEnumerated = true;
                    _wmiNamespace.IsEnumerationCancelled = true;
                }
                else
                {
                    _wmiNamespace.IsPartiallyEnumerated = false;
                    _wmiNamespace.IsEnumerationCancelled = false;
                }

                _wmiNamespace.IsEnumerated = true;
                _wmiNamespace.IsEnumerating = false;
                _wmiNamespace.EnumerationStatus = e.Status.ToString();
                _wmiNamespace.EnumTime = DateTime.Now;
                _wmiNamespace.EnumTimeElapsed = _stopwatch.Elapsed;

                CacheItem ci = new CacheItem(_wmiNamespace.Path, _wmiNamespace.Classes);
                WmiExplorer.AppCache.Set(ci, WmiExplorer.CachePolicy);
                _wmiNamespace.ResetClasses();
            }

            if (_isClass)
            {
                if (e.Status == ManagementStatus.CallCanceled)
                {
                    _wmiClass.IsPartiallyEnumerated = true;
                    _wmiClass.IsEnumerationCancelled = true;
                }
                else
                {
                    _wmiClass.IsPartiallyEnumerated = false;
                    _wmiClass.IsEnumerationCancelled = false;
                }

                _wmiClass.IsEnumerated = true;
                _wmiClass.IsEnumerating = false;
                _wmiClass.IsEnumerationCancelled = false;
                _wmiClass.EnumerationStatus = e.Status.ToString();
                _wmiClass.EnumTime = DateTime.Now;
                _wmiClass.EnumTimeElapsed = _stopwatch.Elapsed;

                CacheItem ci = new CacheItem(_wmiClass.Path, _wmiClass.Instances);
                WmiExplorer.AppCache.Set(ci, WmiExplorer.CachePolicy);
                _wmiClass.ResetInstances();
            }

            IsComplete = true;
        }

        public void NewObject(object sender, ObjectReadyEventArgs e)
        {
            ManagementObject mObject = (ManagementObject)e.NewObject;

            if (mObject.Path.IsClass && _isNamespace)
            {
                WmiClass wmiClass = new WmiClass(mObject as ManagementClass);

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

                _wmiNamespace.AddClass(li);
            }

            if (mObject.Path.IsInstance && _isClass)
            {
                WmiInstance wmiInstance = new WmiInstance(mObject);

                ListViewItem li = new ListViewItem
                {
                    Name = wmiInstance.Path,
                    Text = wmiInstance.RelativePath,
                    ToolTipText = wmiInstance.RelativePath,
                    Tag = wmiInstance
                };

                _wmiClass.AddInstance(li);
            }
        }
    }
}