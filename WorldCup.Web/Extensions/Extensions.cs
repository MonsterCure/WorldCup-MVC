using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using WorldCup.Entities;

namespace WorldCup.Web.Extensions
{
    public static class Extensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            DisplayAttribute displayAttribute = enumValue.GetType()
                                                         .GetMember(enumValue.ToString())
                                                         .First()
                                                         .GetCustomAttribute<DisplayAttribute>();
            //string displayName = "";

            //if (displayAttribute != null)
            //{

            //    displayName = displayAttribute?.GetName();
            //}
            //else
            //{
            //    displayName = enumValue.ToString();
            //}

            //return displayName;

            string displayName = displayAttribute?.GetName();

            return displayName ?? enumValue.ToString();
        }

        public static List<string> GetDisplayNames(this Array enumValues)
        {
            List<string> displayName = new List<string>();

            foreach (var value in enumValues)
            {
                DisplayAttribute displayAttribute = value.GetType()
                                                         .GetMember(value.ToString())
                                                         .First()
                                                         .GetCustomAttribute<DisplayAttribute>();

                if(displayAttribute != null)
                {

                    displayName.Add(displayAttribute?.GetName());
                }
                else
                {
                    displayName.Add(value.ToString());
                }
            }

            return displayName;
        }

        public static string MatchToString(this Match match)
        {
            return $"{match.Team1.Name} {match.ScoreTeam1} : {match.ScoreTeam2} {match.Team2.Name}";
        }
    }
}