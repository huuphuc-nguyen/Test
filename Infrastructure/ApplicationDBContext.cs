using PictureSocialMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using DotNetEnv;

namespace PictureSocialMedia.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Test> Tests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.Load();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .LogTo(Console.WriteLine)
                    .UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING"), x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test");
                entity.HasKey(e => e.ID);
            });
        }
    }
}
