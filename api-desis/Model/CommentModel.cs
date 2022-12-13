using System;
using api_desis.DesisEfCore;

namespace api_desis.Model
{
    public class CommentModel
    {
        public int commentId { get; set; }
        public string comment { get; set; } = string.Empty;
        public DateTime dateTime { get; set; }
        public int DesisEntryId { get; set; }
        public int DesisUserId { get; set; }

        public CommentModel()
        {
        }
    }
}

