using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class ProductReviewRepository
{
    private readonly MangaFigureContext _dbContext;

    public ProductReviewRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductReview>> GetProductReviewAsync()
    {
        var data = await _dbContext.ProductReviews.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<ProductReview> AddProductReviewAsync(ProductReviewDto productReviewModel)
    {
        var newProductReview = new ProductReview()
        {
            Product = productReviewModel.Product,
            Customer = productReviewModel.Customer,
            Rate = productReviewModel.Rate,
            Content = productReviewModel.Content,
            Meta = productReviewModel.Meta,
            Order = productReviewModel.Order,
            Active = productReviewModel.Active, 
            CreateAt = productReviewModel.CreateAt,
        };
        await _dbContext.ProductReviews.AddAsync(newProductReview);
        await _dbContext.SaveChangesAsync();
        return newProductReview;
    }

    public async Task<ProductReview> UpdateProductReviewAsync(int productReviewId, ProductReviewDto productReviewModel)
    {
        var productReview = await _dbContext.ProductReviews.FindAsync(productReviewId);

        if (productReview == null)
        {
            throw new Exception($"Not found author with id: {productReviewId}");
        }
        productReview.Product = productReviewModel.Product;
        productReview.Customer  = productReviewModel.Customer;
        productReview.Rate = productReviewModel.Rate;
        productReview.Content = productReview.Content;
        productReview.Meta = productReviewModel.Meta;
        productReview.Active = productReviewModel.Active;
        productReview.Order = productReviewModel.Order;
        productReview.CreateAt = productReviewModel.CreateAt;

        _dbContext.ProductReviews.Update(productReview);

        await _dbContext.SaveChangesAsync();
        return productReview;

    }

    public async Task<ProductReview> RemoveProductReviewAsync(int productReviewId)
    {
        var productReview = await _dbContext.ProductReviews.FindAsync(productReviewId);

        if (productReview == null)
        {
            throw new Exception($"Not found author with id: {productReviewId}");
        }

        _dbContext.ProductReviews.Remove(productReview);

        await _dbContext.SaveChangesAsync();
        return productReview;

    }

}