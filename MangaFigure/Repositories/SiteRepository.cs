using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace MangaFigure.Repositories;

public class SiteRepository
{
    private readonly MangaFigureContext _dbContext;
    
    public SiteRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> PostSignInByCustomerAsync(Customer customer)
    {
        var signIn = from t in _dbContext.Customers where t.Username == customer.Username select t;
        var account = signIn.FirstOrDefault();
        if (account == null)
        {
            return null;
        }

        if(BCrypt.Net.BCrypt.Verify(customer.Password, account.Password))
        {
            return account;
        }

        return null;
    }

    public async Task<Employee> PostSignInByEmployeeAsync(Employee employee)
    {
        var signIn = from t in _dbContext.Employees where t.Username == employee.Username select t;
        var account = signIn.FirstOrDefault();
        if (account == null)
        {
            return null;
        }

        if (BCrypt.Net.BCrypt.Verify(employee.Password, account.Password))
        {
            return account;
        }

        return null;
    }

    public async Task<Customer> PostSignUpByCustomerAsync(CustomerDto customer)
    {
        var checkExist = from t in _dbContext.Customers where t.Username == customer.Username select t;
        var account = checkExist.FirstOrDefault();
        if (account != null)
        {
            return null;
        }
        
        var newCustomer = new Customer()
        {
            Name = customer.Name,
            Username = customer.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(customer.Password),
            Email = customer.Email,
            Phone = customer.Phone,
            Address = customer.Address,
            Birthday = customer.Birthday,
            Meta = customer.Meta
        };
        await _dbContext.Customers.AddAsync(newCustomer);
        await _dbContext.SaveChangesAsync();
        return newCustomer;
    }
    public async Task<List<Header>> GetHeaderAsync()
    {
        var data = await _dbContext.Headers.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<List<HeaderDto>> GetHeaderWithBodyAsync(HeaderDto body)
    {
        IQueryable<HeaderDto> data = from header in _dbContext.Headers
                   select new HeaderDto() 
                   { 
                        Description = header.Description,
                        Logo = "https://localhost:7114/" + "Uploads/Logos/" + header.Logo,
                        Meta = header.Meta,
                        Active = header.Active,
                        Order = header.Order,
                        CreateAt = header.CreateAt
                   };

        if (body.Newest != null)
        {
            if ((bool) body.Newest)
            {
                data = data.Take(1);
            }
        }

        return await data.AsQueryable().AsNoTracking().ToListAsync();
    } 

    public async Task<Header> AddHeaderAsync(HeaderDto headerModel)
    {
        var newHeader = new Header()
        {
            Description = headerModel.Description,
            Logo = headerModel.Logo,
            Meta = headerModel.Meta,
            Active = headerModel.Active,
            Order = headerModel.Order,
            CreateAt = headerModel.CreateAt,
        };
        await _dbContext.Headers.AddAsync(newHeader);
        await _dbContext.SaveChangesAsync();
        return newHeader;
    }

    public async Task<Header> UpdateHeaderAsync(int headerId, HeaderDto headerModel)
    {
        var header = await _dbContext.Headers.FindAsync(headerId);

        if (header == null)
        {
            throw new Exception($"Not found author with id: {headerId}");
        }
        header.Description = headerModel.Description;
        header.Logo = headerModel.Logo;
        header.Meta = headerModel.Meta;
        header.Order = headerModel.Order;
        header.CreateAt = headerModel.CreateAt;
        header.Active = headerModel.Active;

        _dbContext.Headers.Update(header);

        await _dbContext.SaveChangesAsync();
        return header;

    }

    public async Task<Header> RemoveHeaderAsync(int headerId)
    {
        var header = await _dbContext.Headers.FindAsync(headerId);

        if (header == null)
        {
            throw new Exception($"Not found author with id: {headerId}");
        }

        _dbContext.Headers.Remove(header);

        await _dbContext.SaveChangesAsync();
        return header;

    }

    public async Task<List<SlideShow>> GetSlideShowAsync()
    {
        var data = await _dbContext.SlideShows.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }
    public async Task<SlideShow> AddSlideShowAsync(SlideShowDto slideShowModel)
    {
        var newSlideShow = new SlideShow()
        {
            Image = slideShowModel.Image,
            Meta = slideShowModel.Meta,
            Active = slideShowModel.Active,
            Order = slideShowModel.Order,
            CreateAt = slideShowModel.CreateAt,
        };
        await _dbContext.SlideShows.AddAsync(newSlideShow);
        await _dbContext.SaveChangesAsync();
        return newSlideShow;
    }

    public async Task<SlideShow> UpdateSlideShowAsync(int slideShowId, SlideShowDto slideShowModel)
    {
        var slideShow = await _dbContext.SlideShows.FindAsync(slideShowId);

        if (slideShow == null)
        {
            throw new Exception($"Not found author with id: {slideShowId}");
        }
        slideShow.Image = slideShowModel.Image;
        slideShow.Meta = slideShowModel.Meta;
        slideShow.Order = slideShowModel.Order;
        slideShow.CreateAt = slideShowModel.CreateAt;
        slideShow.Active = slideShowModel.Active;

        _dbContext.SlideShows.Update(slideShow);

        await _dbContext.SaveChangesAsync();
        return slideShow;

    }

    public async Task<SlideShow> RemoveSlideShowAsync(int slideShowId)
    {
        var slideShow = await _dbContext.SlideShows.FindAsync(slideShowId);

        if (slideShow == null)
        {
            throw new Exception($"Not found author with id: {slideShowId}");
        }

        _dbContext.SlideShows.Remove(slideShow);

        await _dbContext.SaveChangesAsync();
        return slideShow;
    }

    public async Task<List<Catalog>> GetCatalogAsync()
    {
        return await _dbContext.Catalogs.AsQueryable().AsNoTracking().ToListAsync(); ;
    }

    public async Task<List<Catalog>> GetCatalogWithBodyAsync(CatalogDto body)
    {
        var data = _dbContext.Catalogs;
        if (body.Type != null)
        {
            data.Where(catalog => catalog.Type == body.Type);
        }
        return await data.AsQueryable().AsNoTracking().ToListAsync(); ;
    }

    public async Task<Catalog> AddCatalogAsync(CatalogDto catalogModel)
    {
        var newCatalog = new Catalog()
        {
            Name = catalogModel.Name,
            Type = catalogModel.Type,
            Meta = catalogModel.Meta,
            Active = catalogModel.Active,
            Order = catalogModel.Order,
            CreateAt = catalogModel.CreateAt,
        };
        await _dbContext.Catalogs.AddAsync(newCatalog);
        await _dbContext.SaveChangesAsync();
        return newCatalog;
    }

    public async Task<Catalog> UpdateCatalogAsync(int catalogId, CatalogDto catalogModel)
    {
        var catalog = await _dbContext.Catalogs.FindAsync(catalogId);

        if (catalog == null)
        {
            throw new Exception($"Not found author with id: {catalogId}");
        }
        catalog.Name = catalogModel.Name;
        catalog.Type = catalogModel.Type;
        catalog.Meta = catalogModel.Meta;
        catalog.Order = catalogModel.Order;
        catalog.CreateAt = catalogModel.CreateAt;
        catalog.Active = catalogModel.Active;

        _dbContext.Catalogs.Update(catalog);

        await _dbContext.SaveChangesAsync();
        return catalog;

    }

    public async Task<Catalog> RemoveCatalogAsync(int catalogId)
    {
        var catalog = await _dbContext.Catalogs.FindAsync(catalogId);

        if (catalog == null)
        {
            throw new Exception($"Not found author with id: {catalogId}");
        }

        _dbContext.Catalogs.Remove(catalog);

        await _dbContext.SaveChangesAsync();
        return catalog;

    }


    public async Task<List<Footer>> GetFooterWithTypeAsync()
    {
        var data = _dbContext.Footers;
        return await data.AsQueryable().AsNoTracking().ToListAsync(); ;
    }

    public async Task<Footer> AddFooterAsync(FooterDto footerModel)
    {
        var newFooter = new Footer()
        {
            Description = footerModel.Description,
            Logo = footerModel.Logo,
            Meta = footerModel.Meta,
            Active = footerModel.Active,
            Order = footerModel.Order,
            CreateAt = footerModel.CreateAt,
        };
        await _dbContext.Footers.AddAsync(newFooter);
        await _dbContext.SaveChangesAsync();
        return newFooter;
    }

    public async Task<Footer> UpdateFooterAsync(int footerId, FooterDto footerModel)
    {
        var footer = await _dbContext.Footers.FindAsync(footerId);

        if (footer == null)
        {
            throw new Exception($"Not found author with id: {footerId}");
        }
        footer.Description = footerModel.Description;
        footer.Logo = footerModel.Logo;
        footer.Meta = footerModel.Meta;
        footer.Order = footerModel.Order;
        footer.CreateAt = footerModel.CreateAt;
        footer.Active = footerModel.Active;

        _dbContext.Footers.Update(footer);

        await _dbContext.SaveChangesAsync();
        return footer;

    }

    public async Task<Footer> RemoveFooterAsync(int footerId)
    {
        var footer = await _dbContext.Footers.FindAsync(footerId);

        if (footer == null)
        {
            throw new Exception($"Not found author with id: {footerId}");
        }

        _dbContext.Footers.Remove(footer);

        await _dbContext.SaveChangesAsync();
        return footer;
    }
}