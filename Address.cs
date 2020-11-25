using System;
using System.Collections.Generic;

namespace _2lab.Models
{
    public partial class Address
    {
        public Address()
        {
            Employee = new HashSet<Employee>();
        }

        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
