
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
    
public partial class State
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public State()
    {

        this.BenefitProcesses = new HashSet<BenefitProcess>();

        this.Agents = new HashSet<Agent>();

        this.Cases = new HashSet<Case>();

        this.HRCases = new HashSet<HRCase>();

    }


    public int StateId { get; set; }

    public string Name { get; set; }

    public bool Active { get; set; }

    public System.DateTime DatetimeCreated { get; set; }

    public Nullable<System.DateTime> DatetimeUpdated { get; set; }

    public Nullable<int> RegionId { get; set; }

    public Nullable<int> CountryId { get; set; }

    public string StateCode { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<BenefitProcess> BenefitProcesses { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Agent> Agents { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Case> Cases { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<HRCase> HRCases { get; set; }

}

}
