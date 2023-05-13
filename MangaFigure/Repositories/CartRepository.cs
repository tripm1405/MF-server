using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class CartRepository
{
    private readonly MangaFigureContext _dbContext;

    public CartRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Cart>> GetCartAsync()
    {
        var data = await _dbContext.Carts.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<List<Cart>> GetCartWithBodyAsync(CartsWithBodyReqDto body)
    {
        IQueryable<Cart> data = _dbContext.Carts;

        if (body.Customer != null)
        {
            data = data.Where(t => t.Customer == body.Customer);
        }

        return await data
            .Include(t => t.ProductNavigation)
                .ThenInclude(t1 => t1.ImageNavigation)
            .AsQueryable()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Cart> AddCartAsync(int userId, CartDto body)
    {
        var cart = await _dbContext.Carts
            .Where(t => t.Product == body.Product && t.Customer == body.Customer)
            .FirstOrDefaultAsync();

        if (cart != null)
        {
            throw new Exception("San pham da co trong gio hang");
        }

        var newCart = new Cart()
        {
            Customer = userId,
            Product = body.Product,
            Meta = body.Meta,
            Active = body.Active,
            Order = body.Order,
            CreateAt = body.CreateAt,
        };
        await _dbContext.Carts.AddAsync(newCart);
        await _dbContext.SaveChangesAsync();
        return newCart;
    }

    public async Task<Cart> UpdateCartAsync(int cartId, CartDto cartModel)
    {
        var cart = await _dbContext.Carts.FindAsync(cartId);

        if (cart == null)
        {
            throw new Exception($"Not found author with id: {cartId}");
        }
        cart.Product = cartModel.Product;
        cart.Customer = cartModel.Customer;
        cart.Meta = cartModel.Meta;
        cart.Active = cartModel.Active;
        cart.Order = cartModel.Order;
        cart.CreateAt = cartModel.CreateAt;

        _dbContext.Carts.Update(cart);

        await _dbContext.SaveChangesAsync();
        return cart;

    }

    public async Task<Cart> RemoveCartAsync(int cartId)
    {
        var cart = await _dbContext.Carts.FindAsync(cartId);

        if (cart == null)
        {
            throw new Exception($"Not found author with id: {cartId}");
        }

        _dbContext.Carts.Remove(cart);

        await _dbContext.SaveChangesAsync();
        return cart;

    }

}