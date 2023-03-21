using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductImageController : ControllerBase
{
    private readonly ProductImageRepository _productImageRepository;

    public ProductImageController(ProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetProductImageAsync()
    {
        var authors = await _productImageRepository.GetProductImageAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewProductImageAsync([FromBody] ProductImageDto productImageModel)
    {
        var authors = await _productImageRepository.AddProductImageAsync(productImageModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateProductImageAsync(int id, [FromBody] ProductImageDto productImageModel)
    {
        var authors = await _productImageRepository.UpdateProductImageAsync(id,productImageModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveProductImageAsync(int id)
    {
        var authors = await _productImageRepository.RemoveProductImageAsync(id);
        return Ok(authors);
    }
}