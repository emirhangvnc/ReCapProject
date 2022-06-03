using Core.Entities;

namespace Entities.DTOs.ColorDto
{
    public class ColorUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
