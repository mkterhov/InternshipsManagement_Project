//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternshipsManagmentProject.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Internship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Internship()
        {
            this.StudentInternships = new HashSet<StudentInternship>();
            this.Comments = new HashSet<Comment>();
            this.Files = new HashSet<File>();
        }
    
        public string InternshipId { get; set; }
        public string FirmOrganizerId { get; set; }
        public string RecruiterResponsibleId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public Nullable<int> PositionsAvailable { get; set; }
        public string InternshipPostPhoto { get; set; }

        [DisplayName("Titlu")]
        public string Title { get; set; }
        public Nullable<System.DateTime> DeadlineApplications { get; set; }
        public string TypeJob { get; set; }
        public string Department { get; set; }
        public string Keywords { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> Hidden { get; set; }
        public string Duration { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    
        public virtual Firm Firm { get; set; }
        public virtual Image Image { get; set; }
        public virtual Recruiter Recruiter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentInternship> StudentInternships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<File> Files { get; set; }
    }
}
