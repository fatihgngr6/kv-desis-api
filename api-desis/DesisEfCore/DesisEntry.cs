using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_desis.DesisEfCore
{
    [Table("desisEntry")]
    public class DesisEntry
    {
        [Key,Required]
        public int id { get; set; }
        public int category { get; set; }
        public string name { get; set; } = string.Empty;
        public virtual List<DesisComment>? DesisComments { get; set; }
        public virtual List<DesisRating>? DesisRatings { get; set; }
    }
}

