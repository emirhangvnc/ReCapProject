using AutoMapper;
using Entities.DTOs.FuelTypeDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class FuelTypeProfile : Profile
    {
        public FuelTypeProfile()
        {
            CreateMap<FuelTypeAddDto, FuelType>().ReverseMap();
            CreateMap<FuelTypeDeleteDto, FuelType>().ReverseMap();
            CreateMap<FuelTypeUpdateDto, FuelType>().ReverseMap();
        }
    }
}
