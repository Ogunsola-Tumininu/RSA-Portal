
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
    
public partial class EnquiryLog
{

    public long Id { get; set; }

    public string Pin { get; set; }

    public string StateCode { get; set; }

    public string SupportType { get; set; }

    public Nullable<int> CategoryId { get; set; }

    public string Message { get; set; }

    public System.DateTime DateCreated { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> DateModified { get; set; }

    public string ModifiedBy { get; set; }

}

}
