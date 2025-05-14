namespace CuraSys.Models;

public class TestResult
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int TestId { get; set; }
    public int VisitId{ get; set; }
    public int DoctorId { get; set; }
    public DateTime ResultDate { get; set; }
    public string? ResultText { get; set; }
    public string? Comments { get; set; }
    public string? AttachmentUrl { get; set; }

    public Patient Patient { get; set; } = null!;
    public MedicalTest MedicalTest { get; set; } = null!;
    public Visit Visit { get; set; } = null!;
}