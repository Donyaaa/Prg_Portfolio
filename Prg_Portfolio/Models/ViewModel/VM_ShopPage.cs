using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class VM_ShopPage
    {
        public IEnumerable<Vm_PictureProduct> PictureProductVMNew { get; set; }
        public IEnumerable<Vm_Product> ProductVM { get; set; }
        public IEnumerable<Vm_PictureProduct> PortofioProductVM { get; set; }
        public IEnumerable<Vm_Price> PriceVM { get; set; }
        public IEnumerable<Vm_PictureProduct> PortofioProductVM2 { get; set; }
        public IEnumerable<Vm_X> Vm_MainProduct { get; set; }
    }
}