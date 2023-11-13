using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Interfaces;
using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public IActionResult AddToCart(CartDTO cartDTO)
        {
            var result = _cartService.AddToCart(cartDTO);
            if (result)
                return Ok(cartDTO);
            return BadRequest("Could not add item to cart");
        }
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(CartDTO cartDTO) {
            var result = _cartService.RemoveFromCart(cartDTO);
            if(result)
                return Ok(cartDTO);
            return BadRequest("There is no item to delete from cart");
        }
    }
}