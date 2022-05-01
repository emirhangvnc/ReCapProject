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
            CarManager carManager = new CarManager(new EfRentalCarDal());

            foreach (var item in carManager.GetAll())
            {                
                Console.WriteLine(item.Car_Name);
                Console.WriteLine(carManager.GetByBrandId(item.Brand_Id));
                Console.WriteLine(item.Daily_Price.ToString());
            }            
            
        }
    }
}
