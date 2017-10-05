using System;
using System.Drawing;
using System.Windows.Forms;

namespace WmiExplorer.Classes
{
    /// <summary>
    /// Used to allow scrolling for the controls, without having to select them or focus on them.
    /// http://www.brad-smith.info/blog/archives/635
    /// http://stackoverflow.com/questions/7852824/usercontrol-how-to-add-mousewheel-listener
    /// </summary>
    internal class MouseWheelMessageFilter : IMessageFilter
    {
        private const int WM_MOUSEWHEEL = 0x20a;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL)
            {
                // LParam contains the location of the mouse pointer
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = NativeMethods.WindowFromPoint(pos);
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    // redirect the message to the correct control
                    NativeMethods.SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }

            return false;
        }
    }
}