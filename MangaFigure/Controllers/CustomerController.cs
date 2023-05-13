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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetCustomerByIdAsync(int id)
    {
        var data = await _customerRepository.GetCustomerByIdAsync(id);
        return Ok(data);
    }

    [HttpPost("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> AddNewCustomerAsync([FromBody] CustomerDto customerModel)
    {
        var data = await _customerRepository.AddCustomerAsync(customerModel);
        return Ok(data);
    }
    
    [HttpPost("change-password/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> ChangePasswordAsync(int id, ChangePasswordDto body)
    {
        int userId = int.Parse(this.User.Claims.First(i => i.Type == "id").Value);

        if (userId != id) {
            throw new Exception("Lỗi!!!");
        }
        
        var data = await _customerRepository.ChangePassword(id, body);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] CustomerDto customerModel)
    {
        int userId = int.Parse(this.User.Claims.First(i => i.Type == "id").Value);

        if (userId != id) {
            throw new Exception("Lỗi!!!");
        }
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