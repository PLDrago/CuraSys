namespace CuraSys.Models;

public class SystemUser
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Invoice> InvoicesIssued { get; set; } = new();
    public List<WorkSchedule> WorkSchedules { get; set; } = new();
}