using System.ComponentModel.DataAnnotations;

namespace Tutorial_10.ResponseModels;

public class DoctorDTO
{
    public int IdDoctor { get; set; }

    [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
}