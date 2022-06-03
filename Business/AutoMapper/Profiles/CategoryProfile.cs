using AutoMapper;
using Entities.DTOs.CategoryDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryDeleteDto, Category>();
            CreateMap<Category, CategoryDeleteDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
