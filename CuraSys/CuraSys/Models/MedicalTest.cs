namespace CuraSys.Models;

public class MedicalTest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool RequiresFasting { get; set; }
    public decimal Price { get; set; }

    public List<TestResult> Results { get; set; } = new();
    public ICollection<ScheduledTest> ScheduledTests { get; set; } = new List<ScheduledTest>();
}