using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class TestRepository
{
    private readonly MangaFigureContext _dbContext;

    public TestRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetTestAsync()
    {
        var product = from p in _dbContext.Products.Include(e => e.ProductImages) select p;

        return product.ToList();
    }
}