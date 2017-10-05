using System;
using System.Collections;
using System.Windows.Forms;

namespace WmiExplorer.Classes
{
    public static class ToolStripItemExtensions
    {
        public static void SortToolStripItemCollection(this ToolStripItemCollection items)
        {
            ArrayList aList = new ArrayList(items);
            aList.Sort(new ToolStripItemCollectionSorter());
            items.Clear();

            foreach (ToolStripItem item in aList)
            {
                items.Add(item);
            }
        }
    }

    public class ToolStripItemCollectionSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            // Cast the objects to be compared to ListViewItem objects
            ToolStripItem toolStripItemX = (ToolStripItem)x;
            ToolStripItem toolStripItemY = (ToolStripItem)y;

            return String.Compare(toolStripItemX.Text, toolStripItemY.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}