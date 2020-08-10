using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Models
{
    public partial class JobDataContext : DbContext
    {
        public JobDataContext()
        {
        }

        public JobDataContext(DbContextOptions<JobDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Job> Job { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationInfo).IsUnicode(false);

                entity.Property(e => e.CandidateProfile).IsUnicode(false);

                entity.Property(e => e.CompanyInfo).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobTask).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.ProfileData).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
