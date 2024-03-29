﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PalRSA.Core.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PALSiteDBEntities : DbContext
    {
        public PALSiteDBEntities()
            : base("name=PALSiteDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BenefitClass> BenefitClasses { get; set; }
        public virtual DbSet<BenefitDocument> BenefitDocuments { get; set; }
        public virtual DbSet<CaseSummary> CaseSummaries { get; set; }
        public virtual DbSet<ClientUpdate> ClientUpdates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployerDetail> EmployerDetails { get; set; }
        public virtual DbSet<ExitProcessMaster> ExitProcessMasters { get; set; }
        public virtual DbSet<LoginTrail> LoginTrails { get; set; }
        public virtual DbSet<NextOfKin> NextOfKins { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<BenefitSubClass> BenefitSubClasses { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<BenefitApplication> BenefitApplications { get; set; }
        public virtual DbSet<EmployeeBenefitDocument> EmployeeBenefitDocuments { get; set; }
        public virtual DbSet<UploadType> UploadTypes { get; set; }
        public virtual DbSet<UserPublication> UserPublications { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<AccountManager> AccountManagers { get; set; }
        public virtual DbSet<PriceHistory> PriceHistories { get; set; }
        public virtual DbSet<Sheme> Shemes { get; set; }
        public virtual DbSet<AssetAllocation> AssetAllocations { get; set; }
        public virtual DbSet<AssetType> AssetTypes { get; set; }
        public virtual DbSet<TempCustomerInformation> TempCustomerInformations { get; set; }
        public virtual DbSet<ChangeOfNameProfile> ChangeOfNameProfiles { get; set; }
        public virtual DbSet<ChangeOfAddressProfile> ChangeOfAddressProfiles { get; set; }
        public virtual DbSet<SupportCategory> SupportCategories { get; set; }
        public virtual DbSet<SupportLog> SupportLogs { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<SecretQuestionsStore> SecretQuestionsStores { get; set; }
        public virtual DbSet<Contribution> Contributions { get; set; }
        public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
