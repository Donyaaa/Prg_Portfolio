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
    
    public partial class Tbl_CommentBlog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_CommentBlog()
        {
            this.Tbl_CommentBlog1 = new HashSet<Tbl_CommentBlog>();
        }
    
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
    
        public virtual Tbl_Blog Tbl_Blog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CommentBlog> Tbl_CommentBlog1 { get; set; }
        public virtual Tbl_CommentBlog Tbl_CommentBlog2 { get; set; }
        public virtual Tbl_User Tbl_User { get; set; }
    }
}
