﻿using AutoMapper;
using Core.Entities;
using SKINET.Dtos;

namespace SKINET.Helpers
{
    public class ProductURLResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        public readonly IConfiguration _config;

        public ProductURLResolver(IConfiguration config)
        {
            _config = config;
        }
         
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
