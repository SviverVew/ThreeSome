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
    
    public partial class favorite
    {
        public int favID { get; set; }
        public Nullable<int> userID { get; set; }
        public Nullable<int> episodeID { get; set; }
    
        public virtual espisode espisode { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
