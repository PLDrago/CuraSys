namespace CuraSys.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Pesel { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? HashPassword { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = "other";
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Visit> Visits { get; set; } = new();
    public List<Invoice> Invoices { get; set; } = new();
    public List<TestResult> TestResults { get; set; } = new();
}