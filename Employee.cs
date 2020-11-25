using System;
using System.Collections.Generic;

namespace _2lab.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int FullnameId { get; set; }
        public int AddressId { get; set; }
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        public int? CharacterizationId { get; set; }
        public int Days { get; set; }
        public int Salary { get; set; }

        public Address Address { get; set; }
        public Characterization Characterization { get; set; }
        public Fullname Fullname { get; set; }
        public Position Position { get; set; }
        public ProjectInfo Project { get; set; }
    }
}
