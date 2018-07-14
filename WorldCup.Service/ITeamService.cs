using System;
using System.Collections.Generic;
using WorldCup.Entities;

namespace WorldCup.Service
{
    public interface ITeamService
    {
        //Read
        IEnumerable<Team> GetAllTeams(string searchCriteria);

        IEnumerable<Team> GetTeamsByGroup(string group);

        IEnumerable<Team> GetTeamsByContinent(string continent);

        //Write
    }
}
