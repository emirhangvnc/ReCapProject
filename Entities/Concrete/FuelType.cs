using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class FuelType:IEntity
    {
        [Key]
        public int FuelTypeId { get; set; }
        public string FuelTypeName { get; set; }
    }
}
