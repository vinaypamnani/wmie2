using System.ComponentModel;
using System.Management;

namespace WmiExplorer.Classes
{
    /// <summary>
    /// Wrapper Class for ManagementObject
    /// </summary>
    [TypeConverter(typeof(ManagementBaseObjectWConverter))]
    internal class ManagementObjectW : ManagementBaseObjectW
    {
        public ManagementObjectW(ManagementBaseObject actualObject)
            : base(actualObject)
        {
        }
    }
}