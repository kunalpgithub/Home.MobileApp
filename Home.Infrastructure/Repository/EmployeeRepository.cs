using Home.AppCore.Entities;
using Home.AppCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        HomeContext context = new HomeContext();
        public void Add(Employee employee)
        {
            context.Employer.Add(employee);
            context.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Employee FindById(int EmployeeId)
        {
            return context.Employer.FirstOrDefault(x => x.EmployeeId == EmployeeId);
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return context.Employer;
        }

        public void Remove(int EmployeeId)
        {
            Employee emp = context.Employer.Find(EmployeeId);
            context.Employer.Remove(emp);
            context.SaveChanges();

        }
    }
}
