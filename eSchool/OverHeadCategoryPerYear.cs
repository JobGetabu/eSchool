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
    
    public partial class OverHeadCategoryPerYear
    {
        public int Id { get; set; }
        public int Term { get; set; }
        public decimal Amount { get; set; }
        public int Form { get; set; }
        public int Year { get; set; }
    
        public virtual SchoolPeriodTerm SchoolPeriodTerm { get; set; }
        public virtual SchoolPeriodYear SchoolPeriodYear { get; set; }
    }
}