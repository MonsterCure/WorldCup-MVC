using System;
using System.Collections.Generic;
using WorldCup.Entities;

namespace WorldCup.Service
{
    public interface IMatchService
    {
        //Read
        IEnumerable<Match> GetMatchesByDate(DateTime matchDate);

        IEnumerable<Match> GetMatchesByGroup(string group);

        IEnumerable<Match> GetMatchesByLocation(string location);

        IEnumerable<Match> GetMatchesByType(string matchType);

        IEnumerable<Match> GetMatchesByTeam(string teamName);

        //Write
        bool UpdateMatch(Match matchUpdated);
    }
}
