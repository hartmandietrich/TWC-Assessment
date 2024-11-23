namespace TroyWebConsultingApplication.Requests;

public class ApplicationLoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}