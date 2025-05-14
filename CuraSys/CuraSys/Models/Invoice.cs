namespace CuraSys.Models;

public class Invoice
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int IssuedById { get; set; }
    public int VisitId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime IssuedAt { get; set; }
    public string PaymentStatus { get; set; } = "unpaid";

    public Patient Patient { get; set; } = null!;
    public SystemUser IssuedBy { get; set; } = null!;
    public Visit Visit { get; set; } = null!;
}