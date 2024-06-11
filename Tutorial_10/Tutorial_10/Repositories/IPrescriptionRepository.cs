using Tutorial_10.Models;
using Tutorial_10.RequestModels;
using Tutorial_10.ResponseModels;

namespace Tutorial_10.Repositories;

public interface IPrescriptionRepository
{
    public Task<bool> DoesPatientExist(int id);
    public Task AddPatient(PatientDTO patient);
    public Task<bool> DoesMedicamentExist(int id);
    public Task AddPrescription(Prescription prescription);
    public Task<PatientsDTO> GetAllData(int id);
}