using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "2")]
    public async Task<IActionResult> AddNewTransactionAsync([FromBody] TransactionCreateReqDto transactionModel)
    {
        var data = await _transactionRepository.AddTransactionAsync(transactionModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> UpdateTransactionAsync(int id, [FromBody] TransactionDto transactionModel)
    {

        int userId = int.Parse(this.User.Claims.First(i => i.Type == "id").Value);
        int userRole = int.Parse(this.User.Claims.First(i => i.Type == ClaimTypes.Role).Value);

        var data = await _transactionRepository.UpdateTransactionAsync(userId, userRole, id, transactionModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveTransactionAsync(int id)
    {
        var data = await _transactionRepository.RemoveTransactionAsync(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> GetEmployeeWithBodyAsync([FromBody] TransactionDto body)
    {
        var data = await _transactionRepository.GetTransactionsWithBodyAsync(body);
        return Ok(data);
    }
}