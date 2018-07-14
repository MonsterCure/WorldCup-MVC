using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.Entities
{
    public class Team
    {
        public Team()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        [Key]
        public Int16 TeamId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Team name is required.")]
        [StringLength(maximumLength: 40, MinimumLength = 2)]
        [Display(Name = "Team")]
        public string Name { get; set; }

        [Display(Name = "Flag URL")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Team's flag is required.")]
        [StringLength(500, ErrorMessage = "Url must be between 10 and 500 characters.", MinimumLength = 10)]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string FlagUrl { get; set; }

        [Required(ErrorMessage = "Team group is required.")]
        public Group Group { get; set; }

        [Required(ErrorMessage = "Team continent is required.")]
        public Continent Continent { get; set; }
        
        public virtual ICollection<Player> Players { get; set; }

        [Display(Name = "Matches played")]
        public Int16 MatchesPlayed { get; set; } = 0;

        [Display(Name = "Matches won")]
        public Int16 MatchesWon { get; set; } = 0;

        [Display(Name = "Matches drawn")]
        public Int16 MatchesDrawn { get; set; } = 0;

        [Display(Name = "Matches lost")]
        public Int16 MatchesLost { get; set; } = 0;

        [Display(Name = "Goals for")]
        public Int16 GoalsFor { get; set; } = 0;

        [Display(Name = "Goals against")]
        public Int16 GoalsAgainst { get; set; } = 0;

        [Display(Name = "Goals difference")]
        public Int16 GoalsDifference
        {
            get
            {
                return _goalsDifference;
            }
            set
            {
                _goalsDifference = (Int16)(GoalsFor - GoalsAgainst);
            }
        }
        private Int16 _goalsDifference = 0;

        [Display(Name = "Points")]
        public Int16 Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = (Int16)((MatchesWon * 3) + (MatchesDrawn * 1));
            }
        }
        private Int16 _points = 0;

        public string UpdatedMatches { get; set; } = "";

        public virtual ICollection<Match> Team1Matches { get; set; }

        public virtual ICollection<Match> Team2Matches { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
