using MangaFigure.DTOs;
using MangaFigure.Models;
using MangaFigure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly FileRepository _fileRepository;

    public FileController(FileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    [HttpPost("{table}")]
    public async Task<IActionResult> Upload(string table, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file selected.");
        }

        var data = await _fileRepository.UploadFileAsync(table, file);

        return Ok(data);
    }
}