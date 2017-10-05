using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Local

namespace WmiExplorer.Classes
{
    // Sort listview Columns and Set Sort Arrow Icon on Column Header
    // http://www.codeproject.com/Tips/734463/Sort-listview-Columns-and-Set-Sort-Arrow-Icon-on-C
    internal static class ListViewExtensions
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct LVCOLUMN
        {
            public Int32 mask;
            public Int32 cx;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;

            public IntPtr hbm;
            public Int32 cchTextMax;
            public Int32 fmt;
            public Int32 iSubItem;
            public Int32 iImage;
            public Int32 iOrder;
        }

        private const Int32 HDI_WIDTH = 0x0001;
        private const Int32 HDI_HEIGHT = HDI_WIDTH;
        private const Int32 HDI_TEXT = 0x0002;
        private const Int32 HDI_FORMAT = 0x0004;
        private const Int32 HDI_LPARAM = 0x0008;
        private const Int32 HDI_BITMAP = 0x0010;
        private const Int32 HDI_IMAGE = 0x0020;
        private const Int32 HDI_DI_SETITEM = 0x0040;
        private const Int32 HDI_ORDER = 0x0080;
        private const Int32 HDI_FILTER = 0x0100;

        private const Int32 HDF_LEFT = 0x0000;
        private const Int32 HDF_RIGHT = 0x0001;
        private const Int32 HDF_CENTER = 0x0002;
        private const Int32 HDF_JUSTIFYMASK = 0x0003;
        private const Int32 HDF_RTLREADING = 0x0004;
        private const Int32 HDF_OWNERDRAW = 0x8000;
        private const Int32 HDF_STRING = 0x4000;
        private const Int32 HDF_BITMAP = 0x2000;
        private const Int32 HDF_BITMAP_ON_RIGHT = 0x1000;
        private const Int32 HDF_IMAGE = 0x0800;
        private const Int32 HDF_SORTUP = 0x0400;
        private const Int32 HDF_SORTDOWN = 0x0200;

        private const Int32 LVM_FIRST = 0x1000;         // List messages
        private const Int32 LVM_GETHEADER = LVM_FIRST + 31;
        private const Int32 HDM_FIRST = 0x1200;         // Header messages
        private const Int32 HDM_SETIMAGELIST = HDM_FIRST + 8;
        private const Int32 HDM_GETIMAGELIST = HDM_FIRST + 9;
        private const Int32 HDM_GETITEM = HDM_FIRST + 11;
        private const Int32 HDM_SETITEM = HDM_FIRST + 12;

        //This method is used to set arrow icon
        public static void SetSortIcon(this ListView listView, int columnIndex, SortOrder order)
        {
            IntPtr columnHeader = NativeMethods.SendMessage(listView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

            for (int columnNumber = 0; columnNumber <= listView.Columns.Count - 1; columnNumber++)
            {
                IntPtr columnPtr = new IntPtr(columnNumber);
                LVCOLUMN lvColumn = new LVCOLUMN();
                lvColumn.mask = HDI_FORMAT;

                NativeMethods.SendMessageLVCOLUMN(columnHeader, HDM_GETITEM, columnPtr, ref lvColumn);

                if (!(order == SortOrder.None) && columnNumber == columnIndex)
                {
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            lvColumn.fmt &= ~HDF_SORTDOWN;
                            lvColumn.fmt |= HDF_SORTUP;
                            break;

                        case SortOrder.Descending:
                            lvColumn.fmt &= ~HDF_SORTUP;
                            lvColumn.fmt |= HDF_SORTDOWN;
                            break;
                    }
                    lvColumn.fmt |= (HDF_LEFT | HDF_BITMAP_ON_RIGHT);
                }
                else
                {
                    lvColumn.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP & ~HDF_BITMAP_ON_RIGHT;
                }

                NativeMethods.SendMessageLVCOLUMN(columnHeader, HDM_SETITEM, columnPtr, ref lvColumn);
            }
        }

        // Reference link:
        // http://stackoverflow.com/questions/14133225/listview-autoresizecolumns-based-on-both-column-content-and-header
        // Reference link
        public static void ResizeColumns(this ListView lv)
        {
            //lv.AutoResizeColumns(lv.Items.Count > 0
            //    ? ColumnHeaderAutoResizeStyle.ColumnContent
            //    : ColumnHeaderAutoResizeStyle.HeaderSize);

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //ListView.ColumnHeaderCollection cc = lv.Columns;
            //for (int i = 0; i < cc.Count; i++)
            //{
            //    int colWidth = TextRenderer.MeasureText(cc[i].Text, lv.Font).Width + 10;
            //    if (colWidth > cc[i].Width)
            //    {
            //        cc[i].Width = colWidth;
            //    }
            //}
        }
    }
}

// ReSharper restore InconsistentNaming
// ReSharper restore UnusedMember.Local