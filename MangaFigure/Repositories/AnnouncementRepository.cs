using MangaFigure.DTOs;
using MangaFigure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MangaFigure.Repositories;

public class AnnouncementRepository
{
    private readonly MangaFigureContext _dbContext;

    public AnnouncementRepository(MangaFigureContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Announcement>> GetAnnouncementAsync()
    {
        // Config.OUT_ANNOUNCES + 
        var data = from announcementModel in _dbContext.Announcements
                   select new Announcement()
                   {
                       Meta = announcementModel.Meta,
                       Title = announcementModel.Title,
                       Content = announcementModel.Content,
                       Order = announcementModel.Order,
                       Active = announcementModel.Active,
                       CreateAt = announcementModel.CreateAt,
                       Image = Config.OUT_ANNOUNCES + announcementModel.Image
                   };

        //var data = await _dbContext.Announcements.AsQueryable().AsNoTracking().ToListAsync();
        return await data.AsQueryable().AsNoTracking().ToListAsync();
    }

    public async Task<Announcement> AddAnnouncementAsync(AnnouncementDto announcementModel)
    {
        var newAnnouncement = new Announcement()
        {
            Meta = announcementModel.Meta,
            Title = announcementModel.Title,
            Content = announcementModel.Content,
            Order = announcementModel.Order,
            Active = announcementModel.Active, 
            CreateAt = announcementModel.CreateAt,
            Image = announcementModel.Image
        };
        await _dbContext.Announcements.AddAsync(newAnnouncement);
        await _dbContext.SaveChangesAsync();
        return newAnnouncement;
    }

    public async Task<Announcement> UpdateAnnouncementAsync(int announcementId, AnnouncementDto announcementModel)
    {
        var announcement = await _dbContext.Announcements.FindAsync(announcementId);

        if (announcement == null)
        {
            throw new Exception($"Not found author with id: {announcementId}");
        }
        announcement.Title = announcementModel.Title;
        announcement.Content = announcementModel.Content;
        announcement.Image = announcementModel.Image;
        announcement.Meta = announcementModel.Meta;
        announcement.Active = announcementModel.Active;
        announcement.Order = announcementModel.Order;
        announcement.CreateAt = announcementModel.CreateAt;

        _dbContext.Announcements.Update(announcement);

        await _dbContext.SaveChangesAsync();
        return announcement;

    }

    public async Task<Announcement> RemoveAnnouncementAsync(int AnnouncementId)
    {
        var Announcement = await _dbContext.Announcements.FindAsync(AnnouncementId);

        if (Announcement == null)
        {
            throw new Exception($"Not found author with id: {AnnouncementId}");
        }

        _dbContext.Announcements.Remove(Announcement);

        await _dbContext.SaveChangesAsync();
        return Announcement;

    }

}