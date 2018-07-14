using System.ComponentModel.DataAnnotations;

namespace WorldCup.Entities
{
    public enum StadiumLocation
    {
        [Display(Name = "Ekaterinburg Arena, Ekaterinburg")]
        Ekaterinburg = 0,

        [Display(Name = "Kaliningrad Stadium, Kaliningrad")]
        Kaliningrad = 1,

        [Display(Name = "Kazan Arena, Kazan")]
        Kazan = 2,

        [Display(Name = "Spartak Stadium, Moscow")]
        MoscowSpartak = 3,

        [Display(Name = "Luzhniki Stadium, Moscow")]
        MoscowLuzhniki = 4,

        [Display(Name = "Nizhny Novgorod Stadium, Nizhny Novgorod")]
        NizhnyNovgorod = 5,

        [Display(Name = "Rostov Arena, Rostov-On-Don")]
        RostovOnDon = 6,

        [Display(Name = "Saint Petersburg Stadium, Saint Petersburg")]
        SaintPetersburg = 7,

        [Display(Name = "Samara Arena, Samara")]
        Samara = 8,

        [Display(Name = "Mordovia Arena, Saransk")]
        Saransk = 9,

        [Display(Name = "Fisht Stadium, Sochi")]
        Sochi = 10,

        [Display(Name = "Volgograd Arena, Volgograd")]
        Volgograd = 11
    }
}
