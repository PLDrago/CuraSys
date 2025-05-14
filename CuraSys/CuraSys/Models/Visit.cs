namespace CuraSys.Models;

public class Visit
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }

    public DateTime AppointmentDateTime { get; set; } 
    public string AppointmentType { get; set; } = null!;


    public string Status { get; set; } = null!;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }

    public Patient Patient { get; set; } = null!;
    public MedicalStaff Doctor { get; set; } = null!;

    public List<Invoice> Invoices { get; set; } = new();
    public List<Prescription> Prescriptions { get; set; } = new();
    public List<TestResult> TestResults { get; set; } = new();
}