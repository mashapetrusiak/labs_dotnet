using System;
using System.Collections.Generic;

namespace _2lab.Models
{
    public partial class Characterization
    {
        public Characterization()
        {
            Employee = new HashSet<Employee>();
        }

        public string CharacterizationText { get; set; }
        public int CharacterizationId { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
