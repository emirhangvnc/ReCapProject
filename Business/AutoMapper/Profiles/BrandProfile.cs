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
            CreateMap<Brand,BrandAddDto>();

            CreateMap<BrandUpdateDto, Brand>();
            CreateMap<Brand,BrandUpdateDto>();

            CreateMap<BrandDeleteDto, Brand>();
            CreateMap<Brand,BrandDeleteDto>();
        }
    }
}
