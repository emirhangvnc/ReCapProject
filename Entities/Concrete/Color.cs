using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
