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
        var authors = await _transactionStatusRepository.GetTransactionStatusAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewTransactionStatusAsync([FromBody] TransactionStatusDto transactionStatusModel)
    {
        var authors = await _transactionStatusRepository.AddTransactionStatusAsync(transactionStatusModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTransactionStatusAsync(int id, [FromBody] TransactionStatusDto transactionStatusModel)
    {
        var authors = await _transactionStatusRepository.UpdateTransactionStatusAsync(id,transactionStatusModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveTransactionStatusAsync(int id)
    {
        var authors = await _transactionStatusRepository.RemoveTransactionStatusAsync(id);
        return Ok(authors);
    }
}