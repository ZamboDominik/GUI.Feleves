using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSAHN6_HFT_202231.Models
{
    public class Coach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Team")]
        public int TeamID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Team team { get; set; }
    }
}
