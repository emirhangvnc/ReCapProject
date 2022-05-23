using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CarTypeDetail:IEntity
    {
        [Key]
        public int CarTypeDetailId { get; set; }
        public int FuelTypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
