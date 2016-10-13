﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LegalTestEntities : DbContext
    {
        public LegalTestEntities()
            : base("name=LegalTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int AddUpdateSubscriber(Nullable<long> subscriberID, Nullable<long> licenseID, Nullable<int> type, string name, string email, string userName, string password, string photoURL, string contactNumber1, string contactNumber2, Nullable<int> districtID, Nullable<int> stateID, string address, Nullable<bool> isDeleted, Nullable<bool> isActive)
        {
            var subscriberIDParameter = subscriberID.HasValue ?
                new ObjectParameter("SubscriberID", subscriberID) :
                new ObjectParameter("SubscriberID", typeof(long));
    
            var licenseIDParameter = licenseID.HasValue ?
                new ObjectParameter("LicenseID", licenseID) :
                new ObjectParameter("LicenseID", typeof(long));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var photoURLParameter = photoURL != null ?
                new ObjectParameter("PhotoURL", photoURL) :
                new ObjectParameter("PhotoURL", typeof(string));
    
            var contactNumber1Parameter = contactNumber1 != null ?
                new ObjectParameter("ContactNumber1", contactNumber1) :
                new ObjectParameter("ContactNumber1", typeof(string));
    
            var contactNumber2Parameter = contactNumber2 != null ?
                new ObjectParameter("ContactNumber2", contactNumber2) :
                new ObjectParameter("ContactNumber2", typeof(string));
    
            var districtIDParameter = districtID.HasValue ?
                new ObjectParameter("DistrictID", districtID) :
                new ObjectParameter("DistrictID", typeof(int));
    
            var stateIDParameter = stateID.HasValue ?
                new ObjectParameter("StateID", stateID) :
                new ObjectParameter("StateID", typeof(int));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("IsDeleted", isDeleted) :
                new ObjectParameter("IsDeleted", typeof(bool));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUpdateSubscriber", subscriberIDParameter, licenseIDParameter, typeParameter, nameParameter, emailParameter, userNameParameter, passwordParameter, photoURLParameter, contactNumber1Parameter, contactNumber2Parameter, districtIDParameter, stateIDParameter, addressParameter, isDeletedParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<GetSubscriberByEmailID_Result> GetSubscriberByEmailID(string emailID)
        {
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSubscriberByEmailID_Result>("GetSubscriberByEmailID", emailIDParameter);
        }
    
        public virtual ObjectResult<GetAllLawyersBySubscriberID_Result> GetAllLawyersBySubscriberID(Nullable<long> subscriberID)
        {
            var subscriberIDParameter = subscriberID.HasValue ?
                new ObjectParameter("SubscriberID", subscriberID) :
                new ObjectParameter("SubscriberID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllLawyersBySubscriberID_Result>("GetAllLawyersBySubscriberID", subscriberIDParameter);
        }
    }
}
