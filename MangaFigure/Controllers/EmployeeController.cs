﻿using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
        var data = await _employeeRepository.GetEmployeeAsync();
        return Ok(data);
    }

    [HttpPost("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> AddNewEmployeeAsync([FromBody] EmployeeDto employeeModel)
    {
        var data = await _employeeRepository.AddEmployeeAsync(employeeModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeDto employeeModel)
    {
        var data = await _employeeRepository.UpdateEmployeeAsync(id,employeeModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> RemoveEmployeeAsync(int id)
    {
        var data = await _employeeRepository.RemoveEmployeeAsync(id);
        return Ok(data);
    }

    [HttpPost("")]
    public async Task<IActionResult> GetEmployeeWithBodyAsync([FromBody] EmployeeDto body)
    {
        var data = await _employeeRepository.GetEmployeesWithBodyAsync(body);
        return Ok(data);
    }
}