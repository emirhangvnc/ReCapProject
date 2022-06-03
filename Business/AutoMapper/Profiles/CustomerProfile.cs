using AutoMapper;
using Entities.DTOs.CustomerDto;
using Entities.Concrete;


namespace Business.AutoMapper.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<Customer, CustomerAddDto>();

            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerUpdateDto>();

            CreateMap<CustomerDeleteDto, Customer>();
            CreateMap<Customer, CustomerDeleteDto>();
        }
    }
}
