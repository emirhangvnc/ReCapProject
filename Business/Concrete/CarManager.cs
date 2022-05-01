using Business.Abstract;
using DataAccess.Abstract;
using System.Linq;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int id)
        {
            return _carDal.GetAll().Where(c => c.Brand_Id == id).ToList();
        }

        public List<Car> GetByColor(int id)
        {
            return _carDal.GetAll().Where(c => c.Color_Id == id).ToList();
        }

        public List<Car> GetByDailyPriceContains(decimal minPrice, decimal maxPrice)
        {
            return _carDal.GetAll().Where(c => c.Daily_Price >= minPrice && c.Daily_Price <= maxPrice).ToList();
        }
        public List<Car> GetByDailyPrice(decimal price)
        {
            return _carDal.GetAll().Where(c => c.Daily_Price ==price).ToList();
        }
        public List<Car> GetByDailyPriceBuyuktur(decimal price)
        {
            return _carDal.GetAll().Where(c => c.Daily_Price >= price).ToList();
        }
        public List<Car> GetByDailyPriceKucuktur(decimal price)
        {
            return _carDal.GetAll().Where(c => c.Daily_Price <= price).ToList();
        }
    }
}
