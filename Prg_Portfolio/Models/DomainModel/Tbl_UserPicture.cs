//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prg_Portfolio.Models.DomainModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_UserPicture
    {
        public long Id { get; set; }
        public Nullable<long> User_Id { get; set; }
        public Nullable<long> Picture_Id { get; set; }
        public Nullable<System.DateTime> CreationDateTime { get; set; }
        public Nullable<int> Creator_Id { get; set; }
        public Nullable<System.DateTime> DeactivationDateTime { get; set; }
        public Nullable<int> Deactivetor_Id { get; set; }
        public Nullable<System.DateTime> ModificationDateTime { get; set; }
        public Nullable<int> Modificator_Id { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Tbl_Picture Tbl_Picture { get; set; }
        public virtual Tbl_User Tbl_User { get; set; }
    }
}
