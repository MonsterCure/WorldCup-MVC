using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WorldCup.Entities;

namespace WorldCup.Repository
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly WorldCupDb _db;

        public PlayerRepository()
        {
            _db = new WorldCupDb();
        }

        public static void InitializeDatabase()
        {
            Database.SetInitializer(new WorldCupDbInitializer());
        }

        public bool Create(Player playerToBeCreated)
        {
            bool isCreated = false;

            try
            {
                _db.Players.Add(playerToBeCreated);
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
                Player player = _db.Players.Find(id);
                _db.Players.Remove(player);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isDeleted;
        }

        public IEnumerable<Player> GetAll()
        {
            try
            {
                List<Player> players = _db.Players.Include("Team").ToList();
                return players;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Player GetById(Int16 id)
        {
            try
            {
                Player player = _db.Players.Include("Team").FirstOrDefault(playerItem => playerItem.PlayerId == id);
                return player;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Player playerToBeUpdated)
        {
            bool isUpdated = false;

            try
            {
                _db.Entry(playerToBeUpdated).State = EntityState.Modified;
                _db.SaveChanges();

                //var modifiedCount = _db.SaveChanges();
                //if (modifiedCount > 0)

                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isUpdated;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
