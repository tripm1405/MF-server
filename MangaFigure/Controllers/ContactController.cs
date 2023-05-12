using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly ContactRepository _contactRepository;

    public ContactController(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetContactAsync()
    {
        var data = await _contactRepository.GetContactAsync();
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewContactAsync([FromBody] ContactDto contactModel)
    {
        var data = await _contactRepository.AddContactAsync(contactModel);
        return Ok(data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateContactAsync(int id, [FromBody] ContactDto contactModel)
    {
        var data = await _contactRepository.UpdateContactAsync(id,contactModel);
        return Ok(data);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveContactAsync(int id)
    {
        var data = await _contactRepository.RemoveContactAsync(id);
        return Ok(data);
    }
}