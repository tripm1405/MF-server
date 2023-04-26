using MangaFigure.DTOs;
using MangaFigure.Models;
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
    
    public async Task<Transaction> GetTransactionByMetaAsync(string meta)
    {
        var qb = _dbContext.Transactions.AsQueryable()
            .Include(e => e.TransactionDetails)
            .Include(e => e.StatusNavigation)
            .Where(e => e.Meta == meta);
        var res = await qb.AsNoTracking().FirstOrDefaultAsync();
        return res;
    }

    public async Task<Transaction> AddTransactionAsync(TransactionDto transactionModel)
    {
        var newTransaction = new Transaction()
        {
            Customer = transactionModel.Customer,
            Employee = transactionModel.Employee,
            Status = transactionModel.Status,
            Rate = transactionModel.Rate,
            Meta = transactionModel.Meta,
            Active = transactionModel.Active,
            Order = transactionModel.Order,
            CreateAt = transactionModel.CreateAt,
        };
        await _dbContext.Transactions.AddAsync(newTransaction);
        await _dbContext.SaveChangesAsync();
        return newTransaction;
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
                   };

        return await data.AsQueryable().AsNoTracking().ToListAsync();
    }
}