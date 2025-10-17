using CcgActivityTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CcgActivityTracker.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Activity> Activities => Set<Activity>();
}
