using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class FuelType:IEntity
    {
        [Key]
        public int FuelType_Id { get; set; }
        public string? FuelType_Name { get; set; }
    }
}
