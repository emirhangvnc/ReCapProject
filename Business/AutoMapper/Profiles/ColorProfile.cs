using AutoMapper;
using Entities.DTOs.ColorDto;
using Entities.Concrete;


namespace Business.AutoMapper.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorAddDto, Color>().ReverseMap();
            CreateMap<ColorUpdateDto, Color>().ReverseMap();
            CreateMap<ColorDeleteDto, Color>().ReverseMap();
        }
    }
}