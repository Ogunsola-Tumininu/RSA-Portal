
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
    
public partial class UnProcessed
{

    public int Id { get; set; }

    public string InvalidRsaPin { get; set; }

    public string EmployeeName { get; set; }

    public string ValidRsaPin { get; set; }

    public string EmployerCode { get; set; }

    public Nullable<decimal> EmployeeContribution { get; set; }

    public Nullable<decimal> EmployerContribution { get; set; }

    public Nullable<decimal> AVC { get; set; }

    public string EmployerName { get; set; }

    public Nullable<System.DateTime> ContributionDate { get; set; }

    public Nullable<System.DateTime> ProcessedDate { get; set; }

    public string Analyst { get; set; }

    public string Remarks { get; set; }

}

}