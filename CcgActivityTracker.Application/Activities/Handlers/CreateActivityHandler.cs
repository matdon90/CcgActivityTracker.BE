using CcgActivityTracker.Application.Activities.Commands;
using CcgActivityTracker.Domain.Entities;
using CcgActivityTracker.Domain.Interfaces;

namespace CcgActivityTracker.Application.Activities.Handlers;

public class CreateActivityHandler
{
    private readonly IActivityRepository _repo;

    public CreateActivityHandler(IActivityRepository repo) => _repo = repo;

    public async Task<int> Handle(CreateActivityCommand cmd)
    {
        var activity = new Activity { Name = cmd.Name, Date = cmd.Date };
        await _repo.AddAsync(activity);
        return activity.Id;
    }
}
