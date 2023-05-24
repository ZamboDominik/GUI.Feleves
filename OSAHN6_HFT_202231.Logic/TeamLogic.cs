using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Logic
{
    public class TeamLogic:ITeamLogic
    {
        IRepository<Team> repo;

        public TeamLogic(IRepository<Team> repo)
        {
            this.repo = repo;
        }



        public void Create(Team item)
        {
            if (item.Name.Length > 150 || item.Name.Length <= 0) throw new FormatException();
            if(item.LuxuryTax < 0) throw new FormatException();
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            if(repo.ReadAll().Select(x=> x.Id).Contains(id)) this.repo.Delete(id);
            else throw new Exception("Not Found");

        }

        public Team Read(int id)
        {
           
            if (repo.ReadAll().Select(x => x.Id).Contains(id)) return this.repo.Read(id); 
            else throw new Exception("Not Found");
        }

        public IQueryable<Team> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Team item)
        {
            if(item.Name.Length <= 0 || item.Name.Length > 100) throw new FormatException();
            if(item.LuxuryTax <0 ) throw new FormatException();
            //if (repo.ReadAll().Select(x => x.Id).Contains(item.Id)) throw new FormatException();
            this.repo.Update(item);
        }
        public Player HighestSalary(string team) 
        {
            var highest = from t in repo.ReadAll()
                          where t.Name == team
                          from p in t.Players
                          orderby p.Salary descending
                          select p;           
            return highest.First();
        }
        public IQueryable<Player> PlayerListByPos(string team, string Pos) 
        {
            var list = from t in repo.ReadAll()
                       where t.Name == team
                       from p in t.Players
                       where p.Position == Pos
                       select p;
            return list;
        }
        public IQueryable<Player> ListPlayersCoachedBy(string name) 
        {
            var players = from t in repo.ReadAll()
                          where t.HeadCoach.CoachName == name
                          from p in t.Players
                          select p;
            return players;
        }
        public IQueryable<PositionStats> PositionStats() 
        {
            var positions = from t in repo.ReadAll()
                            from p in t.Players
                            group p.Salary by p.Position into g
                            select new PositionStats{Position=g.Key, AvgSalary = g.Average(), MaxSalary = g.Max(),MinSalary = g.Min()}
                            ;
            return positions;                 
        }
        public IQueryable StarPlayers()
        {
            var team = from t in repo.ReadAll()
                       from p in t.Players
                       where p.Salary == t.Players.Select(p => p.Salary).Max()
                       select p;
            return team;
        }


    }
}
