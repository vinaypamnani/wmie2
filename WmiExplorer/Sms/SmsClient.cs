using System.Linq;
using System.Management;

namespace WmiExplorer.Sms
{
    public class SmsClient
    {
        public SmsClient(string clientNamespacePath, ConnectionOptions connection)
        {
            ClientNamespacePath = clientNamespacePath;
            SmsClientClassPath = clientNamespacePath + ":SMS_Client";
            Connection = connection;
            IsClientInstalled = IsInstalled();
        }

        public string ClientNamespacePath { get; set; }

        public ConnectionOptions Connection { get; set; }

        public bool IsClientInstalled { get; set; }

        public bool IsConnected { get; set; }

        public ManagementClass SmsClientClass { get; set; }

        public string SmsClientClassPath { get; set; }

        public bool IsInstalled()
        {
            const string queryString = "SELECT * FROM meta_class WHERE __Class = 'SMS_Client'";

            ManagementScope scope = new ManagementScope(ClientNamespacePath, Connection);
            ObjectQuery query = new ObjectQuery(queryString);
            EnumerationOptions eOption = new EnumerationOptions();
            ManagementObjectSearcher queryClientSearcher = new ManagementObjectSearcher(scope, query, eOption);

            ManagementObject ccmClient = (from ManagementClass mClass in queryClientSearcher.Get()
                                          orderby mClass.Path.ClassName
                                          select mClass).FirstOrDefault();

            return ccmClient != null;
        }

        //public void InitiateClientAction(SmsClientAction smsClientAction)
        //{
        //    try
        //    {
        //        ManagementBaseObject inParams = SmsClientClass.GetMethodParameters("TriggerSchedule");
        //        inParams["sScheduleId"] = smsClientAction.Id;
        //        ManagementBaseObject outParams = SmsClientClass.InvokeMethod("TriggerSchedule", inParams, null);

        //        if (outParams != null)
        //        {
        //            MessageBox.Show("Successfully triggered " + smsClientAction.DisplayName + ".",
        //                "Initiate Client Action",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to trigger " + smsClientAction.DisplayName + ". Error: " + ex.Message,
        //            "Initiate Client Action",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //}
    }
}