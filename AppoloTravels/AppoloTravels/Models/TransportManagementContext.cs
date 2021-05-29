using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppoloTravels.Models
{
    public class TransportManagementContext:DbContext
    {
        public TransportManagementContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Route> Routes { get; set; }
       
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<Login> Logins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasData(new Login() { UserName = "Admin", PassWord = "1234" });
        }

    }
}
