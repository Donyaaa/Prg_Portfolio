using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prg_Portfolio.Models.ViewModel
{
    public class Vm_User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> CompleteInformation { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}