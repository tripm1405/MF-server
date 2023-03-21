using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class TransactionStatusRepository
{
    private readonly MangaFigureContext _dbContext;

    public TransactionStatusRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TransactionStatus>> GetTransactionStatusAsync()
    {
        var data = await _dbContext.TransactionStatuses.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<TransactionStatus> AddTransactionStatusAsync(TransactionStatusDto transactionStatusModel)
    {
        var newTransactionStatus = new TransactionStatus()
        {
            Content = transactionStatusModel.Content,
            Meta = transactionStatusModel.Meta,
            Active = transactionStatusModel.Active,
            Order = transactionStatusModel.Order,
            CreateAt = transactionStatusModel.CreateAt,
        };
        await _dbContext.TransactionStatuses.AddAsync(newTransactionStatus);
        await _dbContext.SaveChangesAsync();
        return newTransactionStatus;
    }

    public async Task<TransactionStatus> UpdateTransactionStatusAsync(int transactionStatusId, TransactionStatusDto transactionStatusModel)
    {
        var transactionStatus = await _dbContext.TransactionStatuses.FindAsync(transactionStatusId);

        if (transactionStatus == null)
        {
            throw new Exception($"Not found author with id: {transactionStatusId}");
        }
        transactionStatus.Content = transactionStatusModel.Content;
        transactionStatus.Meta = transactionStatusModel.Meta;
        transactionStatus.Active = transactionStatusModel.Active;
        transactionStatus.Order = transactionStatusModel.Order;
        transactionStatus.CreateAt = transactionStatusModel.CreateAt;

        _dbContext.TransactionStatuses.Update(transactionStatus);

        await _dbContext.SaveChangesAsync();
        return transactionStatus;

    }

    public async Task<TransactionStatus> RemoveTransactionStatusAsync(int transactionStatusId)
    {
        var transactionStatus = await _dbContext.TransactionStatuses.FindAsync(transactionStatusId);

        if (transactionStatus == null)
        {
            throw new Exception($"Not found author with id: {transactionStatusId}");
        }

        _dbContext.TransactionStatuses.Remove(transactionStatus);

        await _dbContext.SaveChangesAsync();
        return transactionStatus;

    }

}