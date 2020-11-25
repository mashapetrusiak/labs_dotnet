using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab4.ViewModels
{
    public class PositionViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Position")]
        public string Name { get; set; }

        public new string ToString => $"Position: {Name}";

        #endregion Properties
    }
}