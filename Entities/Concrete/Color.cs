using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        [Key]
        public int Color_Id { get; set; }
        public string? Color_Name { get; set; }
    }
}
