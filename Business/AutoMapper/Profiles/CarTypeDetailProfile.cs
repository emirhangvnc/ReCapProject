using AutoMapper;
using Entities.DTOs.CarTypeDetailDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class CarTypeDetailProfile:Profile
    {
        public CarTypeDetailProfile()
        {
            CreateMap<CarTypeDetailAddDto, CarTypeDetail>().ReverseMap();
            CreateMap<CarTypeDetailDeleteDto, CarTypeDetail>().ReverseMap();
            CreateMap<CarTypeDetailUpdateDto, CarTypeDetail>().ReverseMap();
        }
    }
}
