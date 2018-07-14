using System.ComponentModel.DataAnnotations;

namespace WorldCup.Entities
{
    public enum Continent
    {
        Asia = 0,

        Africa = 1,

        [Display(Name = "North America, Central America and the Caribbean")]
        NorthAmerica = 2,

        [Display(Name = "South America")]
        SouthAmerica = 3,

        Oceania = 4,

        Europe = 5
    }
}
