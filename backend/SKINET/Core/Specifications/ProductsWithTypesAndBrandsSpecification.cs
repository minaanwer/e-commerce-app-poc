using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id ==id)
        {
            base.AddInclude(x => x.ProductType);
            base.AddInclude(x => x.ProductBrand);
        }
    }
}
