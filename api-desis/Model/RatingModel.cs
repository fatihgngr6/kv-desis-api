using System;
using api_desis.DesisEfCore;

namespace api_desis.Model
{
    public class RatingModel
    {
        public int rateId { get; set; }
        public int rating { get; set; }

        public virtual DesisEntry? DesisEntry { get; set; }

        public virtual DesisUser? DesisUser { get; set; }

        public RatingModel()
        {
        }
    }
}

