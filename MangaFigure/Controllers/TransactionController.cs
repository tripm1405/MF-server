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
        var data = await _transactionRepository.GetTransactionAsync();
        return Ok(data);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionByMetaAsync(int id)
    {
        var transactions = await _transactionRepository.GetTransactionByMetaAsync(id);
        return Ok(transactions);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewTransactionAsync([FromBody] TransactionCreateReqDto transactionModel)
    {
        var data = await _transactionRepository.AddTransactionAsync(transactionModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTransactionAsync(int id, [FromBody] TransactionDto transactionModel)
    {
        var data = await _transactionRepository.UpdateTransactionAsync(id,transactionModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveTransactionAsync(int id)
    {
        var data = await _transactionRepository.RemoveTransactionAsync(id);
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> GetEmployeeWithBodyAsync([FromBody] TransactionDto body)
    {
        var data = await _transactionRepository.GetTransactionsWithBodyAsync(body);
        return Ok(data);
    }


    //[HttpGet("detail/{id}")]
    //public async Task<IActionResult> GetEmployeeWithBodyAsync(int id)
    //{
    //    var data = await _transactionRepository.GetTransactionsWithBodyAsync(id);
    //    return Ok(data);
    //}
}