using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3___Anropa_Databasen.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PersonalId { get; set; }
        public int JobId { get; set; }

        public virtual Job Job { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public DateTime DateOfHire { get; internal set; }
        public decimal MonthlySalary { get; internal set; }
    }
}
