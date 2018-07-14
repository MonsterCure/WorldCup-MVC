using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WorldCup.Entities;

namespace WorldCup.Repository
{
    public class MatchRepository : IRepository<Match>
    {
        private readonly WorldCupDb _db;

        public MatchRepository()
        {
            _db = new WorldCupDb();
        }

        public bool Create(Match matchToBeCreated)
        {
            bool isCreated = false;

            try
            {
                _db.Matches.Add(matchToBeCreated);
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
                Match match = _db.Matches.Find(id);
                _db.Matches.Remove(match);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isDeleted;
        }

        public IEnumerable<Match> GetAll()
        {
            try
            {
                List<Match> matches = _db.Matches.ToList();
                return matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Match GetById(Int16 id)
        {
            try
            {
                Match match = _db.Matches.FirstOrDefault(matchItem => matchItem.MatchId == id);
                return match;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Update(Match matchToBeUpdated)
        {
            bool isUpdated = false;

            try
            {
                _db.Entry(matchToBeUpdated).State = EntityState.Modified;
                _db.SaveChanges();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isUpdated;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
