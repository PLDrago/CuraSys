namespace CuraSys.Models;

public class Prescription
{
    public int Id { get; set; }
    
    public string PrescriptionNumber { get; set; } = string.Empty;
    public int VisitId { get; set; }
    public DateTime IssuedAt { get; set; }
    public string? Notes { get; set; }

    public Visit Visit { get; set; } = null!;
    public List<PrescriptionItem> Items { get; set; } = new();
}