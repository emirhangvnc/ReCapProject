using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Car_Id { get; set; }
        public int Brand_Id { get; set; } //Marka
        public int Color_Id { get; set; }
        public string Car_Name { get; set; }
        public decimal Daily_Price { get; set; }
        public string Description { get; set; }
    }
}
