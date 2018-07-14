using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Entities;

namespace WorldCup.Repository
{
    public class UserRepository : IDisposable
    {
        private readonly WorldCupDb _db;

        public UserRepository()
        {
            _db = new WorldCupDb();
        }

        public IEnumerable<Player> GetFavoritePlayers(string id)
        {
            List<Player> favoritePlayers =_db.Users.Where(userItem => userItem.Id == id).SelectMany(userItem => userItem.FavoritePlayers).ToList();

            //IEnumerable<Player> favoritePlayers = (from player in _db.Players
            //             from user in player.Users.Where(userItem => userItem.Id == id)
            //             select player);

            //var result = (
            //    from user in _db.Users
            //    from player in user.FavoritePlayers
            //    join item in _db.Players on player.PlayerId equals item.PlayerId
            //    where user.Id == id
            //    select player).ToList();

            return favoritePlayers.IsNullOrEmpty()
                ? Enumerable.Empty<Player>()
                : favoritePlayers;
        }

        public IEnumerable<Team> GetFavoriteTeams(string id)
        {
            List<Team> favoriteTeams = _db.Users.Where(userItem => userItem.Id == id).SelectMany(userItem => userItem.FavoriteTeams).ToList();

            return favoriteTeams.IsNullOrEmpty()
                ? Enumerable.Empty<Team>()
                : favoriteTeams;
        }

        public IEnumerable<Match> GetFavoriteMatches(string id)
        {
            List<Match> favoriteMatches = _db.Users.Where(userItem => userItem.Id == id).SelectMany(userItem => userItem.FavoriteMatches).ToList();

            return favoriteMatches.IsNullOrEmpty()
                ? Enumerable.Empty<Match>()
                : favoriteMatches;
        }

        public bool AddFavoritePlayer(Int16 playerId, string id)
        {
            bool isAdded = false;

            try
            {
                ApplicationUser userInDb = new ApplicationUser { Id = id};
                _db.Users.Add(userInDb);
                _db.Users.Attach(userInDb);

                Player playerInDb = new Player { PlayerId = playerId};
                _db.Players.Add(playerInDb);
                _db.Players.Attach(playerInDb);

                userInDb.FavoritePlayers.Add(playerInDb);
                _db.SaveChanges();
                isAdded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isAdded;
        }

        public bool AddFavoriteTeam(Int16 teamId, string id)
        {
            bool isAdded = false;

            try
            {
                ApplicationUser userInDb = new ApplicationUser { Id = id };
                _db.Users.Add(userInDb);
                _db.Users.Attach(userInDb);

                Team teamInDb = new Team { TeamId = teamId };
                _db.Teams.Add(teamInDb);
                _db.Teams.Attach(teamInDb);

                userInDb.FavoriteTeams.Add(teamInDb);
                _db.SaveChanges();
                isAdded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isAdded;
        }

        public bool AddFavoriteMatch(Int16 matchId, string id)
        {
            bool isAdded = false;

            try
            {
                ApplicationUser userInDb = new ApplicationUser { Id = id };
                _db.Users.Add(userInDb);
                _db.Users.Attach(userInDb);

                Match matchInDb = new Match { MatchId = matchId };
                _db.Matches.Add(matchInDb);
                _db.Matches.Attach(matchInDb);

                userInDb.FavoriteMatches.Add(matchInDb);
                _db.SaveChanges();
                isAdded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isAdded;
        }

        public bool RemoveFavoritePlayer(Int16 playerId, string userId)
        {
            bool isRemoved = false;

            try
            {
                ApplicationUser user = _db.Users.Include("FavoritePlayers").SingleOrDefault(userItem => userItem.Id == userId);

                Player playerToBeDeleted = _db.Players.SingleOrDefault(playerItem => playerItem.PlayerId == playerId);

                if (user != null && playerToBeDeleted != null)
                {
                    user.FavoritePlayers.Remove(playerToBeDeleted);
                    _db.SaveChanges();
                    isRemoved = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isRemoved;
        }

        public bool RemoveFavoriteTeam(Int16 teamId, string userId)
        {
            bool isRemoved = false;

            try
            {
                ApplicationUser user = _db.Users.Include("FavoriteTeams").SingleOrDefault(userItem => userItem.Id == userId);

                Team teamToBeDeleted = _db.Teams.SingleOrDefault(teamItem => teamItem.TeamId == teamId);

                if (user != null && teamToBeDeleted != null)
                {
                    user.FavoriteTeams.Remove(teamToBeDeleted);
                    _db.SaveChanges();
                    isRemoved = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isRemoved;
        }

        public bool RemoveFavoriteMatch(Int16 matchId, string userId)
        {
            bool isRemoved = false;

            try
            {
                ApplicationUser user = _db.Users.Include("FavoriteMatches").SingleOrDefault(userItem => userItem.Id == userId);

                //if(user != null)
                //{
                //    foreach (var favoriteMatch in user.FavoriteMatches.Where(matchItem => matchItem.MatchId == matchId))
                //    {
                //        user.FavoriteMatches.Remove(favoriteMatch);
                //    }
                //}

                Match matchToBeDeleted = _db.Matches.SingleOrDefault(matchItem => matchItem.MatchId == matchId);

                if(user != null && matchToBeDeleted != null)
                {
                    user.FavoriteMatches.Remove(matchToBeDeleted);
                    _db.SaveChanges();
                    isRemoved = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isRemoved;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
