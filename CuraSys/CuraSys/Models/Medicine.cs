namespace CuraSys.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string DosageForm { get; set; } = null!;
    public string Strength { get; set; } = null!;
    public decimal Price { get; set; }

    public List<PrescriptionItem> UsedIn { get; set; } = new();
}