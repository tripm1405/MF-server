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
        var data = await _customerRepository.GetCustomerAsync();
        return Ok(data);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerByIdAsync(int id)
    {
        var data = await _customerRepository.GetCustomerByIdAsync(id);
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewCustomerAsync([FromBody] CustomerDto customerModel)
    {
        var data = await _customerRepository.AddCustomerAsync(customerModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] CustomerDto customerModel)
    {
        var data = await _customerRepository.UpdateCustomerAsync(id,customerModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveCustomerAsync(int id)
    {
        var data = await _customerRepository.RemoveCustomerAsync(id);
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> GetCustomerWithBody([FromBody] CustomerDto body)
    {
        var data = await _customerRepository.GetCustomerWithBodyAsync(body);
        return Ok(data);
    }
}