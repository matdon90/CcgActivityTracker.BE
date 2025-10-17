using CcgActivityTracker.Domain.Entities;
using CcgActivityTracker.Domain.Interfaces;
using CcgActivityTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CcgActivityTracker.Infrastructure.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly AppDbContext _context;
    public ActivityRepository(AppDbContext context) => _context = context;

    public async Task<Activity?> GetByIdAsync(int id) =>
        await _context.Activities.FindAsync(id);

    public async Task<List<Activity>> GetAllAsync() =>
        await _context.Activities.ToListAsync();

    public async Task AddAsync(Activity activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
    }
}