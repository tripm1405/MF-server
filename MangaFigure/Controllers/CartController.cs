using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartRepository _cartRepository;

    public CartController(CartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpPost]
    public async Task<IActionResult> GetCartsWithBodyAsync([FromBody] CartsWithBodyReqDto body)
    {
        var data = await _cartRepository.GetCartWithBodyAsync(body);
        return Ok(data);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetCartAsync()
    {
        var data = await _cartRepository.GetCartAsync();
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewCartAsync([FromBody] CartDto cartModel)
    {
        var data = await _cartRepository.AddCartAsync(cartModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCartAsync(int id, [FromBody] CartDto cartModel)
    {
        var data = await _cartRepository.UpdateCartAsync(id,cartModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveCartAsync(int id)
    {
        var data = await _cartRepository.RemoveCartAsync(id);
        return Ok(data);
    }
}