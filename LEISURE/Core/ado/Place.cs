//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.ado
{
    using System;
    using System.Collections.Generic;
    
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            this.Activity = new HashSet<Activity>();
            this.Request = new HashSet<Request>();
            this.Review = new HashSet<Review>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_Type { get; set; }
        public string Adress { get; set; }
        public Nullable<int> ID_Owner { get; set; }
        public string Capacity { get; set; }
        public Nullable<bool> IsOpen { get; set; }
        public Nullable<int> Visits { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        public virtual Place_Type Place_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Review { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
