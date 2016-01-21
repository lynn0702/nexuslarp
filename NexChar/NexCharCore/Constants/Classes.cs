using System.Collections.Generic;

namespace NexCharCore.Constants
{
    public static class Classes
    {
        public const string Alchemist = "Alchemist";
        public const string Druid = "Druid";
        public const string Fighter = "Fighter";
        public const string Necromancer = "Necromancer";
        public const string Psionicist = "Psionicist";
        public const string Rogue = "Rogue";
        public const string Sorcerer = "Sorcerer";
        public const string General ="General";
        public const string Profession ="Profession";
        public const string Formal ="Formal";
        public const string Racial = "Racial";
        public const string None = "None";
        public static readonly List<string> AllClassTypes = new List<string>{Alchemist,Druid,Fighter,Necromancer,Psionicist,Rogue,Sorcerer,General,Profession,Formal,Racial,None};
        public static readonly List<string> CoreClasses = new List<string> { Alchemist, Druid, Fighter, Necromancer, Psionicist, Rogue, Sorcerer };

    }
}
