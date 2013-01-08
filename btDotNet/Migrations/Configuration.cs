using btDotNet.Models;

namespace btDotNet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<btDotNet.Models.BtDotNetDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(btDotNet.Models.BtDotNetDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.NewsItems.AddOrUpdate(
            //      m => m.Title,
            //      new NewsItem { Title = "Alien" },
            //      new NewsItem { Title = "Apocalypse Now" },
            //      new NewsItem { Title = "Goodfellas" }
            //    );


        }
    }
}
