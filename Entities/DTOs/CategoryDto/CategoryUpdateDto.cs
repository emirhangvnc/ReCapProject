using Core.Entities;

namespace Entities.DTOs.CategoryDto
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

