using System;
using System.ComponentModel;
using System.Management;

namespace WmiExplorer.Classes
{
    /// <summary>
    /// Wrapper Class for ManagementBaseObject
    /// Uses ManagementBaseObjectWConverter to display appropriate text if Embedded Objects are expanded.
    /// Reference Links and Tutorials:
    /// http://www.codeproject.com/Articles/539202/CIMTool-for-Windows-Management-Instrumentation-Par
    /// http://www.codeproject.com/Articles/4448/Customized-display-of-collection-data-in-a-Propert
    /// http://msdn.microsoft.com/en-us/magazine/cc163816.aspx
    /// </summary>
    [TypeConverter(typeof(ManagementBaseObjectWConverter))]
    internal class ManagementBaseObjectW : ICustomTypeDescriptor
    {
        private readonly ManagementBaseObject _wrapperObject;

        private ManagementPath _classPath;

        private PropertyDataCollection _properties;

        private QualifierDataCollection _qualifiers;

        private PropertyDataCollection _systemProperties;

        private PropertyDescriptorCollection _propertyDescriptorCollection;

        public ManagementBaseObjectW(ManagementBaseObject actualObject)
        {
            _wrapperObject = actualObject;
        }

        public ManagementPath ClassPath
        {
            get
            {
                if (_classPath == null)
                {
                    _classPath = _wrapperObject.ClassPath;
                }
                return _classPath;
            }
        }

        public bool IncludeNullProperties { get; set; }

        public bool IncludeSystemProperties { get; set; }

        public PropertyDataCollection Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = _wrapperObject.Properties;
                }
                return _properties;
            }
        }

        public virtual QualifierDataCollection Qualifiers
        {
            get
            {
                if (_qualifiers == null)
                {
                    _qualifiers = _wrapperObject.Qualifiers;
                }
                return _qualifiers;
            }
        }

        public virtual PropertyDataCollection SystemProperties
        {
            get
            {
                if (_systemProperties == null)
                {
                    _systemProperties = _wrapperObject.SystemProperties;
                }
                return _systemProperties;
            }
        }

        public object this[string propertyName]
        {
            get
            {
                return _wrapperObject[propertyName];
            }
            set
            {
                _wrapperObject[propertyName] = value;
            }
        }

        public static Type GetTypeFor(CimType cimType, bool isArray)
        {
            switch (cimType)
            {
                case CimType.None:
                    break;

                case CimType.SInt8:
                    if (isArray)
                        return typeof(sbyte[]);
                    return typeof(sbyte);

                case CimType.UInt8:
                    if (isArray)
                        return typeof(byte[]);
                    return typeof(byte);

                case CimType.SInt16:
                    if (isArray)
                        return typeof(short[]);
                    return typeof(short);

                case CimType.UInt16:
                    if (isArray)
                        return typeof(ushort[]);
                    return typeof(ushort);

                case CimType.SInt32:
                    if (isArray)
                        return typeof(int[]);
                    return typeof(int);

                case CimType.UInt32:
                    if (isArray)
                        return typeof(uint[]);
                    return typeof(uint);

                case CimType.SInt64:
                    if (isArray)
                        return typeof(long[]);
                    return typeof(long);

                case CimType.UInt64:
                    if (isArray)
                        return typeof(ulong[]);
                    return typeof(ulong);

                case CimType.Real32:
                    if (isArray)
                        return typeof(float[]);
                    return typeof(float);

                case CimType.Real64:
                    if (isArray)
                        return typeof(double[]);
                    return typeof(double);

                case CimType.Boolean:
                    if (isArray)
                        return typeof(bool[]);
                    return typeof(bool);

                case CimType.String:
                    if (isArray)
                        return typeof(string[]);
                    return typeof(string);

                case CimType.DateTime:
                    if (isArray)
                        return typeof(DateTime[]);
                    return typeof(DateTime);

                case CimType.Reference:
                    if (isArray)
                        return typeof(object[]);
                    return typeof(object);

                case CimType.Char16:
                    if (isArray)
                        return typeof(char[]);
                    return typeof(char);

                case CimType.Object:

                    if (isArray)
                        return typeof(object[]);
                    return typeof(object);
            }
            return null;
        }

        public bool CompareTo(ManagementBaseObject otherObject, ComparisonSettings settings)
        {
            return _wrapperObject.CompareTo(otherObject, settings);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            if (_propertyDescriptorCollection == null)
            {
                _propertyDescriptorCollection = new PropertyDescriptorCollection(null);

                // Properties
                foreach (PropertyData property in Properties)
                {
                    if (_propertyDescriptorCollection.Find(property.Name, true) == null)
                    {
                        if (IncludeNullProperties)
                        {
                            PropertyDescriptor propertyDescriptor = GetPropertyDescriptor(property);
                            _propertyDescriptorCollection.Add(propertyDescriptor);
                        }
                        else if (property.Value != null)
                        {
                            PropertyDescriptor propertyDescriptor = GetPropertyDescriptor(property);
                            _propertyDescriptorCollection.Add(propertyDescriptor);
                        }
                    }
                }

                // System Properties
                if (IncludeSystemProperties)
                {
                    foreach (PropertyData property in SystemProperties)
                    {
                        if (_propertyDescriptorCollection.Find(property.Name, true) == null)
                        {
                            PropertyDescriptor propertyDescriptor = GetPropertyDescriptor(property);
                            _propertyDescriptorCollection.Add(propertyDescriptor);
                        }
                    }
                }
            }

            return _propertyDescriptorCollection;
        }

        public object GetPropertyQualifierValue(string propertyName, string qualifierName)
        {
            return _wrapperObject.GetPropertyQualifierValue(propertyName, qualifierName);
        }

        public object GetPropertyValue(string propertyName)
        {
            //not used by PropertyGrid
            return _wrapperObject.GetPropertyValue(propertyName);
        }

        public object GetQualifierValue(string qualifierName)
        {
            return _wrapperObject.GetQualifierValue(qualifierName);
        }

        public string GetText(TextFormat format)
        {
            return _wrapperObject.GetText(format);
        }

        // ICustomTypeDescriptor implementation
        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return GetProperties();
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        public void SetPropertyQualifierValue(string propertyName, string qualifierName, object qualifierValue)
        {
            _wrapperObject.SetPropertyQualifierValue(propertyName, qualifierName, qualifierValue);
        }

        public void SetPropertyValue(string propertyName, object propertyValue)
        {
            _wrapperObject.SetPropertyValue(propertyName, propertyValue);
        }

        public void SetQualifierValue(string qualifierName, object qualifierValue)
        {
            _wrapperObject.SetQualifierValue(qualifierName, qualifierValue);
        }

        protected virtual PropertyDescriptor GetPropertyDescriptor(PropertyData property)
        {
            ManagementBaseObjectPropertyDescriptor result = new ManagementBaseObjectPropertyDescriptor(this, property);
            return result;
        }
    }
}