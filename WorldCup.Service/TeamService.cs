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
    public class TeamService : ITeamService
    {
        private ModelStateDictionary _modelState;
        private MatchRepository _matchRepository;
     
        public TeamService(ModelStateDictionary modelState)
        {
            _modelState = modelState;
            _matchRepository = new MatchRepository();
        }

        public bool CreateTeam(Team teamToBeCreated)
        {
            using (var teamRepository = new TeamRepository())
            {
                if (!_modelState.IsValid)
                    return false;
                try
                {
                    teamRepository.Create(teamToBeCreated);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteTeam(Int16 id)
        {
            using (var teamRepository = new TeamRepository())
            {
                try
                {
                    teamRepository.Delete(id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using (var teamRepository = new TeamRepository())
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

        public IEnumerable<Team> GetAllTeams(string searchCriteria)
        {
            using (var teamRepository = new TeamRepository())
            {
                try
                {
                    return string.IsNullOrEmpty(searchCriteria)
                    ? teamRepository.GetAll().ToList()
                    : teamRepository.GetAll().Where(teamItem => teamItem.Name.ToLower().Contains(searchCriteria.ToLower())).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Team> GetTeamsByContinent(string continent)
        {
            using (var teamRepository = new TeamRepository())
            {
                try
                {
                    return string.IsNullOrEmpty(continent)
                        ? teamRepository.GetAll()
                        : teamRepository.GetAll().Where(teamItem => teamItem.Continent.ToString() == continent).ToList();
                    //teamRepository.GetAll().Where(teamItem => teamItem.Continent.GetType().GetCustomAttributes(true).First().ToString() == continent).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<Team> GetTeamsByGroup(string group)
        {
            using (var teamRepository = new TeamRepository())
            {
                try
                {
                    return string.IsNullOrEmpty(group)
                        ? teamRepository.GetAll()
                        : teamRepository.GetAll().Where(teamItem => teamItem.Group.ToString() == group).ToList();
                    //teamRepository.GetAll().Where(teamItem => teamItem.Group.GetType().GetCustomAttributes(true).First().ToString() == group).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Team GetTeamById(Int16 id)
        {
            using (var teamRepository = new TeamRepository())
            {
                try
                {
                    return teamRepository.GetById(id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool UpdateTeam(Team teamToBeUpdated)
        {
            using (var teamRepository = new TeamRepository())
            {
                if (!_modelState.IsValid)
                    return false;
                try
                {
                    teamRepository.Update(teamToBeUpdated);
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
