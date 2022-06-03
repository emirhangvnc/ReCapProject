using AutoMapper;
using Entities.DTOs.ColorDto;
using Entities.Concrete;


namespace Business.AutoMapper.Profiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorAddDto, Color>();
            CreateMap<Color, ColorAddDto>();

            CreateMap<ColorUpdateDto, Color>();
            CreateMap<Color, ColorUpdateDto>();

            CreateMap<ColorDeleteDto, Color>();
            CreateMap<Color, ColorDeleteDto>();
        }
    }
}