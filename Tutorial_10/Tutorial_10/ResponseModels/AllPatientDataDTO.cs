using System.ComponentModel.DataAnnotations;
using Tutorial_10.Models;

namespace Tutorial_10.ResponseModels;

public class AllPatientDataDTO
{
    public PatientsDTO PatientsDto  { get; set; }

  public PrescriptionDTO PrescriptionDto { get; set; }
    
}