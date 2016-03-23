using System;
using System.Collections.Generic;
using System.Linq;
using Nexchar.Documents;
using NexCharCore;
using NexCharCore.Models;

namespace NexChar.Services
{
    public class CharacterService : ResourceService<CharacterDocument>
    {
        
        public CharacterService(IContextManager contextManager)
            : base(contextManager)
        {

        }

        public  CharacterDocument Get(int modelID)
        {
            throw new NotImplementedException();
        }

        public override CharacterDocument Get(string modelID)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<CharacterDocument> GetAll()
        {
            throw new NotImplementedException();
        }

        public CharacterDocument Checkout(CheckoutDocument checkoutRecord)
        {
            _nexCharContext.CharacterCheckoutRecords.Add(new CharacterCheckoutRecord
            {
                APorMP = checkoutRecord.APorMP,
                Character_ID = checkoutRecord.Character_ID,
                DateEntered = DateTime.Now,
                Event_ID = checkoutRecord.Event_ID,
                SigsEarned = checkoutRecord.SigsEarned,
                WorkTime = checkoutRecord.WorkTime,
                NobleAlliedTo_ID = checkoutRecord.NobleAlliedTo_ID
                
            });
            _nexCharContext.SaveChanges();
            return AsDocument(_nexCharContext.Characters.Find(checkoutRecord.Character_ID));
        }

        private CharacterDocument AsDocument(Character character)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<CharacterDocument> GetFiltered(IReadOnlyCollection<KeyValuePair<string, string>> readOnlyCollection)
        {
            throw new NotImplementedException();
        }

        public CharacterDocument CreateOrUpdate(CharacterDocument doc)
        {
            throw new NotImplementedException();
        }

        public int AddFreeSkills(Character character)
        {
            var possesedSkills = character.CharacterSkills.Select(c => c.Skill_SkillKey).ToList();
            var skillsToAdd =
                _nexCharContext.Skills.Where(
                    s =>
                        !possesedSkills.Contains(s.SkillKey) && //ignore already possessed skills
                        s.BaseAPCost == 0  &&
                        s.Prereqs.Any(
                            k =>
                                possesedSkills.Contains(k.PrimaryRequirement_SkillKey) &&
                                possesedSkills.Contains(k.SecondaryRequirement_SkillKey)))
                                .Select(s => new CharacterSkill
                                {
                                    APSpent = 0,
                                    Character_ID = character.ID,
                                    DatePurchased = DateTime.Now,
                                    HitPointsEarned = 0,
                                    Skill_SkillKey = s.SkillKey
                                }).ToList();

            character.CharacterSkills.AddRange(skillsToAdd);
            return skillsToAdd.Count;
        }

        public int AddFavoredFreeSkills(Character character)
        {
            var possesedSkills = character.CharacterSkills.Select(c => c.Skill_SkillKey).ToList();
            var skillsToAdd =
                _nexCharContext.FavoredSkills.Where(
                    f =>
                        !possesedSkills.Contains(f.Favors_SkillKey) && //ignore already possessed skills
                        possesedSkills.Contains(f.Skill_SkillKey) && (f.FavorsSkill.BaseAPCost + f.APReduction) <=0
                         &&
                        f.FavorsSkill.Prereqs.Any(
                            k =>
                                possesedSkills.Contains(k.PrimaryRequirement_SkillKey) &&
                                possesedSkills.Contains(k.SecondaryRequirement_SkillKey))
                                )
                                .Select(s => new CharacterSkill
                                {
                                    APSpent = 0,
                                    Character_ID = character.ID,
                                    DatePurchased = DateTime.Now,
                                    HitPointsEarned = 0, //TODO Fix - Not True for Consitution/Hardy
                                    Skill_SkillKey = s.Favors_SkillKey
                                }).ToList();

            character.CharacterSkills.AddRange(skillsToAdd);
            return skillsToAdd.Count;
        }

        public void AddDerivedHardCodedLogistics(Character character)
        {
            //Level and Class Level Entries
            //Purchased AP Entries
                //Formal
                
        }

        public bool IsQualifedToPurchase(Character character, Skill desiredSkill)
        {
            return (character.APTotal - character.CharacterSkills.Sum(cs => cs.APSpent)) >=
                   getSkillAPCost(character, desiredSkill) && meetsPrereq(character, desiredSkill);
        }

        public int getSkillAPCost(Character character, Skill desiredSkill)
        {
            return desiredSkill.BaseAPCost +
                   _nexCharContext.FavoredSkills.Where(
                       f => character.CharacterSkills.Select(cs => cs.Skill_SkillKey).Contains(f.Skill_SkillKey))
                       .Sum(fs => fs.APReduction);
        }

        public static bool meetsPrereq(Character character, Skill desiredSkill)
        {
            return
                desiredSkill.Prereqs.Any(
                    p =>
                        character.CharacterSkills.Select(cs => cs.Skill_SkillKey)
                            .Contains(p.PrimaryRequirement_SkillKey) &&
                        character.CharacterSkills.Select(cs => cs.Skill_SkillKey)
                            .Contains(p.SecondaryRequirement_SkillKey));
        }

        public List<CharacterSkillDocument> CreateOrUpdateSkills(List<CharacterSkillDocument> docs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CharacterSkillDocument> GetSkillsByCharacter(int i)
        {
            throw new NotImplementedException();
        }

        public List<OrganizationMembershipDocument> CreateOrUpdateOrganizationMemberships(List<OrganizationMembershipDocument> docs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrganizationMembershipDocument> GetOrganizationMembershipsByCharacter(int p)
        {
            throw new NotImplementedException();
        }
    }
}
