using System;
using Microsoft.EntityFrameworkCore;

namespace api_desis.DesisEfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) {}

        public DbSet<DesisUser> desisUsers { get; set; }

        public DbSet<DesisEntry> desisEntries { get; set; }

        public DbSet<DesisRating> desisRatings { get; set; }

        public DbSet<DesisComment> desisComments { get; set; }
    }
}

