using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerRepository _customerRepository;

    public CustomerController(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetCustomerAsync()
    {
        var authors = await _customerRepository.GetCustomerAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewCustomerAsync([FromBody] CustomerDto customerModel)
    {
        var authors = await _customerRepository.AddCustomerAsync(customerModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] CustomerDto customerModel)
    {
        var authors = await _customerRepository.UpdateCustomerAsync(id,customerModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveCustomerAsync(int id)
    {
        var authors = await _customerRepository.RemoveCustomerAsync(id);
        return Ok(authors);
    }
}