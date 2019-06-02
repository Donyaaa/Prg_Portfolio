using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_SellFactorDetail
    {
        public long Id { get; set; }
        public Nullable<long> Products_Id { get; set; }
        public Nullable<long> SellFactor_Id { get; set; }
        public Nullable<int> ProductCount { get; set; }
        public Nullable<int> Creator_Id { get; set; }
    }
}