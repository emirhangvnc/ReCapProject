using Core.Entities;
using System;

namespace Entities.DTOs.RentalDto
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public string ModelName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string FuelTypeName { get; set; }
        public string CategoryName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
