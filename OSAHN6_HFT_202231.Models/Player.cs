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
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public int TeamID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Team team { get; set; }
        public override string ToString()
        {
            return $"ID: {PlayerId} Name:{Name} Position:{Position}";
        }
    }
}
