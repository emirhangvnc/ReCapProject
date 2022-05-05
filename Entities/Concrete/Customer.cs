using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int Customer_Id { get; set; }
        public int Gender_Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
