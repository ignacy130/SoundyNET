namespace SoundyAPI.Migrations
{
    using SoundyAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoundyAPI.Models.SoundyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SoundyAPI.Models.SoundyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.Add(new User() { 
            Created = DateTime.Now,
            Modified = DateTime.Now,
            Hash = "lol",
            UserName = "ignacy130"
            });
            context.Users.Add(new User()
            {
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Hash = "lol",
                UserName = "ignacy140"
            });
            context.SaveChanges();
            context.Sounds.Add(new Sound()
            {
                Created = DateTime.Now,
                Modified = DateTime.Now,
                FilePath= "lol",
                Creator = context.Users.First()
            });
            context.SaveChanges();
            context.Users.First().Tracks.Add(new Track()
            {
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Name = "pierwszy track",
                NextUser = context.Users.ToList()[1],
                Owners = context.Users.ToList(),
            });
            context.SaveChanges();
        }
    }
}
