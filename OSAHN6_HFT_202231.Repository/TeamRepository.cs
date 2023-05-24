using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Repository
{
    public  class TeamRepository:Repository<Team>
    {
        public TeamRepository(NBADbContext ctx) : base(ctx)
        {
        }

        public override Team Read(int id)
        {
            return ctx.Teams.FirstOrDefault(b => b.Id == id);
        }

        public override void Update(Team item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
