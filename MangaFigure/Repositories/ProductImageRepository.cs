using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class ProductImageRepository
{
    private readonly MangaFigureContext _dbContext;

    public ProductImageRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductImage>> GetProductImageAsync()
    {
        var data = await _dbContext.ProductImages.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<ProductImage> AddProductImageAsync(ProductImageDto productImageModel)
    {
        var newProductImage = new ProductImage()
        {
            Product = productImageModel.Product,
            Link = productImageModel.Link,
            Meta = productImageModel.Meta,
            Order = productImageModel.Order,
            Active = productImageModel.Active, 
            CreateAt = productImageModel.CreateAt,
        };
        await _dbContext.ProductImages.AddAsync(newProductImage);
        await _dbContext.SaveChangesAsync();
        return newProductImage;
    }

    public async Task<ProductImage> UpdateProductImageAsync(int productImageId, ProductImageDto productImageModel)
    {
        var productImage = await _dbContext.ProductImages.FindAsync(productImageId);

        if (productImage == null)
        {
            throw new Exception($"Not found author with id: {productImageId}");
        }
        productImage.Product = productImageModel.Product;
        productImage.Link = productImageModel.Link;
        productImage.Meta = productImageModel.Meta;
        productImage.Active = productImageModel.Active;
        productImage.Order = productImageModel.Order;
        productImage.CreateAt = productImageModel.CreateAt;

        _dbContext.ProductImages.Update(productImage);

        await _dbContext.SaveChangesAsync();
        return productImage;

    }

    public async Task<ProductImage> RemoveProductImageAsync(int productImageId)
    {
        var productImage = await _dbContext.ProductImages.FindAsync(productImageId);

        if (productImage == null)
        {
            throw new Exception($"Not found author with id: {productImageId}");
        }

        _dbContext.ProductImages.Remove(productImage);

        await _dbContext.SaveChangesAsync();
        return productImage;

    }

}