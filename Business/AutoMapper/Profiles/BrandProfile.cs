using AutoMapper;
using Entities.DTOs.BrandDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandAddDto,Brand>();
            CreateMap<BrandUpdateDto, Brand>();
            CreateMap<BrandDeleteDto, Brand>();
        }
    }
}
