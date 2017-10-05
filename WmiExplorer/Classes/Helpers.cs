using System.Drawing;
using System.Management;
using System.Windows.Forms;
using WmiExplorer.Sms;

namespace WmiExplorer.Classes
{
    public static class Helpers
    {
        public static Form CenterForm(this Form child, Form parent)
        {
            child.StartPosition = FormStartPosition.Manual;
            child.Location = new Point(parent.Location.X + (parent.Width - child.Width) / 2, parent.Location.Y + (parent.Height - child.Height) / 2);
            return child;
        }

        public static TreeNode GetRootNode(this TreeNode treeNode)
        {
            var rootNode = treeNode;

            while (rootNode.Parent != null)
            {
                rootNode = rootNode.Parent;
            }

            return rootNode;
        }

        public static ConnectionOptions GetRootNodeCredentials(TreeNode treeNode)
        {
            var rootNode = treeNode.GetRootNode();
            return ((WmiNode)rootNode.Tag).Connection;
        }

        public static SmsClient GetSmsClient(TreeNode treeNode)
        {
            var rootNode = treeNode;

            while (rootNode.Parent != null)
            {
                rootNode = rootNode.Parent;
            }

            return ((WmiNode)rootNode.Tag).SmsClient;
        }

        public static bool IsNodeDisconnected(TreeNode treeNode)
        {
            WmiNode wmiNode = treeNode.Tag as WmiNode;
            if (wmiNode != null && wmiNode.IsRootNode && wmiNode.IsConnected == false)
                return true;

            return false;
        }

        
    }
}