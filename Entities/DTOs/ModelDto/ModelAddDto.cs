using Core.Entities;

namespace Entities.DTOs.ModelDto
{
    public class ModelAddDto:IDto
    {
        public int BrandId { get; set; }
        public int CarTypeDetailId { get; set; }
        public int ColorId { get; set; }
        public string ModelName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }
    }
}
