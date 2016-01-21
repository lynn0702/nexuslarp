using System.Collections.Generic;

namespace NexCharCore.Constants
{
    public static class OrganizationTypes
    {
        public const string Guild = "Guild";
        public const string Noble = "Noble";
        public const string Military = "Military";
        public const string Cult = "Cult";
        public static List<string> AllTypes = new List<string>{Guild,Noble,Military,Cult}; 
    }
}
