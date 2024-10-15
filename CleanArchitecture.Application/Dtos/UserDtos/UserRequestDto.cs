using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.UserDtos;
public class UserRequestDto : PageCountDto, IValidatableObject
{
    [DisplayName(nameof(FirstName))]
    [Required(ErrorMessage = $"{nameof(FirstName)} is required")]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Required(ErrorMessage = $"{nameof(Age)} is required")]
    public int Age { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Age >= 18)
            yield return new ValidationResult("Age must be at least 18.");
    }
}
