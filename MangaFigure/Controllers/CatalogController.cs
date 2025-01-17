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
public class CatalogController : ControllerBase
{
    private readonly CatalogRepository _repository;

    public CatalogController(CatalogRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Gets()
    {
        var data = await _repository.Gets();

        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWithId(int id)
    {
        var data = await _repository.GetWithId(id);

        return Ok(data);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> Create([FromBody] Catalog body)
    {
        var data = await _repository.Create(body);

        return Ok(data);
    }

    [HttpPost("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> Update(int id, [FromBody] Catalog body)
    {
        var data = await _repository.Update(id, body);

        return Ok(data);
    }
}