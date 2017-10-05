using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WmiExplorer.Classes
{
    /// <summary>
    /// Wrapper for Native Methods
    /// </summary>
    internal class NativeMethods
    {
        // P/Invoke declarations

        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessageLVCOLUMN(IntPtr hWnd, Int32 Msg, IntPtr wParam, ref ListViewExtensions.LVCOLUMN lPLVCOLUMN);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        [SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "0"), DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);
    }
}