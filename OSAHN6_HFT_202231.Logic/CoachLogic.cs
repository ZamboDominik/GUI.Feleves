using OSAHN6_HFT_202231.Logic.Interfaces;
using OSAHN6_HFT_202231.Models;
using OSAHN6_HFT_202231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Logic
{
    public class CoachLogic:ICoachLogic
    {
        IRepository<Coach> repo;

        public CoachLogic(IRepository<Coach> repo)
        {
            this.repo = repo;
        }



        public void Create(Coach item)
        {
            if (item.CoachName.Length < 0 || item.CoachName.Length > 100) throw new FormatException();
            
            if (item.Salary<=0) throw new FormatException();
                this.repo.Create(item);
        }

        public void Delete(int id)
        {
            if (!repo.ReadAll().Select(x => x.CoachId).Contains(id)) throw new FormatException();
            this.repo.Delete(id);
        }

        public Coach Read(int id)
        {
          
            return this.repo.Read(id);
        }

        public IQueryable<Coach> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Coach item)
        {
            this.repo.Update(item);
        }
    }
}
