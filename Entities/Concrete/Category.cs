using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        [Key]
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
    }
}
