﻿using Core.Entities;

namespace Entities.Concrete.Entity
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStoct { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
