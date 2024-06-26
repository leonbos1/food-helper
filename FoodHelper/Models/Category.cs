﻿using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public List<Food>? Foods { get; set; }
    }
}