using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    class Contracts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
        public string PositionName { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectEnd { get; set; }
        public string ProjectDescription { get; set; }
        public string Characterization { get; set; }
        public int Days { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + SurName + " " + City + " " + Street + " " + Home + " " + PositionName + " " + ProjectStart + " " +
                ProjectEnd + " " + ProjectDescription + " " + Characterization + " " + Days + " " + Salary;
        }
    }
}
