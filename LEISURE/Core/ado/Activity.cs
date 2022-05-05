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
    
    public partial class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> ID_Place { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> ID_Type { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> ID_Request { get; set; }
        public Nullable<int> Visits { get; set; }
    
        public virtual Activity_Type Activity_Type { get; set; }
        public virtual Place Place { get; set; }
        public virtual Request Request { get; set; }
    }
}
