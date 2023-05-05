using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace won5lab18reztema.Models
{
    internal class CarsDbContext : DbContext
    {
        public DbSet<Autovehicul> Autovehicule { get; set; }
        public DbSet<Cheie> Chei { get; set; }
        public DbSet<CarteTehnica> CartiTehnice { get; set; }
        public DbSet<Producator> Producatori { get; set; }

        public CarsDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\v\source\repos\won5lab18reztema\won5lab18reztema\Cars.mdf;Integrated Security=True");
        }

    }
}
