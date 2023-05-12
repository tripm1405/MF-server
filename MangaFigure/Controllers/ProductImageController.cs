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
        var data = await _productImageRepository.GetProductImageAsync();
        return Ok(data);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file selected.");

        var filePath = await _productImageRepository.UploadFileAsync(file);

        return Ok(new { file = filePath });
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewProductImageAsync([FromBody] ProductImageDto productImageModel)
    {
        var data = await _productImageRepository.AddProductImageAsync(productImageModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateProductImageAsync(int id, [FromBody] ProductImageDto productImageModel)
    {
        var data = await _productImageRepository.UpdateProductImageAsync(id,productImageModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveProductImageAsync(int id)
    {
        var data = await _productImageRepository.RemoveProductImageAsync(id);
        return Ok(data);
    }
}