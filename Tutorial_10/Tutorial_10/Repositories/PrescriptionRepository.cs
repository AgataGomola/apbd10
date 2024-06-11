using Microsoft.EntityFrameworkCore;
using Tutorial_10.Contexts;
using Tutorial_10.Models;
using Tutorial_10.ResponseModels;
using PatientDTO = Tutorial_10.RequestModels.PatientDTO;

namespace Tutorial_10.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly DataBaseContext _dataBaseContext;

    public PrescriptionRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public async Task<bool> DoesPatientExist(int id)
    {
        return await _dataBaseContext.Patients.AnyAsync(p => p.IdPatient == id);
    }

    public async Task AddPatient(PatientDTO patient)
    {
        await _dataBaseContext.Patients.AddAsync(new Patient()
        {
            IdPatient = patient.IdPatient,
            BirthDate = patient.BirthDate,
            FirstName = patient.FirstName,
            LastName = patient.LastName
        });
        await _dataBaseContext.SaveChangesAsync();
    }

    public async Task<bool> DoesMedicamentExist(int id)
    {
        return await _dataBaseContext.Medicaments.AnyAsync(m => m.IdMedicament == id);
    }

    public async Task AddPrescription(Prescription prescription)
    {
        await _dataBaseContext.Prescriptions.AddAsync(prescription);
        await _dataBaseContext.SaveChangesAsync();
    }

    public async Task<PatientsDTO> GetAllData(int id)
    {
        var patient = await _dataBaseContext.Patients
            .Where(p => p.IdPatient == id)
            .Select(p => new PatientsDTO()
            {
                IdPatient = p.IdPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate,
                Prescriptions = p.Prescriptions.OrderBy(pr => pr.DueDate).Select(pr => new PrescriptionDTO()
                {
                    IdPrescription = pr.IdPrescription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Medicaments = pr.PrescriptionMedicaments.Select(pm => new PrescriptionMedicamentDTO()
                    {
                        IdMedicament = pm.Medicament.IdMedicament,
                        Description = pm.Medicament.Description,
                        Dose = pm.Dose,
                        Name = pm.Medicament.Name
                    }).ToList(),
                    Doctor = new DoctorDTO()
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.FirstName
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();

        return patient;
    }
}