using System;
using System.Collections.Generic;
using System.Text;

namespace Home.MobileApp.Models
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
