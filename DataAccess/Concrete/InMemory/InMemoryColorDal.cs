using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;


namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _color;
        public InMemoryColorDal()
        {
            _color = new List<Color>
            {
                new Color{ColorId=1,ColorName="Blue"},
                new Color{ColorId=2,ColorName="Yellow"},
                new Color{ColorId=3,ColorName="White"},
                new Color{ColorId=4,ColorName="red"},
                new Color{ColorId=5,ColorName="black"},
                new Color{ColorId=6,ColorName="Gray"}
            };
        }
        public void Add(Color color)
        {
            _color.Add(color);
        }

        public void Update(Color color)
        {
            var result = _color.SingleOrDefault(c => c.ColorId == color.ColorId);
            result.ColorName = color.ColorName;
        }
        public void Delete(Color color)
        {
            var result = _color.SingleOrDefault(c => c.ColorId == color.ColorId);
            _color.Remove(result);
        }

        public List<Color> GetAll()
        {
            return _color;
        }

    }
}
