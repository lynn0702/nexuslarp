using NexCharCore.Constants;
using NexCharCore.Models;

namespace NexCharCore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NexCharCore.NexCharContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NexCharCore.NexCharContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Organizations.AddOrUpdate(
              p => p.Name,
              new Organization { Name = "Tier 1 Rogue", Tier = 1, Type = OrganizationTypes.Guild, Abbreviation = "SoC"},
              new Organization { Name = "the Hunt", Tier = 1, Type = OrganizationTypes.Guild, Abbreviation = "Hunt" },
              new Organization { Name = "Tier 3 Rogue", Tier = 3, Type = OrganizationTypes.Guild, Abbreviation = "AH"}
            );
            
        }
    }
}
