using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Repositories;

public class NavbarRepository
{
    private readonly MangaFigureContext _dbContext;
    
    public NavbarRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Navbar>> GetAllNavrbarsAsync()
    {
        var authors = await _dbContext.Navbars.AsQueryable().AsNoTracking().ToListAsync();
        return authors;
    }

    public async Task<Navbar> AddNavbarAsync(NavbarDto navbarModel)
    {
        var newNavbar = new Navbar()
        {
            Name = navbarModel.Name,
            Meta = navbarModel.Meta,
            Active = navbarModel.Active,
            Order = navbarModel.Order,
            CreateAt = navbarModel.CreateAt,
        };
        await _dbContext.Navbars.AddAsync(newNavbar);
        await _dbContext.SaveChangesAsync();
        return newNavbar;
    }
}