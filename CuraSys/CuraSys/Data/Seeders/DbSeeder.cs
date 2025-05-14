using CuraSys.Models;
using Microsoft.EntityFrameworkCore;

namespace CuraSys.Data;

public class DbSeeder
{
    public static void Seed(CuraSysContext context)
    {
        context.Database.Migrate();

        if (!context.Patients.Any())
        { 
            var patients = new List<Patient>
            {
                new Patient { FirstName = "Anna", LastName = "Kowalska", Pesel = "90010112345", Phone = "501123456", Email = "anna.kowalska@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1990,1,1), Gender = "female", Address = "ul. Lipowa 10", City = "Warszawa", PostalCode = "00-001", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Jan", LastName = "Nowak", Pesel = "85020254321", Phone = "502234567", Email = "jan.nowak@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1985,2,2), Gender = "male", Address = "ul. Klonowa 5", City = "Kraków", PostalCode = "30-002", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Magdalena", LastName = "Wiśniewska", Pesel = "95030367890", Phone = "503345678", Email = "magda.wisniewska@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1995,3,3), Gender = "female", Address = "ul. Jesionowa 3", City = "Gdańsk", PostalCode = "80-003", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Tomasz", LastName = "Wójcik", Pesel = "92040498765", Phone = "504456789", Email = "tomasz.wojcik@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1992,4,4), Gender = "male", Address = "ul. Dębowa 8", City = "Wrocław", PostalCode = "50-004", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Karolina", LastName = "Kamińska", Pesel = "88050523456", Phone = "505567890", Email = "karolina.kaminska@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1988,5,5), Gender = "female", Address = "ul. Sosnowa 12", City = "Poznań", PostalCode = "60-005", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Michał", LastName = "Lewandowski", Pesel = "89060634567", Phone = "506678901", Email = "michal.lewandowski@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1989,6,6), Gender = "male", Address = "ul. Brzozowa 4", City = "Lublin", PostalCode = "20-006", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Ewa", LastName = "Zielińska", Pesel = "93070745678", Phone = "507789012", Email = "ewa.zielinska@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1993,7,7), Gender = "female", Address = "ul. Grabowa 9", City = "Rzeszów", PostalCode = "35-007", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Krzysztof", LastName = "Szymański", Pesel = "87080856789", Phone = "508890123", Email = "krzysztof.szymanski@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1987,8,8), Gender = "male", Address = "ul. Akacjowa 6", City = "Szczecin", PostalCode = "70-008", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Natalia", LastName = "Dąbrowska", Pesel = "91090967890", Phone = "509901234", Email = "natalia.dabrowska@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1991,9,9), Gender = "female", Address = "ul. Topolowa 7", City = "Białystok", PostalCode = "15-009", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Piotr", LastName = "Pawłowski", Pesel = "94010178901", Phone = "510012345", Email = "piotr.pawlowski@example.com", HashPassword = "hashed_pw", BirthDate = new DateTime(1994,1,1), Gender = "male", Address = "ul. Wierzbowa 11", City = "Katowice", PostalCode = "40-010", CreatedAt = DateTime.Now },
                new Patient { FirstName = "Krzysztof", LastName = "Majka", Pesel = "11111111111", Phone = "730051758", Email = "krzysztof_majka@poczta.fm", HashPassword = "opiea502", BirthDate = new DateTime(2003, 4, 27), Gender = "male", Address = "ul. Dębicka 252", City = "Rzeszów", PostalCode = "35-213", CreatedAt = DateTime.Now },
            };

            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
        if (!context.MedicalStaff.Any())
        {
            var medicalStaff = new List<MedicalStaff>
            {
                new MedicalStaff { FirstName = "Andrzej", LastName = "Nowicki", LicenseNumber = "MED001", Pesel = "72010112345", Email = "andrzej.nowicki@medibase.com", Phone = "601234567", Gender = "male", HireDate = new DateTime(2010, 5, 1), Salary = 12000, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Barbara", LastName = "Krawczyk", LicenseNumber = "MED002", Pesel = "75020223456", Email = "barbara.krawczyk@medibase.com", Phone = "602345678", Gender = "female", HireDate = new DateTime(2012, 6, 15), Salary = 11500, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Cezary", LastName = "Lis", LicenseNumber = "MED003", Pesel = "69030334567", Email = "cezary.lis@medibase.com", Phone = "603456789", Gender = "male", HireDate = new DateTime(2008, 3, 20), Salary = 13000, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Danuta", LastName = "Wrona", LicenseNumber = "MED004", Pesel = "80040445678", Email = "danuta.wrona@medibase.com", Phone = "604567890", Gender = "female", HireDate = new DateTime(2015, 8, 10), Salary = 11000, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Edward", LastName = "Bąk", LicenseNumber = "MED005", Pesel = "71050556789", Email = "edward.bak@medibase.com", Phone = "605678901", Gender = "male", HireDate = new DateTime(2005, 9, 5), Salary = 13500, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Franciszka", LastName = "Cichoń", LicenseNumber = "MED006", Pesel = "76060667890", Email = "franciszkac@medibase.com", Phone = "606789012", Gender = "female", HireDate = new DateTime(2011, 2, 3), Salary = 11800, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Grzegorz", LastName = "Urban", LicenseNumber = "MED007", Pesel = "74070778901", Email = "grzegorz.urban@medibase.com", Phone = "607890123", Gender = "male", HireDate = new DateTime(2013, 11, 25), Salary = 12500, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Halina", LastName = "Frydrych", LicenseNumber = "MED008", Pesel = "77080889012", Email = "halina.frydrych@medibase.com", Phone = "608901234", Gender = "female", HireDate = new DateTime(2016, 1, 19), Salary = 11200, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Ireneusz", LastName = "Wilk", LicenseNumber = "MED009", Pesel = "73090990123", Email = "ireneusz.wilk@medibase.com", Phone = "609012345", Gender = "male", HireDate = new DateTime(2009, 7, 30), Salary = 12800, CreatedAt = DateTime.Now },
                new MedicalStaff { FirstName = "Jolanta", LastName = "Tomczyk", LicenseNumber = "MED010", Pesel = "79010101234", Email = "jolanta.tomczyk@medibase.com", Phone = "610123456", Gender = "female", HireDate = new DateTime(2017, 12, 12), Salary = 11700, CreatedAt = DateTime.Now },
            };

            context.MedicalStaff.AddRange(medicalStaff);
            context.SaveChanges();
        }
        if (!context.DoctorSpecialities.Any())
        {
            var specialities = new List<DoctorSpeciality>
            {
                new DoctorSpeciality { Name = "Kardiolog", Description = "Specjalista chorób serca i układu krążenia" },
                new DoctorSpeciality { Name = "Neurolog", Description = "Specjalista układu nerwowego" },
                new DoctorSpeciality { Name = "Ortopeda", Description = "Specjalista układu kostno-stawowego" },
                new DoctorSpeciality { Name = "Pediatra", Description = "Lekarz dziecięcy" },
                new DoctorSpeciality { Name = "Dermatolog", Description = "Specjalista chorób skóry" },
                new DoctorSpeciality { Name = "Endokrynolog", Description = "Specjalista gruczołów dokrewnych i hormonów" },
                new DoctorSpeciality { Name = "Ginekolog", Description = "Specjalista zdrowia kobiet i układu rozrodczego" },
                new DoctorSpeciality { Name = "Laryngolog", Description = "Specjalista uszu, nosa i gardła (ENT)" },
                new DoctorSpeciality { Name = "Psychiatra", Description = "Lekarz zajmujący się zdrowiem psychicznym" },
                new DoctorSpeciality { Name = "Onkolog", Description = "Specjalista w leczeniu chorób nowotworowych" },
            };

            context.DoctorSpecialities.AddRange(specialities);
            context.SaveChanges();
        }
        if (!context.StaffSpecialities.Any())
        {
            var staffSpecialities = new List<StaffSpeciality>
            {
                new StaffSpeciality { MedicalStaffId = 1, DoctorSpecialityId = 1 },
                new StaffSpeciality { MedicalStaffId = 1, DoctorSpecialityId = 2 },
                new StaffSpeciality { MedicalStaffId = 2, DoctorSpecialityId = 2 },
                new StaffSpeciality { MedicalStaffId = 2, DoctorSpecialityId = 3 },
                new StaffSpeciality { MedicalStaffId = 3, DoctorSpecialityId = 3 },
                new StaffSpeciality { MedicalStaffId = 3, DoctorSpecialityId = 4 },
                new StaffSpeciality { MedicalStaffId = 4, DoctorSpecialityId = 4 },
                new StaffSpeciality { MedicalStaffId = 4, DoctorSpecialityId = 5 },
                new StaffSpeciality { MedicalStaffId = 5, DoctorSpecialityId = 5 },
                new StaffSpeciality { MedicalStaffId = 6, DoctorSpecialityId = 1 },
                new StaffSpeciality { MedicalStaffId = 7, DoctorSpecialityId = 2 },
                new StaffSpeciality { MedicalStaffId = 8, DoctorSpecialityId = 3 },
                new StaffSpeciality { MedicalStaffId = 9, DoctorSpecialityId = 4 },
                new StaffSpeciality { MedicalStaffId = 10, DoctorSpecialityId = 5 },
                new StaffSpeciality { MedicalStaffId = 10, DoctorSpecialityId = 1 },
            };

            context.StaffSpecialities.AddRange(staffSpecialities);
            context.SaveChanges();
        }
        if (!context.Medicines.Any())
        {
            var medicines = new List<Medicine>
            {
                new Medicine { Name = "Polopiryna S", Description = "Przeciwbólowy i przeciwgorączkowy", DosageForm = "tabletka", Strength = "300mg", Price = 9.99m },
                new Medicine { Name = "Apap", Description = "Paracetamol przeciwbólowy", DosageForm = "tabletka", Strength = "500mg", Price = 12.50m },
                new Medicine { Name = "Ibuprom", Description = "Lek przeciwzapalny i przeciwbólowy", DosageForm = "tabletka", Strength = "200mg", Price = 10.00m },
                new Medicine { Name = "Amoksiklav", Description = "Antybiotyk penicylinowy", DosageForm = "tabletka", Strength = "875mg", Price = 25.30m },
                new Medicine { Name = "Controloc", Description = "Na refluks i nadkwasotę", DosageForm = "tabletka", Strength = "40mg", Price = 18.75m },
            };

            context.Medicines.AddRange(medicines);
            context.SaveChanges();
        }
        if (!context.MedicalTests.Any())
        {
            var medicalTests = new List<MedicalTest>
            {
                new MedicalTest { Name = "Morfologia krwi", Description = "Podstawowe badanie krwi", Price = 25.00m },
                new MedicalTest { Name = "EKG", Description = "Elektrokardiogram – badanie pracy serca", Price = 50.00m },
                new MedicalTest { Name = "RTG klatki piersiowej", Description = "Zdjęcie rentgenowskie płuc i klatki piersiowej", Price = 80.00m },
                new MedicalTest { Name = "USG jamy brzusznej", Description = "Ultrasonografia narządów wewnętrznych", Price = 100.00m },
                new MedicalTest { Name = "Badanie moczu", Description = "Analiza próbki moczu", Price = 20.00m },
            };

            context.MedicalTests.AddRange(medicalTests);
            context.SaveChanges();
        }
        if (!context.SystemUsers.Any())
        {
            var users = new List<SystemUser>
            {
                new SystemUser { Username = "admin", Email = "admin@medibase.com", PasswordHash = "admin123hashed", Role = "admin" },
                new SystemUser { Username = "sekretarka1", Email = "sekretariat1@medibase.com", PasswordHash = "sekret1hashed", Role = "staff" },
                new SystemUser { Username = "doktor_jan", Email = "j.nowicki@medibase.com", PasswordHash = "dokjanhashed", Role = "doctor" },
                new SystemUser { Username = "piel1", Email = "pielegniarka@medibase.com", PasswordHash = "haslopiel", Role = "nurse" },
                new SystemUser { Username = "diagnosta", Email = "diagnosta@medibase.com", PasswordHash = "diagnostahash", Role = "lab" },
            };

            context.SystemUsers.AddRange(users);
            context.SaveChanges();
        }
        if (!context.AdminStaff.Any())
        {
            var adminStaff = new List<AdminStaff>
            {
                new AdminStaff { FirstName = "Aleksandra", LastName = "Rybak", Role = "Recepcjonistka", Email = "aleksandra.rybak@medibase.com", Phone = "700100100", HireDate = new DateTime(2018, 3, 1), CreatedAt = DateTime.Now },
                new AdminStaff { FirstName = "Łukasz", LastName = "Domański", Role = "Księgowy", Email = "lukasz.domanski@medibase.com", Phone = "700200200", HireDate = new DateTime(2019, 6, 12), CreatedAt = DateTime.Now },
                new AdminStaff { FirstName = "Beata", LastName = "Sikora", Role = "Asystentka medyczna", Email = "beata.sikora@medibase.com", Phone = "700300300", HireDate = new DateTime(2020, 11, 4), CreatedAt = DateTime.Now },
                new AdminStaff { FirstName = "Tomasz", LastName = "Biel", Role = "Koordynator administracyjny", Email = "tomasz.biel@medibase.com", Phone = "700400400", HireDate = new DateTime(2017, 1, 20), CreatedAt = DateTime.Now },
                new AdminStaff { FirstName = "Katarzyna", LastName = "Lisowska", Role = "Kierownik działu", Email = "k.lisowska@medibase.com", Phone = "700500500", HireDate = new DateTime(2021, 7, 8), CreatedAt = DateTime.Now },
            };

            context.AdminStaff.AddRange(adminStaff);
            context.SaveChanges();
        }
        if (!context.Visits.Any())
        {
            var visits = new List<Visit>
            {
                new Visit { PatientId = 1, DoctorId = 1, AppointmentDateTime = DateTime.Now.AddDays(-10), AppointmentType = "Kontrolna", Status = "zrealizowana", Notes = "Wizyta kontrolna – wyniki dobre.", CreatedAt = DateTime.Now },
                new Visit { PatientId = 2, DoctorId = 2, AppointmentDateTime = DateTime.Now.AddDays(-7), AppointmentType = "Konsultacja", Status = "zrealizowana", Notes = "Skarga na ból głowy. Zlecono badania.", CreatedAt = DateTime.Now },
                new Visit { PatientId = 3, DoctorId = 3, AppointmentDateTime = DateTime.Now.AddDays(-5), AppointmentType = "Pilna", Status = "zrealizowana", Notes = "Zdiagnozowano anginę. Przepisano antybiotyk.", CreatedAt = DateTime.Now },
                new Visit { PatientId = 4, DoctorId = 4, AppointmentDateTime = DateTime.Now.AddDays(-2), AppointmentType = "Ortopedyczna", Status = "zrealizowana", Notes = "Kontuzja kolana – skierowanie na RTG.", CreatedAt = DateTime.Now },
                new Visit { PatientId = 5, DoctorId = 5, AppointmentDateTime = DateTime.Now.AddDays(-1), AppointmentType = "Pediatryczna", Status = "zrealizowana", Notes = "Wizyta pediatryczna – dziecko zdrowe.", CreatedAt = DateTime.Now },
            };

            context.Visits.AddRange(visits);
            context.SaveChanges();
        }
        if (!context.TestResults.Any())
        {
            var testResults = new List<TestResult>
            {
                new TestResult { PatientId = 1, TestId = 1, DoctorId = 1, VisitId = 1, ResultDate = DateTime.Now.AddDays(-10), ResultText = "Wszystkie parametry w normie.", Comments = "Brak uwag." },
                new TestResult { PatientId = 2, TestId = 2, DoctorId = 2, VisitId = 2, ResultDate = DateTime.Now.AddDays(-7), ResultText = "Zapis EKG prawidłowy.", Comments = "EKG w normie." },
                new TestResult { PatientId = 3, TestId = 3, DoctorId = 3, VisitId = 3, ResultDate = DateTime.Now.AddDays(-5), ResultText = "Obraz płuc bez zmian.", Comments = "RTG bez patologii." },
                new TestResult { PatientId = 4, TestId = 4, DoctorId = 4, VisitId = 4, ResultDate = DateTime.Now.AddDays(-2), ResultText = "USG: bez nieprawidłowości.", Comments = "Zalecana kontrola za 6 miesięcy." },
                new TestResult { PatientId = 5, TestId = 5, DoctorId = 5, VisitId = 5, ResultDate = DateTime.Now.AddDays(-1), ResultText = "Wynik moczu w normie.", Comments = "Brak infekcji." },
            };

            context.TestResults.AddRange(testResults);
            context.SaveChanges();
        }
        if (!context.Invoices.Any())
        {
            var invoices = new List<Invoice>
            {
                new Invoice { PatientId = 1, VisitId = 1, IssuedById = 1, TotalAmount = 150.00m, IssuedAt = DateTime.Now.AddDays(-10), PaymentStatus = "paid" },
                new Invoice { PatientId = 2, VisitId = 2, IssuedById = 2, TotalAmount = 200.00m, IssuedAt = DateTime.Now.AddDays(-7), PaymentStatus = "paid" },
                new Invoice { PatientId = 3, VisitId = 3, IssuedById = 3, TotalAmount = 175.50m, IssuedAt = DateTime.Now.AddDays(-5), PaymentStatus = "unpaid" },
                new Invoice { PatientId = 4, VisitId = 4, IssuedById = 4, TotalAmount = 220.00m, IssuedAt = DateTime.Now.AddDays(-3), PaymentStatus = "paid" },
                new Invoice { PatientId = 5, VisitId = 5, IssuedById = 5, TotalAmount = 90.00m, IssuedAt = DateTime.Now.AddDays(-1), PaymentStatus = "unpaid" },
            };

            context.Invoices.AddRange(invoices);
            context.SaveChanges();
        }

        if (!context.Prescriptions.Any())
        {
            var prescriptions = new List<Prescription>
            {
                new Prescription { PrescriptionNumber = "1234", VisitId = 1, IssuedAt = DateTime.Now.AddDays(-10), Notes = "Ibuprofen 3x dziennie przez 5 dni." },
                new Prescription { PrescriptionNumber = "4444", VisitId = 2, IssuedAt = DateTime.Now.AddDays(-7), Notes = "Apap na gorączkę – do 4 tabletek dziennie." },
                new Prescription { PrescriptionNumber = "1111", VisitId = 3, IssuedAt = DateTime.Now.AddDays(-5), Notes = "Amoksiklav przez 7 dni – zakażenie bakteryjne." },
                new Prescription { PrescriptionNumber = "4321", VisitId = 4, IssuedAt = DateTime.Now.AddDays(-3), Notes = "Controloc rano, przed posiłkiem, przez 2 tygodnie." },
                new Prescription { PrescriptionNumber = "1324", VisitId = 5, IssuedAt = DateTime.Now.AddDays(-1), Notes = "Polopiryna S – doraźnie." },
            };

            context.Prescriptions.AddRange(prescriptions);
            context.SaveChanges();
        }
        if (!context.PrescriptionItems.Any())
        {
            var items = new List<PrescriptionItem>
            {
                new PrescriptionItem { PrescriptionId = 1, MedicationId = 3, DosageInstructions = "1 tabletka co 8 godzin", Quantity = 15 },
                new PrescriptionItem { PrescriptionId = 2, MedicationId = 2, DosageInstructions = "2 tabletki co 6 godzin", Quantity = 12 },
                new PrescriptionItem { PrescriptionId = 3, MedicationId = 4, DosageInstructions = "1 tabletka co 12 godzin", Quantity = 14 },
                new PrescriptionItem { PrescriptionId = 4, MedicationId = 5, DosageInstructions = "1 tabletka dziennie", Quantity = 14 },
                new PrescriptionItem { PrescriptionId = 5, MedicationId = 1, DosageInstructions = "1 tabletka w razie potrzeby", Quantity = 6 },
            };

            context.PrescriptionItems.AddRange(items);
            context.SaveChanges();
        }
        if (!context.WorkSchedules.Any())
        {
            var schedules = new List<WorkSchedule>
            {
                new WorkSchedule { StaffId = 1, StaffType = "doctor", DayOfWeek = "Monday", StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(16, 0, 0) },
                new WorkSchedule { StaffId = 2, StaffType = "doctor", DayOfWeek = "Tuesday", StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(17, 0, 0) },
                new WorkSchedule { StaffId = 3, StaffType = "doctor", DayOfWeek = "Wednesday", StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(18, 0, 0) },
                new WorkSchedule { StaffId = 4, StaffType = "doctor", DayOfWeek = "Thursday", StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(16, 30, 0) },
                new WorkSchedule { StaffId = 5, StaffType = "doctor", DayOfWeek = "Friday", StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(15, 0, 0) },
            };

            context.WorkSchedules.AddRange(schedules);
            context.SaveChanges();
        }
        if (!context.ScheduledTests.Any())
        {
            context.ScheduledTests.AddRange(new[]
            {
                new ScheduledTest { PatientId = 1, TestId = 1, DoctorId = 1, ScheduledDateTime = DateTime.Today.AddDays(1).AddHours(9), Status = "Zaplanowane", Comments = "Na czczo" },
                new ScheduledTest { PatientId = 2, TestId = 3, DoctorId = 2, ScheduledDateTime = DateTime.Today.AddDays(2).AddHours(10), Status = "Zaplanowane", Comments = null },
                new ScheduledTest { PatientId = 3, TestId = 2, DoctorId = 1, ScheduledDateTime = DateTime.Today.AddDays(3).AddHours(8), Status = "Zaplanowane", Comments = "Przynieść wyniki morfologii" },
                new ScheduledTest { PatientId = 4, TestId = 4, DoctorId = 3, ScheduledDateTime = DateTime.Today.AddDays(1).AddHours(11), Status = "Zaplanowane", Comments = null },
                new ScheduledTest { PatientId = 5, TestId = 5, DoctorId = 2, ScheduledDateTime = DateTime.Today.AddDays(4).AddHours(9), Status = "Zaplanowane", Comments = "Obserwacja ciśnienia" },
                new ScheduledTest { PatientId = 1, TestId = 5, DoctorId = 3, ScheduledDateTime = DateTime.Today.AddDays(5).AddHours(10), Status = "Zaplanowane", Comments = null },
                new ScheduledTest { PatientId = 2, TestId = 2, DoctorId = 1, ScheduledDateTime = DateTime.Today.AddDays(2).AddHours(13), Status = "Zaplanowane", Comments = null },
                new ScheduledTest { PatientId = 3, TestId = 1, DoctorId = 2, ScheduledDateTime = DateTime.Today.AddDays(3).AddHours(15), Status = "Zaplanowane", Comments = "Skontrolować wcześniej wykonane badanie" },
                new ScheduledTest { PatientId = 4, TestId = 3, DoctorId = 1, ScheduledDateTime = DateTime.Today.AddDays(6).AddHours(10), Status = "Zaplanowane", Comments = null },
                new ScheduledTest { PatientId = 5, TestId = 4, DoctorId = 2, ScheduledDateTime = DateTime.Today.AddDays(7).AddHours(9), Status = "Zaplanowane", Comments = "Obowiązkowe skierowanie" }
            });
            context.SaveChanges();
        }
        context.SaveChanges();
    }
}