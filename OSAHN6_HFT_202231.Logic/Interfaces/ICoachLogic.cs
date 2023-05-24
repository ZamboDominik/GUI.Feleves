using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Logic.Interfaces
{
    public interface ICoachLogic
    {
        void Create(Coach item);
        void Delete(int id);
        Coach Read(int id);
        IQueryable<Coach> ReadAll();
        void Update(Coach item);
    }
}
