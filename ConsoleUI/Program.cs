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

            foreach (var modelY in modelManager.GetModelDetails().Data)
            {                
                Console.WriteLine(modelY.ModelName);
                Console.WriteLine(modelY.BrandName);
                Console.WriteLine("-----------------");
            }    
        }
    }
}
