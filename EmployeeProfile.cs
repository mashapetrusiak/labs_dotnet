using AutoMapper;
using lab4.DTO.Models;
using lab4.ViewModels;

namespace lab4.Profiles
{
    public class EmployeeProfile : Profile
    {
        #region Constructors

        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>(MemberList.Destination);
            CreateMap<Employee, EmployeeViewModel>(MemberList.Source);
        }

        #endregion Constructors
    }
}