using OSAHN6_HFT_202231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Repository
{
    public class CoachRepository:Repository<Coach>
    {
        public CoachRepository(NBADbContext ctx) : base(ctx)
        {
        }

        public override Coach Read(int id)
        {
            return ctx.Coaches.FirstOrDefault(b => b.CoachId == id);
        }

        public override void Update(Coach item)
        {
            var old = Read(item.CoachId);
            foreach (var prop in item.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
