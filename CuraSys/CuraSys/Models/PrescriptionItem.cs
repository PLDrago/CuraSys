namespace CuraSys.Models;

public class PrescriptionItem
{
    public int Id { get; set; }
    public int PrescriptionId { get; set; }
    public int MedicationId { get; set; }
    public string? DosageInstructions { get; set; }
    public int Quantity { get; set; }

    public Prescription Prescription { get; set; } = null!;
    public Medicine Medicine { get; set; } = null!;
}