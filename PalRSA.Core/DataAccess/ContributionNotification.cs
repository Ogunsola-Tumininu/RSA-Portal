
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
    
public partial class ContributionNotification
{

    public long Id { get; set; }

    public string PaymentRef { get; set; }

    public string RsaNumber { get; set; }

    public string Name { get; set; }

    public string MobileNumber { get; set; }

    public Nullable<decimal> Amount { get; set; }

    public Nullable<System.DateTime> TransactionDate { get; set; }

    public string PFAValidationID { get; set; }

    public string PaymentSource { get; set; }

    public string PaymentDescription { get; set; }

    public System.DateTime DateCreated { get; set; }

    public Nullable<System.DateTime> DateUpdated { get; set; }

    public Nullable<bool> Processed { get; set; }

    public Nullable<System.DateTime> DateProcessed { get; set; }

}

}