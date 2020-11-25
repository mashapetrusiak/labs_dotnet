using System;
using System.Collections.Generic;

namespace _2lab.Models
{
    public partial class Fullname
    {
        public Fullname()
        {
            Employee = new HashSet<Employee>();
        }

        public int FullnameId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
