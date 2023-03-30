using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class FileRepository
{
    private readonly MangaFigureContext _dbContext;

    public FileRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var filePath = Path.Combine(Config.IN_PRODUCTS, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;
    }
}