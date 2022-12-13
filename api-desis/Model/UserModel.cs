using System;
using api_desis.DesisEfCore;

namespace api_desis.Model
{
    public class UserModel
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string university { get; set; } = string.Empty;
        public int studentNumber { get; set; }
        public string password { get; set; } = string.Empty;

        public List<CommentModel>? DesisComments { get; set; }
        public virtual List<DesisRating>? DesisRatings { get; set; }

        public UserModel()
        {

        }

    }
}

