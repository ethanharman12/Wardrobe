using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Infrastructure.Entities;

namespace Wardrobe.Infrastructure
{
    public class WardrobeContext : DbContext
    {
        public WardrobeContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<AspNetUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<WearEvent> WearEvents { get; set; }
        public DbSet<WashEvent> WashEvents { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<WardrobeContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<AspNetUser>().ToTable("AspNetUsers");
        }
    }
}
