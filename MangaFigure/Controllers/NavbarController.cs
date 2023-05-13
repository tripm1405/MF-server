using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NavbarController : ControllerBase
{
    private readonly NavbarRepository _navbarRepository;

    public NavbarController(NavbarRepository navbarRepository)
    {
        _navbarRepository = navbarRepository;
    }
    
    [HttpGet("")] 
    public async Task<IActionResult> GetNavbarAuthor()
    {
        var data = await _navbarRepository.GetAllNavrbarsAsync();
        return Ok(data);
    }
    
    [HttpPost("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> AddNewNavbar([FromBody] NavbarDto navbarModel)
    {
        var newNavbar = await _navbarRepository.AddNavbarAsync(navbarModel);
        return Ok(newNavbar);
    }
}