using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab4.ViewModels
{
    public class FullNameViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        public new string ToString => $"FirstName: {FirstName} LastName: {LastName}";

        #endregion Properties
    }
}