namespace TroyWebConsultingApplication.Requests;

public class RegisterUserRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? RoleName { get; set; }
}