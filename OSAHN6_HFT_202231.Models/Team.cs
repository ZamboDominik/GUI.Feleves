using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSAHN6_HFT_202231.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int LuxuryTax { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Coach HeadCoach { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
    }
}
