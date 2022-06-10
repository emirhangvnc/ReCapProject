using AutoMapper;
using Entities.DTOs.CategoryDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryDeleteDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
