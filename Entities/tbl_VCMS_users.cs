//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentralRestWS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_VCMS_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_VCMS_users()
        {
            this.tbl_VCMS_userDetails = new HashSet<tbl_VCMS_userDetails>();
        }
    
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int is_active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VCMS_userDetails> tbl_VCMS_userDetails { get; set; }
    }
}
