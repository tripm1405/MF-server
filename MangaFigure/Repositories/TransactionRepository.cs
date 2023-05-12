﻿using MangaFigure.DTOs;
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
        var data = await _dbContext.Transactions.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }
    
    public async Task<Transaction> GetTransactionByMetaAsync(int id)
    {
        var qb = _dbContext.Transactions.AsQueryable()
            .Include(e => e.TransactionDetails)
            .Include(e => e.StatusNavigation)
            .Where(e => e.Id == id);
        var res = await qb.AsNoTracking().FirstOrDefaultAsync();
        return res;
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

    public async Task<Transaction> UpdateTransactionAsync(int transactionId, TransactionDto transactionModel)
    {
        var transaction = await _dbContext.Transactions.FindAsync(transactionId);

        if (transaction == null)
        {
            throw new Exception($"Not found author with id: {transactionId}");
        }
        transaction.Employee = transactionModel.Employee;
        transaction.Rate = transactionModel.Rate;
        transaction.Status = transactionModel.Status;
        transaction.Customer = transactionModel.Customer;
        transaction.Meta = transactionModel.Meta;
        transaction.Active = transactionModel.Active;
        transaction.Order = transactionModel.Order;
        transaction.CreateAt = transactionModel.CreateAt;
        transaction.Price = transactionModel.Price;
        transaction.Address = transactionModel.Address;


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

    public async Task<List<MyTransactionDto>> GetTransactionsWithBodyAsync(TransactionDto body)
    {
        var data = from transaction in _dbContext.Transactions
                   join customer in _dbContext.Customers on transaction.Customer equals customer.Id
                   join employee in _dbContext.Employees on transaction.Employee equals employee.Id
                   join transactionStatus in _dbContext.TransactionStatuses on transaction.Status equals transactionStatus.Id
                   orderby transaction.CreateAt descending
                   select new MyTransactionDto()
                   {
                        Id = transaction.Id,
                        Customer = transaction.Customer,
                        CustomerName = customer.Name,
                        Employee = transaction.Employee,
                        EmployeeName = employee.Name,
                        Status = transaction.Status,
                        StatusName = transactionStatus.Content,
                        Rate = transaction.Rate,
                        Meta = transaction.Meta,
                        Active = transaction.Active,
                        Order = transaction.Order,
                        CreateAt = transaction.CreateAt,
                        Price = transaction.Price,
                        Address = transaction.Address,

                   };

        return await data.AsQueryable().AsNoTracking().ToListAsync();
    }

    //public async Task<Transaction> GetTransactionWithIdAsync(int id)
    //{
    //    Transaction transaction = await _dbContext.Transactions.FirstOrDefaultAsync(t => t.Id == id);

    //    if (transaction == null)
    //    {
    //        throw new Exception("Id khong khop");
    //    }

    //    var data = new
    //    {
    //        Id = transaction.Id,
    //        Customer = await Pro,
    //        Employee = transaction.Employee,

    //    }

    //    return ;

    //    await _dbContext.SaveChangesAsync();
    //    return transaction;
    //}
}