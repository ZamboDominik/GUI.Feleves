using Moq;
using NUnit.Framework;
using OSAHN6_HFT_202231.Logic;
using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSAHN6_HFT_202231.Test
{
    [TestFixture]
    public class Tests
    {
        TeamLogic teamLogic;
        CoachLogic coachLogic;
        PlayerLogic playerLogic;
        Mock<IRepository<Team>> mockTeamRepository;
        Mock<IRepository<Coach>> mockCoachRepository;
        Mock<IRepository<Player>> mockPlayerRepository;
        Team team;
        Player player;
        Coach hc;
        [SetUp]
        public void Init()
        {
            mockTeamRepository = new Mock<IRepository<Team>>();
            mockCoachRepository = new Mock<IRepository<Coach>>();
            mockPlayerRepository = new Mock<IRepository<Player>>(); 
            player = new Player();
            player.Name = "bela";
            player.Salary = 1;
            player.TeamID = 1;
            player.Position = "Janitor";
            hc = new Coach(); 
            hc.Salary = 1;
            hc.CoachId = 1;
            hc.CoachName = "bela2";
            hc.TeamID = 1;
            team = new Team();
            team.Players = new List<Player>();
            team.Id = 1;
            team.Name = "belaim";
            team.LuxuryTax = 0;
            hc.team = team;
            player.team = team;
            team.HeadCoach = hc;
            team.Players.Add(player);
            Team t2 = new Team() { Id = 2, Name = "Nembelak", LuxuryTax = 1 };
            Player p2 = new Player() { Name ="nembela",team = t2,TeamID = 2,PlayerId=2,Position="Janitor",Salary=1};
            Coach hc2 = new Coach() { CoachName = "nembela2", team = t2, TeamID = 2, CoachId = 2, Salary = 1 };
            t2.HeadCoach = hc2;
            t2.Players = new List<Player>();
            t2.Players.Add(p2);
            List<Team> list =new List<Team> { team, t2 };
            mockTeamRepository.Setup(t => t.ReadAll()).Returns(list.AsQueryable);
            List<Player> players = new List<Player>() { player,p2}; 
            List<Coach> coaches = new List<Coach>() {hc,hc2 };
            mockCoachRepository.Setup(c => c.ReadAll()).Returns(coaches.AsQueryable());
            mockPlayerRepository.Setup(p => p.ReadAll()).Returns(players.AsQueryable());
            teamLogic = new TeamLogic(mockTeamRepository.Object);
            coachLogic = new CoachLogic(mockCoachRepository.Object);
            playerLogic = new PlayerLogic(mockPlayerRepository.Object);
        }

        [Test]
        public void StatTester()
        {
            PositionStats stats = new PositionStats() {Position ="Janitor",AvgSalary=1,MaxSalary=1,MinSalary=1 };

            var actual = teamLogic.PositionStats();

            mockTeamRepository.Verify(mock => mock.ReadAll(),Times.Once);
            Assert.That(actual,Has.Exactly(1).Items);
            
            foreach (var item in actual) 
            {
                Assert.That(item.MinSalary,Is.EqualTo(stats.MinSalary));
            }

        }
        [Test]
        public void StarTester()
        {
            var actual = teamLogic.StarPlayers();
            mockTeamRepository.Verify(mock => mock.ReadAll(), Times.Once);
            Assert.That(actual, Has.Exactly(2).Items);
        }
        [Test]
        public void ListPlayerCoachedByTest()
        {
            var actual = teamLogic.ListPlayersCoachedBy("bela2");
            mockTeamRepository.Verify(mock => mock.ReadAll(), Times.Once);
            Assert.That(actual, Has.Exactly(1).Items);
            foreach (var item in actual)
            {
                Assert.That(item.Name,Is.EqualTo("bela"));
            }
        }
        [Test]
        public void PlayerListByPos()
        {
            var actual = teamLogic.PlayerListByPos("belaim","Janitor");
            mockTeamRepository.Verify(mock => mock.ReadAll(), Times.Once);
            Assert.That(actual, Has.Exactly(1).Items);
            foreach (var item in actual)
            {
                Assert.That(item.Name, Is.EqualTo("bela"));
            }
        }
        [Test]
        public void HighestSalTester() 
        {
            var actual = teamLogic.HighestSalary("belaim");
            mockTeamRepository.Verify(mock => mock.ReadAll(), Times.Once);
            //Assert.That(actual, Has.Exactly(1).Items);
            Assert.That(actual.Name, Is.EqualTo("bela"));
        }

        [Test]
        public void PlayerCreateTester() 
        {
            Player newP = new Player() {Name="Me",Position="SG",Salary=15,TeamID=1 };
            playerLogic.Create(newP);
            mockPlayerRepository.Verify(v => v.Create(newP), Times.Once);

            newP = new Player() { Name = "", Position = "SG", Salary = 15, TeamID = 1 };
            Assert.Throws<FormatException>(() =>
            {
                playerLogic.Create(newP);
            });
            mockPlayerRepository.Verify(x => x.Create(newP), Times.Never);


        }
        [Test]
        public void CoachCreateTester()
        {
            Coach newc = new Coach() {CoachName ="Coach",Salary=77,TeamID=3  };
            coachLogic.Create(newc);
            mockCoachRepository.Verify(v => v.Create(newc), Times.Once);
           newc = new Coach() { CoachName = "Coach", Salary = -56, TeamID = 3 };
            Assert.Throws<FormatException>(() =>
            {
                coachLogic.Create(newc);
            });
            mockCoachRepository.Verify(x => x.Create(newc), Times.Never);
        }
        [Test]
        public void TeamCreateTester()
        {
            Team t = new Team() { Name = "Dont", LuxuryTax = 89 };
            teamLogic.Create(t);
            mockTeamRepository.Verify(v=>v.Create(t),Times.Once);
            t = new Team() { Name = "", LuxuryTax = 89 };
            Assert.Throws<FormatException>(() =>
            {
                teamLogic.Create(t);
            });
            mockTeamRepository.Verify(x => x.Create(t), Times.Never);
        }
        [Test]
        public void TeamDeleteTester()
        {
            
            teamLogic.Delete(1);
            mockTeamRepository.Verify(v => v.Delete(1), Times.Once);
        }
        [Test]
        public void PlayerDeleteTester()
        {
            playerLogic.Delete(1);
            mockPlayerRepository.Verify(v => v.Delete(1), Times.Once);
        }


    }
}