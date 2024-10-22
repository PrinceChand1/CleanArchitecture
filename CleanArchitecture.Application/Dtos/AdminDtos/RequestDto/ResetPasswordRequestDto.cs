using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
public class ResetPasswordRequestDto : IValidatableObject
{
    [Required(ErrorMessage = $"{nameof(OldPassword)} is required.")]
    public required string OldPassword { get; set; }


    [Required(ErrorMessage = $"{nameof(NewPassword)} is required.")]
    [StringLength(16, ErrorMessage = "Must be between 8 and 16 characters", MinimumLength = 16)]
    //[DataType(DataType.Password)]
    public required string NewPassword { get; set; }


    [Required(ErrorMessage = $"{nameof(ConfirmPassword)} is required.")]
    public required string ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (OldPassword != NewPassword)
            yield return new ValidationResult("Old Password and New password should not be same.");

        if (NewPassword != ConfirmPassword)
            yield return new ValidationResult("New password and confirm password should match");
    }
}
