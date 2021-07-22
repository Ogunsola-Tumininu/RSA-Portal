
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
    
public partial class Contribution
{

    public long Id { get; set; }

    public string Recno { get; set; }

    public string Pin { get; set; }

    public Nullable<double> EmployeeContribution { get; set; }

    public Nullable<double> EmployerContribution { get; set; }

    public Nullable<System.DateTime> ContributionDate { get; set; }

    public Nullable<double> OtherContribution { get; set; }

    public Nullable<double> EmployeeFee { get; set; }

    public Nullable<double> EmployerFee { get; set; }

    public Nullable<double> OtherFee { get; set; }

    public Nullable<double> TotalUnits { get; set; }

    public Nullable<double> TotalContribution { get; set; }

    public Nullable<double> TotalFee { get; set; }

    public Nullable<double> EmployeeBf { get; set; }

    public Nullable<double> EmployerBf { get; set; }

    public Nullable<System.DateTime> PaymentDate { get; set; }

    public Nullable<System.DateTime> TransDate { get; set; }

    public Nullable<decimal> SchemeId { get; set; }

    public Nullable<decimal> Price { get; set; }

    public Nullable<decimal> TransUnitsR { get; set; }

    public Nullable<decimal> TransUnitsV { get; set; }

    public Nullable<System.DateTime> ValueDate { get; set; }

    public string TransId { get; set; }

    public Nullable<decimal> VatFee { get; set; }

    public Nullable<byte> Flaguploaded { get; set; }

    public int FundId { get; set; }

    public string ReconciliationTransid { get; set; }

    public Nullable<double> Withdrawal { get; set; }

    public Nullable<double> WithdrawalVc { get; set; }

    public string BATCH_ID { get; set; }

    public string Narration { get; set; }

    public bool Interfund { get; set; }

    public Nullable<decimal> VcContigent { get; set; }

    public Nullable<decimal> VcNonContigent { get; set; }



    public virtual Employee Employee { get; set; }

}

}
