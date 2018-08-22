using Home.MobileApp.Models;
using Home.MobileApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.MobileApp.ViewModels
{
    public class AttandanceVM
    {
        private EmployeeRepository _empRepo;
        public ICollection<IWorker> EmployeeList { get; set; }

        public void DidWork(IWorker emp) {
            emp.DidWork(true);
        }

        public void DidNotWork(IWorker emp) {
            emp.DidWork(false);
        }

        public void LoadAllWorkingEmployee()
        {
            _empRepo = new EmployeeRepository();
            EmployeeList = _empRepo.GetAllEmployee();
        }
    }
}
