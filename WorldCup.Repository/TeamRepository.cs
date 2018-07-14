using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Entities;

namespace WorldCup.Repository
{
    public class TeamRepository : IRepository<Team>, IDisposable
    {
        private readonly WorldCupDb _db;

        public TeamRepository()
        {
            _db = new WorldCupDb();
        }

        public bool Create(Team teamToBeCreated)
        {
            bool isCreated = false;

            try
            {
                _db.Teams.Add(teamToBeCreated);
                _db.SaveChanges();
                isCreated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isCreated;
        }

        public bool Delete(Int16 id)
        {
            bool isDeleted = false;

            try
            {
                Team team = _db.Teams.Find(id);
                _db.Teams.Remove(team);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isDeleted;
        }

        public IEnumerable<Team> GetAll()
        {
            try
            {
                List<Team> teams = _db.Teams.ToList();
                return teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Team GetById(Int16 id)
        {
            try
            {
                Team team = _db.Teams.Include("Players").FirstOrDefault(teamItem => teamItem.TeamId == id);
                return team;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Team teamToBeUpdated)
        {
            bool isUpdated = false;

            try
            {
                _db.Entry(teamToBeUpdated).State = EntityState.Modified;
                _db.SaveChanges();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isUpdated;
        }

        ///<summary>
        ///Get the UpdatedMatches string property from a Team object as a list of strings of the matches' IDs for the matches the team has played.
        ///</summary>
        public List<string> GetPlayedMatches(Int16 teamId)
        {
            //get the team whose UpdatedMatches property will be returned
            Team team = _db.Teams.FirstOrDefault(teamItem => teamItem.TeamId == teamId);

            //get the UpdatedMatches property of the team as a list of strings of the matches' IDs
            List<string> matchIdList = team.UpdatedMatches.Split(',').ToList();

            //return the list of strings, or an empty list
            if (matchIdList.IsNullOrEmpty())
            {
                return new List<string>();
            }
            else
            {
                return matchIdList;
            }
        }

        ///<summary>
        ///Add the match ID for a match a team has played, to the UpdatedMatches string property in the Team object.
        ///</summary>
        public bool AddPlayedMatches(Int16 teamId, Int16 matchId)
        {
            bool isAdded = false;

            try
            {
                //get the team whose UpdatedMatches property will be updated
                Team team = _db.Teams.FirstOrDefault(teamItem => teamItem.TeamId == teamId);

                //get the UpdatedMatches property of the team as a list of strings of the matches' IDs
                List<string> matchIdList = team.UpdatedMatches.Split(',').ToList();

                //add the new match ID to the list of strings
                matchIdList.Add(matchId.ToString());

                //convert the updated list of strings to a string
                string updatedMatches = String.Join(",", matchIdList.Select(item => item.ToString()));

                //add that string to the Team object's UpdatedMatches property
                team.UpdatedMatches = updatedMatches;

                //save the changes to the Team object in the database
                _db.Entry(team).State = EntityState.Modified;
                _db.SaveChanges();

                isAdded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isAdded;
        }

        ///<summary>
        ///Remove the match ID for a match a team has played, from the UpdatedMatches string property in the Team object.
        ///</summary>
        public bool RemovePlayedMatches(Int16 teamId, Int16 matchId)
        {
            bool isRemoved = false;

            try
            {
                //get the team whose UpdatedMatches property will be updated
                Team team = _db.Teams.FirstOrDefault(teamItem => teamItem.TeamId == teamId);

                //get the UpdatedMatches property of the team as a list of strings of the matches' IDs
                List<string> matchIdList = team.UpdatedMatches.Split(',').ToList();

                //remove the match ID from the list of strings
                matchIdList.Remove(matchId.ToString());

                //convert the updated list of strings to a string
                string updatedMatches = String.Join(",", matchIdList.Select(item => item.ToString()));

                //add that string to the Team object's UpdatedMatches property
                team.UpdatedMatches = updatedMatches;

                //save the changes to the Team object in the database
                _db.Entry(team).State = EntityState.Modified;
                _db.SaveChanges();

                isRemoved = true;
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
