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
    public class PlayerService : IPlayerService
    {
        private ModelStateDictionary _modelState;

        public PlayerService(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public static void InitializeDatabase()
        {
            PlayerRepository.InitializeDatabase();
        }

        public bool CreatePlayer(Player playerToBeCreated)
        {
            using (var playerRepository = new PlayerRepository())
            {
                if (!_modelState.IsValid)
                    return false;
                try
                {
                    playerRepository.Create(playerToBeCreated);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeletePlayer(Int16 id)
        {
            using (var playerRepository = new PlayerRepository())
            {
                try
                {
                    playerRepository.Delete(id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            using (var playerRepository = new PlayerRepository())
            {
                try
                {
                    return playerRepository.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Player> GetAllPlayers(string searchCriteria = null)
        {
            using(var playerRepository = new PlayerRepository())
            {
                try
                {
                    return string.IsNullOrEmpty(searchCriteria)
                    ? playerRepository.GetAll().ToList()
                    : playerRepository.GetAll().Where(playerItem => playerItem.PlayerName.ToLower().Contains(searchCriteria.ToLower())).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Player GetPlayerById(Int16 id)
        {
            using (var playerRepository = new PlayerRepository())
            {
                try
                {
                    return playerRepository.GetById(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Player> GetPlayersByPosition(string position)
        {
            using (var playerRepository = new PlayerRepository())
            {
                try
                {
                    return string.IsNullOrEmpty(position)
                        ? playerRepository.GetAll().ToList()
                        : playerRepository.GetAll().Where(playerItem => playerItem.Position.ToString().ToLower().Contains(position.ToLower())).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Player> GetPlayersByTeam(string teamName)
        {
            using (var playerRepository = new PlayerRepository())
            {
                try
                {
                    return string.IsNullOrEmpty(teamName)
                        ? playerRepository.GetAll().ToList()
                        : playerRepository.GetAll().Where(playerItem => playerItem.Team.Name.ToLower().Contains(teamName.ToLower())).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using(var teamRepository = new TeamRepository())
            {
                try
                {
                    return teamRepository.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool UpdatePlayer(Player playerToBeUpdated)
        {
            using (var playerRepository = new PlayerRepository())
            {
                if (!_modelState.IsValid)
                    return false;

                try
                {
                    playerRepository.Update(playerToBeUpdated);
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
