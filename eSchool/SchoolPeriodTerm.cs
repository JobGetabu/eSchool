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
    
    public partial class SchoolPeriodTerm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SchoolPeriodTerm()
        {
            this.Expenses = new HashSet<Expense>();
            this.Fees = new HashSet<Fee>();
            this.FeesRequiredPerTerms = new HashSet<FeesRequiredPerTerm>();
            this.Incomes = new HashSet<Income>();
            this.OverHeadCategoryPerYears = new HashSet<OverHeadCategoryPerYear>();
        }
    
        public int Term { get; set; }
    
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
        public virtual ICollection<FeesRequiredPerTerm> FeesRequiredPerTerms { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<OverHeadCategoryPerYear> OverHeadCategoryPerYears { get; set; }
    }
}
