using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int Customer_Id { get; set; }
        public int User_Id { get; set; }
        public string? Company_Name { get; set; }
    }
}
