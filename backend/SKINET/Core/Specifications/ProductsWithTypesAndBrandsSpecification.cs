using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort)
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

        public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id ==id)
        {
            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
        }
    }
}
