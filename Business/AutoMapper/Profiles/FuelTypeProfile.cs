using AutoMapper;
using Entities.DTOs.FuelTypeDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class FuelTypeProfile : Profile
    {
        public FuelTypeProfile()
        {
            CreateMap<FuelTypeAddDto, FuelType>();
            CreateMap<FuelType, FuelTypeAddDto>();

            CreateMap<FuelTypeDeleteDto, FuelType>();
            CreateMap<FuelType, FuelTypeDeleteDto>();

            CreateMap<FuelTypeUpdateDto, FuelType>();
            CreateMap<FuelType, FuelTypeUpdateDto>();
        }
    }
}
