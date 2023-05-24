using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Logic.Interfaces
{
    public interface ITeamLogic
    {
        void Create(Team item);
        void Delete(int id);
        Team Read(int id);
        IQueryable<Team> ReadAll();
        void Update(Team item);
        public IQueryable StarPlayers();
        public IQueryable<PositionStats> PositionStats();
        public IQueryable<Player> ListPlayersCoachedBy(string name);
        public IQueryable<Player> PlayerListByPos(string team, string Pos);
        public Player HighestSalary(string team);


    }
}
