﻿using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CarTypeDetail:IEntity
    {
        [Key]
        public int CarTypeDetail_Id { get; set; }
        public int FuelType_Id { get; set; }
        public int Category_Id { get; set; }
    }
}
