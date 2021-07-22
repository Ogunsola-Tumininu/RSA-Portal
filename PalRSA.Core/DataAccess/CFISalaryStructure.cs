
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
    
public partial class CFISalaryStructure
{

    public int SalaryId { get; set; }

    public int UserId { get; set; }

    public Nullable<int> HarmonisedSalary { get; set; }

    public Nullable<int> ConsolidatedSalary2007 { get; set; }

    public Nullable<int> ConsolidatedSalary2010 { get; set; }

    public Nullable<int> GL2004 { get; set; }

    public Nullable<int> Step2004 { get; set; }

    public Nullable<int> GL2007 { get; set; }

    public Nullable<int> Step2007 { get; set; }

    public Nullable<int> GL2010 { get; set; }

    public Nullable<int> Step2010 { get; set; }

    public Nullable<int> CurrentSalary { get; set; }

    public Nullable<int> CurrentGL { get; set; }

    public Nullable<int> CurrentStep { get; set; }

    public Nullable<bool> SentToPencom { get; set; }

    public bool Active { get; set; }

    public System.DateTime DatetimeCreated { get; set; }

    public System.DateTime DatetimeUpdated { get; set; }



    public virtual CFIRegisterUser CFIRegisterUser { get; set; }

}

}
