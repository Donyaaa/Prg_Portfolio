using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_Blog
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }     
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}