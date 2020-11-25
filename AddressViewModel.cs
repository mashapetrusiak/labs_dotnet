using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab4.ViewModels
{
    public class AddressViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("House number")]
        public int HouseNumber { get; set; }

        public new string ToString => $"City:" +
            $" {City} Street: {Street} House number: {HouseNumber}";

        #endregion Properties
    }
}