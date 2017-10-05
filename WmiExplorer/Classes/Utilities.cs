using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Windows.Forms;
using WmiExplorer.Properties;

namespace WmiExplorer.Classes
{
    public static class Utilities
    {
        /// <summary>
        /// Checks if Application is running as Administrator
        /// </summary>
        /// <returns>True if running as Administrator.</returns>
        public static bool CheckIfElevated()
        {
            try
            {
                WindowsIdentity userIdentity = WindowsIdentity.GetCurrent();
                WindowsPrincipal userPrincipal = new WindowsPrincipal(userIdentity);

                if (userPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to determine if Application is running as Administrator: " + ex.Message);
                //Log("Unable to determine whether Application is running Elevated. Error: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// To search and highlight text in Rich Text Box
        /// http://www.dotnetcurry.com/showarticle.aspx?ID=146
        /// </summary>
        /// <param name="txtToSearch">Text to Search in RichTextBox rtb</param>
        /// <param name="searchStart">Start index for search</param>
        /// <param name="indexOfSearchText">Index of Last Search result</param>
        /// <param name="rtb">RichTextBox to search in</param>
        /// <returns></returns>
        public static int FindTextInRichTextBox(string txtToSearch, int searchStart, int indexOfSearchText, RichTextBox rtb)
        {
            // Set the return value to -1 by default.
            int retVal = -1;
            int searchEnd = rtb.Text.Length;

            // A valid starting index should be specified.
            // if _indexOfSearchText = -1, the end of search
            if (searchStart >= 0 && indexOfSearchText >= 0)
            {
                // A valid ending index
                if (searchEnd > searchStart || searchEnd == -1)
                {
                    // Find the position of search string in RichTextBox
                    indexOfSearchText = rtb.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);

                    // Determine whether the text was found in rtb.
                    if (indexOfSearchText != -1)
                    {
                        // Return the index to the specified search text.
                        retVal = indexOfSearchText;
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// Returns all Application settings
        /// </summary>
        /// <returns>String value containing name & value of all settings</returns>
        public static string GetSettings()
        {
            string settings = String.Empty;

            foreach (SettingsProperty p in from SettingsProperty p in Settings.Default.Properties
                                           orderby p.Name
                                           select p)
            {
                // Exclude UpdateCheckUrl and WindowPlacement settings
                if (p.Name.StartsWith("UpdateCheckUrl", StringComparison.InvariantCultureIgnoreCase) || p.Name.Equals("WindowPlacement", StringComparison.InvariantCultureIgnoreCase))
                    continue;

                // Settings containing a string array
                if (Settings.Default[p.Name] is StringCollection)
                {
                    settings += p.Name + " = ";
                    foreach (var s in Settings.Default[p.Name] as StringCollection)
                        settings += s + ", ";
                    settings += "\r\n";
                    continue;
                }

                // Settings without default values
                if (p.DefaultValue == null)
                {
                    settings += p.Name + " = " + Settings.Default[p.Name] + "\r\n";
                    continue;
                }

                // Other settings with indicator whether value is the default value
                if (p.DefaultValue.ToString() == Settings.Default[p.Name].ToString())
                    settings += p.Name + " = " + Settings.Default[p.Name] + " (Default)\r\n";
                else
                    settings += p.Name + " = " + Settings.Default[p.Name] + "\r\n";
            }

            return settings;
        }

        /// <summary>
        /// Launch the specified program
        /// </summary>
        /// <param name="sCmd">Command to run</param>
        public static void LaunchProgram(string sCmd)
        {
            try
            {
                Process.Start(sCmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error launching program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Launch the specified program with arguments
        /// </summary>
        /// <param name="sCmd">Command to run</param>
        /// <param name="sArgument">Argument for the command</param>
        /// <param name="bWaitForExit">Wait for the command to Exit</param>
        public static void LaunchProgram(string sCmd, string sArgument, bool bWaitForExit)
        {
            try
            {
                if (bWaitForExit)
                    Process.Start(sCmd, sArgument).WaitForExit();
                else
                    Process.Start(sCmd, sArgument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error launching program", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Returns a string from the source SecureString
        /// http://blogs.msdn.com/b/fpintos/archive/2009/06/12/how-to-properly-convert-securestring-to-string.aspx
        /// </summary>
        /// <param name="secureString">SecureString to convert to String</param>
        /// <returns>String</returns>
        public static string SecureStringToString(this SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException("secureString");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        /// <summary>
        /// Returns a Secure string from the source string
        /// http://msdn.microsoft.com/en-us/library/system.security.securestring(v=vs.110).aspx
        /// </summary>
        /// <param name="source">String to convert to SecureString</param>
        /// <returns>SecureString</returns>
        public static SecureString StringToSecureString(this string source)
        {
            if (String.IsNullOrWhiteSpace(source))
                return null;

            SecureString result = new SecureString();
            foreach (char c in source.ToCharArray())
                result.AppendChar(c);

            return result;
        }

        /// <summary>
        /// Update User Settings on Application version update
        /// http://www.ngpixel.com/2011/05/05/c-keep-user-settings-between-versions/
        /// </summary>
        public static void UpdateSettings()
        {
            try
            {
                Settings.Default.Upgrade();
                Settings.Default.bUpgradeSettings = false;
                Settings.Default.bUpdateAvailable = false;
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to upgrade user settings. Error: " + ex.Message);
            }
        }
    }
}