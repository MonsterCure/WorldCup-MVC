using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.Entities
{
    public class Match
    {
        public Match()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        [Key]
        public Int16 MatchId { get; set; }

        [Required(ErrorMessage = "Match time is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Match time")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MatchTime { get; set; }

        [Required(ErrorMessage = "Match type is required.")]
        [Display(Name = "Match type")]
        public MatchType MatchType { get; set; }

        [Display(AutoGenerateField = false, Name = "Group")]
        public Group? Group { get; set; }

        [Required(ErrorMessage = "Match location is required.")]
        [Display(Name = "Location")]
        public StadiumLocation StadiumLocation { get; set; }

        //[ForeignKey("Team1")]
        [Display(AutoGenerateField = false, Name = "Team One")]
        public Int16? Team1Id { get; set; }

        [ForeignKey("Team1Id")]
        public virtual Team Team1 { get; set; }

        //[ForeignKey("Team2")]
        [Display(AutoGenerateField = false, Name = "Team Two")]
        public Int16? Team2Id { get; set; }

        [ForeignKey("Team2Id")]
        public virtual Team Team2 { get; set; }

        [Display(Name = "Team One Score")]
        public Int16 ScoreTeam1 { get; set; } = 0;

        [Display(Name = "Team Two Score")]
        public Int16 ScoreTeam2 { get; set; } = 0;

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
