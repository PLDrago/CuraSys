using System;
using CuraSys.Models;

namespace CuraSys.Models
{
    public class ScheduledTest
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public int DoctorId { get; set; }

        public DateTime ScheduledDateTime { get; set; }
        public string Status { get; set; } = "Zaplanowane";
        public string? Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Patient Patient { get; set; }
        public MedicalTest Test { get; set; }
        public MedicalStaff Doctor { get; set; }
    }
}