
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
    
public partial class ChangeOfAddressProfile
{

    public int Id { get; set; }

    public string Pin { get; set; }

    public string OldAddress { get; set; }

    public string NewAddress { get; set; }

    public string Status { get; set; }

    public Nullable<System.DateTime> DateUploaded { get; set; }

    public string DocumentId { get; set; }

    public string Doc { get; set; }

    public string Ext { get; set; }

    public string Reason { get; set; }



    public virtual Employee Employee { get; set; }

}

}