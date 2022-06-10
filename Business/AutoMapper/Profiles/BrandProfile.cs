using AutoMapper;
using Entities.DTOs.BrandDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandAddDto,Brand>().ReverseMap();
            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
            CreateMap<BrandDeleteDto, Brand>().ReverseMap();
        } 
    }
}
