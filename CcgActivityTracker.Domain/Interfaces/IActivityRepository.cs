using CcgActivityTracker.Domain.Entities;

namespace CcgActivityTracker.Domain.Interfaces;

public interface IActivityRepository
{
    Task<Activity?> GetByIdAsync(int id);
    Task<List<Activity>> GetAllAsync();
    Task AddAsync(Activity activity);
}