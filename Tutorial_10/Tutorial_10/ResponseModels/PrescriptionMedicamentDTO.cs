using System.ComponentModel.DataAnnotations;

namespace Tutorial_10.ResponseModels;

public class PrescriptionMedicamentDTO
{
    public int IdMedicament  { get; set; }

    [MaxLength(100)] public string Name { get; set; } = string.Empty;
    public int Dose { get; set; }
    [MaxLength(100)] public string Description { get; set; } = string.Empty;

}