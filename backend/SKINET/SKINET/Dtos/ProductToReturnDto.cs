﻿using Core.Entities;

namespace SKINET.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string ProductType { get; set; }
         
        public string ProductBrand { get; set; }
 
    }
}
