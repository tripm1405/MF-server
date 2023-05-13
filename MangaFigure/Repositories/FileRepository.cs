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

    public async Task<Object> UploadFileAsync(string table, IFormFile file)
    {
        if (table == "ProductImage")
        {
            var filePath = Path.Combine(Config.IN_PRODUCTS, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ProductImage productImage = new ProductImage()
            {
                Link = file.FileName,
            };

            await _dbContext.ProductImages.AddAsync(productImage);

            await _dbContext.SaveChangesAsync();

            return productImage;
        }
        else if (table == "AnnounceImage")
        {
            var filePath = Path.Combine(Config.IN_ANNOUNCES, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return file.FileName;
        }

        string inPath = Config.IN_LOGOS;

        string pathFile = Path.Combine(inPath, file.FileName);

        using (var stream = new FileStream(pathFile, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Task.Run(() => "ok");


        throw new Exception($"Bad request");
    }
}

public class Tmp
{
    public string? Table { get; set; }
    public string? File { get; set; }
}