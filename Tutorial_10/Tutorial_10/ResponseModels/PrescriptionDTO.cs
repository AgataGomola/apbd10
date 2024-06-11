using Tutorial_10.Models;

namespace Tutorial_10.ResponseModels;

public class PrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date  { get; set; }
    public DateTime DueDate  { get; set; }

    public ICollection<PrescriptionMedicamentDTO> Medicaments { get; set; } = new HashSet<PrescriptionMedicamentDTO>();
    public DoctorDTO Doctor { get; set; }
}