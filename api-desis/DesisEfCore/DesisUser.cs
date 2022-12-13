using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_desis.DesisEfCore
{
    [Table("desisUser")]
    public class DesisUser
    {
        [Key,Required]
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string university { get; set; } = string.Empty;
        public int studentNumber { get; set; }
        public string password { get; set; } = string.Empty;

        public virtual List<DesisComment>? DesisComments { get; set; }
        public virtual List<DesisRating>? DesisRatings { get; set; }

    }
}

