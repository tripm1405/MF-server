using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        var authors = await _navbarRepository.GetAllNavrbarsAsync();
        return Ok(authors); 
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> AddNewNavbar([FromBody] NavbarDto navbarModel)
    {
        var newNavbar = await _navbarRepository.AddNavbarAsync(navbarModel);
        return Ok(newNavbar);
    }
}