using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Models
{
    public class PositionStats
    {
        public string Position { get; set; }
        public double AvgSalary { get; set; }
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }

        public override string ToString()
        {
            return $"Pos: {Position} Average Salary:{AvgSalary} Minimum Salary:{MinSalary} Maximum Salary:{MaxSalary}";
        }

    }
}
