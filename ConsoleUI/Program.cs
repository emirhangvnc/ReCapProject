using Business.Concrete;
using DataAccess.Abstract;
using System.Linq;
using Entities.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Security.JWT;
using Business.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            GenderManager genderManager = new GenderManager(new EfGenderDal());

            //authManager.Register(UserForRegisterDto userForRegisterDto, string password();

        }
    }
}
