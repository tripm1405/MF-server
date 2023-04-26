using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class CatalogRepository
{
    private readonly MangaFigureContext _dbContext;

    public CatalogRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Object> Gets()
    {
        var data = await _dbContext.Catalogs.ToListAsync();

        return data;
    }

    public async Task<Object> GetWithId(int id)
    {
        var data = await _dbContext.Catalogs.FirstOrDefaultAsync(t => t.Id == id);

        return data;
    }

    public async Task<Object> Create(Catalog body)
    {
        await _dbContext.Catalogs.AddAsync(body);

        await _dbContext.SaveChangesAsync();

        return body;
    }

    public async Task<Object> Update(int id, Catalog body)
    {
        var catalog = await _dbContext.Catalogs.FirstOrDefaultAsync(t => t.Id == id);

        if (catalog == null)
        {
            throw new Exception("Id khong khop");
        }

        catalog.Name = body.Name;
        catalog.Type = body.Type;

        _dbContext.Catalogs.Update(catalog);

        await _dbContext.SaveChangesAsync();

        return catalog;
    }
}