using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;

namespace btDotNet.Models
{
    public class MoviesDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove
                <System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            // Add any configuration or mapping stuff here
        }

        public void Seed(MoviesDb context)
        {
#if DEBUG
            // Create my debug (testing) objects here
            Movie[] testMovies = {
                new Movie { Name = "Alien" },
                new Movie { Name = "Apocalypse Now" },
                new Movie { Name = "Goodfellas" }
            };
            foreach (Movie m in testMovies)
            {
                context.Movies.Add(m);
            }
            
#endif

            // Normal seeding goes here

            context.SaveChanges();
        }

        public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<MoviesDb>
        {
            protected override void Seed(MoviesDb context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<MoviesDb>
        {
            protected override void Seed(MoviesDb context)
            {
                context.Seed(context);

                base.Seed(context);
            }
        }

        static MoviesDb()
        {
#if DEBUG
            Database.SetInitializer<MoviesDb>(new DropCreateAlwaysInitializer());
#else
            Database.SetInitializer<MoviesDb> (new DropCreateAlwaysInitializer());
#endif
        }
    }
}