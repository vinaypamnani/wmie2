using System.Management;

namespace WmiExplorer.Classes
{
    internal class WmiInstance
    {
        private string _path;
        private string _relativePath;

        public WmiInstance(ManagementObject actualObject)
        {
            Instance = actualObject;
        }

        public ManagementObject Instance { get; set; }

        public string Path
        {
            get
            {
                if (_path == null)
                    _path = Instance.Path.Path;

                return _path;
            }
        }

        public string RelativePath
        {
            get
            {
                if (_relativePath == null)
                    _relativePath = Instance.Path.RelativePath;

                return _relativePath;
            }
        }

        public string GetInstanceMof(bool bAmended = false)
        {
            if (bAmended)
                Instance.Options.UseAmendedQualifiers = true;
            else
                Instance.Options.UseAmendedQualifiers = false;

            Instance.Get();
            return Instance.GetText(TextFormat.Mof).Replace("\n", "\r\n");
        }
    }
}