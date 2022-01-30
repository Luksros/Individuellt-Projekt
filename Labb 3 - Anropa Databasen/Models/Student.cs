using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3___Anropa_Databasen.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PersonalId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
