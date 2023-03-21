using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
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
        var authors = await _announcementRepository.GetAnnouncementAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewAnnouncementAsync([FromBody] AnnouncementDto announcementModel)
    {
        var authors = await _announcementRepository.AddAnnouncementAsync(announcementModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAnnouncementAsync(int id, [FromBody] AnnouncementDto announcementModel)
    {
        var authors = await _announcementRepository.UpdateAnnouncementAsync(id,announcementModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveAnnouncementAsync(int id)
    {
        var authors = await _announcementRepository.RemoveAnnouncementAsync(id);
        return Ok(authors);
    }
}