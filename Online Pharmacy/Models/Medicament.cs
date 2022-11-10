using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;

namespace Online_Pharmacy.Models
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
    }

    public class Reciept
    {
        public int Id { get; set; }
        public List<Medicament> MedicamentList { get; set; }
        public float Sum { get; set; } = 0;
        public DateTime Date { get; set; }
    }

    public class ApplicationContext : DbContext //Передаем информацию о создаваемых таблицах Entity Framework
    {
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Reciept> Reciepts { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Filename=OnlinePharmacy.db");
    }
}
