using AutoMapper;
using Entities.DTOs.CarImageDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class CarImageProfile:Profile
    {
        public CarImageProfile()
        {
            CreateMap<CarImageAddDto, CarImage>().ReverseMap();
            CreateMap<CarImageDeleteDto, CarImage>().ReverseMap();
            CreateMap<CarImageUpdateDto, CarImage>().ReverseMap();
        }
    }
}
