using btDotNet.Models;

namespace btDotNet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<btDotNet.Models.MoviesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(btDotNet.Models.MoviesDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.Movies.AddOrUpdate(
            //      m => m.Name,
            //      new Movie { Name = "Alien" },
            //      new Movie { Name = "Apocalypse Now" },
            //      new Movie { Name = "Goodfellas" }
            //    );


        }
    }
}
