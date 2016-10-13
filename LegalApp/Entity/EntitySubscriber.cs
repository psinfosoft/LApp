using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegalApp.Entity
{
    public class EntitySubscriber
    {
        public long SubscriberID { get; set; }
        public long LicenseID { get; set; }
        public Nullable<int> Type { get; set; }
       
        public string Name { get; set; }
        [Required()]     
        [MaxLength(320)]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required()]
        [MaxLength(1000)]
        public string Password { get; set; }
        public string PhotoURL { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
