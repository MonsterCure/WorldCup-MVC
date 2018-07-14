using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCup.Entities
{
    public class Player
    {
        public Player()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        [Key]
        public Int16 PlayerId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Player's name is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string PlayerName { get; set; }

        public byte Age { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 3000)]
        public string Biography { get; set; }

        [Display(Name = "Picture URL")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Player's picture is required.")]
        [StringLength(500, ErrorMessage = "Url must be between 10 and 500 characters.", MinimumLength = 10)]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string PictureUrl { get; set; }

        public Position Position { get; set; }

        [ForeignKey("Team")]
        [Display(Name = "Player's team", AutoGenerateField = false)]
        public Int16? PlayerTeamId { get; set; }

        //[ForeignKey("PlayerTeamId")]
        public virtual Team Team { get; set; }

        [Display(Name = "International goals")]
        public byte GoalsScored { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
