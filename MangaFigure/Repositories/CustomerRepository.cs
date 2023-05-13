using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Repositories;

public class CustomerRepository
{
    private readonly MangaFigureContext _dbContext;

    public CustomerRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Customer>> GetCustomerAsync()
    {
        var data = await _dbContext.Customers
            .OrderByDescending(t => t.CreateAt)
            .AsNoTracking()
            .ToListAsync();
        return data;
    }
    
    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var data = await _dbContext.Customers.AsQueryable().Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();
        return data;
    }

    public async Task<Customer> AddCustomerAsync(CustomerDto customerModel)
    {
        var newCustomer = new Customer()
        {
            Name = customerModel.Name,
            Username = customerModel.Username,
            Password = customerModel.Password,
            Address = customerModel.Address,
            Phone  = customerModel.Phone,
            Email = customerModel.Email,
            Birthday = customerModel.Birthday,
            Meta = customerModel.Meta,
            Active = customerModel.Active,
            Order = customerModel.Order,
            CreateAt = customerModel.CreateAt,
        };
        await _dbContext.Customers.AddAsync(newCustomer);
        await _dbContext.SaveChangesAsync();
        return newCustomer;
    }

    public async Task<Customer> UpdateCustomerAsync(int customerId, CustomerDto customerModel)
    {
        var customer = await _dbContext.Customers.FindAsync(customerId);

        if (customer == null)
        {
            throw new Exception($"Not found author with id: {customerId}");
        }
        customer.Name = customerModel.Name;
        customer.Address = customerModel.Address;
        customer.Email = customerModel.Email;
        customer.Birthday = customerModel.Birthday;
        customer.Phone = customerModel.Phone;

        _dbContext.Customers.Update(customer);

        await _dbContext.SaveChangesAsync();
        return customer;

    }

    public async Task<Customer> RemoveCustomerAsync(int customerId)
    {
        var customer = await _dbContext.Customers.FindAsync(customerId);

        if (customer == null)
        {
            throw new Exception($"Not found author with id: {customerId}");
        }

        _dbContext.Customers.Remove(customer);

        await _dbContext.SaveChangesAsync();
        return customer;

    }

    public async Task<List<Customer>> GetCustomerWithBodyAsync(CustomerDto body)
    {
        var data = from customer in _dbContext.Customers
                   orderby customer.CreateAt descending
                   select customer;

        return await data.AsQueryable().AsNoTracking().ToListAsync();
    }

    public async Task<Customer> ChangePassword(int id, ChangePasswordDto body)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if (!BCrypt.Net.BCrypt.Verify(body.OldPassword, customer?.Password))
        {
            throw new Exception("Mật khẩu không khớp!");
        }

        if (customer != null)
        {
            customer.Password = BCrypt.Net.BCrypt.HashPassword(body.NewPassword);
            _dbContext.Customers.Update(customer);

            await _dbContext.SaveChangesAsync();
        }
        return customer;
    }
}