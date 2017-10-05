using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Xml;

namespace WmiExplorer.Updater
{
    internal class UpdaterService
    {
        public static Update GetUpdateFromSyndicationItem(SyndicationItem item)
        {
            Debug.Assert(item != null);

            var update = new Update();

            // Update Version
            Version version;
            if (Version.TryParse(item.Title.Text, out version))
            {
                update.Version = version;
            }

            // Last Updated Time
            update.LastUpdatedTime = item.LastUpdatedTime;

            // Update Url
            var updateLink = item.Links.FirstOrDefault(
                l => String.IsNullOrWhiteSpace(l.RelationshipType)
                    || l.RelationshipType.Equals("alternate", StringComparison.OrdinalIgnoreCase));

            if (updateLink != null)
            {
                update.Url = updateLink.GetAbsoluteUri();
            }

            // Change Log Url
            var changeLogLink = item.Links.FirstOrDefault(
                l => String.IsNullOrWhiteSpace(l.RelationshipType)
                    || l.RelationshipType.Equals("related", StringComparison.OrdinalIgnoreCase));

            if (changeLogLink != null)
            {
                update.ChangeLogUrl = changeLogLink.GetAbsoluteUri();
            }

            // Update Release Status
            update.ReleaseStatus
                = item.Categories.Aggregate(
                    ReleaseStatus.None,
                    (rs, c) =>
                    {
                        ReleaseStatus releaseStatus;

                        if (Enum.TryParse<ReleaseStatus>(c.Name, true, out releaseStatus))
                        {
                            rs |= releaseStatus;
                        }

                        return rs;
                    });

            return update;
        }

        public Update CheckForUpdatesAsync(string updateUrl, UpdateFilter updateFilter)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(updateUrl));

            Update latestUpdate = null;

            var formatter = new Atom10FeedFormatter();
            var reader = XmlReader.Create(updateUrl);
            formatter.ReadFrom(reader);

            latestUpdate = (from i in formatter.Feed.Items
                            let u = GetUpdateFromSyndicationItem(i)
                            where u.Version > Assembly.GetExecutingAssembly().GetName().Version
                            && ((int)updateFilter & (int)u.ReleaseStatus) != 0
                            orderby u.LastUpdatedTime descending
                            select u).FirstOrDefault();

            return latestUpdate;
        }

        public string GetChangeLog(Uri changeLogUrl)
        {
            return new WebClient().DownloadString(changeLogUrl);
        }
    }
}