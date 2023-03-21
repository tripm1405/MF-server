using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetEmployeeAsync()
    {
        var authors = await _employeeRepository.GetEmployeeAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewEmployeeAsync([FromBody] EmployeeDto employeeModel)
    {
        var authors = await _employeeRepository.AddEmployeeAsync(employeeModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeDto employeeModel)
    {
        var authors = await _employeeRepository.UpdateEmployeeAsync(id,employeeModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveEmployeeAsync(int id)
    {
        var authors = await _employeeRepository.RemoveEmployeeAsync(id);
        return Ok(authors);
    }
}