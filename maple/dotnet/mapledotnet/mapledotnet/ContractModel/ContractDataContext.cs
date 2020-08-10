using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace mapledotnet.ContractModel
{
    public partial class ContractDataContext : DbContext
    {
        public ContractDataContext()
        {
        }

        public ContractDataContext(DbContextOptions<ContractDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<CoveragePlan> CoveragePlan { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<RatePlan> RatePlan { get; set; }

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
            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PK__Contract__C90D34696F785EEF");

                entity.Property(e => e.CoveragePlan).IsUnicode(false);

                entity.Property(e => e.CustomerAddress).IsUnicode(false);

                entity.Property(e => e.CustomerCountry).IsUnicode(false);

                entity.Property(e => e.CustomerGender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerName).IsUnicode(false);
            });

            modelBuilder.Entity<CoveragePlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__Coverage__755C22B78F1AB7A2");

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PlanName).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Empname).IsUnicode(false);
            });

            modelBuilder.Entity<RatePlan>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Plan)
                    .WithMany()
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__RatePlan__PlanId__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
