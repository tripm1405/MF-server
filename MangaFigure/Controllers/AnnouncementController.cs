using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementController : ControllerBase
{
    private readonly AnnouncementRepository _announcementRepository;

    public AnnouncementController(AnnouncementRepository announcementRepository)
    {
        _announcementRepository = announcementRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAnnouncementAsync()
    {
        var data = await _announcementRepository.GetAnnouncementAsync();
        return Ok(data);
    }

    [HttpGet("{meta}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetAnnouncementWithIdAsync(string meta)
    {
        var data = await _announcementRepository.GetAnnouncementWithMetaAsync(meta);
        return Ok(data);
    }

    [HttpPost("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> AddNewAnnouncementAsync([FromBody] AnnouncementDto announcementModel)
    {
        var data = await _announcementRepository.AddAnnouncementAsync(announcementModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> UpdateAnnouncementAsync(int id, [FromBody] AnnouncementDto announcementModel)
    {
        var data = await _announcementRepository.UpdateAnnouncementAsync(id,announcementModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0")]
    public async Task<IActionResult> RemoveAnnouncementAsync(int id)
    {
        var data = await _announcementRepository.RemoveAnnouncementAsync(id);
        return Ok(data);
    }
}