using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_CommentBlog
    {
        public long Id { get; set; }
        public Nullable<long> Blog_Id { get; set; }
        public Nullable<long> User_Id { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public Nullable<long> RepllayTo { get; set; }
        public Nullable<System.DateTime> CreationDateTime { get; set; }
        public Nullable<int> Creator_Id { get; set; }
        public Nullable<System.DateTime> DeactivationDateTime { get; set; }
        public Nullable<int> Deactivetor_Id { get; set; }
        public Nullable<System.DateTime> ModificationDateTime { get; set; }
        public Nullable<int> Modificator_Id { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}