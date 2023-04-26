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
        var data = await _productRepository.GetProductsAsync();
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> GetProducts([FromBody] ProductBodyDto body)
    {
        var data = await _productRepository.GetProductsWithBodyAsync(body);
        return Ok(data);
    }

    [HttpPost("page")]
    public async Task<IActionResult> GetProductPage([FromBody] ProductPageBodyDto body)
    {
        var data = await _productRepository.GetProductPageAsync(body);
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewProduct([FromBody] ProductDto body)
    {
        var data = await _productRepository.AddProductAsync(body);
        return Ok(data);
    }

    [HttpGet("{meta}")]
    public async Task<IActionResult> GetProductWithMeta(string meta)
    {
        var data = await _productRepository.GetProductAsync(meta);

        return Ok(data);
    }

    [HttpDelete("{meta}")]
    public async Task<IActionResult> DelProduct(string meta)
    {
        var data = await _productRepository.DelProductAsync(meta);

        return Ok(data);
    }
}