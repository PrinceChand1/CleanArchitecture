namespace CleanArchitecture.Application.Dtos;
public class AppSettingsDto
{
    public required string SecretKey { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int AddMinutes { get; set; }
    public string? LoginPasswordLink { get; set; }
    public string? ResetPasswordLink { get; set; }
}
