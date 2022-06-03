using Core.Entities;

namespace Entities.DTOs.CustomerDto
{
    public class CustomerDetailDto : IDto
    {
        public int Customer_Id { get; set; }
        public string GenderName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}
