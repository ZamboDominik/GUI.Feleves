using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace OSAHN6_HFT_202231.Logic
{
    public class PlayerLogic:IPlayerLogic
    {
        IRepository<Player> repo;

        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }



        public void Create(Player item)
        {
            if (item.Name.Length <=0 || item.Name.Length >100) throw new FormatException();
 
            if(item.Salary<=0) throw new FormatException();
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
           // if (!repo.ReadAll().Select(x => x.PlayerId).Contains(id)) throw new FormatException();
            this.repo.Delete(id);
        }

        public Player Read(int id)
        {
            //if (!repo.ReadAll().Select(x => x.PlayerId).Contains(id)) throw new FormatException();
            return this.repo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Player item)
        {
            if (item.Name.Length < 0 || item.Name.Length > 100) throw new FormatException();
            
            if (item.Salary <= 0) throw new FormatException();
            this.repo.Update(item);
        }
    }
}
