//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSchool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_Basic
    {
        public Student_Basic()
        {
            this.Fees = new HashSet<Fee>();
        }
    
        public int Admin_No { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public int Form { get; set; }
        public string Class { get; set; }
    
        public virtual ICollection<Fee> Fees { get; set; }
    }
}