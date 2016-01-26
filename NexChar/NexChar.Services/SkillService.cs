using System;
using System.Collections.Generic;
using System.Linq;
using Nexchar.Documents;
using NexCharCore;
using NexCharCore.Models;
using System.Data.Entity;

namespace NexChar.Services
{
    public class SkillService : ResourceService<SkillDocument>
    {
        public SkillService(IContextManager contextManager)
            : base(contextManager)
        {
 
        }

        public override SkillDocument Get(string modelID)
        {
            return AsDocument(_nexCharContext.Skills.AsNoTracking().FirstOrDefault(o => o.SkillKey == modelID));

        }

        public override IEnumerable<SkillDocument> GetAll()
        {
            throw new System.NotImplementedException();
        }
        public SkillDocument CreateOrUpdate(SkillDocument doc)
        {
            return string.IsNullOrEmpty( doc.SkillKey) || doc.SkillKey == null ? Create(doc) : Update(doc);
        }

        private SkillDocument Create(SkillDocument doc)
        {
            var skill = new Skill
            {
                 Name =doc.Name,
                 Rank =doc.Rank,
                 Type =doc.Type,
                 BaseAPCost =doc.BaseAPCost,
                 ClassType =doc.ClassType,
                 Description =doc.Description,
                 BGPCost =doc.BGPCost
            };

            _nexCharContext.Skills.Add(skill);

            _nexCharContext.SaveChanges();

            return AsDocument(skill);
        }
        private SkillDocument Update(SkillDocument doc)
        {
            var modelToUpdate = _nexCharContext.Skills.FirstOrDefault(t => t.SkillKey == doc.SkillKey);
            if (modelToUpdate != null)
            {
                MergeChanges(ref modelToUpdate, doc);
            }
            else
            {
                return null;
            }

            var changed = _nexCharContext.ChangeTracker.HasChanges();

            _nexCharContext.SaveChanges();
            return AsDocument(modelToUpdate);
        }

        private static void MergeChanges(ref Skill modelToUpdate, SkillDocument doc)
        {
            if (
                 modelToUpdate.Name != doc.Name
                 || modelToUpdate.Rank != doc.Rank
                 || modelToUpdate.Type != doc.Type
                 || modelToUpdate.BaseAPCost != doc.BaseAPCost
                 || modelToUpdate.ClassType != doc.ClassType
                 || modelToUpdate.Description != doc.Description
                 || modelToUpdate.BGPCost != doc.BGPCost
            )
            {

            }
            modelToUpdate.Name = doc.Name;
            modelToUpdate.Rank = doc.Rank;
            modelToUpdate.Type = doc.Type;
            modelToUpdate.BaseAPCost = doc.BaseAPCost;
            modelToUpdate.ClassType = doc.ClassType;
            modelToUpdate.Description = doc.Description;
            modelToUpdate.BGPCost = doc.BGPCost;
        }

        private readonly Func<Skill, SkillDocument> AsDocument =
            x => new SkillDocument
            {
                SkillKey = x.SkillKey,
                Name = x.Name,
                Rank = x.Rank,
                Type = x.Type,
                BaseAPCost = x.BaseAPCost,
                ClassType = x.ClassType,
                Description = x.Description,
                Prereqs = new List<PrereqDocument>(x.Prereqs.Select(p => new PrereqDocument{SkillKey = p.Skill_SkillKey, ID = p.ID, PrimaryRequirement = p.PrimaryRequirement_SkillKey, SecondaryRequirement = p.SecondaryRequirement_SkillKey})),
                Prohibited = new List<ProhitedDocument>(x.Prohibited.Select(p => new ProhitedDocument { SkillKey = p.Skill_SkillKey, ID = p.ID, Prohibits = p.Prohibits_SkillKey})),
                BGPCost = x.BGPCost
            };

        public IEnumerable<SkillDocument> GetFiltered(IReadOnlyCollection<KeyValuePair<string, string>> queryString)
        {
            var dbSkillQuery = _nexCharContext.Skills
                .Include(s => s.Prereqs)
                .Include(s => s.Prohibited)
                .AsNoTracking().AsQueryable();

            //AddVendorNumberToQuery(queryString, ref dbTaxEntityQuery);
            //AddTaxNumberToQuery(queryString, ref dbTaxEntityQuery);
            //AddW9NameToQuery(queryString, ref dbTaxEntityQuery);
            //AddStateIDToQuery(queryString, ref dbTaxEntityQuery);
            //AddCityToQuery(queryString, ref dbTaxEntityQuery);
            //Add1099TypeToQuery(queryString, ref dbTaxEntityQuery);
            //AddTaxEntityTypeToQuery(queryString, ref dbTaxEntityQuery);

            // var matchingVendors1099s = dbTaxEntityQuery.ToList();

            //AddYearToResults(queryString, ref dbTaxEntityQuery);


            return dbSkillQuery.ToList().Select(s => AsDocument(s));
        }
    }
}
