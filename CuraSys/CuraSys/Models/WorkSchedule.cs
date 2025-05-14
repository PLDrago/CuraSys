namespace CuraSys.Models;

public class WorkSchedule
{
    public int Id { get; set; }
    public string StaffType { get; set; } = null!;
    public int StaffId { get; set; }
    public string DayOfWeek { get; set; } = null!;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public SystemUser Staff { get; set; } = null!;
}