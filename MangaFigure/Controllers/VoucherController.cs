using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoucherController : ControllerBase
{
    private readonly VoucherRepository _voucherRepository;

    public VoucherController(VoucherRepository voucherRepository)
    {
        _voucherRepository = voucherRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetVoucherAsync()
    {
        var authors = await _voucherRepository.GetVoucherAsync();
        return Ok(authors);
    }

    [HttpPost("create")]
    public async Task<IActionResult> AddNewVoucherAsync([FromBody] VoucherDto voucherModel)
    {
        var authors = await _voucherRepository.AddVoucherAsync(voucherModel);
        return Ok(authors);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateVoucherAsync(int id, [FromBody] VoucherDto voucherModel)
    {
        var authors = await _voucherRepository.UpdateVoucherAsync(id,voucherModel);
        return Ok(authors);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> RemoveVoucherAsync(int id)
    {
        var authors = await _voucherRepository.RemoveVoucherAsync(id);
        return Ok(authors);
    }
}