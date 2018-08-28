using System;
using System.Collections.Generic;
using System.Text;

namespace Home.AppCore
{
    abstract class BaseWorker : IWorker
    {
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public string JobTitle { get ; set ; }
        public DateTime StartDate { get ; set ; }
        public DateTime EndDate { get ; set ; }

        public void DidWork(bool didWork)
        {
            //throw new NotImplementedException();
        }
    }
}
