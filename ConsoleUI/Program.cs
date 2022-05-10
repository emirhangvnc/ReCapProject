using Business.Concrete;
using DataAccess.Abstract;
using System.Linq;
using Entities.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {                
                Console.WriteLine(customer.FirstName);
                Console.WriteLine(customer.GenderName);
                Console.WriteLine(customer.GenderName);
                Console.WriteLine("-----------------");
            }    
        }
    }
}
