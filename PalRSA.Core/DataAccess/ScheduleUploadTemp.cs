
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
    
public partial class ScheduleUploadTemp
{

    public long Id { get; set; }

    public string EmployerCode { get; set; }

    public Nullable<System.DateTime> Period { get; set; }

    public string Pin { get; set; }

    public string Surname { get; set; }

    public string FirstName { get; set; }

    public string OtherName { get; set; }

    public Nullable<decimal> EmployeeContribution { get; set; }

    public Nullable<decimal> EmployerContribution { get; set; }

    public Nullable<decimal> VoluntaryContribution { get; set; }

    public Nullable<decimal> TotalContribution { get; set; }

    public string FileName { get; set; }

    public Nullable<bool> PinValid { get; set; }

    public string PaymentType { get; set; }

    public Nullable<System.DateTime> CreatedOn { get; set; }

    public string CreatedBy { get; set; }

}

}
