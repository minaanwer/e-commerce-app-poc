using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            base.AddInclude(x => x.ProductTypeId);
            base.AddInclude(x => x.ProductBrandId);
        }

        public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id ==id)
        {
            base.AddInclude(x => x.ProductTypeId);
            base.AddInclude(x => x.ProductBrandId);
        }
    }
}
