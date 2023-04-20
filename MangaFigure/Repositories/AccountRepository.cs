﻿using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MangaFigure.Repositories;

public class AccountRepository
{
    private readonly MangaFigureContext _dbContext = new MangaFigureContext();
    private IConfiguration _configuration;

    public AccountRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> SignInAsync(AccountBody body)
    {
        if (body == null)
        {
            throw new Exception("Thieu body");
        }

        if (body.Username == null)
        {
            throw new Exception("Thieu username");
        }

        if (body.Password == null)
        {
            throw new Exception("Thieu password");
        }

        if (body.Username.Equals("admin"))
        {
            if (body.Password.Equals("123456"))
            {

                return await Task<string>.Run(() => GetToken(new AccountData()
                {
                    Username = body.Username,
                    Email = "",
                    Role = 0
                }));
            }
        }

        var employeeAccount = (from t in _dbContext.Employees where t.Username == body.Username select t).FirstOrDefault();
        if (employeeAccount != null)
        {
            if (BCrypt.Net.BCrypt.Verify(body.Password, employeeAccount.Password))
            {
                return await Task<string>.Run(() => GetToken(new AccountData()
                {
                    Username = body.Username,
                    Email = employeeAccount.Email,
                    Role = 1
                }));
            }
        }

        var customerAccount = (from t in _dbContext.Customers where t.Username == body.Username select t).FirstOrDefault();
        if (customerAccount != null)
        {
            if (BCrypt.Net.BCrypt.Verify(body.Password, customerAccount.Password))
            {
                return await Task<string>.Run(() => GetToken(new AccountData()
                {
                    Username = body.Username,
                    Email = customerAccount.Email,
                    Role = 2
                }));
            }
        }

        throw new Exception("Dang nhap that bai");
    }

    public async Task<AccountData> CheckToken(string token)
    {
        if (token == null)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.FromHours(1)
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var claims = jwtToken.Claims;

            return await Task<AccountData>.Run(() => new AccountData()
            {
                Username = claims.First(x => x.Type == "Username").Value,
                Email = claims.First(x => x.Type == "Email").Value,
                Role = int.Parse(claims.First(x => x.Type == "Role").Value)
            });
        }
        catch
        {
            return null;
        }
    }

    public string GetToken(AccountData data)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("username", data.Username),
            new Claim("email", data.Email),
            new Claim("role", data.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signIn);

        return (new JwtSecurityTokenHandler()).WriteToken(token);
    }
}

public class AccountData
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public int? Role { get; set; }
}