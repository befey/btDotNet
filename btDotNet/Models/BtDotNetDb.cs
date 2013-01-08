using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;

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
            NewsItem[] testNewsItems = {
                new NewsItem { Title = "Alien" },
                new NewsItem { Title = "Apocalypse Now" },
                new NewsItem { Title = "Goodfellas" }
            };
            foreach (NewsItem m in testNewsItems)
            {
                context.NewsItems.Add(m);
            }
            
#endif

            // Normal seeding goes here

            context.SaveChanges();
        }

        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<BtDotNetDb>
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
            Database.SetInitializer<BtDotNetDb>(new DropCreateAlwaysInitializer());
#else
            Database.SetInitializer<BtDotNetDb> (new DropCreateAlwaysInitializer());
#endif
        }
    }
}