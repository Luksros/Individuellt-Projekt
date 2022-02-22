using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3___Anropa_Databasen.Models
{
    public partial class StudentsInCourses
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int? GradeId { get; set; }
        public DateTime? GradeDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Student Student { get; set; }
        
    }
}
