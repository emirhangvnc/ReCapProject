using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByBrandId(int id); //By=ile
        List<Car> GetByDailyPriceContains(decimal minPrice, decimal maxPrice);
        List<Car> GetByDailyPrice(decimal price);
        List<Car> GetByDailyPriceBuyuktur(decimal price);
        List<Car> GetByDailyPriceKucuktur(decimal price);
        List<Car> GetByColor(int id);
    }
}
