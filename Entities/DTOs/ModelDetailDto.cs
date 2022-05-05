using Core.Entities;

namespace Entities.DTOs
{
    public class ModelDetailDto:IDto
    {
        public int ModelId { get; set; }
        public string BrandName{ get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
