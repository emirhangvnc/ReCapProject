using AutoMapper;
using Entities.DTOs.ModelDto;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {
            CreateMap<ModelAddDto, Model>();
            CreateMap<Model,ModelAddDto>();

            CreateMap<ModelDeleteDto, Model>();
            CreateMap<Model, ModelDeleteDto>();

            CreateMap<ModelUpdateDto, Model>();
            CreateMap<Model, ModelUpdateDto>();
        }
    }
}
