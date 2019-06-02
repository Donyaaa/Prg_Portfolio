﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_Product
    {
        public long Id { get; set; }
        public string NameProduct { get; set; }
        public Nullable<int> Inventory { get; set; }
        public string Description { get; set; }     
        public Nullable<bool> IsActive { get; set; }
    }
}