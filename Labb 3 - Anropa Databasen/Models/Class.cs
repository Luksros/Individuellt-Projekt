using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3___Anropa_Databasen.Models
{
    public partial class Class
    {
        public Class()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
