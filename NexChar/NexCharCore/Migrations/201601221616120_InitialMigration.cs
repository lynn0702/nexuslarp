namespace NexCharCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterCheckoutRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Character_ID = c.Int(nullable: false),
                        Event_ID = c.Int(nullable: false),
                        NobleAlliedTo_ID = c.Int(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateProcessed = c.DateTime(),
                        IsProcessed = c.Boolean(nullable: false),
                        IsAPGain = c.Boolean(nullable: false),
                        IsMPGain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Characters", t => t.Character_ID, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: false)
                .ForeignKey("dbo.Characters", t => t.NobleAlliedTo_ID, cascadeDelete: false)
                .Index(t => t.Character_ID)
                .Index(t => t.Event_ID)
                .Index(t => t.NobleAlliedTo_ID);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(),
                        Player_ID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        APTotal = c.Int(nullable: false),
                        MPTotal = c.Int(nullable: false),
                        SigTotal = c.Int(nullable: false),
                        HitPoints = c.Int(nullable: false),
                        ChosenClass = c.String(nullable: false),
                        HasUsedChartDiscount = c.Boolean(nullable: false),
                        HasAppliedStartingRacials = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Players", t => t.Player_ID, cascadeDelete: false)
                .Index(t => t.Player_ID);
            
            CreateTable(
                "dbo.CharacterSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Character_ID = c.Int(nullable: false),
                        Skill_SkillKey = c.String(maxLength: 128),
                        DatePurchased = c.DateTime(nullable: false),
                        APSpent = c.Int(nullable: false),
                        HitPointsEarned = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Characters", t => t.Character_ID, cascadeDelete: false)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillKey)
                .Index(t => t.Character_ID)
                .Index(t => t.Skill_SkillKey);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillKey = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 80),
                        Rank = c.Int(nullable: false),
                        Type = c.String(),
                        BaseAPCost = c.Int(nullable: false),
                        ClassType = c.String(),
                        Description = c.String(),
                        BGPCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillKey);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 80),
                        Tier = c.Int(nullable: false),
                        Abbreviation = c.String(maxLength: 5),
                        Type = c.String(),
                        Character_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Characters", t => t.Character_ID)
                .Index(t => t.Character_ID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        VaultKey = c.String(),
                        WorkTimeBank = c.Int(nullable: false),
                        EEPTotal = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        APBlanket = c.Int(nullable: false),
                        MPBlanket = c.Int(nullable: false),
                        BGPs = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FavoredSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Skill_SkillKey = c.String(maxLength: 128),
                        Favors_SkillKey = c.String(maxLength: 128),
                        APReduction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Skills", t => t.Favors_SkillKey)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillKey)
                .Index(t => t.Skill_SkillKey)
                .Index(t => t.Favors_SkillKey);
            
            CreateTable(
                "dbo.OrganizationCheckoutRecords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Character_ID = c.Int(nullable: false),
                        Event_ID = c.Int(nullable: false),
                        Organization_Name = c.String(maxLength: 80),
                        FactionGain = c.Int(nullable: false),
                        FactionSpent = c.Int(nullable: false),
                        BountyTag = c.Int(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateProcessed = c.DateTime(),
                        IsProcessed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Characters", t => t.Character_ID, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.Organization_Name)
                .Index(t => t.Character_ID)
                .Index(t => t.Event_ID)
                .Index(t => t.Organization_Name);
            
            CreateTable(
                "dbo.OrganizationMemberships",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Organization_Name = c.String(maxLength: 80),
                        Character_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Characters", t => t.Character_ID, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.Organization_Name)
                .Index(t => t.Organization_Name)
                .Index(t => t.Character_ID);
            
            CreateTable(
                "dbo.PrerequisiteSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Skill_SkillKey = c.String(maxLength: 128),
                        PrimaryRequirement_SkillKey = c.String(maxLength: 128),
                        SecondaryRequirement_SkillKey = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Skills", t => t.PrimaryRequirement_SkillKey)
                .ForeignKey("dbo.Skills", t => t.SecondaryRequirement_SkillKey)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillKey)
                .Index(t => t.Skill_SkillKey)
                .Index(t => t.PrimaryRequirement_SkillKey)
                .Index(t => t.SecondaryRequirement_SkillKey);
            
            CreateTable(
                "dbo.ProhibitedSkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Skill_SkillKey = c.String(maxLength: 128),
                        Prohibits_SkillKey = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Skills", t => t.Prohibits_SkillKey)
                .ForeignKey("dbo.Skills", t => t.Skill_SkillKey)
                .Index(t => t.Skill_SkillKey)
                .Index(t => t.Prohibits_SkillKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProhibitedSkills", "Skill_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.ProhibitedSkills", "Prohibits_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.PrerequisiteSkills", "Skill_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.PrerequisiteSkills", "SecondaryRequirement_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.PrerequisiteSkills", "PrimaryRequirement_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.OrganizationMemberships", "Organization_Name", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationMemberships", "Character_ID", "dbo.Characters");
            DropForeignKey("dbo.OrganizationCheckoutRecords", "Organization_Name", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationCheckoutRecords", "Event_ID", "dbo.Events");
            DropForeignKey("dbo.OrganizationCheckoutRecords", "Character_ID", "dbo.Characters");
            DropForeignKey("dbo.FavoredSkills", "Skill_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.FavoredSkills", "Favors_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.CharacterCheckoutRecords", "NobleAlliedTo_ID", "dbo.Characters");
            DropForeignKey("dbo.CharacterCheckoutRecords", "Event_ID", "dbo.Events");
            DropForeignKey("dbo.CharacterCheckoutRecords", "Character_ID", "dbo.Characters");
            DropForeignKey("dbo.Characters", "Player_ID", "dbo.Players");
            DropForeignKey("dbo.Organizations", "Character_ID", "dbo.Characters");
            DropForeignKey("dbo.CharacterSkills", "Skill_SkillKey", "dbo.Skills");
            DropForeignKey("dbo.CharacterSkills", "Character_ID", "dbo.Characters");
            DropIndex("dbo.ProhibitedSkills", new[] { "Prohibits_SkillKey" });
            DropIndex("dbo.ProhibitedSkills", new[] { "Skill_SkillKey" });
            DropIndex("dbo.PrerequisiteSkills", new[] { "SecondaryRequirement_SkillKey" });
            DropIndex("dbo.PrerequisiteSkills", new[] { "PrimaryRequirement_SkillKey" });
            DropIndex("dbo.PrerequisiteSkills", new[] { "Skill_SkillKey" });
            DropIndex("dbo.OrganizationMemberships", new[] { "Character_ID" });
            DropIndex("dbo.OrganizationMemberships", new[] { "Organization_Name" });
            DropIndex("dbo.OrganizationCheckoutRecords", new[] { "Organization_Name" });
            DropIndex("dbo.OrganizationCheckoutRecords", new[] { "Event_ID" });
            DropIndex("dbo.OrganizationCheckoutRecords", new[] { "Character_ID" });
            DropIndex("dbo.FavoredSkills", new[] { "Favors_SkillKey" });
            DropIndex("dbo.FavoredSkills", new[] { "Skill_SkillKey" });
            DropIndex("dbo.Organizations", new[] { "Character_ID" });
            DropIndex("dbo.CharacterSkills", new[] { "Skill_SkillKey" });
            DropIndex("dbo.CharacterSkills", new[] { "Character_ID" });
            DropIndex("dbo.Characters", new[] { "Player_ID" });
            DropIndex("dbo.CharacterCheckoutRecords", new[] { "NobleAlliedTo_ID" });
            DropIndex("dbo.CharacterCheckoutRecords", new[] { "Event_ID" });
            DropIndex("dbo.CharacterCheckoutRecords", new[] { "Character_ID" });
            DropTable("dbo.ProhibitedSkills");
            DropTable("dbo.PrerequisiteSkills");
            DropTable("dbo.OrganizationMemberships");
            DropTable("dbo.OrganizationCheckoutRecords");
            DropTable("dbo.FavoredSkills");
            DropTable("dbo.Events");
            DropTable("dbo.Players");
            DropTable("dbo.Organizations");
            DropTable("dbo.Skills");
            DropTable("dbo.CharacterSkills");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterCheckoutRecords");
        }
    }
}
