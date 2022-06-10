using Core.Entities;

namespace Entities.DTOs.BrandDto
{
    public class BrandUpdateDto:IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
