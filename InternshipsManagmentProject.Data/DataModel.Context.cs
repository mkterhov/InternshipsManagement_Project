﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternshipsManagmentProject.Data
{
    using InternshipsManagmentProject.Utilities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=InternshipsManagmentProjectDatabaseEntities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Internship> Internships { get; set; }
        public virtual DbSet<Recruiter> Recruiters { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<StudentInternship> StudentInternships { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
