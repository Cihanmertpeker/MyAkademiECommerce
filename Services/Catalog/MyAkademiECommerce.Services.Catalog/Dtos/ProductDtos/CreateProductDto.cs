﻿using MyAkademiECommerce.Services.Catalog.Models;

namespace MyAkademiECommerce.Services.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductImage { get; set; }

        public string CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
