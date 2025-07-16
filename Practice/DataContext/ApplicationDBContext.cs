using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.DataContext
{
    internal class ApplicationDBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                            "Server=SHAHZAIBAHMED-L\\SQLEXPRESS;Database=BookOrderingMicroServiceDB;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=true"
                        );

        }
    }
}
