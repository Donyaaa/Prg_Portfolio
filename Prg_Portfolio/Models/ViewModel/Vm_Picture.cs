using Prg_Portfolio.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_Picture
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public string ProductName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public short CategoryID { get; set; }

        public Enum_ProductType TypePro { get; set; }
    }
}