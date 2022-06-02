using AutoMapper;
using Entities.DTOs.RentalDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class RentalProfile:Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalAddDto, Rental>();
            CreateMap<Rental, RentalAddDto>();

            CreateMap<RentalDeleteDto, Rental>();
            CreateMap<Rental, RentalDeleteDto>();

            CreateMap<RentalUpdateDto, Rental>();
            CreateMap<Rental, RentalUpdateDto>();
        }
    }
}
