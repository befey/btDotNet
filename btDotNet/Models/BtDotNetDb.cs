using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Text;
using btDotNet.Controllers;

namespace btDotNet.Models
{
    public class BtDotNetDb : DbContext
    {
        public DbSet<NewsItem> NewsItems { get; set; }
        public DbSet<Query> Queries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove
                <System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            // Add any configuration or mapping stuff here
        }

        public void Seed(BtDotNetDb context)
        {
#if DEBUG
            // Create my debug (testing) objects here
            //NewsItem[] testNewsItems = {
            //    new NewsItem { Title = "Alien" },
            //    new NewsItem { Title = "Apocalypse Now" },
            //    new NewsItem { Title = "Goodfellas" }
            //};
            //foreach (NewsItem m in testNewsItems)
            //{
            //    context.NewsItems.Add(m);
            //}
            
#endif

            // Normal seeding goes here

            context.SaveChanges();
        }

        public class DropCreateAlwaysInitializer : DropCreateDatabaseIfModelChanges<BtDotNetDb>
        {
            protected override void Seed(BtDotNetDb context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<BtDotNetDb>
        {
            protected override void Seed(BtDotNetDb context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        static BtDotNetDb()
        {
#if DEBUG
            Database.SetInitializer<BtDotNetDb> (new DropCreateAlwaysInitializer());
#else
            Database.SetInitializer<BtDotNetDb> (new CreateInitializer());
#endif
        }

        public void RefreshNewsItems()
        {
            var locations = new Dictionary<string,NewsItemLocation>(Queries.Count());
            foreach (var q in Queries)
            {
                locations.Add(q.QueryString, new NewsItemLocation(q));
            }
            ILocationManager manager= new NewsItemLocationManager(locations);

            ClearDb(NewsItems);

            var wc = new WebClient();

            foreach (KeyValuePair<string, NewsItemLocation> item in manager)
            {
                int maxRequests = 8;
                int itemsPerPage = 8;
                for (Int32 i = 0; i<maxRequests; i++)
                {
                    var rawFeedData = wc.DownloadString(
                        item.Value.Location+"&start="+i*itemsPerPage);
                    var fromJson = JsonSerializer.DeserializeFromString<GoogleNewsSearchResultsWrapper>
                        (rawFeedData);
                    foreach (var result in fromJson.responseData.results)
                    {
                        NewsItems.Add(new NewsItem { Title = HttpUtility.HtmlDecode(result.titleNoFormatting) });
                    }
                }
            }

            SaveChanges();
        }

        private void ClearDb(DbSet dbToClear)
        {
            foreach (var item in dbToClear)
            {
                dbToClear.Remove(item);
            }
            SaveChanges();
        }
    }
}