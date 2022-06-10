using Core.Entities;

namespace Entities.DTOs.CarTypeDetailDto
{
    public class CarTypeDetailUpdateDto:IDto
    {
        public int Id { get; set; }
        public int FuelTypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
