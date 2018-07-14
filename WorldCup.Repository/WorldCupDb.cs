using System.Data.Entity;
using WorldCup.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WorldCup.Repository
{
    public class WorldCupDb : IdentityDbContext<ApplicationUser>/*DbContext*/
    {
        public WorldCupDb() : base("WorldCupDb", throwIfV1Schema: false)
        {
            Database.SetInitializer<WorldCupDb>(new WorldCupDbInitializer());
            //Database.Create();
        }

        public static WorldCupDb Create()
        {
            return new WorldCupDb();
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                    .HasOptional(m => m.Team1)
                    .WithMany(t => t.Team1Matches)
                    .HasForeignKey(m => m.Team1Id)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasOptional(m => m.Team2)
                        .WithMany(t => t.Team2Matches)
                        .HasForeignKey(m => m.Team2Id)
                        .WillCascadeOnDelete(false);
        }
    }
}
