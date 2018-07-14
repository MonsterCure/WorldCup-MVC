using System.ComponentModel.DataAnnotations;

namespace WorldCup.Entities
{
    public enum Position
    {
        Other = 0,

        Goalkeeper = 1,

        Sweeper = 2,

        [Display(Name = "Centre-back")]
        CentreBack = 3,

        [Display(Name = "Right-back")]
        RightBack = 4,

        [Display(Name = "Left-back")]
        LeftBack = 5,

        [Display(Name = "Wing-back")]
        WingBack = 6,

        [Display(Name = "Defensive midfielder")]
        DefensiveMidfielder = 7,

        [Display(Name = "Side midfielder")]
        SideMidfielder = 8,

        [Display(Name = "Central midfielder")]
        CentralMidfielder = 9,

        [Display(Name = "Attacking midfielder")]
        AttackingMidfielder = 10,

        [Display(Name = "Wing-forward")]
        WingForward = 11,

        [Display(Name = "Centre-forward")]
        CentreForward = 12,

        Striker = 13
    }
}
