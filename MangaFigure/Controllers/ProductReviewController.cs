using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductReviewController : ControllerBase
{
    private readonly ProductReviewRepository _productReviewRepository;

    public ProductReviewController(ProductReviewRepository productReviewRepository)
    {
        _productReviewRepository = productReviewRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetProductReviewAsync()
    {
        var data = await _productReviewRepository.GetProductReviewAsync();
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewProductReviewAsync([FromBody] ProductReviewDto productReviewModel)
    {
        var data = await _productReviewRepository.AddProductReviewAsync(productReviewModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateProductReviewAsync(int id, [FromBody] ProductReviewDto productReviewModel)
    {
        var data = await _productReviewRepository.UpdateProductReviewAsync(id,productReviewModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveProductReviewAsync(int id)
    {
        var data = await _productReviewRepository.RemoveProductReviewAsync(id);
        return Ok(data);
    }
}