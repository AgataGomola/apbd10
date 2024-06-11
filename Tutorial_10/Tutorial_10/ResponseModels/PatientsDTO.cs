using System.ComponentModel.DataAnnotations;
using Tutorial_10.Models;

namespace Tutorial_10.ResponseModels;

public class PatientsDTO
{
    public int IdPatient { get; set; }

    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)] public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

    public ICollection<PrescriptionDTO> Prescriptions { get; set; } = new HashSet<PrescriptionDTO>();    
}