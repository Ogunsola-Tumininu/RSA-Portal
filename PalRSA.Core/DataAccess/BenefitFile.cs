
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
    
public partial class BenefitFile
{

    public long FileId { get; set; }

    public string FileName { get; set; }

    public string FilePath { get; set; }

    public string PIN { get; set; }

    public Nullable<long> BenefitProcessId { get; set; }

    public System.DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public Nullable<System.DateTime> ModifiedOn { get; set; }

    public string ModifiedBy { get; set; }

}

}
