using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_desis.DesisEfCore
{
    [Table("desisComment")]
    public class DesisComment
    {
        [Key,Required]
        public int commentId { get; set; }
        public string comment { get; set; } = string.Empty;
        public DateTime dateTime { get; set; }
        public virtual DesisEntry? DesisEntry { get; set; }
        public virtual DesisUser? DesisUser { get; set; }
        

    }
}

