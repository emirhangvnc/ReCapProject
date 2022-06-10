using AutoMapper;
using Entities.DTOs.ModelDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {
            CreateMap<ModelAddDto, Model>().ReverseMap();
            CreateMap<ModelDeleteDto, Model>().ReverseMap();
            CreateMap<ModelUpdateDto, Model>().ReverseMap();
        }
    }
}
