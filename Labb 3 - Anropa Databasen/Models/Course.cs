using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3___Anropa_Databasen.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }

        public virtual Employee Teacher { get; set; }
    }
}
