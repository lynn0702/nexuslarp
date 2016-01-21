using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using NexCharCore.Models;

namespace NexCharCore
{

    public interface INexCharContext
    {
         DbSet<Player> Players { get; set; }
         DbSet<Character> Characters { get; set; }
         DbSet<Organization> Organizations { get; set; }
         DbSet<OrganizationMembership> OrganizationMemberships { get; set; }
         DbSet<Skill> Skills { get; set; }
         DbSet<CharacterSkill> CharacterSkills { get; set; }
         DbSet<FavoredSkill> FavoredSkills { get; set; }
         DbSet<ProhibitedSkill> ProhibitedSkills { get; set; }
         DbSet<PrerequisiteSkill> PrerequisiteSkills { get; set; }
         DbSet<OrganizationCheckoutRecord> OrganizationCheckoutRecords { get; set; }
         DbSet<CharacterCheckoutRecord> CharacterCheckoutRecords { get; set; }
         DbSet<Event> Events { get; set; }

    }

    public abstract class NexCharContextBase : DbContext, INexCharContext
    {

        public NexCharContextBase()
        {
        }

        public NexCharContextBase(string connectString)
            : base(connectString)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationMembership> OrganizationMemberships { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<FavoredSkill> FavoredSkills { get; set; }
        public DbSet<ProhibitedSkill> ProhibitedSkills { get; set; }
        public DbSet<PrerequisiteSkill> PrerequisiteSkills { get; set; }
        public DbSet<OrganizationCheckoutRecord> OrganizationCheckoutRecords { get; set; }
        public DbSet<CharacterCheckoutRecord> CharacterCheckoutRecords { get; set; }
        public DbSet<Event> Events { get; set; }

    }

    public class NexCharContext : NexCharContextBase
    {
        static NexCharContext()
        {
            Database.SetInitializer<NexCharContext>(null);
        }

        public NexCharContext()
            : base("NexCharDB")
        {
            ((IObjectContextAdapter) this).ObjectContext.SavingChanges += ObjectContext_SavingChanges;
        }

        private void ObjectContext_SavingChanges(object sender, EventArgs e)
        {
            var context = (ObjectContext) sender;
           // var securityService = new SecurityService();
            string currentUser = "default";
            try
            {
              //  currentUser = securityService.CurrentPartyName();
            }
            catch
            {
                currentUser = "BatchProcesses";
            }


            foreach (var entry in context.ObjectStateManager
                .GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                .Where(entry => entry.Entity is IAuditable))
            {
                ((IAuditable) entry.Entity).Audit(context, entry, currentUser);
            }

        }
    }
}