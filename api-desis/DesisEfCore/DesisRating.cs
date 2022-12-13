using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_desis.DesisEfCore
{
    [Table("desisRating")]
    public class DesisRating
    {
        [Key,Required]
        public int rateId { get; set; }
        public int rating { get; set; }

        public virtual DesisEntry? DesisEntry { get; set; }

        public virtual DesisUser? DesisUser { get; set; }

    }
}
