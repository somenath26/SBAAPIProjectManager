﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBAAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SBAEntities : DbContext
    {
        public SBAEntities()
            : base("name=SBAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Parent_Task_New> Parent_Task_New { get; set; }
        public virtual DbSet<Project_new> Project_new { get; set; }
        public virtual DbSet<Task_New> Task_New { get; set; }
        public virtual DbSet<User_New> User_New { get; set; }
    }
}
