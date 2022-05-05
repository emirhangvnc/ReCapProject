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
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var model in modelManager.GetModelDetails())
            {                
                Console.WriteLine(model.ModelName);
                Console.WriteLine(model.BrandName);
                Console.WriteLine(model.CategoryName);
                Console.WriteLine(model.ColorName);
                Console.WriteLine(model.DailyPrice);
                Console.WriteLine("-----------------");
            }            
            
        }
    }
}
