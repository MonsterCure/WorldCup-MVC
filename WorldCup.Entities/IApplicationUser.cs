using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup.Entities
{
    public interface IApplicationUser
    {
        ICollection<Player> FavoritePlayers { get; set; }

        ICollection<Team> FavoriteTeams { get; set; }

        ICollection<Match> FavoriteMatches { get; set; }
    }
}
