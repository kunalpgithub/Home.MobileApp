using System;
using System.Collections.Generic;
using System.Text;

namespace Home.AppCore
{
    class HouseMaid:BaseWorker
    {
        public MaidWork JobType { get; set; }
    }

    public enum MaidWork {
        Cleaning,
        Cooking
    }
}
