using System;
using System.ComponentModel;
using System.Globalization;
using System.Management;

namespace WmiExplorer.Classes
{
    /// <summary>
    /// Used to display property values of Embedded WMI Objects.
    /// Reference tutorial: http://www.codeproject.com/Articles/4448/Customized-display-of-collection-data-in-a-Propert
    /// </summary>
    internal class ManagementBaseObjectWConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is ManagementBaseObjectW)
            {
                ManagementBaseObjectW mObjectW = (ManagementBaseObjectW)value;

                // If PropertyName contains Name, return the value of the property
                foreach (PropertyData p in mObjectW.Properties)
                {
                    if (p.Name.Contains("Name"))
                        return p.Value.ToString();
                }

                // No match on Name. If PropertyName contains ID, return the value of the property
                foreach (PropertyData p in mObjectW.Properties)
                {
                    if (p.Name.Contains("ID"))
                        return p.Value.ToString();
                }

                // No match on Name or ID. If Property is key, return the value of the property
                foreach (PropertyData p in mObjectW.Properties)
                {
                    foreach (QualifierData q in p.Qualifiers)
                        if (q.Name.Equals("key", StringComparison.InvariantCultureIgnoreCase))
                            if (String.IsNullOrEmpty(p.Value.ToString()))
                                return String.Empty;
                            else
                                return p.Value.ToString();
                }

                // No matches. Return an empty string.
                return String.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}