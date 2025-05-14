using Microsoft.EntityFrameworkCore;
using CuraSys.Models;

namespace CuraSys.Data;

public class CuraSysContext : DbContext
{
    public CuraSysContext(DbContextOptions<CuraSysContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MedicalTest> MedicalTests { get; set; }
    public DbSet<AdminStaff> AdminStaff { get; set; }
    public DbSet<MedicalStaff> MedicalStaff { get; set; }
    public DbSet<SystemUser> SystemUsers { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<WorkSchedule> WorkSchedules { get; set; }
    public DbSet<StaffSpeciality> StaffSpecialities { get; set; }
    public DbSet<ScheduledTest> ScheduledTests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SystemUser>()
            .ToTable("system_users")
            .HasKey(e => e.Id);

        modelBuilder.Entity<SystemUser>()
            .Property(e => e.IsActive).HasDefaultValue(true);

        modelBuilder.Entity<Patient>()
            .ToTable("patients")
            .HasKey(e => e.Id);

        modelBuilder.Entity<Patient>()
            .HasIndex(e => e.Pesel).IsUnique();

        modelBuilder.Entity<MedicalStaff>()
            .ToTable("medical_staff")
            .HasKey(e => e.Id);

        modelBuilder.Entity<AdminStaff>()
            .ToTable("admin_staff")
            .HasKey(e => e.Id);

        modelBuilder.Entity<WorkSchedule>()
            .ToTable("work_schedules")
            .HasKey(e => e.Id);

        modelBuilder.Entity<WorkSchedule>()
            .HasOne(w => w.Staff)
            .WithMany(u => u.WorkSchedules)
            .HasForeignKey(w => w.StaffId);

        modelBuilder.Entity<DoctorSpeciality>()
            .ToTable("doctor_specialities")
            .HasKey(e => e.Id);

        modelBuilder.Entity<StaffSpeciality>()
            .ToTable("staff_specialities")
            .HasKey(e => e.Id);

        modelBuilder.Entity<StaffSpeciality>()
            .HasOne(s => s.MedicalStaff)
            .WithMany(d => d.Specialities)
            .HasForeignKey(s => s.MedicalStaffId);

        modelBuilder.Entity<StaffSpeciality>()
            .HasOne(s => s.DoctorSpeciality)
            .WithMany(d => d.StaffSpecialities)
            .HasForeignKey(s => s.DoctorSpecialityId);

        modelBuilder.Entity<Visit>()
            .ToTable("visits")
            .HasKey(e => e.Id);

        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientId);

        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Doctor)
            .WithMany(d => d.Visits)
            .HasForeignKey(v => v.DoctorId);

        modelBuilder.Entity<Prescription>()
            .ToTable("prescriptions")
            .HasKey(e => e.Id);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Visit)
            .WithMany(v => v.Prescriptions)
            .HasForeignKey(p => p.VisitId);

        modelBuilder.Entity<PrescriptionItem>()
            .ToTable("prescription_items")
            .HasKey(e => e.Id);

        modelBuilder.Entity<PrescriptionItem>()
            .HasOne(i => i.Prescription)
            .WithMany(p => p.Items)
            .HasForeignKey(i => i.PrescriptionId);

        modelBuilder.Entity<PrescriptionItem>()
            .HasOne(i => i.Medicine)
            .WithMany(m => m.UsedIn)
            .HasForeignKey(i => i.MedicationId);

        modelBuilder.Entity<Medicine>()
            .ToTable("medicines")
            .HasKey(e => e.Id);

        modelBuilder.Entity<MedicalTest>()
            .ToTable("medical_tests")
            .HasKey(e => e.Id);

        modelBuilder.Entity<TestResult>()
            .ToTable("test_results")
            .HasKey(e => e.Id);

        modelBuilder.Entity<TestResult>()
            .HasOne(tr => tr.Patient)
            .WithMany(p => p.TestResults)
            .HasForeignKey(tr => tr.PatientId);

        modelBuilder.Entity<TestResult>()
            .HasOne(tr => tr.MedicalTest)
            .WithMany(mt => mt.Results)
            .HasForeignKey(tr => tr.TestId);

        modelBuilder.Entity<TestResult>()
            .HasOne(tr => tr.Visit)
            .WithMany(v => v.TestResults)
            .HasForeignKey(tr => tr.VisitId);

        modelBuilder.Entity<Invoice>()
            .ToTable("invoices")
            .HasKey(e => e.Id);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Patient)
            .WithMany(p => p.Invoices)
            .HasForeignKey(i => i.PatientId);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.IssuedBy)
            .WithMany(u => u.InvoicesIssued)
            .HasForeignKey(i => i.IssuedById);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Visit)
            .WithMany(v => v.Invoices)
            .HasForeignKey(i => i.VisitId);
        modelBuilder.Entity<ScheduledTest>()
            .ToTable("scheduled_tests")
            .HasKey(st => st.Id);

        modelBuilder.Entity<ScheduledTest>()
            .HasOne(st => st.Patient)
            .WithMany(p => p.ScheduledTests)
            .HasForeignKey(st => st.PatientId);

        modelBuilder.Entity<ScheduledTest>()
            .HasOne(st => st.Test)
            .WithMany(mt => mt.ScheduledTests)
            .HasForeignKey(st => st.TestId);

        modelBuilder.Entity<ScheduledTest>()
            .HasOne(st => st.Doctor)
            .WithMany(d => d.ScheduledTests)
            .HasForeignKey(st => st.DoctorId);

    }
}
