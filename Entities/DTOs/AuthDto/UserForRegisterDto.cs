using Core.Entities;

namespace Entities.DTOs.AuthDto
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public int GenderId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
