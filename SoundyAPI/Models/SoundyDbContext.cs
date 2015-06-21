using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
    public class SoundyDbContext : DbContext
    {
        public SoundyDbContext():base("SoundyDbConnection")
        {

        }

        public DbSet<Sound> Sounds { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();            
        }
    }
}