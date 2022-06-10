using AutoMapper;
using Entities.DTOs.RentalDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class RentalProfile:Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalAddDto, Rental>().ReverseMap();
            CreateMap<RentalDeleteDto, Rental>().ReverseMap();
            CreateMap<RentalUpdateDto, Rental>().ReverseMap();
        }
    }
}
