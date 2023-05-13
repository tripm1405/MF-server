using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class TransactionRepository
{
    private readonly MangaFigureContext _dbContext;

    public TransactionRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Transaction>> GetTransactionAsync()
    {
        var data = await _dbContext.Transactions
            .OrderByDescending(t => t.CreateAt)
            .AsNoTracking()
            .ToListAsync();
        return data;
    }
    
    public async Task<Transaction> GetTransactionByMetaAsync(int id)
    {
        var qb = _dbContext.Transactions
            .Include(t => t.EmployeeNavigation)
            .Include(t => t.CustomerNavigation)
            .Include(e => e.TransactionDetails)
                .ThenInclude(t => t.ProductNavigation)
            .Include(e => e.StatusNavigation)
            .Where(e => e.Id == id);
        var res = await qb
            .AsNoTracking().
            FirstOrDefaultAsync();
        return res;
    }

    public async Task<List<Transaction>> GetTransactionsWithBodyAsync(TransactionDto body)
    {
        IQueryable<Transaction> data = _dbContext.Transactions;

        if (body.Customer != null)
        {
            data = data.Where(t => t.Customer == body.Customer);
        }

        if (body.Status != null)
        {
            data = data.Where(t => t.Status == body.Status);
        }

        return await data
            .OrderByDescending(t => t.CreateAt)
            .Include(t => t.CustomerNavigation)
            .Include(t => t.EmployeeNavigation)
            .Include(t => t.StatusNavigation)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Transaction> AddTransactionAsync(TransactionCreateReqDto body)
    {
        try
        {

            var newTransaction = new Transaction()
            {
                Customer = body.Customer,
                Status = 1,
                Address = body.Address,
                Fee = body.Fee
            };

            if (body.Products == null)
            {
                throw new Exception();
            }

            int transactionPrice = 0;
            newTransaction.TransactionDetails = new List<TransactionDetail>();
            foreach (var product in body.Products)
            {
                var productTmp = await _dbContext.Products.FirstOrDefaultAsync(t => t.Id == product.Id);
                if (productTmp == null)
                {
                    throw new Exception();
                }
                productTmp.Amount -= product.Number;
                _dbContext.Products.Update(productTmp);

                newTransaction.TransactionDetails.Add(new TransactionDetail()
                {
                    Transaction = newTransaction.Id,
                    Product = product.Id,
                    Amount = product.Number,
                    Price = productTmp.Price,
                });

                transactionPrice += (int)product.Number * (int)productTmp.Price;
            }

            newTransaction.Price = transactionPrice;

            var carts = await _dbContext.Carts.Where(t => t.Customer == body.Customer).ToListAsync();

            _dbContext.Carts.RemoveRange(carts);

            await _dbContext.Transactions.AddAsync(newTransaction);

            await _dbContext.SaveChangesAsync();

            return newTransaction;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<Transaction> UpdateTransactionAsync(int userId, int userRole, int transactionId, TransactionDto body)
    {

        var transaction = await _dbContext.Transactions.FindAsync(transactionId);

        if (transaction == null)
        {
            throw new Exception($"Not found author with id: {transactionId}");
        }

        Console.WriteLine(1);
        if (body.Status != null)
        {
            Console.WriteLine(2);
            if (body.Status > 5 || body.Status <= transaction.Status)
            {
                Console.WriteLine(3);
                throw new Exception();
            }

            if (userRole == 2)
            {
                Console.WriteLine(4);
                if (body.Status != 5)
                {
                    Console.WriteLine(6);
                    throw new Exception();
                }
            }
            else
            {
                Console.WriteLine(7);
                if (transaction.Status == 1)
                {
                    Console.WriteLine(8);
                    transaction.Employee = userId;
                }
            }
            Console.WriteLine(9);

            transaction.Status = body.Status;
        }

        _dbContext.Transactions.Update(transaction);

        await _dbContext.SaveChangesAsync();
        return transaction;

    }

    public async Task<Transaction> RemoveTransactionAsync(int transactionId)
    {
        var transaction = await _dbContext.Transactions.FindAsync(transactionId);

        if (transaction == null)
        {
            throw new Exception($"Not found author with id: {transactionId}");
        }

        _dbContext.Transactions.Remove(transaction);

        await _dbContext.SaveChangesAsync();
        return transaction;
    }
}