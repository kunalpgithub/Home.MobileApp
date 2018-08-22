using Home.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Home.MobileApp.Repository
{
    internal class EmployeeRepository
    {

        internal ICollection<IWorker> GetAllEmployee() {

            return this.GetAllMaids();

        }

        ICollection<IWorker> GetAllMaids() {
            List<IWorker> maidList = new List<IWorker>
            {
                new HouseMaid() { StartDate = new DateTime(2018, 08, 20), FirstName = "Rashmi", LastName = "Ben", JobType = MaidWork.Cooking },
                new HouseMaid() { StartDate = new DateTime(2018, 08, 20), FirstName = "Rashmi", LastName = "Ben", JobType = MaidWork.Cleaning }
            };
            return maidList;
        }

         void GetAllVendors() {

        }
    }
}
