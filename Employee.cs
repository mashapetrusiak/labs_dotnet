using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.DTO.Models
{
    public class Employee
    {
        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AddressId { get; set; }

        public int PositionId { get; set; }

        public int ProjectInfoId { get; set; }

        public int FullNameId { get; set; }

        [Required]
        public int Days { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Characterization { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [ForeignKey("ProjectInfoId")]
        public ProjectInfo ProjectInfo { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        [ForeignKey("FullNameId")]
        public FullName FullName { get; set; }

        #endregion Properties
    }
}