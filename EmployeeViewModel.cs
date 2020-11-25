using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4.ViewModels
{
    public class EmployeeViewModel
    {
        #region Properties

        public int Id { get; set; }

        [DisplayName("Address")]
        public int AddressId { get; set; }

        [DisplayName("FullName")]
        public int FullNameId { get; set; }

        [DisplayName("ProjectInfo")]
        public int ProjectInfoId { get; set; }

        [DisplayName("Position")]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Days")]
        [Range(1, 5000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Days { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Salary")]
        [Range(1, 5000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Characterization")]
        public string Characterization { get; set; }

        [NotMapped]
        [DisplayName("Address")]
        public AddressViewModel Address { get; set; }

        [NotMapped]
        [DisplayName("FullName")]
        public FullNameViewModel FullName { get; set; }

        [NotMapped]
        [DisplayName("ProjectInfo")]
        public ProjectInfoViewModel ProjectInfo { get; set; }

        [NotMapped]
        [DisplayName("Position")]
        public PositionViewModel Position { get; set; }

        public new string ToString => $"{FullName?.ToString ?? ""} {Address?.ToString ?? ""} " +
            $"{Position?.ToString ?? ""} {ProjectInfo?.ToString ?? ""} " +
            $"Days: {Days} Salary: {Salary} Characterization: {Characterization}";

        #endregion Properties
    }
}