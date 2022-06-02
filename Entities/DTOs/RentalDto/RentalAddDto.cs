using System;
using Core.Entities;

namespace Entities.DTOs.RentalDto
{
    public class RentalAddDto:IDto
    {
        public int ModelId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
