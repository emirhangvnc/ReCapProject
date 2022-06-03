using Core.Entities;

namespace Entities.DTOs.CarImageDto
{
    public class CarImageUpdateDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
    }
}
