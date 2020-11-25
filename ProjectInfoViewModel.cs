using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab4.ViewModels
{
    public class ProjectInfoViewModel
    {
        #region Properties

        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("ProjectName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("StartDate")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("EndDate")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Description")]
        public string Description { get; set; }

        public new string ToString => $"ProjectName: {Name} Start date: {StartDate.ToShortDateString()} " +
            $"End date: {EndDate.ToShortDateString()} Description: {Description}";

        #endregion Properties
    }
}