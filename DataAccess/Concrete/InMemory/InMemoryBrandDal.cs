using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brand;
        public InMemoryBrandDal()
        {
            _brand = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="BMW"},
                new Brand{BrandId=2,BrandName="AUDI"},
                new Brand{BrandId=3,BrandName="Mercedes"}
            };
        }
        public void Add(Brand brand)
        {
            _brand.Add(brand);
        }

        public void Delete(Brand brand)
        {
            var brandToDelete = _brand.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brand.Remove(brandToDelete);
        }

        public void Update(Brand brand)
        {
            var brandToUpdate = _brand.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }
        public List<Brand> GetAll()
        {
            return _brand;
        }

    }
}
