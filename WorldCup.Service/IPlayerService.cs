using System;
using System.Collections.Generic;
using WorldCup.Entities;

namespace WorldCup.Service
{
    public interface IPlayerService
    {
        //Read
        IEnumerable<Player> GetAllPlayers(string searchCriteria);

        IEnumerable<Player> GetPlayersByPosition(string position);

        IEnumerable<Player> GetPlayersByTeam(string teamName);

        //Write
    }
}
