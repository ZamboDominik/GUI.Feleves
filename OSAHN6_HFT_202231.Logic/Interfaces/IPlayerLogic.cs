using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Logic.Interfaces
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        void Delete(int id);
        Player Read(int id);
        IQueryable<Player> ReadAll();
        void Update(Player item);
    }
}
