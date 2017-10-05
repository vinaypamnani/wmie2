using System;

namespace WmiExplorer.Updater
{
    [Flags]
    public enum ReleaseStatus
    {
        None = 0,
        Stable = 1,
        Beta = 2,
        Alpha = 4
    }

    public enum UpdateFilter
    {
        None = 0,
        Stable = ReleaseStatus.Stable,
        Beta = Stable | ReleaseStatus.Beta,
        Alpha = Beta | ReleaseStatus.Alpha
    }
}