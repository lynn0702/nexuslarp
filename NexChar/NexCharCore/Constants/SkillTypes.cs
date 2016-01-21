using System.Collections.Generic;

namespace NexCharCore.Constants
{
    public class SkillTypes
    {
        public const string PurchasedChart = "PurchasedChart";
        public const string Race = "Race";
        public const string HiddenPrereq = "HiddenPrereq";
        public const string ChartSkill = "ChartSkill";
        public const string GrantedChart = "GrantedChart";
        public const string GrantedRacial = "GrantedRacial";
        public const string LogisticsEntry = "LogisticsEntry";
        public static List<string> AllTypes = new List<string> { PurchasedChart, Race, HiddenPrereq, ChartSkill, GrantedChart, GrantedRacial, LogisticsEntry }; 
    }
}
