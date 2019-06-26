using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class VM_ShopPage
    {
        public IEnumerable<Vm_PictureProduct> PictureProductVMNew { get; set; }
        public IEnumerable<Vm_Picture> PictureVM { get; set; }

    }
}