using System.Management;

namespace WmiExplorer.Classes
{
    internal class WmiMethod
    {
        private string _description;
        private bool _isStatic;
        private string _methodName;
        private string _path;
        private MethodData _wmiMethod;

        public WmiMethod(MethodData actualMethod)
        {
            _wmiMethod = actualMethod;
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool IsStatic
        {
            get { return _isStatic; }
            set { _isStatic = value; }
        }

        public string MethodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}