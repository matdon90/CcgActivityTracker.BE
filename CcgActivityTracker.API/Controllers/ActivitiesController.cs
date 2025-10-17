using CcgActivityTracker.Application.Activities.Commands;
using CcgActivityTracker.Application.Activities.Handlers;
using CcgActivityTracker.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CcgActivityTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityRepository _repo;
    private readonly CreateActivityHandler _create;

    public ActivitiesController(IActivityRepository repo, CreateActivityHandler create)
    {
        _repo = repo;
        _create = create;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateActivityCommand cmd)
    {
        var id = await _create.Handle(cmd);
        return Ok(new { id });
    }
}
