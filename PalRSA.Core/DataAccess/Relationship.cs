
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
    
public partial class Relationship
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Relationship()
    {

        this.CFINextOfKins = new HashSet<CFINextOfKin>();

    }


    public int RelationshipId { get; set; }

    public string Name { get; set; }

    public Nullable<bool> Active { get; set; }

    public Nullable<System.DateTime> DatetimeCreated { get; set; }

    public Nullable<System.DateTime> DatetimeUpdated { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CFINextOfKin> CFINextOfKins { get; set; }

}

}
