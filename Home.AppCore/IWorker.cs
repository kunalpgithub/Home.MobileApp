using System;
using System.Collections.Generic;
using System.Text;

namespace Home.AppCore
{
    public interface IWorker
    {
         string FirstName { get; set; }
         string LastName { get; set; }
         string JobTitle { get; set; }
         DateTime StartDate { get; set; }
         DateTime EndDate { get; set; }
         void DidWork(bool didWork);
    }
}
