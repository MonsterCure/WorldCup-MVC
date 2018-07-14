using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using WorldCup.Entities;

namespace WorldCup.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public ApplicationUser()
        {
            this.FavoritePlayers = new HashSet<Player>();
            this.FavoriteTeams = new HashSet<Team>();
            this.FavoriteMatches = new HashSet<Match>();
        }

        public virtual ICollection<Player> FavoritePlayers { get; set; }
        public virtual ICollection<Team> FavoriteTeams { get; set; }
        public virtual ICollection<Match> FavoriteMatches { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
