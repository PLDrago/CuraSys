namespace CuraSys.Models;

public class StaffSpeciality
{
    public int Id { get; set; }
    public int MedicalStaffId { get; set; }
    public int DoctorSpecialityId { get; set; }

    public MedicalStaff MedicalStaff { get; set; } = null!;
    public DoctorSpeciality DoctorSpeciality { get; set; } = null!;
}