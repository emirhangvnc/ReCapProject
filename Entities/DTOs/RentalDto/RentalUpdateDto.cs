using System;
using Core.Entities;

namespace Entities.DTOs.RentalDto
{
    public class RentalUpdateDto:IDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
