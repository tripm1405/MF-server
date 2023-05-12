using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionDetailController : ControllerBase
{
    private readonly TransactionDetailRepository _transactionDetailRepository;

    public TransactionDetailController(TransactionDetailRepository transactionDetailRepository)
    {
        _transactionDetailRepository = transactionDetailRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetTransactionDetailAsync()
    {
        var data = await _transactionDetailRepository.GetTransactionDetailAsync();
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewTransactionDetailAsync([FromBody] TransactionDetailDto transactionDetailModel)
    {
        var data = await _transactionDetailRepository.AddTransactionDetailAsync(transactionDetailModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTransactionDetailAsync(int id, [FromBody] TransactionDetailDto transactionDetailModel)
    {
        var data = await _transactionDetailRepository.UpdateTransactionDetailAsync(id,transactionDetailModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveTransactionDetailAsync(int id)
    {
        var data = await _transactionDetailRepository.RemoveTransactionDetailAsync(id);
        return Ok(data);
    }
}