
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
public partial class Case
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Case()
    {

        this.CaseAttachments = new HashSet<CaseAttachment>();

    }


    public int CaseId { get; set; }

    public string PIN { get; set; }

    public string State { get; set; }

    public Nullable<int> StateId { get; set; }

    public string Location { get; set; }

    public Nullable<bool> DropCall { get; set; }

    public string IssueCategory { get; set; }

    public Nullable<int> IssueCategoryId { get; set; }

    public string IssueType { get; set; }

    public Nullable<int> IssueTypeId { get; set; }

    public string IssueTitle { get; set; }

    public string Origin { get; set; }

    public Nullable<int> OriginId { get; set; }

    public Nullable<System.DateTime> CreatedOn { get; set; }

    public Nullable<System.DateTime> Walking { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> WalkOut { get; set; }

    public string Description { get; set; }

    public string ResponsibleDept { get; set; }

    public string Owner { get; set; }

    public string FollowUpBy { get; set; }

    public string Status { get; set; }

    public string CRMId { get; set; }

    public Nullable<System.DateTime> LastUpdated { get; set; }

    public string LastModifiedBy { get; set; }

    public string InTime { get; set; }

    public string Outtime { get; set; }



    public virtual Employee Employee { get; set; }

    public virtual IssueCategory IssueCategory1 { get; set; }

    public virtual IssueOrigin IssueOrigin { get; set; }

    public virtual IssueType IssueType1 { get; set; }

    public virtual State State1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CaseAttachment> CaseAttachments { get; set; }

}

}
