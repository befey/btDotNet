using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace btDotNet.Models
{
    public class MoviesDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}