using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountRepository _Repository;

    public AccountController(AccountRepository Repository)
    {
        _Repository = Repository;
    }
    
    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> PostSignInAsync([FromBody] AccountBody body)
    {
        var data = await _Repository.SignInAsync(body);
        return Ok(data); 
    }

    [HttpPost("check-token")]
    [AllowAnonymous]
    public async Task<IActionResult> PostCheckTokenAsync(string token)
    {
        var data = await _Repository.CheckToken(token);
        return Ok(data);
    }
}