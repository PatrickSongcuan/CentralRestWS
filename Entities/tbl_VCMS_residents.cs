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
    
    public partial class tbl_VCMS_residents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_VCMS_residents()
        {
            this.tbl_VCMS_residentBalance = new HashSet<tbl_VCMS_residentBalance>();
            this.tbl_VCMS_residentCollection = new HashSet<tbl_VCMS_residentCollection>();
        }
    
        public int resident_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string contact_number { get; set; }
        public string email_address { get; set; }
        public string total_monthly_collection { get; set; }
        public System.DateTime start_of_collection { get; set; }
        public System.DateTime date_created { get; set; }
        public int created_by { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<int> modified_by { get; set; }
        public int is_active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VCMS_residentBalance> tbl_VCMS_residentBalance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_VCMS_residentCollection> tbl_VCMS_residentCollection { get; set; }
    }
}
