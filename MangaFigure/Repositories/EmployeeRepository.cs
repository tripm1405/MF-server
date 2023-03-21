using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaFigure.Repositories;

public class EmployeeRepository
{
    private readonly MangaFigureContext _dbContext;

    public EmployeeRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Employee>> GetEmployeeAsync()
    {
        var data = await _dbContext.Employees.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<Employee> AddEmployeeAsync(EmployeeDto employeeModel)
    {
        var newEmployee = new Employee()
        {
            Name = employeeModel.Name,
            Username = employeeModel.Username,
            Password = employeeModel.Password,
            Address = employeeModel.Address,
            Phone = employeeModel.Phone,
            Email = employeeModel.Email,
            Birthday = employeeModel.Birthday,
            Meta = employeeModel.Meta,
            Active = employeeModel.Active,
            Order = employeeModel.Order,
            CreateAt = employeeModel.CreateAt,
        };
        await _dbContext.Employees.AddAsync(newEmployee);
        await _dbContext.SaveChangesAsync();
        return newEmployee;
    }

    public async Task<Employee> UpdateEmployeeAsync(int employeeId, EmployeeDto employeeModel)
    {
        var employee = await _dbContext.Employees.FindAsync(employeeId);

        if (employee == null)
        {
            throw new Exception($"Not found author with id: {employeeId}");
        }
        employee.Name = employeeModel.Name;
        employee.Password = employeeModel.Password;
        employee.Address = employeeModel.Address;
        employee.Email = employeeModel.Email;
        employee.Birthday = employeeModel.Birthday;
        employee.Phone = employeeModel.Phone;
        employee.Meta = employeeModel.Meta;
        employee.Order = employeeModel.Order;
        employee.CreateAt = employeeModel.CreateAt;
        employee.Active = employeeModel.Active;

        _dbContext.Employees.Update(employee);

        await _dbContext.SaveChangesAsync();
        return employee;

    }

    public async Task<Employee> RemoveEmployeeAsync(int employeeId)
    {
        var employee = await _dbContext.Employees.FindAsync(employeeId);

        if (employee == null)
        {
            throw new Exception($"Not found author with id: {employeeId}");
        }

        _dbContext.Employees.Remove(employee);

        await _dbContext.SaveChangesAsync();
        return employee;

    }

}