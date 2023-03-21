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

    [HttpGet("list")]
    public async Task<IActionResult> GetCartAsync()
    {
        var authors = await _cartRepository.GetCartAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewCartAsync([FromBody] CartDto cartModel)
    {
        var authors = await _cartRepository.AddCartAsync(cartModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCartAsync(int id, [FromBody] CartDto cartModel)
    {
        var authors = await _cartRepository.UpdateCartAsync(id,cartModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveCartAsync(int id)
    {
        var authors = await _cartRepository.RemoveCartAsync(id);
        return Ok(authors);
    }
}