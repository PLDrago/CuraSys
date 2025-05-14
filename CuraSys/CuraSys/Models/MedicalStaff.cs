namespace CuraSys.Models;

public class MedicalStaff
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string LicenseNumber { get; set; } = null!;
    public string Pesel { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Visit> Visits { get; set; } = new();
    public List<StaffSpeciality> Specialities { get; set; } = new();
    public ICollection<ScheduledTest> ScheduledTests { get; set; } = new List<ScheduledTest>();
}