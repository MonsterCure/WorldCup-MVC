using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorldCup.Entities;

namespace WorldCup.Web.Models
{
    public class PlayerViewModel
    {
        public Player Player { get; set; }

        public string TeamName { get; set; }

        public IEnumerable<Team> Teams { get; set; }


    }
}