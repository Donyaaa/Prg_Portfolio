using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_Link
    {
        public long Id { get; set; }
        public Nullable<byte> linkType_Id { get; set; }
        public Nullable<long> User_Id { get; set; }
        public string LinkPath { get; set; }
    }
}