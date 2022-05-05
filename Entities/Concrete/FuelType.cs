using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class FuelType:IEntity
    {
        [Key]
        public int Fuel_Id { get; set; }
        public string? Fuel_Name { get; set; }
    }
}
