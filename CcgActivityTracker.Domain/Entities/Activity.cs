namespace CcgActivityTracker.Domain.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
