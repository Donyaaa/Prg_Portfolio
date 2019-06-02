using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_CommentProduct
    {
        public long Id { get; set; }
        public Nullable<long> Products_Id { get; set; }
        public Nullable<byte> ReasonRating_Id { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public Nullable<long> RepllayTo { get; set; }
        public Nullable<byte> Point_Of100 { get; set; }
        public Nullable<long> User_Id { get; set; }

 
    }
}