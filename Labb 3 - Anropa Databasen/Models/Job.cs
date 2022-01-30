using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb_3___Anropa_Databasen.Models
{
    public partial class Job
    {
        public Job()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string JobTitle { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
