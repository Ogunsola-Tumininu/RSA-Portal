
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
    
public partial class RegOther
{

    public int OtherId { get; set; }

    public Nullable<int> UserId { get; set; }

    public string ContributorDate { get; set; }

    public Nullable<bool> IsFingerprintChallenge { get; set; }

    public string ChallengeType { get; set; }

    public string Designation { get; set; }

    public bool Active { get; set; }

    public System.DateTime DatetimeCreated { get; set; }

    public System.DateTime DatetimeUpdated { get; set; }



    public virtual Registration Registration { get; set; }

}

}