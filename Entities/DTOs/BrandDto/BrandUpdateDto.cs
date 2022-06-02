using Core.Entities;

namespace Entities.DTOs.BrandDto
{
    public class BrandUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
