using Core.Entities;

namespace Entities.DTOs.CustomerDto
{
    public class CustomerAddDto : IDto
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}