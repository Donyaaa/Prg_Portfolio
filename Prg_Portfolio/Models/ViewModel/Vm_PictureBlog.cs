using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_PictureBlog
    {
        public Vm_Blog BlogVMNew { get; set; }
        public Vm_Picture PictureVMNew { get; set; }
        public Vm_User UserName { get; set; }
    }
}