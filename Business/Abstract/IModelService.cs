using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IModelService
    {
        List<Model> GetAll();
        List<Model> GetByBrandId(int id); //By=ile
        List<Model> GetByDailyPriceContains(decimal minPrice, decimal maxPrice);
        List<Model> GetByDailyPrice(decimal price);
        List<Model> GetByDailyPriceBuyuktur(decimal price);
        List<Model> GetByDailyPriceKucuktur(decimal price);
        List<Model> GetByColor(int id);
        List<ModelDetailDto> GetModelDetails();
    }
}
