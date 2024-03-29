
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
    
public partial class CFINextOfKin
{

    public int NextOfKinId { get; set; }

    public int UserId { get; set; }

    public Nullable<int> KinGenderId { get; set; }

    public Nullable<int> KinTitleId { get; set; }

    public string Surname { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public Nullable<int> RelationshipId { get; set; }

    public Nullable<bool> SentToPencom { get; set; }

    public Nullable<bool> IsNigerian { get; set; }

    public string HouseNo { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public Nullable<int> LGAId { get; set; }

    public Nullable<int> StateId { get; set; }

    public Nullable<int> CountryId { get; set; }

    public string ZIP { get; set; }

    public string POBox { get; set; }

    public string Email { get; set; }

    public string PhoneNo { get; set; }

    public string MobileNo { get; set; }

    public bool Active { get; set; }

    public string DataSrc { get; set; }

    public string Createdby { get; set; }

    public string Modifiedby { get; set; }

    public System.DateTime DatetimeCreated { get; set; }

    public System.DateTime DatetimeUpdated { get; set; }



    public virtual Sex Sex { get; set; }

    public virtual CFIRegisterUser CFIRegisterUser { get; set; }

    public virtual Country Country { get; set; }

    public virtual Relationship Relationship { get; set; }

    public virtual Title Title { get; set; }

}

}
