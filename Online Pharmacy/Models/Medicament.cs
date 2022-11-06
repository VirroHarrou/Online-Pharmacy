using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Pharmacy.Models
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserProfile Profile { get; set; }
        public UserCharacteristic Characteristic { get; set; }

    }
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Secondname { get; set; }
        public string Email { get; set; }


        public int UserId { get; set; }
    }

    public class UserCharacteristic
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double Arm { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class UserContext : DbContext //Передаем информацию о создаваемых таблицах Entity Framework
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserCharacteristic> Characteristics { get; set; }

        public UserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Filename=AppHealthTogether.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Characteristic)
                .WithOne(p => p.User);

            modelBuilder.Entity<User>().Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
