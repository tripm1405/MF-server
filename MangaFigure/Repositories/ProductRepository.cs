using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Repositories;

public class ProductRepository
{
    private readonly MangaFigureContext _dbContext;
    
    public ProductRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductsWithImageSrcDto>> GetProductsAsync()
    {
        var model = from product in _dbContext.Products
                    join productImage in _dbContext.ProductImages on product.Image equals productImage.Id
                    select new ProductsWithImageSrcDto ()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Image = "https://localhost:7114" + "/Uploads/Products/" + productImage.Link,
                        Type = product.Type,
                        Catalog = product.Catalog,
                        Price = product.Price,
                        Discount = product.Discount,
                        Amount = product.Amount,
                        Sale = product.Sale,
                        Meta = product.Meta,
                        Active = product.Active,
                        Order = product.Order,
                        CreateAt = product.CreateAt
                    };


        return model.ToList();
    }

    public async Task<List<ProductsWithImageSrcDto>> GetProductsWithBodyAsync(ProductDto body)
    {
        var data = from product in _dbContext.Products
                                   join productImage in _dbContext.ProductImages on product.Image equals productImage.Id
                                   select new ProductsWithImageSrcDto()
                                   {
                                       Id = product.Id,
                                       Name = product.Name,
                                       Description = product.Description,
                                       Image = productImage.Link,
                                       Type = product.Type,
                                       Catalog = product.Catalog,
                                       Price = product.Price,
                                       Discount = product.Discount,
                                       Amount = product.Amount,
                                       Sale = product.Sale,
                                       Meta = product.Meta,
                                       Active = product.Active,
                                       Order = product.Order,
                                       CreateAt = product.CreateAt
                                   };

        if (body.Type != null)
        {
            data = data.Where(product => product.Type == body.Type);
        }

        if (body.Catalog != null)
        {
            data = data.Where(product => product.Catalog == body.Catalog);
        }

        return await data.AsQueryable().AsNoTracking().ToListAsync();
    }
}