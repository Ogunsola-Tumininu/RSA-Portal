
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
    
public partial class Publication
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Publication()
    {

        this.UserPublications = new HashSet<UserPublication>();

    }


    public int PublicationsId { get; set; }

    public Nullable<int> UploadTypeId { get; set; }

    public System.DateTime DateUploaded { get; set; }

    public string PublicationName { get; set; }

    public string Extension { get; set; }



    public virtual UploadType UploadType { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserPublication> UserPublications { get; set; }

}

}
