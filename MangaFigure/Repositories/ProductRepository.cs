using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace MangaFigure.Repositories;

public class ProductRepository
{
    private readonly MangaFigureContext _dbContext;
    
    public ProductRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public class fileUploadAPI
    {
        public IFormFile files { get; set; }
    }

    public async Task<Product> AddProductAsync(ProductDto Product)
    {
        var newProduct = new Product()
        {
            Name = Product.Name,
            Description = Product.Description,
            Image = Product.Image,
            Type = Product.Type,
            Catalog = Product.Catalog,
            Price = Product.Price,
            Discount = Product.Discount,
            Amount = Product.Amount,
            Meta = Product.Meta,
            Active = Product.Active,
        };
        await _dbContext.Products.AddAsync(newProduct);
        await _dbContext.SaveChangesAsync();

        if (newProduct.Image != null)
        {
            var productImage = await _dbContext.ProductImages.FirstOrDefaultAsync(t => t.Id == newProduct.Image);

            productImage.Product = Product.Id;

            _dbContext.ProductImages.Update(productImage);

            await _dbContext.SaveChangesAsync();
        }

        return newProduct;
    }

    public async Task<Product> UpdateProductAsync(string meta, ProductDto Product)
    {
        var newProduct = await _dbContext.Products.FirstOrDefaultAsync(t => t.Meta == meta);

        if (newProduct == null)
        {
            throw new Exception("Bad request");
        }

        if (Product.Name != null)
        {
            newProduct.Name = Product.Name;
        }
        if (Product.Description != null)
        {
            newProduct.Description = Product.Description;
        }
        if (Product.Type != null)
        {
            newProduct.Type = Product.Type;
        }
        if (Product.Catalog != null)
        {
            newProduct.Catalog = Product.Catalog;
        }
        if (Product.Amount != null)
        {
            newProduct.Amount = Product.Amount;
        }
        if (Product.Price != null)
        {
            newProduct.Price = Product.Price;
        }
        if (Product.Discount != null)
        {
            newProduct.Discount = Product.Discount;
        }
        if (Product.Active != null)
        {
            newProduct.Active = Product.Active;
        }
        if (Product.Image != null)
        {
            newProduct.Image = Product.Image;
        }

        _dbContext.Products.Update(newProduct);
        await _dbContext.SaveChangesAsync();


        if (Product.Image != null)
        {
            var productImage = await _dbContext.ProductImages.FirstOrDefaultAsync(t => t.Id == newProduct.Image);

            productImage.Product = newProduct.Id;

            _dbContext.ProductImages.Update(productImage);

            await _dbContext.SaveChangesAsync();
        }

        return newProduct;
    }

    public async Task<List<ProductsWithImageSrcDto>> GetProductsAsync()
    {
        var data = from product in _dbContext.Products
                   join productImage in _dbContext.ProductImages on product.Image equals productImage.Id
                   select new ProductsWithImageSrcDto ()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Image = product.Image,
                        Type = product.Type,
                        Catalog = product.Catalog,
                        Price = product.Price,
                        Discount = product.Discount,
                        Amount = product.Amount,
                        Meta = product.Meta,
                        Active = product.Active,
                        Order = product.Order,
                        CreateAt = product.CreateAt,
                        SrcImg = "https://localhost:7114/" + "/Uploads/Products/" + productImage.Link
                    };


        return await data

            .OrderByDescending(t => t.CreateAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<ProductsWithImageSrcDto>> GetProductsWithBodyAsync(ProductBodyDto body)
    {
        var data = from product in _dbContext.Products
                   join productImage in _dbContext.ProductImages on product.Image equals productImage.Id
                   join catalog in _dbContext.Catalogs on product.Catalog equals catalog.Id
                   orderby product.Id descending
                   select new ProductsWithImageSrcDto()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       Description = product.Description,
                       Image = product.Image,
                       Type = product.Type,
                       Catalog = product.Catalog,
                       Price = product.Price,
                       Discount = product.Discount,
                       Amount = product.Amount,
                       Meta = product.Meta,
                       Active = product.Active,
                       Order = product.Order,
                       CreateAt = product.CreateAt,
                       SrcImg = Config.OUT_PRODUCTS + productImage.Link,
                       CatalogMeta = catalog.Meta
                   };

        if (body.Type != null)
        {
            data = data.Where(product => product.Type == body.Type);
        }

        if (body.CatalogMeta != null)
        {
            data = data.Where(product => product.CatalogMeta == body.CatalogMeta);
        }

        if (body.Take != null) {
            data = data.Take((int) body.Take);
        }

        return await data
            .OrderByDescending(t => t.CreateAt)
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ProductsWithImageSrcDto> GetProductAsync(string meta)
    {
        var data = from product in _dbContext.Products
                   join productImage in _dbContext.ProductImages on product.Image equals productImage.Id
                   where product.Meta == meta
                   select new ProductsWithImageSrcDto()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       Description = product.Description,
                       Image = product.Image,
                       Type = product.Type,
                       Catalog = product.Catalog,
                       Price = product.Price,
                       Discount = product.Discount,
                       Amount = product.Amount,
                       Meta = product.Meta,
                       Active = product.Active,
                       Order = product.Order,
                       CreateAt = product.CreateAt,
                       SrcImg = Config.OUT_PRODUCTS + productImage.Link
                   };

        return await data
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<ProductPageData> GetProductPageAsync(ProductPageBodyDto body)
    {
        int page = (int)(body.Page != null && (int)body.Page > 0? body.Page : 1);
        int pageSize = (int)(body.PageSize != null && (int)body.PageSize > 0 ? body.PageSize : 10);
        
        return new ProductPageData()
        {
            Products = await (from product in _dbContext.Products
                              join productImage in _dbContext.ProductImages on product.Image equals productImage.Id
                              orderby product.Id descending
                              select new ProductsWithImageSrcDto()
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  Description = product.Description,
                                  Image = product.Image,
                                  Type = product.Type,
                                  Catalog = product.Catalog,
                                  Price = product.Price,
                                  Discount = product.Discount,
                                  Amount = product.Amount,
                                  Meta = product.Meta,
                                  Active = product.Active,
                                  Order = product.Order,
                                  CreateAt = product.CreateAt,
                                  SrcImg = Config.OUT_PRODUCTS + productImage.Link
                              })
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .OrderByDescending(t => t.CreateAt)
                              .AsNoTracking()
                              .ToListAsync(),
            Pages = ((from product in _dbContext.Products select product).Count() / pageSize) + 1
        };
    }

    public async Task<Product> DelProductAsync(string meta)
    {
        Product? product = await _dbContext.Products.FirstOrDefaultAsync(t => t.Meta == meta);

        List<ProductImage> productImages = await _dbContext.ProductImages.Where(t => t.Product == product.Id).ToListAsync();

        foreach(ProductImage productImage in productImages)
        {
            _dbContext.ProductImages.Remove(productImage);
            await _dbContext.SaveChangesAsync();
        }

        _dbContext.Products.Remove(product);

        return product;
    }
}

public class ProductPageData
{
    public List<ProductsWithImageSrcDto>? Products { get; set; }
    public int? Pages { get; set; }
}