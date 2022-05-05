using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ModelManager:IModelService
    {
        IModelDal _modelDal;  
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }

        public List<Model> GetByBrandId(int id)
        {                        
            return _modelDal.GetAll().Where(m => m.Brand_Id == id).ToList();
        }

        public List<Model> GetByColor(int id)
        {
            return _modelDal.GetAll().Where(c => c.Color_Id == id).ToList();
        }

        public List<Model> GetByDailyPriceContains(decimal minPrice, decimal maxPrice)
        {
            return _modelDal.GetAll().Where(c => c.Daily_Price >= minPrice && c.Daily_Price <= maxPrice).ToList();
        }
        public List<Model> GetByDailyPrice(decimal price)
        {
            return _modelDal.GetAll().Where(c => c.Daily_Price == price).ToList();
        }
        public List<Model> GetByDailyPriceBuyuktur(decimal price)
        {
            return _modelDal.GetAll().Where(c => c.Daily_Price >= price).ToList();
        }
        public List<Model> GetByDailyPriceKucuktur(decimal price)
        {
            return _modelDal.GetAll().Where(c => c.Daily_Price <= price).ToList();
        }

        public List<ModelDetailDto> GetModelDetails()
        {
            return _modelDal.GetModelDetails();
        }
    }
}
