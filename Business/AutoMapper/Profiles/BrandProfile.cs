using AutoMapper;
using Entities.DTOs.BrandDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand,BrandAddDto>();
            CreateMap<Brand,BrandUpdateDto>();
            CreateMap<Brand,BrandDeleteDto>();
        } 
    }
}
