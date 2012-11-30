using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcGuessMySonsName.Models
{
    public class DbGuesss : DbContext
    {
        public DbGuesss(string connectionStrings) : base(connectionStrings)
        {

        }

        public DbSet<Guess> Guesses { get; set; }
    }
}