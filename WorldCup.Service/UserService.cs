using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WorldCup.Entities;
using WorldCup.Repository;

namespace WorldCup.Service
{
    public class UserService
    {
        private ModelStateDictionary _modelState;

        public UserService(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public IEnumerable<Player> GetFavoritePlayers(string id)
        {
            using(var userRepository = new UserRepository())
            {
                try
                {
                    return userRepository.GetFavoritePlayers(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Team> GetFavoriteTeams(string id)
        {
            using (var userRepository = new UserRepository())
            {
                try
                {
                    return userRepository.GetFavoriteTeams(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Match> GetFavoriteMatches(string id)
        {
            using (var userRepository = new UserRepository())
            {
                try
                {
                    return userRepository.GetFavoriteMatches(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool AddFavoritePlayer(Int16 playerId, string id)
        {
            using (var userRepository = new UserRepository())
            {
                if (!_modelState.IsValid)
                    return false;
                try
                {
                    userRepository.AddFavoritePlayer(playerId, id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool AddFavoriteTeam(Int16 teamId, string id)
        {
            using (var userRepository = new UserRepository())
            {
                if (!_modelState.IsValid)
                    return false;
                try
                {
                    userRepository.AddFavoriteTeam(teamId, id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool AddFavoriteMatch(Int16 matchId, string id)
        {
            using (var userRepository = new UserRepository())
            {
                if (!_modelState.IsValid)
                    return false;
                try
                {
                    userRepository.AddFavoriteMatch(matchId, id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool RemoveFavoritePlayer(Int16 playerId, string userId)
        {
            using (var userRepository = new UserRepository())
            {
                try
                {
                    userRepository.RemoveFavoritePlayer(playerId, userId);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool RemoveFavoriteTeam(Int16 teamId, string userId)
        {
            using (var userRepository = new UserRepository())
            {
                try
                {
                    userRepository.RemoveFavoriteTeam(teamId, userId);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool RemoveFavoriteMatch(Int16 matchId, string userId)
        {
            using (var userRepository = new UserRepository())
            {
                try
                {
                    userRepository.RemoveFavoriteMatch(matchId, userId);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
