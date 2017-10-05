namespace WmiExplorer.Sms
{
    internal class SmsClientActions
    {
        public SmsClientActions()
        {
        }

        public static SmsClientAction HardwareInventory
        {
            // {00000000-0000-0000-0000-000000000101} is the same
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000001}", "Hardware Inventory Cycle", ActionGroup.Inventory); }
        }

        public static SmsClientAction SoftwareInventory
        {
            // {00000000-0000-0000-0000-000000000102} is the same
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000002}", "Software Inventory Cycle", ActionGroup.Inventory); }
        }

        public static SmsClientAction HeartbeatDiscovery
        {
            // {00000000-0000-0000-0000-000000000103} is the same
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000003}", "Discovery Data Collection Cycle", ActionGroup.Inventory); }
        }

        public static SmsClientAction FileCollection
        {
            // {00000000-0000-0000-0000-000000000104} is the same
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000010}", "File Collection Cycle", ActionGroup.Inventory); }
        }

        public static SmsClientAction IdmifCollection
        {
            // {00000000-0000-0000-0000-000000000105} is the same
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000011}", "IDMIF Collection Cycle", ActionGroup.Inventory); }
        }

        public static SmsClientAction ClientMachineAuthentication
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000012}", "Client Machine Authentication", ActionGroup.Other); }
        }

        public static SmsClientAction MachineAssignmentsRequest
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000021}", "Request Machine Assignments", ActionGroup.Policy); }
        }

        public static SmsClientAction MachineAssignmentsEvaluate
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000022}", "Evaluate Machine Assignments", ActionGroup.Policy); }
        }

        public static SmsClientAction LocationRefreshDefaultMp
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000023}", "Refresh Default MP", ActionGroup.LocationServices); }
        }

        public static SmsClientAction LocationRefreshLocations
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000024}", "Refresh Locations", ActionGroup.LocationServices); }
        }

        public static SmsClientAction LocationTimeoutRefresh
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000025}", "Timeout Refresh", ActionGroup.LocationServices); }
        }

        public static SmsClientAction UserAssignmentsRequest
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000026}", "Request User Assignments", ActionGroup.Policy); }
        }

        public static SmsClientAction UserAssignmentsEvaluate
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000027}", "Evaluate User Assignments", ActionGroup.Policy); }
        }

        public static SmsClientAction SoftwareMeterUsageReport
        {
            // {00000000-0000-0000-0000-000000000106}
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000031}", "Software Metering Usage Report Cycle", ActionGroup.Inventory); }
        }

        public static SmsClientAction SourceUpdateCycle
        {
            // {00000000-0000-0000-0000-000000000107}
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000032}", "Windows Installer Source List Update Cycle", ActionGroup.Other); }
        }

        public static SmsClientAction ProxySettingsCacheClear
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000037}", "Clear Proxy Settings Cache", ActionGroup.Other); }
        }

        public static SmsClientAction PolicyAgentCleanupMachine
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000040}", "Policy Agent Cleanup Cycle (Machine)", ActionGroup.Policy); }
        }

        public static SmsClientAction PolicyAgentCleanupUser
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000041}", "Policy Agent Cleanup Cycle (User)", ActionGroup.Policy); }
        }

        public static SmsClientAction PolicyAgentValidateMachine
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000042}", "Validate Machine Policy/Assignment", ActionGroup.Policy); }
        }

        public static SmsClientAction PolicyAgentValidateUser
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000043}", "Validate User Policy/Assignment", ActionGroup.Policy); }
        }

        public static SmsClientAction RetryRefreshCertificate
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000051}", "Retry/Refresh Certificates in AD on MP", ActionGroup.Other); }
        }

        public static SmsClientAction SoftwareUpdateInstallSchedule
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000063}", "Software Updates Install Schedule", ActionGroup.SoftwareUpdates); }
        }

        public static SmsClientAction Nap
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000071}", "Network Access Protection Schedule", ActionGroup.Other); }
        }

        public static SmsClientAction SoftwareUpdateAssignmentEvaluation
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000108}", "Software Updates Assignment Evaluation Cycle", ActionGroup.SoftwareUpdates); }
        }

        public static SmsClientAction DcmPolicy
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000110}", "DCM Policy", ActionGroup.Other); }
        }

        public static SmsClientAction StateMessageSendUnsent
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000111}", "Send Unsent State Messages", ActionGroup.StateMessage); }
        }

        public static SmsClientAction StateMessagePolicyCacheClean
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000112}", "State System Policy Cache Clean", ActionGroup.StateMessage); }
        }

        public static SmsClientAction SoftwareUpdateScan
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000113}", "Software Update Scan Cycle", ActionGroup.SoftwareUpdates); }
        }

        public static SmsClientAction SoftwareUpdateStore
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000114}", "Software Update Store Refresh", ActionGroup.SoftwareUpdates); }
        }

        public static SmsClientAction StateMessageSendHigh
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000115}", "Bulk Send High Priority", ActionGroup.StateMessage); }
        }

        public static SmsClientAction StateMessageSendLow
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000116}", "Bulk Send Low Priority", ActionGroup.StateMessage); }
        }

        public static SmsClientAction AmtStatusCheck
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000120}", "AMT Status Check Policy", ActionGroup.Other); }
        }

        public static SmsClientAction ApplicationPolicy
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000121}", "Application Manager Machine Policy", ActionGroup.ApplicationEvaluation); }
        }

        public static SmsClientAction ApplicationPolicyUser
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000122}", "Application Manager User Policy", ActionGroup.ApplicationEvaluation); }
        }

        public static SmsClientAction ApplicationPolicyGlobal
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000123}", "Application Manager Global Evaluation Policy", ActionGroup.ApplicationEvaluation); }
        }

        public static SmsClientAction PowerMgmtSummarize
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000131}", "Power Management Summarizer", ActionGroup.Other); }
        }

        public static SmsClientAction EpDeploymentReevaluate
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000221}", "Endpoint Protection Deployment Re-Evaluate", ActionGroup.Endpoint); }
        }

        public static SmsClientAction EpAmPolicyReevaluate
        {
            get { return new SmsClientAction("{00000000-0000-0000-0000-000000000222}", "Endpoint Protection AM Policy Re-Evaluate", ActionGroup.Endpoint); }
        }

        // Excluded Actions:
        // {00000000-0000-0000-0000-000000000061}
        // {00000000-0000-0000-0000-000000000062}
        // {00000000-0000-0000-0000-000000000101}
        // {00000000-0000-0000-0000-000000000109}
        // {00000000-0000-0000-0000-000000000223}
    }
}