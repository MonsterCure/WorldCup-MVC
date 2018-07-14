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
    public class MatchService : IMatchService
    {
        private ModelStateDictionary _modelState;
        private MatchRepository _matchRepository;

        public MatchService(ModelStateDictionary modelState, MatchRepository matchRepository)
        {
            _modelState = modelState;
            _matchRepository = matchRepository;
        }

        public bool CreateMatch(Match matchToBeCreated)
        {
            if (!_modelState.IsValid)
                return false;
            try
            {
                _matchRepository.Create(matchToBeCreated);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMatch(Int16 id)
        {
            bool isDeleted = false;

            using(var teamRepository = new TeamRepository())
            {
                try
                {
                    Match matchNotYetDeleted = _matchRepository.GetAll().FirstOrDefault(matchItem => matchItem.MatchId == id);

                    if (matchNotYetDeleted.Team1Id != null && matchNotYetDeleted.Team2Id != null)
                    {
                        Team teamOne = teamRepository.GetById(matchNotYetDeleted.Team1Id.Value);
                        Team teamTwo = teamRepository.GetById(matchNotYetDeleted.Team2Id.Value);

                        if (!teamRepository.GetPlayedMatches(teamOne.TeamId).IsNullOrEmpty() && teamRepository.GetPlayedMatches(teamOne.TeamId).Contains(matchNotYetDeleted.MatchId.ToString()))
                        {
                            if (matchNotYetDeleted.ScoreTeam1 > matchNotYetDeleted.ScoreTeam2)
                            {
                                teamOne.MatchesWon -= 1;
                            }
                            if (matchNotYetDeleted.ScoreTeam1 < matchNotYetDeleted.ScoreTeam2)
                            {
                                teamOne.MatchesLost -= 1;
                            }
                            if (matchNotYetDeleted.ScoreTeam1 == matchNotYetDeleted.ScoreTeam2)
                            {
                                teamOne.MatchesDrawn -= 1;
                            }

                            teamOne.MatchesPlayed -= 1;
                            teamOne.GoalsFor -= matchNotYetDeleted.ScoreTeam1;
                            teamOne.GoalsAgainst -= matchNotYetDeleted.ScoreTeam2;

                            //remove the matchId from the UpdatedMatches property of the first Team object, in order to be able to enter new nfo for the same match, without duplicating values
                            teamRepository.RemovePlayedMatches(teamOne.TeamId, matchNotYetDeleted.MatchId);

                            //update the first Team object in the database, with the removal of the information from the old Match object
                            teamRepository.Update(teamOne);
                        }


                        if (!teamRepository.GetPlayedMatches(teamTwo.TeamId).IsNullOrEmpty() && teamRepository.GetPlayedMatches(teamTwo.TeamId).Contains(matchNotYetDeleted.MatchId.ToString()))
                        {
                            if (matchNotYetDeleted.ScoreTeam2 > matchNotYetDeleted.ScoreTeam1)
                            {
                                teamTwo.MatchesWon -= 1;
                            }
                            if (matchNotYetDeleted.ScoreTeam2 < matchNotYetDeleted.ScoreTeam1)
                            {
                                teamTwo.MatchesLost -= 1;
                            }
                            if (matchNotYetDeleted.ScoreTeam2 == matchNotYetDeleted.ScoreTeam1)
                            {
                                teamTwo.MatchesDrawn -= 1;
                            }

                            teamTwo.MatchesPlayed -= 1;
                            teamTwo.GoalsFor -= matchNotYetDeleted.ScoreTeam2;
                            teamTwo.GoalsAgainst -= matchNotYetDeleted.ScoreTeam1;

                            //remove the match ID from the UpdatedMatches property of the seond Team object, in order to be able to enter new nfo for the same match, without duplicating values
                            teamRepository.RemovePlayedMatches(teamTwo.TeamId, matchNotYetDeleted.MatchId);

                            //update the second Team object in the database, with the removal of the information from the old Match object
                            teamRepository.Update(teamTwo);
                        }
                    }

                    _matchRepository.Delete(id);

                    isDeleted = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return isDeleted;
            }
            
            //try
            //{
            //    _matchRepository.Delete(id);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public IEnumerable<Match> GetAllMatches()
        {
            try
            {
                return _matchRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Match> GetMatchesByDate(DateTime matchDate)
        {
            try
            {
                List<Match> matches = _matchRepository.GetAll().Where(matchItem => matchItem.MatchTime == matchDate).ToList();
                return matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Match> GetMatchesByGroup(string group)
        {
            try
            {
                return string.IsNullOrEmpty(group)
                    ? _matchRepository.GetAll()
                    : _matchRepository.GetAll().Where(matchItem => matchItem.Group.ToString() == group).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Match GetMatchById(Int16 id)
        {
            try
            {
                return _matchRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Match> GetMatchesByLocation(string location)
        {
            try
            {
                return string.IsNullOrEmpty(location)
                    ? _matchRepository.GetAll()
                    : _matchRepository.GetAll().Where(matchItem => matchItem.StadiumLocation.ToString() == location).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Match> GetMatchesByTeam(string teamName)
        {
            try
            {
                return string.IsNullOrEmpty(teamName)
                    ? _matchRepository.GetAll().ToList()
                    : _matchRepository.GetAll().Where(matchItem => ((matchItem.Team1Id != null && matchItem.Team1.Name.ToLower().Contains(teamName.ToLower())) || (matchItem.Team2Id != null && matchItem.Team2.Name.ToLower().Contains(teamName.ToLower())))).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Match> GetMatchesByType(string matchType)
        {
            try
            {
                return string.IsNullOrEmpty(matchType)
                    ? _matchRepository.GetAll()
                    : _matchRepository.GetAll().Where(matchItem => matchItem.MatchType.ToString() == matchType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
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

        /// <summary>
        /// This method receives two Match objects, the one with new information, to be saved to the database, and the old one, before the changes, so that the old information can be used within this method, both objects refer to the same match, and have the same ID.
        /// </summary>
        public bool UpdateMatch(Match matchUpdated)
        {
            bool isUpdated = false;

            if (!_modelState.IsValid)
                isUpdated = false;

            //using TeamRepository as well as the MatchRepository, in order to effectuate changes to Match and Team objects
            using (var teamRepository = new TeamRepository())
            {
                try
                {
                    //get the old Math object which will be updated with new info
                    Match matchNotUpdated = _matchRepository.GetAll().FirstOrDefault(matchItem => matchItem.MatchId == matchUpdated.MatchId);

                    //get the two Team objects referenced in the Match object, first and second
                    Team teamOne = teamRepository.GetById(matchUpdated.Team1Id.Value);
                    Team teamTwo = teamRepository.GetById(matchUpdated.Team2Id.Value);

                    //check if the UpdatedMatches property of the first Team object is null or empty and if the match has not been entered in that same property already (which would mean that the match has not been updated yet)
                    if (/*!teamRepository.GetPlayedMatches(teamOne.TeamId).IsNullOrEmpty() && */!teamRepository.GetPlayedMatches(teamOne.TeamId).Contains(matchUpdated.MatchId.ToString()))
                    {
                        //add the match information to the first Team object
                        if (matchUpdated.ScoreTeam1 > matchUpdated.ScoreTeam2)
                            teamOne.MatchesWon += 1;
                        if (matchUpdated.ScoreTeam1 < matchUpdated.ScoreTeam2)
                            teamOne.MatchesLost += 1;
                        if (matchUpdated.ScoreTeam1 == matchUpdated.ScoreTeam2)
                            teamOne.MatchesDrawn += 1;

                        teamOne.MatchesPlayed += 1;
                        teamOne.GoalsFor += matchUpdated.ScoreTeam1;
                        teamOne.GoalsAgainst += matchUpdated.ScoreTeam2;

                        //add the match ID to the UpdatedMatches property of the first Team object, in order to know the match has been updated, and that the match info has already been passed to the first Team object
                        teamRepository.AddPlayedMatches(teamOne.TeamId, matchUpdated.MatchId);

                        //update the first Team object in the database
                        teamRepository.Update(teamOne);
                    }
                    //check if the UpdatedMatches property of the first Team object is null or empty and if the match has been entered in the that same property already (which would mean that the match has been updated at least once before)
                    else if (/*!teamRepository.GetPlayedMatches(teamOne.TeamId).IsNullOrEmpty() && */teamRepository.GetPlayedMatches(teamOne.TeamId).Contains(matchUpdated.MatchId.ToString()))
                    {
                        //teamOne.MatchesWon = 0;
                        //teamOne.MatchesLost = 0;
                        //teamOne.MatchesDrawn = 0;
                        //teamOne.MatchesPlayed -= 1;
                        //teamOne.GoalsFor = 0;
                        //teamOne.GoalsAgainst = 0;
                        //teamRepository.Update(teamOne);

                        //remove the match info from the first Team object, according to the information from the old Match object, from before the changes to it
                        if (matchNotUpdated.ScoreTeam1 > matchNotUpdated.ScoreTeam2)
                            teamOne.MatchesWon -= 1;
                        if (matchNotUpdated.ScoreTeam1 < matchNotUpdated.ScoreTeam2)
                            teamOne.MatchesLost -= 1;
                        if (matchNotUpdated.ScoreTeam1 == matchNotUpdated.ScoreTeam2)
                            teamOne.MatchesDrawn -= 1;

                        teamOne.MatchesPlayed -= 1;
                        teamOne.GoalsFor -= matchNotUpdated.ScoreTeam1;
                        teamOne.GoalsAgainst -= matchNotUpdated.ScoreTeam2;

                        //update the first Team object in the database, with the removal of the information from the old Match object
                        teamRepository.Update(teamOne);

                        //add the match information, from the new, changed, Match object to the first Team object, effectively updating the first Team associated with the Match object
                        if (matchUpdated.ScoreTeam1 > matchUpdated.ScoreTeam2)
                            teamOne.MatchesWon += 1;
                        if (matchUpdated.ScoreTeam1 < matchUpdated.ScoreTeam2)
                            teamOne.MatchesLost += 1;
                        if (matchUpdated.ScoreTeam1 == matchUpdated.ScoreTeam2)
                            teamOne.MatchesDrawn += 1;

                        teamOne.MatchesPlayed += 1;
                        teamOne.GoalsFor += matchUpdated.ScoreTeam1;
                        teamOne.GoalsAgainst += matchUpdated.ScoreTeam2;

                        //update the first Team object in the database
                        teamRepository.Update(teamOne);
                    }

                    //check if the UpdatedMatches property of the second Team object is null or empty and if the match has not been entered in the that same property already (which would mean that the match has not been updated yet)
                    if (/*!teamRepository.GetPlayedMatches(teamTwo.TeamId).IsNullOrEmpty() && */!teamRepository.GetPlayedMatches(teamTwo.TeamId).Contains(matchUpdated.MatchId.ToString()))
                    {
                        //add the match information to the second Team object
                        if (matchUpdated.ScoreTeam2 > matchUpdated.ScoreTeam1)
                            teamTwo.MatchesWon += 1;
                        if (matchUpdated.ScoreTeam2 < matchUpdated.ScoreTeam1)
                            teamTwo.MatchesLost += 1;
                        if (matchUpdated.ScoreTeam2 == matchUpdated.ScoreTeam1)
                            teamTwo.MatchesDrawn += 1;

                        teamTwo.MatchesPlayed += 1;
                        teamTwo.GoalsFor += matchUpdated.ScoreTeam2;
                        teamTwo.GoalsAgainst += matchUpdated.ScoreTeam1;

                        //add the match ID to the UpdatedMatches property of the second Team object, in order to know the match has been updated, and that the match info has already been passed to the second Team object
                        teamRepository.AddPlayedMatches(teamTwo.TeamId, matchUpdated.MatchId);

                        //update the second Team object in the database
                        teamRepository.Update(teamTwo);
                    }
                    //check if the UpdatedMatches property of the second Team object is null or empty and if the match has been entered in the that same property already (which would mean that the match has been updated at least once before)
                    else if (/*!teamRepository.GetPlayedMatches(teamTwo.TeamId).IsNullOrEmpty() &&*/ teamRepository.GetPlayedMatches(teamTwo.TeamId).Contains(matchUpdated.MatchId.ToString()))
                    {
                        //teamTwo.MatchesWon = 0;
                        //teamTwo.MatchesLost = 0;
                        //teamTwo.MatchesDrawn = 0;
                        //teamTwo.MatchesPlayed -= 1;
                        //teamTwo.GoalsFor = 0;
                        //teamTwo.GoalsAgainst = 0;
                        //teamRepository.Update(teamTwo);

                        //remove the match info from the second Team object, according to the information from the old Match object, from before the changes to it
                        if (matchNotUpdated.ScoreTeam2 > matchNotUpdated.ScoreTeam1)
                            teamTwo.MatchesWon -= 1;
                        if (matchNotUpdated.ScoreTeam2 < matchNotUpdated.ScoreTeam1)
                            teamTwo.MatchesLost -= 1;
                        if (matchNotUpdated.ScoreTeam2 == matchNotUpdated.ScoreTeam1)
                            teamTwo.MatchesDrawn -= 1;

                        teamTwo.MatchesPlayed -= 1;
                        teamTwo.GoalsFor -= matchNotUpdated.ScoreTeam2;
                        teamTwo.GoalsAgainst -= matchNotUpdated.ScoreTeam1;

                        //update the second Team object in the database, with the removal of the information from the old Match object
                        teamRepository.Update(teamTwo);

                        //add the match information, from the new, changed, Match object to the second Team object, effectively updating the second Team associated with the Match object
                        if (matchUpdated.ScoreTeam2 > matchUpdated.ScoreTeam1)
                            teamTwo.MatchesWon += 1;
                        if (matchUpdated.ScoreTeam2 < matchUpdated.ScoreTeam1)
                            teamTwo.MatchesLost += 1;
                        if (matchUpdated.ScoreTeam2 == matchUpdated.ScoreTeam1)
                            teamTwo.MatchesDrawn += 1;

                        teamTwo.MatchesPlayed += 1;
                        teamTwo.GoalsFor += matchUpdated.ScoreTeam2;
                        teamTwo.GoalsAgainst += matchUpdated.ScoreTeam1;

                        //update the second Team object in the database
                        teamRepository.Update(teamTwo);
                    }

                    //update the properties of the old Match object with the ones form the new Match object
                    matchNotUpdated.Team1Id = matchUpdated.Team1Id;
                    matchNotUpdated.Team2Id = matchUpdated.Team2Id;
                    matchNotUpdated.ScoreTeam1 = matchUpdated.ScoreTeam1;
                    matchNotUpdated.ScoreTeam2 = matchUpdated.ScoreTeam2;
                    //update the Match object in the database
                    _matchRepository.Update(matchNotUpdated);

                    isUpdated = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return isUpdated;
        }        

        public void Dispose()
        {
            _matchRepository.Dispose();
        }
    }
}
