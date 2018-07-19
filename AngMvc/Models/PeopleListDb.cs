using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngMvc.Models
{
    public class PeopleListDb : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<MyImage> Images { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}