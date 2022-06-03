using Core.Entities;

namespace Entities.DTOs.FuelTypeDto
{
    public class FuelTypeUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}