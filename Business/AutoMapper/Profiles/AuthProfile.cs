using System;
using AutoMapper;
using Entities.DTOs.AuthDto;
using Core.Entities.Concrete;

namespace Business.AutoMapper.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<UserForLoginDto,User>().ReverseMap();
            CreateMap<UserForRegisterDto,User>().ReverseMap();
        }
    }
}
