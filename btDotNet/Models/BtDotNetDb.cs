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

        public void RefreshNewsItems(NewsItemLocationManager locationManager)
        {
            foreach (NewsItem item in NewsItems)
            {
                NewsItems.Remove(item);
            }
            SaveChanges();

            var queryString = "Barack Obama";
            for (Int32 i = 0; i<8; i++)
            {
                var url = "https://ajax.googleapis.com/ajax/services/search/news?v=1.0&rsz=8&start=" + i*8 + "&q=" + queryString;
                var wc = new WebClient();
                //var rawFeedData = HttpUtility.HtmlDecode(wc.DownloadString(url));
                var rawFeedData = wc.DownloadString(url);

                var fromJson = JsonSerializer.DeserializeFromString<GoogleNewsSearchResultsWrapper>
                    (rawFeedData);

                foreach (var result in fromJson.responseData.results)
                {
                    NewsItems.Add(new NewsItem { Title = HttpUtility.HtmlDecode(result.titleNoFormatting) });
                }
            }
            
            SaveChanges();
        }
    }
}