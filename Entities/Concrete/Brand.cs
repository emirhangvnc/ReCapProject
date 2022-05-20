using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        [Key]
        public int Brand_Id { get; set; }
        public string Brand_Name { get; set; }
    }
}
