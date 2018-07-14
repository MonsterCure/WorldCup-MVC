using System.ComponentModel.DataAnnotations;

namespace WorldCup.Entities
{
    public enum MatchType
    {
        [Display(Name = "Group match")]
        GroupMatch = 0,

        [Display(Name = "Round of 16")]
        RoundOf16 = 1,

        [Display(Name = "Quarter-final")]
        QuarterFinal = 2,

        [Display(Name = "Semi-final")]
        SemiFinal = 3,

        [Display(Name = "Play off for third place")]
        ThirdPlace = 4,

        [Display(Name = "Final")]
        Final = 5
    }
}
