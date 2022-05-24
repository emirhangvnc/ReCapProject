﻿using Core.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
