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
    
    public partial class Transation
    {
        public int Id { get; set; }
        public string TransactionNo { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Term { get; set; }
        public Nullable<int> Year { get; set; }
    }
}