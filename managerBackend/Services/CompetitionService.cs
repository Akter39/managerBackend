﻿using managerBackend.Models;
using managerBackend.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace managerBackend.Services
{
    public class CompetitionService: ICompetitionService
    {
        ApplicationContext db;
        IHttpContextAccessor HttpContextAccessor;
        public CompetitionService(ApplicationContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
            db = context;
        }

        public async Task New(Competition competition)
        {
            int id = Int32.Parse(HttpContextAccessor.HttpContext.User.FindFirst("id")!.Value);
            competition.User = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            var distances = competition.Distances;
            var yearGroups = competition.YearGroups;
            competition.Distances = null;
            competition.YearGroups = null;
            competition.BidDate = competition.StartCompetition.Date.AddDays(-competition.BidDay);
            competition.CreateDate = DateTime.UtcNow;
            db.Competitions.Add(competition);
            foreach(var item in distances)
            {
               var distance = await db.Distances.FirstOrDefaultAsync(u => 
                    u.Dist == item.Dist 
                    && u.Style == item.Style 
                    && u.Gender == item.Gender);
               distance!.Competitions.Add(competition);
            }
            foreach(var item in yearGroups)
            {
                var yearGroup = await db.YearGroups.FirstOrDefaultAsync(u =>
                    u.StartYear == item.StartYear
                    && u.EndYear == item.EndYear
                    && u.Infinity == item.Infinity
                    && u.Gender == item.Gender);
                if (yearGroup is null)
                {
                    item.Competitions.Add(competition);
                    db.YearGroups.Add(item);                    
                } else
                {
                    yearGroup.Competitions.Add(competition);
                }
            }
            await db.SaveChangesAsync();
        }

        public async Task Update(Competition competition) {
            db.Competitions.Update(competition);
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

        }

        public async Task<List<Competition>> Upcoming()
        {
            return await db.Competitions
                .Include(u => u.Distances)
                .Include(u => u.YearGroups)
                .AsSplitQuery()
                .Where(u => u.BidDate > DateTime.Now).ToListAsync();
        }
        public async Task<List<Competition>> Current()
        {
            return await db.Competitions
                .Include(u => u.Distances)
                .Include(u => u.YearGroups)
                .AsSplitQuery()
                .Where(u => u.BidDate <= DateTime.Now && u.EndCompetition >= DateTime.Now).ToListAsync();
        }
        public async Task<List<Competition>> Archive()
        {
            return await db.Competitions
                .Include(u => u.Distances)
                .Include(u => u.YearGroups)
                .AsSplitQuery()
                .Where(u => u.EndCompetition < DateTime.Now).ToListAsync();
        }

    }
    public static class CompetitionsServiceExtensions
    {
        public static void AddCompetitionManeger<TImplementation>(this IServiceCollection services)
            where TImplementation : class, ICompetitionService
        {
            services.AddScoped<ICompetitionService, TImplementation>();
        }
    }
}
