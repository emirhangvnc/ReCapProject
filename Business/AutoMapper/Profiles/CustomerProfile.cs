using AutoMapper;
using Entities.DTOs.CustomerDto;
using Entities.Concrete;


namespace Business.AutoMapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();
            CreateMap<CustomerDeleteDto, Customer>().ReverseMap();
        }
    }
}
