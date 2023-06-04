using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFilterAndCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterAndCountSpecification(ProductSpecParams productParams) : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
            && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId.Value)
            && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId.Value))
        {

            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
            base.AddOrderBy(x => x.Name);
            base.ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

    }
}
