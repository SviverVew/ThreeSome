//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeSome.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class espisode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public espisode()
        {
            this.favorites = new HashSet<favorite>();
        }
    
        public int vidID { get; set; }
        public string vidAddress { get; set; }
        public string vidIMG { get; set; }
        public Nullable<int> film_ID { get; set; }
    
        public virtual Film Film { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favorite> favorites { get; set; }
    }
}