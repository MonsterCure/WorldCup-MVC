using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorldCup.Entities;

namespace WorldCup.Web.Models
{
    public class TeamViewModel
    {
        [Required(ErrorMessage = "Team name is required.")]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        [Display(Name = "Team")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Team's flag is required.")]
        [Url]
        public string FlagUrl { get; set; }

        [Required(ErrorMessage = "Team group is required.")]
        public Group Group { get; set; }

        [Required(ErrorMessage = "Team continent is required.")]
        public Continent Continent { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public byte MatchesPlayed { get; set; }

        public byte MatchesWon { get; set; }

        public byte MatchesDrawn { get; set; }

        public byte MatchesLost { get; set; }

        public byte GoalsFor { get; set; }

        public byte GoalsAgainst { get; set; }

        public byte GoalsDifference { get; set; }

        public byte Points { get; set; }

        public virtual ICollection<Match> GroupMatches { get; set; }

        public virtual ICollection<Match> OtherMatches { get; set; }

    }
}