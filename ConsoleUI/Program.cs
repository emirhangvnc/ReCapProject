using Business.Concrete;
using DataAccess.Abstract;
using System.Linq;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            foreach (var item in carManager.GetAll())
            {                
                Console.WriteLine(item.ModelYear);
                Console.WriteLine((brandManager.GetAll().SingleOrDefault(b => b.BrandId == item.BrandId)).BrandName);
                Console.WriteLine($"{colorManager.GetAll().SingleOrDefault(c=>c.ColorId==item.ColorId).ColorName}");
                Console.WriteLine();
            }            
            
        }
    }
}
