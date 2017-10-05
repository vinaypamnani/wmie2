using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WmiExplorer.Classes
{
    // Reference Link: David Rickard's Blog
    // http://blogs.msdn.com/b/davidrickard/archive/2010/03/09/saving-window-size-and-location-in-wpf-and-winforms.aspx

    // POINT structure required by WINDOWPLACEMENT structure
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    // RECT structure required by WINDOWPLACEMENT structure
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }

    // WINDOWPLACEMENT stores the position, size, and state of a window
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public int showCmd;
        public POINT minPosition;
        public POINT maxPosition;
        public RECT normalPosition;
    }

    internal class WindowPlacement
    {
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWNORMAL = 1;
        private static readonly Encoding Encoding = new ASCIIEncoding();
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(WINDOWPLACEMENT));

        public static string GetPlacement(IntPtr windowHandle)
        {
            WINDOWPLACEMENT placement;
            NativeMethods.GetWindowPlacement(windowHandle, out placement);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.ASCII))
                {
                    Serializer.Serialize(xmlTextWriter, placement);
                    byte[] xmlBytes = memoryStream.ToArray();
                    return Encoding.GetString(xmlBytes);
                }
            }
        }

        public static void SetPlacement(IntPtr windowHandle, string placementXml)
        {
            if (string.IsNullOrEmpty(placementXml))
            {
                return;
            }

            byte[] xmlBytes = Encoding.GetBytes(placementXml);

            try
            {
                WINDOWPLACEMENT placement;
                using (MemoryStream memoryStream = new MemoryStream(xmlBytes))
                {
                    placement = (WINDOWPLACEMENT)Serializer.Deserialize(memoryStream);
                }

                placement.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                placement.flags = 0;
                placement.showCmd = (placement.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : placement.showCmd);
                NativeMethods.SetWindowPlacement(windowHandle, ref placement);
            }
            catch (InvalidOperationException)
            {
                // Parsing placement XML failed. Fail silently.
            }
        }
    }
}