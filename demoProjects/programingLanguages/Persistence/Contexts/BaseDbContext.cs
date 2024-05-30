using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> programmingLanguageTechnologies {  get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SocialMediaAccount> socialMediaAccounts { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Version).HasColumnName("Version");
                a.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
                a.HasMany(p => p.ProgrammingLanguageTechnologies);
            });

            modelBuilder.Entity<ProgrammingLanguageTechnology>(a =>
            {
                a.ToTable("ProgrammingLanguageTechnologies");
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Description).HasColumnName("Description");
                a.HasOne(a => a.ProgrammingLanguage);
            });
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#", "7.0", DateTime.Now), new(2, "Ruby", "4.0", DateTime.Now) };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            ProgrammingLanguageTechnology[] programmingLanguageTechnologies = { new(1, 1, "MVC", "Örnek sürüm") ,new(2,1,"Core","Örnek sürüm")};
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologies);

        }
    }
}
