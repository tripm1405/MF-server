using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly TestRepository _Repository;

    public TestController(TestRepository Repository)
    {
        _Repository = Repository;
    }
    
    [HttpGet("")] 
    public async Task<IActionResult> GetNavbarAuthor()
    {
        var authors = await _Repository.GetTestAsync();
        return Ok(authors); 
    }
}