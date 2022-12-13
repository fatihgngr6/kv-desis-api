using System;
using api_desis.DesisEfCore;

namespace api_desis.Model
{
    public class EntryModel
    {
        public int id { get; set; }
        public int category { get; set; }
        public string name { get; set; } = string.Empty;
        public List<CommentModel>? DesisComments { get; set; }
        public int DesisRatings { get; set; }

        public EntryModel()
        {
        }
    }
}

