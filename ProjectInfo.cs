using System;
using System.Collections.Generic;

namespace _2lab.Models
{
    public partial class ProjectInfo
    {
        public ProjectInfo()
        {
            Employee = new HashSet<Employee>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectEnd { get; set; }
        public string ProjectDescription { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
