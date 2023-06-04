using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x => (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId.Value)
            && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId.Value))
        {
            
            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
            base.AddOrderBy(x => x.Name);
            base.ApplyPaging(productParams.PageSize*(productParams.PageIndex -1), productParams.PageSize);
            
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

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
        }
    }
}
