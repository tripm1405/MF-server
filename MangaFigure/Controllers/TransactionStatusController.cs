using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionStatusController : ControllerBase
{
    private readonly TransactionStatusRepository _transactionStatusRepository;

    public TransactionStatusController(TransactionStatusRepository transactionStatusRepository)
    {
        _transactionStatusRepository = transactionStatusRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetTransactionStatusAsync()
    {
        var data = await _transactionStatusRepository.GetTransactionStatusAsync();
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewTransactionStatusAsync([FromBody] TransactionStatusDto transactionStatusModel)
    {
        var data = await _transactionStatusRepository.AddTransactionStatusAsync(transactionStatusModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTransactionStatusAsync(int id, [FromBody] TransactionStatusDto transactionStatusModel)
    {
        var data = await _transactionStatusRepository.UpdateTransactionStatusAsync(id,transactionStatusModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveTransactionStatusAsync(int id)
    {
        var data = await _transactionStatusRepository.RemoveTransactionStatusAsync(id);
        return Ok(data);
    }
}