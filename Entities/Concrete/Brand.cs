using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
