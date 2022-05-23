using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Model:IEntity
    {
        [Key]
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public int CarTypeDetailId { get; set; }
        public int ColorId { get; set; }
        public string ModelName { get; set; }
        public decimal DailyPrice { get; set; }
        public short ModelYear { get; set; }
        public string Description { get; set; }
    }
}
