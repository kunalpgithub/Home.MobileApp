using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Infrastructure
{
    public class HomeContext: DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options):base(options) {
        }

        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee:AuditInfo {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }

    public class AuditInfo {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
