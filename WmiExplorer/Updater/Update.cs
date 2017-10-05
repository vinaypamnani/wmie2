using System;

namespace WmiExplorer.Updater
{
    internal class Update
    {
        public Uri ChangeLogUrl { get; set; }

        public DateTimeOffset LastUpdatedTime { get; set; }

        public ReleaseStatus ReleaseStatus { get; set; }

        public Uri Url { get; set; }

        public Version Version { get; set; }
    }
}