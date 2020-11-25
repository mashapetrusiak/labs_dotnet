using AutoMapper;
using lab4.DTO.Models;
using lab4.ViewModels;

namespace lab4.Profiles
{
    public class PositionProfile : Profile
    {
        #region Constructors

        public PositionProfile()
        {
            CreateMap<PositionViewModel, Position>(MemberList.Destination);
            CreateMap<Position, PositionViewModel>(MemberList.Source);
        }

        #endregion Constructors
    }
}