﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EschoolEntities : DbContext
    {
        public EschoolEntities()
            : base("name=EschoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<FeesRequiredPerTerm> FeesRequiredPerTerms { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<OverHeadCategory> OverHeadCategories { get; set; }
        public DbSet<OverHeadCategoryPerYear> OverHeadCategoryPerYears { get; set; }
        public DbSet<SchoolPeriodTerm> SchoolPeriodTerms { get; set; }
        public DbSet<SchoolPeriodYear> SchoolPeriodYears { get; set; }
        public DbSet<Student_Basic> Student_Basic { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GroupedFeeStructure> GroupedFeeStructures { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Transation> Transations { get; set; }
        public DbSet<StudentImport> StudentImports { get; set; }
        public DbSet<ClosingBalance> ClosingBalances { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<eUser> eUsers { get; set; }
    }
}
