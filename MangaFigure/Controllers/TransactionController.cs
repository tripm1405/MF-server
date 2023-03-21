using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionRepository _transactionRepository;

    public TransactionController(TransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetTransactionAsync()
    {
        var authors = await _transactionRepository.GetTransactionAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewTransactionAsync([FromBody] TransactionDto transactionModel)
    {
        var authors = await _transactionRepository.AddTransactionAsync(transactionModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTransactionAsync(int id, [FromBody] TransactionDto transactionModel)
    {
        var authors = await _transactionRepository.UpdateTransactionAsync(id,transactionModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveTransactionAsync(int id)
    {
        var authors = await _transactionRepository.RemoveTransactionAsync(id);
        return Ok(authors);
    }
}