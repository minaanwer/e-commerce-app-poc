using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SKINET.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
           return  Ok(await _productRepo.GetProductsAsync());
               
        }

        [HttpGet]
        [Route("{brands}")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return  Ok(await _productRepo.GetProductBrandsAsync());

        }

        [HttpGet]
        [Route("{types}")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productRepo.GetProductTypesAsync());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepo.GetProductAsync(id);
        }
    }
}
