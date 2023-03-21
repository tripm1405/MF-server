using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetProducts()
    {
        var authors = await _productRepository.GetProductsAsync();
        return Ok(authors);
    }

    [HttpPost("")]
    public async Task<IActionResult> GetProducts([FromBody] ProductDto body)
    {
        var authors = await _productRepository.GetProductsWithBodyAsync(body);
        return Ok(authors);
    }
}