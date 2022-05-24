using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class Gender : IEntity
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
