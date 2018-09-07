using Home.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Infrastructure
{
    public class HomeContext: DbContext
    {
        public HomeContext() {
        }
        public HomeContext(DbContextOptions<HomeContext> options):base(options) {
        }

        public DbSet<Employee> Employer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //seed data here.
            modelBuilder.Entity<Employee>().HasData(
                new { EmployeeId = 1, FirstName = "Kishan", LastName = "Kumar", StartDate = DateTime.Now.AddMonths(-1), JobTitle = "Driver", EmployeeRateId = 1 },
                new { EmployeeId = 2, FirstName = "Manish", LastName = "Pandey", StartDate = DateTime.Now.AddMonths(-4), JobTitle = "Peon", EmployeeRateId = 1 }
                );

        }
    }

}
