using AutoMapper;
using Entities.DTOs.CarImageDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class CarImageProfile:Profile
    {
        public CarImageProfile()
        {
            CreateMap<CarImageAddDto, CarImage>();
            CreateMap<CarImage, CarImageAddDto>();

            CreateMap<CarImageDeleteDto, CarImage>();
            CreateMap<CarImage, CarImageDeleteDto>();

            CreateMap<CarImageUpdateDto, CarImage>();
            CreateMap<CarImage, CarImageUpdateDto>();
        }
    }
}
