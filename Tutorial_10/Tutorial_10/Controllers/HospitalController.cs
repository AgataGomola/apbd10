using Microsoft.AspNetCore.Mvc;
using Tutorial_10.Models;
using Tutorial_10.Repositories;
using Tutorial_10.RequestModels;

namespace Tutorial_10.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public HospitalController(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(AddPresciptionDTO addPresciptionDto)
    {
        if (!await _prescriptionRepository.DoesPatientExist(addPresciptionDto.Patient.IdPatient))
        {
            await _prescriptionRepository.AddPatient(addPresciptionDto.Patient);
        }

        foreach (var medicament in addPresciptionDto.Medicaments)
        {
            if (!await _prescriptionRepository.DoesMedicamentExist(medicament.IdMedicament))
            {
                return NotFound("Medicament does not exist");
            }   
        }

        if (addPresciptionDto.Medicaments.Count > 10)
        {
            return BadRequest("Prescription can have maks 10 medicaments");
        }

        if (addPresciptionDto.DueDate < addPresciptionDto.Date)
        {
            return BadRequest("Due date cannot be smaller than date");
        }

        var prescription = new Prescription()
        {
            Date = addPresciptionDto.Date,
            DueDate = addPresciptionDto.DueDate,
            IdPatient = addPresciptionDto.Patient.IdPatient,
            IdDoctor = 1
        };
        await _prescriptionRepository.AddPrescription(prescription);
        return Created("api/hospital", new
        {
            Id = prescription.IdPrescription,
            prescription.Date,
            prescription.IdPatient,
            prescription.IdDoctor
        });
    }
}