using Microsoft.EntityFrameworkCore;
using Tutorial_10.Models;

namespace Tutorial_10.Contexts;

public class DataBaseContext : DbContext
{
    protected DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament { IdMedicament = 1, Name = "Aspirin", Description = "Pain reliever", Type = "Analgesic" },
            new Medicament { IdMedicament = 2, Name = "Penicillin", Description = "Antibiotic", Type = "Antibacterial" }
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient { IdPatient = 1, FirstName = "Alice", LastName = "Johnson", BirthDate = new DateTime(1990, 1, 1) },
            new Patient { IdPatient = 2, FirstName = "Bob", LastName = "Williams", BirthDate = new DateTime(1985, 5, 23) }
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription { IdPrescription = 1, Date = new DateTime(2023, 1, 1), DueDate = new DateTime(2023, 6, 1), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPrescription = 2, Date = new DateTime(2023, 2, 15), DueDate = new DateTime(2023, 8, 15), IdPatient = 2, IdDoctor = 2 }
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "Take one tablet daily" },
            new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 250, Details = "Take twice a day" }
        });
    }
}
