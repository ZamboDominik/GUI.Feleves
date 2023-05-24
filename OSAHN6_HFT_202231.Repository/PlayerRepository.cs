using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Repository
{
    public class PlayerRepository:Repository<Player>
    {
        public PlayerRepository(NBADbContext ctx) : base(ctx)
        {
        }

        public override Player Read(int id)
        {
            return ctx.Players.FirstOrDefault(b => b.PlayerId == id);
        }

        public override void Update(Player item)
        {
            var old = Read(item.PlayerId);
            foreach (var prop in item.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
