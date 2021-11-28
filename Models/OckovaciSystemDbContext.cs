using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SystemOckovania.Models;

#nullable disable

namespace SystemOckovanie.Models
{
    public partial class OckovaciSystemDbContext : DbContext
    {
        public OckovaciSystemDbContext()
        {
        }

        public OckovaciSystemDbContext(DbContextOptions<OckovaciSystemDbContext> options)
            : base(options)
        {      
        }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Paramedic> Paramedic { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Vaccinated> Vaccinated { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Paramedic>().ToTable("Paramedic");
            modelBuilder.Entity<Hospital>().ToTable("Hospital");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Vaccinated>().ToTable("Vaccinated");

            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            object p = modelBuilder.Entity<Person>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.Surname).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Person>().Property(p => p.PhoneNumber).HasMaxLength(12);
            modelBuilder.Entity<Person>().Property(p => p.Mail).HasMaxLength(50);

            modelBuilder.Entity<Paramedic>().HasKey(p => p.Id);
            modelBuilder.Entity<Paramedic>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Paramedic>().Property(p => p.HospitalId).IsRequired();
            modelBuilder.Entity<Paramedic>().Property(p => p.Role).IsRequired();

            modelBuilder.Entity<Hospital>().HasKey(p => p.Id);
            modelBuilder.Entity<Hospital>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Hospital>().Property(p => p.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Hospital>().Property(p => p.PostCode).IsRequired();
            modelBuilder.Entity<Hospital>().Property(p => p.Director).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Hospital>().Property(p => p.Contact).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Hospital>().Property(p => p.DailyVaccinatedCapacity).IsRequired();
            modelBuilder.Entity<Hospital>().Property(p => p.BreathSupportCapacity).IsRequired();

            modelBuilder.Entity<Account>().HasKey(p => p.Id);
            modelBuilder.Entity<Account>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.Mail).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Account>().Property(p => p.Password).IsRequired().HasMaxLength(255);

            modelBuilder.Entity<Vaccinated>().HasKey(p => p.Id);
            modelBuilder.Entity<Vaccinated>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Vaccinated>().Property(p => p.HospitalId).IsRequired();
            modelBuilder.Entity<Vaccinated>().Property(p => p.VaccineNumber).IsRequired();
            modelBuilder.Entity<Vaccinated>().Property(p => p.VaccineName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Vaccinated>().Property(p => p.Date).IsRequired();

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
