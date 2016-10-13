using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegalApp.Entity
{
    public class EntityLawyer
    {
        public long LawyerID { get; set; }
        public long SubscriberID { get; set; }
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AlternateEmail { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public string Sex { get; set; }
        public string PracticingSince { get; set; }
        public string PracticingAreas { get; set; }
        public string Courts { get; set; }
        public string About { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string State { get; set; }
        public string District { get; set; }
    }
}