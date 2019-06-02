using Prg_Portfolio.Models.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_PictureUser
    {
        public Vm_Picture PictureVMNew { get; set; }
        public Vm_User UserVMNew { get; set; }
        public Vm_UserType UserTypVMNew{ get; set; }
       public IEnumerable<Vm_Link> ListLink { get; set; }
    }
}