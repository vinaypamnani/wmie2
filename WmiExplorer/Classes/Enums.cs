using System;
using System.Drawing;

namespace WmiExplorer.Classes
{
    public enum MessageCategory
    {
        Unknown,
        Info,
        Action,
        Warn,
        Error,
        Cache,
        Sms,
        None,
    }

    [Flags]
    public enum EnumOptions
    {
        None = 0,
        IncludeSystem = 1,
        IncludeCim = 2,
        IncludePerf = 4,
        IncludeMsft = 8,
        ShowNullInstanceValues = 16,
        ShowSystemProperties = 32,
        ExcludeSmsCollections = 64,
        ExcludeSmsInventory = 128
    }

    public static class ColorCategory
    {
        public static Color Unknown = Color.Gold;
        public static Color Info = Color.YellowGreen;
        public static Color Action = Color.Khaki;
        public static Color Warn = Color.Yellow;
        public static Color Error = Color.Red;
        public static Color Cache = Color.LightGreen;
        public static Color Sms = Color.LightSkyBlue;
        public static Color None = Color.Empty;
    }
}
