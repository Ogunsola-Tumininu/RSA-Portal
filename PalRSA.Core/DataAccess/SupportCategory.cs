
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
    
public partial class SupportCategory
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SupportCategory()
    {

        this.SupportLogs = new HashSet<SupportLog>();

    }


    public int Id { get; set; }

    public string Value { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<SupportLog> SupportLogs { get; set; }

}

}