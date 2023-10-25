using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepo _basketRepo;
        public BasketController(IBasketRepo basketRepo)
        {
            _basketRepo = basketRepo;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepo.GetBasketAsync(id);   
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var uppdatedBasket = await _basketRepo.UpdateBasketAsync(basket);
            return Ok(uppdatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepo.DeleteBasketAsync(id);
        }
    }
}