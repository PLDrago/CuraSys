namespace CuraSys.Models;

public class DoctorSpeciality
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public List<StaffSpeciality> StaffSpecialities { get; set; } = new();
}