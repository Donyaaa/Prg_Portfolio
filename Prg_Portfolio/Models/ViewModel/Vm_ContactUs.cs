using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_ContactUs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Massage { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}