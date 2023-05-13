using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "2")]
    public async Task<IActionResult> AddNewCartAsync([FromBody] CartDto cartModel)
    {
        var data = await _cartRepository.AddCartAsync(int.Parse(User.Claims.First(i => i.Type == "id").Value), cartModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCartAsync(int id, [FromBody] CartDto cartModel)
    {
        var data = await _cartRepository.UpdateCartAsync(id,cartModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "2")]
    public async Task<IActionResult> RemoveCartAsync(int id)
    {
        var data = await _cartRepository.RemoveCartAsync(id);
        return Ok(data);
    }
}