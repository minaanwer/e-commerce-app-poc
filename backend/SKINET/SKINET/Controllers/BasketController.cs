using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SKINET.Controllers
{
    public class BasketController : BaseApiController
    {

        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository =  basketRepository;

        }


        [HttpGet]
        public async Task<ActionResult<CustomerBasket>>GetBasketById(string basketId)
        {
           return Ok(await this._basketRepository.GetBasketAsync(basketId)??new CustomerBasket(basketId));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task<ActionResult<CustomerBasket>> DeleteBasketAsync(string id)
        {
            var updatedBasket = await _basketRepository.DeleteBasketAsync(id);
            return Ok(updatedBasket);
        }

    }
}
