using Home.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.AppCore.Repository
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Edit(Employee employee);
        void Remove(int EmployeeId);
        IEnumerable<Employee> GetEmployee();
        Employee FindById(int EmployeeId);
    }
}
