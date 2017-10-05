namespace WmiExplorer.Sms
{
    public static class ActionGroup
    {
        public static string ApplicationEvaluation = "Application Evaluation";
        public static string Default = "Default";
        public static string Endpoint = "Endpoint Protection";
        public static string Inventory = "Inventory";
        public static string LocationServices = "Location Services";
        public static string Other = "Other";
        public static string Policy = "Policy";
        public static string SoftwareUpdates = "Software Updates";
        public static string StateMessage = "State Messages";
    }

    public class SmsClientAction
    {
        public SmsClientAction(string id, string displayName, string group = "Default")
        {
            Id = id;
            DisplayName = displayName;
            Group = group;
        }

        public string DisplayName { get; set; }

        public string Group { get; set; }

        public string Id { get; set; }
    }
}