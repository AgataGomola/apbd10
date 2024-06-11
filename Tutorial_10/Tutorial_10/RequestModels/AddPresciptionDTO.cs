using System.ComponentModel.DataAnnotations;

namespace Tutorial_10.RequestModels;

public class AddPresciptionDTO
{
    public PatientDTO Patient { get; set; }
    public ICollection<MedicamentDTO> Medicaments { get; set; } = new HashSet<MedicamentDTO>();
    public DateTime Date  { get; set; }
    public DateTime DueDate  { get; set; }
}

public class MedicamentDTO
{
    public int IdMedicament  { get; set; }

    public int Dose { get; set; }
    [MaxLength(100)] public string Description { get; set; } = string.Empty;
}
public class PatientDTO
{
    public int IdPatient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)] public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }

}