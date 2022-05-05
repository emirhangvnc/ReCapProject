﻿using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Gender:IEntity
    {
        [Key]
        public int Gender_Id { get; set; }
        public string? Gender_Name { get; set; }
    }
}