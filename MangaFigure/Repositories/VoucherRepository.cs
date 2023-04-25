using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class VoucherRepository
{
    private readonly MangaFigureContext _dbContext;

    public VoucherRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Voucher>> GetVoucherAsync()
    {
        var data = await _dbContext.Vouchers.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<Voucher> AddVoucherAsync(VoucherDto voucherModel)
    {
        var newVoucher = new Voucher()
        {
            Name = voucherModel.Name,
            Description = voucherModel.Description,
            Type = voucherModel.Type,
            Money = voucherModel.Money,
            Percent = voucherModel.Percent,
            Condition = voucherModel.Condition,
            Meta = voucherModel.Meta,
            Active = voucherModel.Active,
            Order = voucherModel.Order,
            CreateAt = voucherModel.CreateAt,
        };
        await _dbContext.Vouchers.AddAsync(newVoucher);
        await _dbContext.SaveChangesAsync();
        return newVoucher;
    }

    public async Task<Voucher> UpdateVoucherAsync(int voucherId, VoucherDto voucherModel)
    {
        var voucher = await _dbContext.Vouchers.FindAsync(voucherId);

        if (voucher == null)
        {
            throw new Exception($"Not found author with id: {voucherId}");
        }
        voucher.Description = voucherModel.Description;
        voucher.Type = voucherModel.Type;
        voucher.Money = voucherModel.Money;
        voucher.Percent = voucherModel.Percent;
        voucher.Name = voucherModel.Name;
        voucher.Meta = voucherModel.Meta;
        voucher.Active = voucherModel.Active;
        voucher.Order = voucherModel.Order;
        voucher.CreateAt = voucherModel.CreateAt;

        _dbContext.Vouchers.Update(voucher);

        await _dbContext.SaveChangesAsync();
        return voucher;

    }

    public async Task<Voucher> RemoveVoucherAsync(int voucherId)
    {
        var Voucher = await _dbContext.Vouchers.FindAsync(voucherId);

        if (Voucher == null)
        {
            throw new Exception($"Not found author with id: {voucherId}");
        }

        _dbContext.Vouchers.Remove(Voucher);

        await _dbContext.SaveChangesAsync();
        return Voucher;

    }

}