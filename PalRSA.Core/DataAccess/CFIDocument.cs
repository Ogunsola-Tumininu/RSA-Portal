
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
    
public partial class CFIDocument
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CFIDocument()
    {

        this.CFISupportDocuments = new HashSet<CFISupportDocument>();

    }


    public int DocumentId { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }

    public System.DateTime DatetimeCreated { get; set; }

    public Nullable<System.DateTime> DatetimeUpdated { get; set; }

    public Nullable<int> SectorId { get; set; }

    public string SectorCode { get; set; }

    public Nullable<int> PrivatePublicDocId { get; set; }

    public Nullable<int> PrivatePublicDocId2 { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CFISupportDocument> CFISupportDocuments { get; set; }

}

}