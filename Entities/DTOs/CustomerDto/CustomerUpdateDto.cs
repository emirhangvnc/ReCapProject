using Core.Entities;

namespace Entities.DTOs.CustomerDto
{
    public class CustomerUpdateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
