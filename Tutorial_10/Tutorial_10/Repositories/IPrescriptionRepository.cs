using Tutorial_10.Models;
using Tutorial_10.RequestModels;

namespace Tutorial_10.Repositories;

public interface IPrescriptionRepository
{
    public Task<bool> DoesPatientExist(int id);
    public Task AddPatient(PatientDTO patient);
    public Task<bool> DoesMedicamentExist(int id);
    public Task AddPrescription(Prescription prescription);
}