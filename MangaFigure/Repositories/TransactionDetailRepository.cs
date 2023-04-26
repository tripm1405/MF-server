using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class TransactionDetailRepository
{
    private readonly MangaFigureContext _dbContext;

    public TransactionDetailRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TransactionDetail>> GetTransactionDetailAsync()
    {
        var data = await _dbContext.TransactionDetails.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<TransactionDetail> AddTransactionDetailAsync(TransactionDetailDto transactionDetailModel)
    {
        var newTransactionDetail = new TransactionDetail()
        {
            Product = transactionDetailModel.Product,
            Transaction = transactionDetailModel.Transaction,
            Meta = transactionDetailModel.Meta,
            Amount = transactionDetailModel.Amount,
            Active = transactionDetailModel.Active,
            Order = transactionDetailModel.Order,
            CreateAt = transactionDetailModel.CreateAt,
        };
        await _dbContext.TransactionDetails.AddAsync(newTransactionDetail);
        await _dbContext.SaveChangesAsync();
        return newTransactionDetail;
    }

    public async Task<TransactionDetail> UpdateTransactionDetailAsync(int transactionDetailId, TransactionDetailDto transactionDetailModel)
    {
        var transactionDetail = await _dbContext.TransactionDetails.FindAsync(transactionDetailId);

        if (transactionDetail == null)
        {
            throw new Exception($"Not found author with id: {transactionDetailId}");
        }
        transactionDetail.Product = transactionDetailModel.Product;
        transactionDetail.Transaction = transactionDetailModel.Transaction;
        transactionDetail.Meta = transactionDetailModel.Meta;
        transactionDetail.Active = transactionDetailModel.Active;
        transactionDetail.Amount = transactionDetailModel.Amount;
        transactionDetail.Order = transactionDetailModel.Order;
        transactionDetail.CreateAt = transactionDetailModel.CreateAt;

        _dbContext.TransactionDetails.Update(transactionDetail);

        await _dbContext.SaveChangesAsync();
        return transactionDetail;

    }

    public async Task<TransactionDetail> RemoveTransactionDetailAsync(int transactionDetailId)
    {
        var transactionDetail = await _dbContext.TransactionDetails.FindAsync(transactionDetailId);

        if (transactionDetail == null)
        {
            throw new Exception($"Not found author with id: {transactionDetailId}");
        }

        _dbContext.TransactionDetails.Remove(transactionDetail);

        await _dbContext.SaveChangesAsync();
        return transactionDetail;

    }

}