using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class ContactRepository
{
    private readonly MangaFigureContext _dbContext;

    public ContactRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Contact>> GetContactAsync()
    {
        var data = await _dbContext.Contacts.AsQueryable().AsNoTracking().ToListAsync();
        return data;
    }

    public async Task<Contact> AddContactAsync(ContactDto contactModel)
    {
        var newContact = new Contact()
        {
            Name = contactModel.Name,
            Link = contactModel.Link,
            Meta = contactModel.Meta,
            Active = contactModel.Active,
            Order = contactModel.Order,
            CreateAt = contactModel.CreateAt,
        };
        await _dbContext.Contacts.AddAsync(newContact);
        await _dbContext.SaveChangesAsync();
        return newContact;
    }

    public async Task<Contact> UpdateContactAsync(int contactId, ContactDto contactModel)
    {
        var contact = await _dbContext.Contacts.FindAsync(contactId);

        if (contact == null)
        {
            throw new Exception($"Not found author with id: {contactId}");
        }
        contact.Name = contactModel.Name;
        contact.Link = contactModel.Link;
        contact.Meta = contactModel.Meta;
        contact.Active = contactModel.Active;
        contact.Order = contactModel.Order;
        contact.CreateAt = contactModel.CreateAt;

        _dbContext.Contacts.Update(contact);

        await _dbContext.SaveChangesAsync();
        return contact;

    }

    public async Task<Contact> RemoveContactAsync(int contactId)
    {
        var contact = await _dbContext.Contacts.FindAsync(contactId);

        if (contact == null)
        {
            throw new Exception($"Not found author with id: {contactId}");
        }

        _dbContext.Contacts.Remove(contact);

        await _dbContext.SaveChangesAsync();
        return contact;

    }

}