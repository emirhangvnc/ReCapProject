using Core.Entities;

namespace Entities.DTOs.CarTypeDetailDto
{
    public class CarTypeDetailAddDto:IDto
    {
        public int FuelTypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
