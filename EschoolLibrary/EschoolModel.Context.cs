﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EschoolLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EschoolEntities : DbContext
    {

        public EschoolEntities(string connectionString)
            : base(connectionString)
        {

        }
        public EschoolEntities()
            : base("name=EschoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Expense_Category> Expense_Category { get; set; }
        public DbSet<FeeRequiredPerYear> FeeRequiredPerYears { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<FeesRequiredPerTerm> FeesRequiredPerTerms { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Income_Category> Income_Category { get; set; }
        public DbSet<Login_Users> Login_Users { get; set; }
        public DbSet<OverHeadCategory> OverHeadCategories { get; set; }
        public DbSet<OverHeadCategoryPerYear> OverHeadCategoryPerYears { get; set; }
        public DbSet<SchoolPeriodTerm> SchoolPeriodTerms { get; set; }
        public DbSet<SchoolPeriodYear> SchoolPeriodYears { get; set; }
        public DbSet<Student_Basic> Student_Basic { get; set; }
    }
}
