
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
    
public partial class BirthDayLog
{

    public long Id { get; set; }

    public string Firstname { get; set; }

    public string Surname { get; set; }

    public string Pin { get; set; }

    public Nullable<System.DateTime> DateOfBirth { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public System.DateTime DateProcessed { get; set; }

    public Nullable<bool> SmsSent { get; set; }

    public Nullable<bool> EmailSent { get; set; }

    public Nullable<System.DateTime> DateSend { get; set; }

    public Nullable<System.DateTime> DateEmailSent { get; set; }

    public string Error { get; set; }

    public string EmailError { get; set; }

    public string MessageId { get; set; }

}

}
