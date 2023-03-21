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
        var authors = await _productReviewRepository.GetProductReviewAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewProductReviewAsync([FromBody] ProductReviewDto productReviewModel)
    {
        var authors = await _productReviewRepository.AddProductReviewAsync(productReviewModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateProductReviewAsync(int id, [FromBody] ProductReviewDto productReviewModel)
    {
        var authors = await _productReviewRepository.UpdateProductReviewAsync(id,productReviewModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveProductReviewAsync(int id)
    {
        var authors = await _productReviewRepository.RemoveProductReviewAsync(id);
        return Ok(authors);
    }
}