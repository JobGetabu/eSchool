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
    
    public partial class GroupedFeeStructure
    {
        public int Id { get; set; }
        public string YearTitle { get; set; }
        public string TermTitle { get; set; }
        public decimal TotalFee { get; set; }
        public Nullable<int> selFm1 { get; set; }
        public Nullable<int> selFm2 { get; set; }
        public Nullable<int> selFm3 { get; set; }
        public Nullable<int> selFm4 { get; set; }
        public Nullable<int> selYear { get; set; }
        public Nullable<int> selTerm { get; set; }
        public string TotalTitle { get; set; }
    }
}