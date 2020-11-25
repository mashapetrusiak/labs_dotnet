using AutoMapper;
using lab4.DTO.Models;
using lab4.ViewModels;

namespace lab4.Profiles
{
    public class AddressProfile : Profile
    {
        #region Constructors

        public AddressProfile()
        {
            CreateMap<AddressViewModel, Address>(MemberList.Destination);
            CreateMap<Address, AddressViewModel>(MemberList.Source);
        }

        #endregion Constructors
    }
}