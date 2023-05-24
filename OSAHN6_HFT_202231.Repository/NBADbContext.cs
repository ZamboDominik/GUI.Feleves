using Microsoft.EntityFrameworkCore;
using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;

namespace OSAHN6_HFT_202231.Repository
{
    public class NBADbContext:DbContext
    {
        
    
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        public NBADbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("NBADB").UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Team> teamArray = new List<Team>
          {
            new Team(){ Id = 1,Name="Golden State Warriors",LuxuryTax=50},
           // new Team(){ Id = 2,Name="Miami Heat",HeadCoach=null,LuxuryTax=0},
            new Team(){ Id = 2,Name="Dallas Maverics",LuxuryTax=20},
            //new Team(){ Id = 4,Name="Memphis Grizzlies",HeadCoach=null,LuxuryTax=15},
          };
            List<Coach> coachList = new List<Coach>
        {
            new Coach(){CoachId = 1, CoachName="Steve Kerr",TeamID = 1,Salary = 5 },
            new Coach(){CoachId = 2, CoachName="Jason Kidd",TeamID=2,Salary = 2 },

        };
            List<Player> playerList = new List<Player>()
         {
                new Player{ PlayerId = 1,Name = "Stephen Curry",TeamID=1, Position = "PG", Salary=33},
                new Player{ PlayerId = 2,Name = "Klay Thompson",TeamID=1, Position = "SG", Salary=20},
                new Player{ PlayerId = 3,Name = "Draymond Green",TeamID=1, Position = "PF", Salary=20},
                new Player{ PlayerId = 4,Name = "Kevon Looney",TeamID=1, Position = "C", Salary=5},
                new Player{ PlayerId = 5,Name = "Jordan Poole",TeamID=1, Position = "PG", Salary=20},
                new Player{ PlayerId = 6,Name = "Luka Doncic",TeamID=2, Position = "PG", Salary=30},
                new Player{ PlayerId = 7,Name = "Christion Wood",TeamID=2, Position = "PF", Salary=24},
                new Player{ PlayerId = 8,Name = "Spencer Dinwiddie", TeamID=2,Position = "SG", Salary=20},
                new Player{ PlayerId = 9,Name = "JaVale McGee",TeamID=2, Position = "C", Salary=7},
                new Player{ PlayerId = 10,Name = "Tim Hardaway",TeamID=2, Position = "SF", Salary=18},
         };
            modelBuilder.Entity<Player>().HasOne(t => t.team).WithMany(t => t.Players).HasForeignKey(t => t.TeamID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Coach>().HasOne(t => t.team).WithOne(t => t.HeadCoach).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Team>().HasData(teamArray);
            modelBuilder.Entity<Player>().HasData(playerList);
            modelBuilder.Entity<Coach>().HasData(coachList);
           

            base.OnModelCreating(modelBuilder);
        }
    }

}
