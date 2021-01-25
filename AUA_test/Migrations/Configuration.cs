namespace AUA_test.Migrations
{
    using AUA_test.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AUA_test.AuaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AUA_test.AuaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Classes.AddOrUpdate(
              new Class { Id = 1, Name = "Intro to CS", Section = "A" },
              new Class { Id = 2, Name = "Intro to CS", Section = "b" }
            );

        }
    }
}
